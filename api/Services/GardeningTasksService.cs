using API.Core;
using API.DTOs;
using API.Persistence;
using API.Relations;
using Microsoft.EntityFrameworkCore;

namespace API.Services
{
    public class GardeningTasksService: IGardeningTasksService
    {
        private readonly DataContext _context;
        public GardeningTasksService(DataContext context)
        {
            _context = context;
        }

        public async Task<Result<List<MonthTaskRelation>>> GetTasks()
        {
            var monthweeks = await _context.MonthWeeks.Include(x => x.GardeningTasks).ToListAsync();

            var tasks = monthweeks
                .GroupBy(a => (a.Week, a.Month))
                .GroupBy(a => (a.First().Month, a.First().MonthIndex))
                .Select(a => new MonthTaskRelation
                {
                    Month = a.Key.Month,
                    Index = a.Key.MonthIndex,
                    WeekTaskRelations = a.Select(b => new WeekTaskRelation
                    {
                        Week = b.Key.Week,
                        GardeningTasks = b.SelectMany(c => c.GardeningTasks).Select(c => new GardeningTaskDTO
                        {
                            Id = c.Id,
                            IsCompleted = c.IsCompleted,
                            Name = c.Name,
                            WasSent = c.WasSent
                        }).ToList(),
                    }).ToList()
                }).OrderBy(a => a.Index).ToList();

            return Result<List<MonthTaskRelation>>.Success(tasks);
        }

        public async Task<Result<GardeningTaskDTO>> PostGardeningTasks(GardeningTaskDTO gardeningTask)
        {                      
            var task = await _context.Tasks.FindAsync(gardeningTask.Id);

            if(task == null)
            {
                return Result<GardeningTaskDTO>.Failure("Task cannot be found", true);
            }

            task.IsCompleted = gardeningTask.IsCompleted;

            var result = await _context.SaveChangesAsync() > 0;

            if (!result)
                return Result<GardeningTaskDTO>.Failure("Failed to save task", false);

            return Result<GardeningTaskDTO>.Success(gardeningTask);
        }
    }
}
