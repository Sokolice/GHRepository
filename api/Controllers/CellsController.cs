using API.Core;
using API.Interfaces;
using API.Persistence;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CellsController : BaseApiController
    {
        private readonly ICellsService _cellsService;

        public CellsController(ICellsService cellsService)
        {
            _cellsService = cellsService;
        }


        [HttpPatch]
        [Route("DeleteCells")]
        public async Task<ActionResult> DeleteCells(List<Guid> ids)
        {
            var result = await _cellsService.DeleteCells(ids);

           return HandleResult(result);
        }

    }
}
