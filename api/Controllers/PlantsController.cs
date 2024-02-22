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

namespace API.Controllers
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

            var plantsDTO = plants.Select(a => new PlantDTO(a))
                                  .ToList();
            
            return plantsDTO;
        }

        // GET: api/Plants/5
        [HttpGet("{id}")]
        public PlantDTO GetPlant(Guid id)
        {
            var plant = _context.Plants.Find(id);

            var plantDTO = new PlantDTO(plant);


            return plantDTO;
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

        [HttpGet]
        [Route("GetOtherPlants")]
        //[HttpGet("{id}/others")]
        public PlantPlantsRelation GetOtherPlants(Guid id)
        {
            var plant = _context.Plants.Find(id);

            var others = new PlantPlantsRelation
            {
                Plant = new PlantDTO(plant),
                AvoidPlants =MyMapping.MapPlantList(plant.AvoidPlants).OrderBy(a=>a.Name).ToList(),
                CompanionPlants = MyMapping.MapPlantList(plant.CompanionPlants).OrderBy(a => a.Name).ToList()
            };

            return others;            
        }

        [HttpGet]
        [Route("GetAllPlantsRelations")]
        //[HttpGet("{id}/others")]
        public List<PlantPlantsRelation> GetAllPlantsRelations()
        {
            var others = _context.Plants.Select(a => new PlantPlantsRelation
            {
                Plant = new PlantDTO(a),
                AvoidPlants = MyMapping.MapPlantList(a.AvoidPlants).ToList(),
                CompanionPlants = MyMapping.MapPlantList(a.CompanionPlants).ToList()
            }).ToList();

            return others;
        }
    }
}
