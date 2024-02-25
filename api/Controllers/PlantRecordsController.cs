using API.DTOs;
using API.Model;
using API.Relations;
using API.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API.Core;

namespace API.Controllers
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
            var plantsRecord = _context.PlantRecords.Select(a => new PlantRecordDTO(a))
                                                    .ToList();

            foreach(var record in plantsRecord)
            {
                if (record.PresumedHarvest.ToString() == "01.01.0001 0:00:00")
                {
                    var plant = _context.Plants.Find(record.PlantId);
                    record.CalculatePresumedHarvest(plant);

                }
                record.calculateProgress();
            }

            return plantsRecord;
        }

        [HttpPost]
        public async Task<ActionResult<PlantRecordDTO>> PostPlantRecord(PlantRecordDTO aPlantRecordDTO)
        {

            var plant = _context.Plants.Find(aPlantRecordDTO.PlantId);

            aPlantRecordDTO.CalculatePresumedHarvest(plant);

            aPlantRecordDTO.calculateProgress();

            var newPlantRecord = new PlantRecord
            {
                Id = aPlantRecordDTO.Id,
                AmountPlanted = aPlantRecordDTO.AmountPlanted,
                DatePlanted = aPlantRecordDTO.DatePlanted,
                PlantId = aPlantRecordDTO.PlantId,
                Plant = _context.Plants.First(a => a.Id == aPlantRecordDTO.PlantId),
                Note = aPlantRecordDTO.Note
            };


            _context.PlantRecords.Add(newPlantRecord);

            await _context.SaveChangesAsync();


            return aPlantRecordDTO;
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<PlantRecordDTO>> DeletePlantRecord(Guid id)
        {
            if (_context.PlantRecords == null)
            {
                return NotFound();
            }
            var plant = await _context.PlantRecords.FindAsync(id);
            if (plant == null)
            {
                return NotFound();
            }

            _context.PlantRecords.Remove(plant);
            await _context.SaveChangesAsync();

            return new OkObjectResult(id);
        }


        [HttpPut("{id}")]
        public async Task<ActionResult<PlantRecordDTO>> UpdatePlantRecord(Guid id, PlantRecordDTO plantRecord)
        {
            if (id != plantRecord.Id)
            {
                return BadRequest();
            }

            //_context.Entry(monthWeek).State = EntityState.Modified;

            try
            {
                var record = await _context.PlantRecords.FindAsync(id);
                if(record != null) 
                {
                    record.AmountPlanted = plantRecord.AmountPlanted;
                    record.DatePlanted = plantRecord.DatePlanted;

                    var plant = await _context.Plants.FindAsync(plantRecord.PlantId);

                    if(plant != null){
                        record.Plant = plant;
                    }

                    record.PlantId = plantRecord.PlantId;
                }

                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
               
            }

            return NoContent();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PlantRecordDTO>> GetPlant(Guid id)
        {
            var plantRecord = await _context.PlantRecords.FindAsync(id);

            if (plantRecord == null)
            {
                return NotFound();
            }
            
            return new PlantRecordDTO(plantRecord);
        }

    }
}
