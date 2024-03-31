using API.Core;
using API.DTOs;
using API.Interfaces;
using API.Model;
using API.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Services
{
    public class HarvestService: IHarvestService
    {
        private readonly DataContext _context;
        private readonly IUserAccessor _userAccessor;
        public HarvestService(DataContext context, IUserAccessor userAccessor)
        {
            _context = context;
            _userAccessor = userAccessor;

        }
        public async Task<Result<HarvestDTO>> Harvest(HarvestDTO harvest)
        {

            var plant = await _context.Plants.FindAsync(harvest.PlantId);


            if (plant == null)
                return Result<HarvestDTO>.Failure("Plant not found", true);

            var user = await _context.Users.FirstOrDefaultAsync(a =>
               a.UserName == _userAccessor.GetUserName());

            _context.Harvests.Add(new Harvest
            {
                Id = harvest.Id,
                Amount = harvest.Amount,
                Date = harvest.Date,
                Note = harvest.Note,
                Rating = harvest.Rating,
                Plant = plant,
                User = user
            });

            var result = await _context.SaveChangesAsync() > 0;

            if(!result)
                return Result<HarvestDTO>.Failure("Failed to save harvest", false);

            return Result<HarvestDTO>.Success(harvest);
        }
    }
}
