using API.Core;
using API.DTOs;
using API.Interfaces;
using API.Persistence;
using API.Relations;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace API.Services
{
    public class MonthWeeksService: IMonthWeeksService
    {
        private readonly DataContext _context;
        private readonly IUserAccessor _userAccessor;

        public MonthWeeksService(DataContext context, IUserAccessor userAccessor)
        {
            _context = context;
            _userAccessor = userAccessor;
        }

        public async Task<Result<List<MonthSewedRelation>>> GetMonthWeeksGrouped()
        {
            var user = await _context.Users.FirstOrDefaultAsync(a =>
               a.Email == _userAccessor.GetUserEmail());

            var monthweeks = await _context.MonthWeeks.Include(x => x.SewedPlants).ToListAsync();

            var monthsDictionary = monthweeks.OrderBy(a => a.MonthIndex)
                .GroupBy(x => x.Month)
                .ToDictionary(x => x.Key,
                    x => x.SelectMany(y => y.SewedPlants.Where(a=> a.Users.Contains(user))).GroupBy(y => y.Id).Select(y => y.First()).ToList());

            var monthWeeksResult =  monthsDictionary.Select(y => new MonthSewedRelation
            {
                Month = y.Key,
                SewedPlants = MyMapping.MapPlantsToDTO(y.Value).OrderBy(a => a.Name).ToList(),
            }).ToList();

            return Result<List<MonthSewedRelation>>.Success(monthWeeksResult);
        }

        public async Task<Result<List<MonthWeekRelation>>> GetMonthWeeksRelation()
        {
            var user = await _context.Users.FirstOrDefaultAsync(a =>
               a.Email == _userAccessor.GetUserEmail());

            var monthWeeksRelations = await _context.MonthWeeks.OrderBy(a => a.MonthIndex).Select(x => new MonthWeekRelation
            {
                GardeningTasks = MyMapping.MapGardeningTasks(x.GardeningTasks.Where(a=> a.User == user).ToList()),
                HarvestedPlants = MyMapping.MapPlantsToDTO(x.HarvestedPlants.Where(b=> b.Users.Contains(user)).ToList()),
                MonthWeekDTO = new MonthWeekDTO { Month = x.Month, MonthIndex = x.MonthIndex, Week = x.Week },
                SewedPlants = MyMapping.MapPlantsToDTO(x.SewedPlants.Where(c=> c.Users.Contains(user)).ToList())
            }).ToListAsync();

            return Result<List<MonthWeekRelation>>.Success(monthWeeksRelations);
        }
    }
}
