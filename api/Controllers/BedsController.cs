using api.DTOs;
using api.Model;
using api.Persistence;
using api.Relations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
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

            var bedsDTO = beds.Select(a => new BedRelation
            {
                Bed = new BedDTO
                {
                    Id = a.Id,
                    Width = a.Width,
                    Length = a.Length,
                    Name = a.Name,
                    NumOfColumns = a.NumOfColumns,
                    NumOfRows = a.NumOfRows
                },

                Cells = a.Cells.OrderBy(x => x.Y).ToList().OrderBy(x => x.X).ToList(),
            }
            ).ToList();

            return bedsDTO;
        }

        [HttpPost]
        public async Task<ActionResult<BedRelation>> PostBed(BedRelation bedRelation)
        {

            var bed = bedRelation;


            _context.Beds.Add(new Bed
            {
                Id = bedRelation.Bed.Id,
                Width = bedRelation.Bed.Width,
                Length = bedRelation.Bed.Length,
                Name = bedRelation.Bed.Name,
                Cells = bedRelation.Cells,
                NumOfColumns = bedRelation.Bed.NumOfColumns,
                NumOfRows = bedRelation.Bed.NumOfRows
            });

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

            return new BedRelation
            {
                Bed = new BedDTO { Id = bed.Id, 
                                    Length = bed.Length, 
                                    Width = bed.Width,
                                    Name = bed.Name,
                                    NumOfColumns = bed.NumOfColumns,
                                    NumOfRows = bed.NumOfRows,
                },
                Cells = bed.Cells.OrderBy(x => x.Y).ToList().OrderBy(x => x.X).ToList(),
            };
        }


    }
}
