using API.DTOs;
using API.Interfaces;
using API.Model;
using API.Persistence;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatsController : BaseApiController
    {
        private readonly IStatsService _statsService;

        public StatsController(IStatsService statsService)
        {
            _statsService = statsService;
        }

        [HttpGet]
        [Route("GetStats")]
        public async Task<ActionResult<StatsDTO>> GetStats()
        {
            var result = await _statsService.GetStats();

            return HandleResult(result);
        }
    }
}
