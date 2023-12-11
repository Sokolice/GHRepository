using api.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using api.Persistence;
using api.DTOs;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlantsController : ControllerBase
    {
        private readonly DataContext _context;

        public PlantsController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Plants
        [HttpGet]
        public List<PlantDTO> GetPlants()
        {
            var plants = _context.Plants.ToList();

            var plantsDTO = plants.Select(a => new PlantDTO
            {
                CropRotation = a.CropRotation,
                Description = a.Description,
                DirectSewing = a.DirectSewing,
                GerminationTemp = a.GerminationTemp,
                Id = a.Id,
                ImageSrc = a.ImageSrc,
                IsHybrid = a.IsHybrid,
                Name = a.Name,
                RepeatedPlanting = a.RepeatedPlanting
            }).ToList();
            
            return plantsDTO;
        }

        // GET: api/Plants/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Plant>> GetPlant(Guid id)
        {
            if (_context.Plants == null)
            {
                return NotFound();
            }
            var plant = await _context.Plants.FindAsync(id);

            if (plant == null)
            {
                return NotFound();
            }

            return plant;
        }

        // PUT: api/Plants/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPlant(Guid id, Plant plant)
        {
            if (id != plant.Id)
            {
                return BadRequest();
            }

            _context.Entry(plant).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlantExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Plants
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Plant>> PostPlant(Plant plant)
        {
            if (_context.Plants == null)
            {
                return Problem("Entity set 'PlantsContext.Plants'  is null.");
            }
            _context.Plants.Add(plant);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPlant", new { id = plant.Id }, plant);
        }

        // DELETE: api/Plants/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePlant(Guid id)
        {
            if (_context.Plants == null)
            {
                return NotFound();
            }
            var plant = await _context.Plants.FindAsync(id);
            if (plant == null)
            {
                return NotFound();
            }

            _context.Plants.Remove(plant);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PlantExists(Guid id)
        {
            return (_context.Plants?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
