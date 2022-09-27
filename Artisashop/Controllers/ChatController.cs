using Artisashop.Interfaces.IRepository;
using Artisashop.Models;
using Artisashop.Models.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.IdentityModel.Tokens.Jwt;
using System.Net;

namespace Artisashop.Controllers
{
    /// <summary>
    /// This controller handles chat actions as message and document exchange
    /// </summary>
    [ApiController]
    [Produces("application/json")]
    [Route("api/chat")]
    [Authorize]
    public class ChatController : ControllerBase
    {
        private readonly IChatHistoryRepository _chatHistoryRepo;
        private readonly StoreDbContext _db;

        public ChatController(IChatHistoryRepository chatHistoryRepo, StoreDbContext db)
        {
            _chatHistoryRepo = chatHistoryRepo;
            _db = db;
        }

        /// <summary>
        /// Display the list of openned chats
        /// </summary>
        /// <returns>Chat list page on success, redirect to AccountController::Login or BadRequest</returns>
        [HttpGet("list")]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> Index()
        {
            try
            {
                string? token = Request.Headers["Authorization"].ToString().Split(" ")[1];
                var handler = new JwtSecurityTokenHandler();
                var jwt = handler.ReadJwtToken(token);
                var username = jwt.Claims.First(claim => claim.Type == "sub").Value;
                var user = await _db.Accounts!.SingleAsync(u => u.UserName == username);
                List<ChatPreviewViewModel> cpvm = await _chatHistoryRepo.LoadLastMsg(user.Id);
                if (cpvm.Any())
                    cpvm[0].User = await _db.Accounts!.FirstAsync(account => account == cpvm[0].LastMsg.ReceiverId);
                return Ok(cpvm);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Display a chat between 2 users
        /// </summary>
        /// <param name="toUserId">The user id of the person to contact</param>
        /// <returns>Chat page on success, AccountController::Login if not logged in or BadRequest</returns>
        [HttpGet("chat/{toUserId}")]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public IActionResult Chat(string toUserId)
        {
            try
            {
                return Ok(toUserId);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
    }
}
