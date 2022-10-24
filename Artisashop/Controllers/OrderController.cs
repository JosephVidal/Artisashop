using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using Artisashop.Models;

namespace Artisashop.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("order")]
    [Authorize]
    public class OrderController : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public IActionResult Order()
        {
            return Ok();
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.Redirect)]
        public IActionResult PostOrder([FromBody] Billing model)
        {
            if (!TryValidateModel(model))
            {
                return BadRequest();
            }
            return RedirectToAction("Index", "Home");
        }
    }
}
