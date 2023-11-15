﻿using api.Model;
using api.Model.DTOs;
using api.Model.Relations;
using api.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
