using API.Core;
using API.DTOs;
using API.Interfaces;
using API.Persistence;
using API.Relations;
using Microsoft.EntityFrameworkCore;

namespace API.Services
{
    public class PlantsService: IPlantsService
    {
        private readonly DataContext _context;
        public PlantsService(DataContext context)
        {
            _context = context;
        }

        public async Task<Result<List<PlantDTO>>> GetPlants()
        {
            var plants = await _context.Plants.ToListAsync();

            var plantsDTO = plants.Select(a => new PlantDTO(a))
                                  .ToList();

            return Result<List<PlantDTO>>.Success(plantsDTO);
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

            var others = new PlantPlantsRelation
            {
                Plant = new PlantDTO(plant),
                AvoidPlants = MyMapping.MapPlantsFromDTO(plant.AvoidPlants).OrderBy(a => a.Name).ToList(),
                CompanionPlants = MyMapping.MapPlantsFromDTO(plant.CompanionPlants).OrderBy(a => a.Name).ToList()
            };

            return Result<PlantPlantsRelation>.Success(others);
        }

        public async Task<Result<List<PlantPlantsRelation>>> GetAllPlantsRelations()
        {
            var others = await _context.Plants.Select(a => new PlantPlantsRelation
            {
                Plant = new PlantDTO(a),
                AvoidPlants = MyMapping.MapPlantsFromDTO(a.AvoidPlants).ToList(),
                CompanionPlants = MyMapping.MapPlantsFromDTO(a.CompanionPlants).ToList()
            }).ToListAsync();

            return Result<List<PlantPlantsRelation>>.Success(others);
        }
    }
}
