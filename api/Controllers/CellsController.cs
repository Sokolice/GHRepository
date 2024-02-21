using API.Persistence;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CellsController : ControllerBase
    {
        private readonly DataContext _context;

        public CellsController(DataContext context)
        {
            _context = context;
        }


        [HttpPatch]
        [Route("DeleteCells")]
        public async Task<IActionResult> DeleteCells(List<Guid> ids)
        {
            try
            {
                var cells = _context.Cells.Where(c => ids.Contains(c.Id));

                _context.Cells.RemoveRange(cells);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }

            return NoContent();
        }

    }
}
