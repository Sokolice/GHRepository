using API.DTOs;
using API.Model;
using API.Relations;
using API.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API.Core;
using Microsoft.AspNetCore.Authorization;
using API.Interfaces;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlantRecordsController: BaseApiController
    {
        private readonly IPlantRecordsService _plantRecordService;

        public PlantRecordsController(IPlantRecordsService plantRecordService)
        {
            _plantRecordService = plantRecordService;
        }

        [HttpGet]
        [Route("GetPlantRecords")]
        public async Task<ActionResult<List<PlantRecordDTO>>> GetPlantRecords()
        {
            var result = await _plantRecordService.GetPlantRecords();

            return HandleResult(result);
        }

        [HttpPost]
        public async Task<ActionResult<PlantRecordDTO>> PostPlantRecord(PlantRecordDTO plantRecordDTO)
        {

            var result = await _plantRecordService.PostPlantRecord(plantRecordDTO);

            return HandleResult(result);

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<PlantRecordDTO>> DeletePlantRecord(Guid id)
        {
            var result = await _plantRecordService.DeletePlantRecord(id);

            return HandleResult(result);
        }


        [HttpPut("{id}")]
        public async Task<ActionResult<PlantRecordDTO>> UpdatePlantRecord(Guid id, PlantRecordDTO plantRecord)
        {
            var result = await _plantRecordService.UpdatePlantRecord(id, plantRecord);

            return HandleResult(result);

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PlantRecordDTO>> GetPlant(Guid id)
        {

            var result = await _plantRecordService.GetPlant(id);

            return HandleResult(result);
        }

    }
}
