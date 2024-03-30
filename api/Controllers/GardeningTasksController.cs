using API.Core;
using API.DTOs;
using API.Interfaces;
using API.Persistence;
using API.Relations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GardeningTasksController : BaseApiController
    {
        private readonly IGardeningTasksService _tasksService;

        public GardeningTasksController(IGardeningTasksService aTaskService)
        {
            _tasksService = aTaskService;
        }

        [HttpGet]
        public async Task<ActionResult<List<MonthTaskRelation>>> GetTasks()
        {
           var result = await _tasksService.GetTasks();

            return HandleResult(result);
        }

        [HttpPost]
        public async Task<ActionResult<GardeningTaskDTO>> PostGardeningTasks(GardeningTaskDTO gardeningTask)
        {
            var result = await _tasksService.PostGardeningTasks(gardeningTask);

            return HandleResult(result);
        }

        [Route("ShareTasks")]
        [HttpPost]
        public async Task<IResult> ShareTasks(WeekTaskRelation weekTaskRelation)
        {


            return Results.Ok();
        }
    }
}
