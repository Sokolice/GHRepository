using API.DTOs;
using API.Model;
using API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [AllowAnonymous]
    public class HarvestController : BaseApiController
    {
        private readonly IHarvestService _harvestService;
        public HarvestController(IHarvestService harvestService)
        {
            _harvestService = harvestService;
        }

        [HttpPost]
        [Route("Harvest")]
        public async Task<ActionResult<HarvestDTO>> Harvest(HarvestDTO harvest)
        {
            var result = await _harvestService.Harvest(harvest);

            return HandleResult(result);
        }
    }
}
