using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Net;
using System.Net.Mail;
using Microsoft.AspNetCore.Authorization;
using Artichaut.Models.ViewModel;

namespace Artichaut.Controllers
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

        public ContactController()
        {
        }

        /// <summary>
        /// Display contact formular
        /// </summary>
        /// <returns>Contact page</returns>
        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public IActionResult Index()
        {
            try
            {
                return Ok(new ContactViewModel());
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
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public IActionResult Send(ContactViewModel contact)
        {
            try
            {
                MailAddress sender = new("ttrest912@gmail.com", "sender");
                MailAddress receiver = new("ttrest912@gmail.com", "receiver");
                string password = "&@Nd4BtFQs!p!bG6";
                string body = "user email: " + contact.Email + "\n\n" + contact.Content;
                SmtpClient smtp = new()
                {
                    Host = "smtp.gmail.com",
                    Port = 587,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(sender.Address, password)
                };
                using (MailMessage mail = new(sender, receiver)
                {
                    Subject = contact.Subject,
                    Body = body
                })
                {
                    smtp.Send(mail);
                }
                return RedirectToAction("Index", "Home");
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                return BadRequest(e.Message);
            }
        }
    }
}