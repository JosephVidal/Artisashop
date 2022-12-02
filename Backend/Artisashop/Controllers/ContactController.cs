using System.Diagnostics;
using System.Net;
using Artisashop.Interfaces.IService;
using Artisashop.Models.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Artisashop.Controllers
{
    /// <summary>
    /// Handles contacts to artisashop
    /// </summary>
    [ApiController]
    [AllowAnonymous]
    [Produces("application/json")]
    [Route("contact")]
    public class ContactController : ControllerBase
    {
        IMailService _mailService;

        public ContactController(IMailService mail)
        {
            _mailService = mail;
        }


        /// <summary>
        /// Send a message to an Artisashop service by mail
        /// </summary>
        /// <param name="contact">Model with contact information and message</param>
        /// <returns>HomeController::Index on success or BadRequest</returns>
        [HttpPost, Route("[controller]", Name = "SendContact")]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.OK)]
        public IActionResult Send(Contact contact)
        {
            try
            {
                _mailService.SendMail("artisashop@artisashop.eu", contact.Subject!, "user email: " + contact.Email + "\n\n" + contact.Content);
                return Ok("Email envoyé");
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                return BadRequest(e.Message);
            }
        }
    }
}