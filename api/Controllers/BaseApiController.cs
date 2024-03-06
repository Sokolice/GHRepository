using API.Core;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class BaseApiController: Controller
    {
        protected ActionResult HandleResult<T>(Result<T> result)
        {
            if (result == null || result.NotFound) return NotFound();

            if (result.IsSucess && result.Value != null)
                return Ok(result.Value);

            if (result.IsSucess && result.Value == null)
                return NotFound();

            return BadRequest(result.Error);
        }
    }
}
