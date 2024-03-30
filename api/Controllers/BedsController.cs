using API.Core;
using API.DTOs;
using API.Interfaces;
using API.Model;
using API.Persistence;
using API.Relations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BedsController : BaseApiController
    {
        private readonly IBedsService _bedsService;

        public BedsController(IBedsService bedsService)
        {
            _bedsService = bedsService;
        }

        [HttpGet]
        [Route("GetBeds")]
        public async Task<ActionResult<List<BedRelation>>> GetBeds()
        {

            var result = await _bedsService.GetBeds();

            return HandleResult(result);
        }

        [HttpPost]
        public async Task<ActionResult<BedRelation>> PostBed(BedRelation bedRelation)
        {
            var result  = await _bedsService.PostBed(bedRelation);

            return HandleResult(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Guid>> DeleteBed(Guid id)
        {
            var result = await _bedsService.DeleteBed(id);

            return HandleResult(result);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<BedRelation>> GetBed(Guid id)
        {
            var result = await _bedsService.GetBed(id);

            return HandleResult(result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<BedRelation>> UpdateBed(Guid id, BedRelation bedRelation)
        {
            var result = await _bedsService.UpdateBed(id, bedRelation);

            return HandleResult(result);
        }

        

    }
}
