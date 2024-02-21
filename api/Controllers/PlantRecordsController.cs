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
            var plantsRecord = _context.PlantRecords.Select(a => new PlantRecordDTO
            {
                Id = a.Id,
                AmountPlanted = a.AmountPlanted,
                DatePlanted = a.DatePlanted,
                PlantId = a.PlantId,
                PresumedHarvest = a.PresumedHarvest                
            }).ToList();

            foreach(var record in plantsRecord)
            {
               PlantRecordDTO.calculateProgress(record);
            }

            return plantsRecord;
        }

        [HttpPost]
        public async Task<ActionResult<PlantRecordDTO>> PostPlantRecord(PlantRecordDTO plantRecordDTO)
        {

            var plant = _context.Plants.Find(plantRecordDTO.PlantId);

            PlantRecordDTO.CalculatePresumedHarvest(plantRecordDTO, plant);
            
            PlantRecordDTO.calculateProgress(plantRecordDTO);

            var newPlantRecord = new PlantRecord
            {
                Id = plantRecordDTO.Id,
                AmountPlanted = plantRecordDTO.AmountPlanted,
                DatePlanted = plantRecordDTO.DatePlanted,
                PlantId = plantRecordDTO.PlantId,
                Plant = _context.Plants.First(a => a.Id == plantRecordDTO.PlantId)
            };


            _context.PlantRecords.Add(newPlantRecord);

            await _context.SaveChangesAsync();


            return plantRecordDTO;
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
            
            return new PlantRecordDTO { 
                AmountPlanted = plantRecord.AmountPlanted, 
                DatePlanted = plantRecord.DatePlanted,
                Id = plantRecord.Id,
                PlantId = plantRecord.PlantId
            };
        }

    }
}
