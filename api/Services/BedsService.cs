using API.Core;
using API.Interfaces;
using API.Domain;
using API.Persistence;
using API.Relations;
using Microsoft.EntityFrameworkCore;
using API.DTOs;

namespace API.Services
{
    public class BedsService : IBedsService
    {
        private readonly DataContext _context;
        private readonly IUserAccessor _userAccessor;

        public BedsService(DataContext context, IUserAccessor userAccessor)
        {
            _context = context;
            _userAccessor = userAccessor;
        }

        public async Task<Result<List<BedRelation>>> GetBeds()
        {

            var bedsDTO = await _context.Beds
                .Where(x => x.User.Email == _userAccessor.GetUserEmail())
                                        .ToListAsync();

            var bedRelations = new List<BedRelation>();
            var plantsDTO = new List<PlantDTO>();
            foreach (var bed in bedsDTO)
            {
                var relation = new BedRelation
                {
                    Bed = MyMapping.MapBedToDTO(bed),
                    Cells = bed.Cells.OrderBy(a=> a.Y).OrderBy(a=>a.X).ToList(),
                };

                var cellRecordIds = bed.Cells.Where(a => a.PlantRecordId != Guid.Empty)
                                              .Select(a => a.PlantRecordId)
                                              .ToList();

                var plants = (bed.IsDesign) ? _context.Plants.Where(a => cellRecordIds.Contains(a.Id))
                                                             .ToList()
                                            : _context.PlantRecords.Where(a => cellRecordIds.Contains(a.Id))
                                                        .Select(a => a.Plant)
                                                        .ToList();

                plantsDTO = MyMapping.MapPlantsToDTO(plants);

                relation.Plants = plantsDTO;

                relation.GetAllCompanionPlants(_context);
                relation.GetAllAvoidPlants(_context);

                bedRelations.Add(relation);
            }


            return Result<List<BedRelation>>.Success(bedRelations);
        }

        public async Task<Result<BedRelation>> PostBed(BedRelation bedRelation)
        {
            var bed = new Bed(bedRelation);

            var user = await _context.Users.FirstOrDefaultAsync(a =>
               a.Email == _userAccessor.GetUserEmail());

            bed.User = user;

            _context.Beds.Add(bed);

            var result = await _context.SaveChangesAsync() > 0;

            if (!result)
                return Result<BedRelation>.Failure("Failed to save bed", false);


            return Result<BedRelation>.Success(bedRelation);
        }

        public async Task<Result<Guid>> DeleteBed(Guid id)
        {
            var user = await _context.Users.FirstOrDefaultAsync(a =>
               a.Email == _userAccessor.GetUserEmail());

            var bed = await _context.Beds.FindAsync(id);

            if (bed == null)
                return Result<Guid>.Failure("Failed to delete bed. Bed with provided ID do not exists", true);

            _context.Cells.RemoveRange(bed.Cells);
            _context.Beds.Remove(bed);

            var result = await _context.SaveChangesAsync() > 0;
            if (!result)
                return Result<Guid>.Failure("Failed to delete bed", false);

            return Result<Guid>.Success(id);
        }

        public async Task<Result<BedRelation>> GetBed(Guid id)
        {
            var bed = await _context.Beds.FindAsync(id);

            return Result<BedRelation>.Success(new BedRelation(bed));
        }

        public async Task<Result<BedRelation>> UpdateBed(Guid id, BedRelation bedRelation)
        {
            if (id != bedRelation.Bed.Id)
                return Result<BedRelation>.Failure("Failed to update bed", false);


            var bed = await _context.Beds.FindAsync(id);

            if (bed == null)
                return Result<BedRelation>.Failure("Failed to update bed. Bed do not exists", true);


            bed.Name = bedRelation.Bed.Name;
            bed.Length = bedRelation.Bed.Length;
            bed.Width = bedRelation.Bed.Width;
            bed.NumOfRows = bedRelation.Bed.NumOfRows;
            bed.NumOfColumns = bedRelation.Bed.NumOfColumns;
            bed.Cells = bedRelation.Cells;
            bed.IsDesign = bedRelation.Bed.IsDesign;
            bed.CropRotation = bedRelation.Bed.CropRotation;

            //bed.Plants = _context.Plants.Where(a => bedRelation.Plants.Select(b => b.Id).ToList().Contains(a.Id)).ToList();


            await _context.SaveChangesAsync();

            return Result<BedRelation>.Success(bedRelation);
        }

    }
}
