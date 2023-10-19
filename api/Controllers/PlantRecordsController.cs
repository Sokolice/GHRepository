using api.Model;
using api.Model.DTOs;
using api.Model.Relations;
using api.Persistence;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlantRecordsController: ControllerBase
    {
        private readonly DataContext _context;

        public PlantRecordsController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("GetPlantRecords")]
        public List<PlantRecordDTO> GetPlantRecords()
        {
            var plantsRecord = _context.PlantRecords.Select(a => new PlantRecordDTO
            {
                Id = a.Id,
                AmountPlanted = a.AmountPlanted,
                DatePlanted = a.DatePlanted,
                PlantId = a.PlantId    
            }).ToList();

            return plantsRecord;
        }

        [HttpPost]
        public async Task<ActionResult<PlantRecordDTO>> PostPlantRecord(PlantRecordDTO plantRecord)
        {
            _context.PlantRecords.Add(new PlantRecord
            {
                Id = plantRecord.Id,
                AmountPlanted = plantRecord.AmountPlanted,
                DatePlanted = plantRecord.DatePlanted,
                PlantId = plantRecord.PlantId,
                Plant = _context.Plants.First(a => a.Id == plantRecord.PlantId)
            }) ;

            await _context.SaveChangesAsync();


            return new OkObjectResult(plantRecord);
        }
     }
}
