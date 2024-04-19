using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API.Model;
using API.Persistence;
using API.DTOs;
using AutoMapper;
using API.Core;
using API.Relations;
using Microsoft.AspNetCore.Authorization;
using API.Interfaces;

namespace API.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class MonthWeeksController : BaseApiController
    {
        private readonly IMonthWeeksService _monthWeeksService;

        public MonthWeeksController(IMonthWeeksService monthWeeksService)
        {
            _monthWeeksService = monthWeeksService;
        }

        [HttpGet]
        [Route("GetMonthWeeksGrouped")]
        public async Task<ActionResult<List<MonthSewedRelation>>> GetMonthWeeksGrouped()
        {

            var result = await _monthWeeksService.GetMonthWeeksGrouped();

            return HandleResult(result);

        }

        [HttpGet]
        [Route("GetMonthWeeksRelation")]
        public async Task<ActionResult<List<MonthWeekRelation>>> GetMonthWeeksRelation()
        {
            var result = await _monthWeeksService.GetMonthWeeksRelation();

            return HandleResult(result);
        }

    }
}
