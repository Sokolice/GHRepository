using api.Core;
using api.DTOs;
using api.Persistence;
using api.Relations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GardeningTasksController : Controller
    {
        private readonly DataContext _context;

        public GardeningTasksController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public List<MonthTaskRelation> GetTasks()
        {
            var monthweeks = _context.MonthWeeks.Include(x => x.GardeningTasks).ToList();

            var tasks = monthweeks
                .GroupBy(a=> (a.Week, a.Month))
                .GroupBy(a=> (a.First().Month, a.First().MonthIndex))
                .Select(a=> new MonthTaskRelation{
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
            }).OrderBy(a=> a.Index).ToList();

            return tasks;
        }

        [HttpPost]
        public async Task<GardeningTaskDTO> PostGardeningTasks(GardeningTaskDTO gardeningTask)
        {

            var task = _context.Tasks.Find(gardeningTask.Id);
            task.IsCompleted = gardeningTask.IsCompleted;

            await _context.SaveChangesAsync();

            return gardeningTask;
        }

        [Route("ShareTasks")]
        [HttpPost]
        public async Task<IResult> ShareTasks(WeekTaskRelation weekTaskRelation)
        {



            return Results.Ok();
        }
    }
}
