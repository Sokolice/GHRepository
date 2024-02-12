using api.Core;
using api.DTOs;
using api.Persistence;
using api.Relations;
using Microsoft.EntityFrameworkCore;

namespace api.Model
{
    public class Stats
    {
        private readonly DataContext _context;

        public int MissingSowingThisWeekAmount { get; set; }
        public int MissingTaskThisWeekAmount { get; set; }
        public int CanBeSowedRepeatedlyAmount { get; set; }
        public List<Guid> CanBeSowedThisWeek { get; set; }
        public List<Guid> CanBeSowedRepeatedly { get; set; }



        public Stats(DataContext context)
        {
            _context = context;
            CanBeSowedThisWeek = new List<Guid>();
            CanBeSowedRepeatedly = new List<Guid>();
            CanBeSowedRepeatedlyAmount = 0;
        }


        public async void ThisWeekSowingCalculation()
        {

            var month = DateTime.Today.Month;
            double day = DateTime.Today.Day;
            var weekOfMonth = Math.Ceiling(day / 7);

            var plants = _context.Plants
                .Include(p => p.PlantRecords)
                .Where(a => a.SewingMonths.Any(sm => sm.MonthIndex == month && sm.Week == weekOfMonth)).ToList();
            
            CanBeSowedThisWeek = plants
                                .Select(p => p.Id)
                                .ToList();

            MissingSowingThisWeekAmount = plants
                                            .Where(a => a.PlantRecords.Count == 0)
                                            .Count();

            MissingTaskThisWeekAmount = _context.Tasks
                                            .Where(a => a.MonthWeeks
                                            .Any(sm => sm.MonthIndex == month && sm.Week == weekOfMonth) && a.IsCompleted == false)
                                            .Count();

            var today = DateTime.Now;

            var records = _context.PlantRecords
                            .Where(r => r.Plant.RepeatedPlanting > 0)
                            .ToList();

           foreach(var record in records)
            {
                if ((today - record.DatePlanted).TotalDays >= 14)
                    CanBeSowedRepeatedlyAmount++;

                CanBeSowedRepeatedly.Add(record.PlantId);
            }           
        }
    }
}
