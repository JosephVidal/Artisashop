using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Net;
using Microsoft.AspNetCore.Authorization;
using Backend.Interfaces.IService;
using Backend.Models.ViewModel;

namespace Backend.Controllers
{
    /// <summary>
    /// Handles contacts to artisashop
    /// </summary>
    [ApiController]
    [AllowAnonymous]
    [Produces("application/json")]
    [Route("api/contact")]
    public class ContactController : ControllerBase
    {
        IMailService _mailService;

        public ContactController(IMailService mail)
        {
            _mailService = mail;
        }

        /// <summary>
        /// Display contact formular
        /// </summary>
        /// <returns>Contact page</returns>
        [HttpGet]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(Contact), (int)HttpStatusCode.OK)]
        public IActionResult Index()
        {
            try
            {
                return Ok(new Contact());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Send a message to an Artisashop service by mail
        /// </summary>
        /// <param name="contact">Model with contact information and message</param>
        /// <returns>HomeController::Index on success or BadRequest</returns>
        [HttpPost]
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