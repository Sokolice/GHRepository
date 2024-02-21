using API.DTOs;
using API.Model;
using API.Persistence;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatsController : Controller
    {
        private readonly DataContext _context;

        public StatsController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("GetStats")]
        public async Task<Stats> GetStats()
        {
            var stats = new Stats(_context);
            await stats.ThisWeekSowingCalculation();

            return stats;
        }
    }
}
