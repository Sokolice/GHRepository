using api.DTOs;
using api.Model;
using api.Persistence;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
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
            stats.ThisWeekSowingCalculation();

            return stats;
        }
    }
}
