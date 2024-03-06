using API.Core;
using API.DTOs;
using API.Model;
using API.Persistence;
using Microsoft.AspNetCore.Mvc;

namespace API.Services
{
    public class HarvestService: IHarvestService
    {
        private readonly DataContext _context;
        public HarvestService(DataContext context)
        {
            _context = context;
        }
        public async Task<Result<HarvestDTO>> Harvest(HarvestDTO harvest)
        {

            var plant = await _context.Plants.FindAsync(harvest.PlantId);


            if (plant == null)
                return Result<HarvestDTO>.Failure("Plant not found", true);

            _context.Harvests.Add(new Harvest
            {
                Id = harvest.Id,
                Amount = harvest.Amount,
                Date = harvest.Date,
                Note = harvest.Note,
                Rating = harvest.Rating,
                Plant = plant
            });

            var result = await _context.SaveChangesAsync() > 0;

            if(result)
                return Result<HarvestDTO>.Failure("Failed to save harvest", false);

            return Result<HarvestDTO>.Success(harvest);
        }
    }
}
