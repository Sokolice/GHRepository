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

            var monthsDictionary = monthweeks.OrderBy(a => a.Week).OrderBy(b => b.MonthIndex).Where(c=>c.GardeningTasks.Count > 0).ToList();
               
            return monthsDictionary.Select(t => new MonthTaskRelation
            {
                GardeningTasks = MyMapping.MapGardeningTasks(t.GardeningTasks),
                MonthWeekDTO = new MonthWeekDTO
                {
                    Month = t.Month,
                    MonthIndex = t.MonthIndex,
                    Week = t.Week,
                }

            }).ToList();

        }
    }
}
