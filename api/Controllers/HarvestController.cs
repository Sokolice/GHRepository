﻿using API.DTOs;
using API.Interfaces;
using API.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HarvestController : BaseApiController
    {
        private readonly IHarvestService _harvestService;
        public HarvestController(IHarvestService harvestService)
        {
            _harvestService = harvestService;
        }

        [HttpPost]
        public async Task<ActionResult<HarvestDTO>> Harvest(HarvestDTO harvest)
        {
            var result = await _harvestService.Harvest(harvest);

            return HandleResult(result);
        }
    }
}
