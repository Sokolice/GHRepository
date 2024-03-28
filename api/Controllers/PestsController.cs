using API.Core;
using API.Relations;
using API.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PestsController : BaseApiController
    {
        private readonly IPestsService _pestsService;

        public PestsController(IPestsService pestsService)
        {
            _pestsService = pestsService;
        }

        [HttpGet]
        public async Task<ActionResult<List<PestRelation>>> GetPests()
        {
            var result = await _pestsService.GetPests();

            return HandleResult(result);
        }
    }
}
