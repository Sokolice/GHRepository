using API.Core;
using API.DTOs;
using API.Model;
using API.Persistence;
using API.Relations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BedsController : ControllerBase
    {
        private readonly DataContext _context;

        public BedsController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("GetBeds")]
        public List<BedRelation> GetBeds()
        {
            var beds = _context.Beds.ToList();

            var bedsDTO = beds.Select(a => new BedRelation(a)).ToList();

            foreach(var bed in bedsDTO)
            {
                bed.GetAllCompanionPlants(_context);
                bed.GetAllAvoidPlants(_context);
            }

            return bedsDTO;
        }

        [HttpPost]
        public async Task<ActionResult<BedRelation>> PostBed(BedRelation bedRelation)
        {
            var bed = new Bed(bedRelation);
            
            _context.Beds.Add(bed);

            await _context.SaveChangesAsync();

            return new OkObjectResult(bedRelation);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<BedRelation>> DeleteBed(Guid id)
        {
            if (_context.Beds == null)
            {
                return NotFound();
            }
            var bed = await _context.Beds.FindAsync(id);
            if (bed == null)
            {
                return NotFound();
            }
            _context.Cells.RemoveRange(bed.Cells);
            _context.Beds.Remove(bed);
            await _context.SaveChangesAsync();

            return new OkObjectResult(id);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<BedRelation>> GetBed(Guid id)
        {
            var bed = await _context.Beds.FindAsync(id);

            if (bed == null)
            {
                return NotFound();
            }

            return new BedRelation(bed);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<BedRelation>> UpdatePlantRecord(Guid id, BedRelation bedRelation)
        {
            if (id != bedRelation.Bed.Id)
            {
                return BadRequest();
            }

            try
            {
                var bed = await _context.Beds.FindAsync(id);

                

                if (bed != null)
                {
                    bed.Name = bedRelation.Bed.Name;
                    bed.Length = bedRelation.Bed.Length;
                    bed.Width = bedRelation.Bed.Width;
                    bed.NumOfRows = bedRelation.Bed.NumOfRows;
                    bed.NumOfColumns = bedRelation.Bed.NumOfColumns;
                    bed.Cells = bedRelation.Cells;
                    bed.IsDesign = bedRelation.Bed.IsDesign;
                    bed.CropRotation = bedRelation.Bed.CropRotation;

                    bed.Plants = _context.Plants.Where(a => bedRelation.Plants.Select(b => b.Id).ToList().Contains(a.Id)).ToList();

                }

                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {

            }

            return NoContent();
        }

        

    }
}
