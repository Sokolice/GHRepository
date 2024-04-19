using API.Core;
using API.Domain;
using API.DTOs;
using API.Interfaces;
using API.Persistence;
using API.Relations;
using Castle.DynamicProxy.Generators;
using Microsoft.EntityFrameworkCore;
using NuGet.Packaging.Signing;

namespace API.Services
{
    public class PlantsService: IPlantsService
    {
        private readonly DataContext _context;
        private readonly IUserAccessor _userAccessor;
        public PlantsService(DataContext context, IUserAccessor userAccessor)
        {
            _context = context;
            _userAccessor = userAccessor;

        }

        public async Task<Result<List<PlantDTO>>> GetPlants()
        {
            var user = await _context.Users.FirstOrDefaultAsync(a =>
               a.Email == _userAccessor.GetUserEmail());

            var plants = await _context.Plants.Where(a=> a.Users.Contains(user)).ToListAsync();

            var plantsDTO = plants.Select(a => new PlantDTO(a))
                                  .ToList();

            return Result<List<PlantDTO>>.Success(plantsDTO);
        }

        public async Task<Result<List<PlantTypePlantsRelation>>> GetAllAvailablePlantsByType()
        {

            var user = await _context.Users.FirstOrDefaultAsync(a =>
               a.Email == _userAccessor.GetUserEmail());

            var userPlants = await _context.Plants.Where(a => a.Users.Contains(user)).ToListAsync();
            var allPlants = await _context.Plants.ToListAsync();

            var finalList = allPlants.Except(userPlants).ToList();

            var plants = finalList.GroupBy(p=>p.PlantType)
                                              .OrderBy(p=>p.Key.Name)
                                              .Select(a=> new PlantTypePlantsRelation 
                                              { 
                                                  PlantType = new PlantTypeDTO(a.Key),
                                                  Plants = MyMapping.MapPlantsToDTO(a.ToList())
                                              }
            ).ToList();

            return Result<List<PlantTypePlantsRelation>>.Success(plants);
        }

        public async Task<Result<List<PlantTypeDTO>>> GetAllPlantTypes()
        {

            var plantTypes = await _context.PlantTypes.Include(a=> a.HarvestMonths)
                                                      .Include(a=> a.SewingMonths)
                                                      .OrderBy(a=> a.Name)
                                                      .Select(a=> new PlantTypeDTO(a))
                                                      .ToListAsync();

            return Result<List<PlantTypeDTO>>.Success(plantTypes);
        }

        public async Task<Result<PlantDTO>> GetPlant(Guid id)
        {

            var plant = await _context.Plants.FindAsync(id);

            if (plant == null)
                return Result<PlantDTO>.Failure("Plant not found", true);

            var plantDTO = new PlantDTO(plant);


            return Result<PlantDTO>.Success(plantDTO);
        }

        public async Task<Result<PlantPlantsRelation>> GetOtherPlants(Guid id)
        {
            var plant = await _context.Plants.FindAsync(id);
            if (plant == null)
                return Result<PlantPlantsRelation>.Failure("Plant not found", true);

            var plantAvoidType = plant.PlantType.AvoidPlantTypes;
            var plantCompanionType = plant.PlantType.CompanionPlantTypes;

            var plantAvoids = new List<Plant>();
            var plantCompanion = new List<Plant>();

            foreach (var avoid in plantAvoidType)
            {
                plantAvoids.AddRange(_context.Plants.Where(a => a.PlantType == avoid).ToList());
            }
            foreach (var companion in plantCompanionType)
            {
                plantCompanion.AddRange(_context.Plants.Where(a => a.PlantType == companion).ToList());
            }
            var others = new PlantPlantsRelation
            {
                Plant = new PlantDTO(plant),
                AvoidPlants = MyMapping.MapPlantsToDTO(plantAvoids).OrderBy(a => a.Name).ToList(),
                CompanionPlants = MyMapping.MapPlantsToDTO(plantCompanion).OrderBy(a => a.Name).ToList()
            };

            return Result<PlantPlantsRelation>.Success(others);
        }

        public async Task<Result<List<PlantPlantsRelation>>> GetAllPlantsRelations()
        {
            /*var others = await _context.Plants.Select(a => new PlantPlantsRelation
            {
                Plant = new PlantDTO(a),
                AvoidPlants = MyMapping.MapPlantsFromDTO(a.AvoidPlants).ToList(),
                CompanionPlants = MyMapping.MapPlantsFromDTO(a.CompanionPlants).ToList()
            }).ToListAsync();

            return Result<List<PlantPlantsRelation>>.Success(others);*/
            return Result<List<PlantPlantsRelation>>.Failure("not implemented", false);
        }

        public async Task<Result<List<Guid>>> SavePlantsForUser(List<Guid> ids)
        {
            var user = await _context.Users.FirstOrDefaultAsync(a =>
               a.Email == _userAccessor.GetUserEmail());

            var plants = _context.Plants.Where(a => ids.Contains(a.Id)).ToList();

            user.Plants.AddRange(plants);

            var result = await _context.SaveChangesAsync() > 0;

            if (!result)
                return Result<List<Guid>>.Failure("Failed to save plants for User", false);

            return Result<List<Guid>>.Success(ids);
        }

        public async Task<Result<PlantDTO>> CreatePlant(PlantDTO plantDTO)
        {
            var user = await _context.Users.FirstOrDefaultAsync(a =>
               a.Email == _userAccessor.GetUserEmail());


            var plantType = _context.PlantTypes.Find(plantDTO.PlantTypeId);
            var plant = new Plant
            {
                CropRotation = plantDTO.CropRotation,
                Description = plantDTO.Description,
                DirectSewing = plantDTO.DirectSewing,
                GerminationTemp = plantDTO.GerminationTemp,
                Id = plantDTO.Id,
                ImageSrc = plantDTO.ImageSrc,
                IsHybrid = plantDTO.IsHybrid,
                Name = plantDTO.Name,
                PlantType = plantType,
                PreCultivation = plantDTO.PreCultivation,
                RepeatedPlanting = plantDTO.RepeatedPlanting,
                IsApproved = (user.DisplayName == "Admin")? true:false
            };
            if (plantDTO.SowingFrom != null)
            {
                GenerateMonths(plantDTO.SowingFrom, plantDTO.SowingTo, plant.SewingMonths);
                GenerateMonths(plantDTO.HarvestFrom, plantDTO.HarvestTo, plant.HarvestMonths);
            }

            _context.Plants.Add(plant);

            user.Plants.Add(_context.Plants.Find(plantDTO.Id));

            var result = await _context.SaveChangesAsync() > 0;

            if (!result)
                return Result<PlantDTO>.Failure("Failed to save plant for User", false);

            return Result<PlantDTO>.Success(plantDTO);

        }

        private void GenerateMonths(MonthWeekDTO from, MonthWeekDTO to,  List<MonthWeek> plantMonthWeeks)
        {
            var monthWeekMap = _context.MonthWeeks.ToDictionary(x => (x.Month, x.Week));

            for (var month = from.MonthIndex; month <= to.MonthIndex; month++)
            {
                var weekFrom = 1;
                var weekTo = 4;
                if(month == 1)
                    weekFrom = from.Week;

                if(month == to.MonthIndex)
                    weekTo = to.Week;

                while (weekFrom <= weekTo)
                {
                    plantMonthWeeks.Add(monthWeekMap[(Month.getMonthName(month), weekFrom)]);
                    weekFrom++;
                }

            }
        }
    }
}
