using API.Core;
using API.DTOs;
using API.Interfaces;
using API.Persistence;
using API.Relations;
using API.Security;
using Microsoft.EntityFrameworkCore;

namespace API.Services
{
    public class GardeningTasksService: IGardeningTasksService
    {
        private readonly DataContext _context;
        private readonly IUserAccessor _userAccessor;
        public GardeningTasksService(DataContext context, IUserAccessor userAccessor)
        {
            _context = context;
            _userAccessor = userAccessor;

        }

        public async Task<Result<List<MonthTaskRelation>>> GetTasks()
        {
            var user = await _context.Users.FirstOrDefaultAsync(a =>
               a.Email == _userAccessor.GetUserEmail());
            var monthweeks = await _context.MonthWeeks.Include(x => x.GardeningTasks.Where( x=> x.User == user)).ToListAsync();

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

            await _context.SaveChangesAsync();


            return Result<GardeningTaskDTO>.Success(gardeningTask);
        }
    }
}
