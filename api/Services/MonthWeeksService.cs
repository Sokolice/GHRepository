using API.Core;
using API.DTOs;
using API.Persistence;
using API.Relations;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace API.Services
{
    public class MonthWeeksService: IMonthWeeksService
    {
        private readonly DataContext _context;

        public MonthWeeksService(DataContext context)
        {
            _context = context;
        }

        public async Task<Result<List<MonthSewedRelation>>> GetMonthWeeksGrouped()
        {

            var monthweeks = await _context.MonthWeeks.Include(x => x.SewedPlant).ToListAsync();

            var monthsDictionary = monthweeks.OrderBy(a => a.MonthIndex)
                .GroupBy(x => x.Month)
                .ToDictionary(x => x.Key,
                    x => x.SelectMany(y => y.SewedPlant).GroupBy(y => y.Id).Select(y => y.First()).ToList());

            var monthWeeksResult =  monthsDictionary.Select(y => new MonthSewedRelation
            {
                Month = y.Key,
                SewedPlants = MyMapping.MapPlantsFromDTO(y.Value).OrderBy(a => a.Name).ToList(),
            }).ToList();

            return Result<List<MonthSewedRelation>>.Success(monthWeeksResult);
        }

        public async Task<Result<List<MonthWeekRelation>>> GetMonthWeeksRelation()
        {

            var monthWeeksRelations = await _context.MonthWeeks.OrderBy(a => a.MonthIndex).Select(x => new MonthWeekRelation
            {
                GardeningTasks = MyMapping.MapGardeningTasks(x.GardeningTasks),
                HarvestedPlants = MyMapping.MapPlantsFromDTO(x.HarvestedPlant),
                MonthWeekDTO = new MonthWeekDTO { Month = x.Month, MonthIndex = x.MonthIndex, Week = x.Week },
                SewedPlants = MyMapping.MapPlantsFromDTO(x.SewedPlant)
            }).ToListAsync();

            return Result<List<MonthWeekRelation>>.Success(monthWeeksRelations);
        }
    }
}
