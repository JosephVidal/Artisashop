using Artisashop.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Artisashop.Controllers
{
    [ApiController]
    [AllowAnonymous]
    [Produces("application/json")]
    [Route("custom-order")]
    public class CustomOrderController : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public IActionResult CustomOrder()
        {
            return Ok();
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.Redirect)]
        public IActionResult PostCustomOrder([FromBody] Billing model)
        {
            if (!TryValidateModel(model))
            {
                return BadRequest();
            }
            return RedirectToAction("Index", "Home");
        }
    }
}
