using API.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API.Persistence;
using API.DTOs;
using System.ComponentModel;
using System.Collections.Specialized;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using API.Relations;
using API.Core;
using API.Services;
using Microsoft.AspNetCore.Authorization;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlantsController : BaseApiController
    {
        private readonly IPlantsService _plantsService;

        public PlantsController(IPlantsService plantsService)
        {
            _plantsService = plantsService;
        }

        // GET: api/Plants
        [HttpGet]
        public async Task<ActionResult<List<PlantDTO>>> GetPlants()
        {

            var result = await _plantsService.GetPlants();

            return HandleResult(result);
        }

        // GET: api/Plants/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PlantDTO>> GetPlant(Guid id)
        {           
            var result = await _plantsService.GetPlant(id);

            return HandleResult(result);
        }


        [HttpGet]
        [Route("GetOtherPlants")]
        //[HttpGet("{id}/others")]
        public async Task<ActionResult<PlantPlantsRelation>> GetOtherPlants(Guid id)
        {
            var result = await _plantsService.GetOtherPlants(id);

            return HandleResult(result);
        }

        [HttpGet]
        [Route("GetAllPlantsRelations")]
        //[HttpGet("{id}/others")]
        public async Task<ActionResult<List<PlantPlantsRelation>>> GetAllPlantsRelations()
        {
            var result = await _plantsService.GetAllPlantsRelations();

            return HandleResult(result);
        }        
    }
}
