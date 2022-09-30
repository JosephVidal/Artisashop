using Artisashop.Models;
using Artisashop.Models.ViewModel;
using Artisashop.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        private readonly StoreDbContext _db;
        private readonly Utils _utils = new();

        public ChatController(StoreDbContext db)
        {
            _db = db;
        }

        /// <summary>
        /// Display the list of openned chats
        /// </summary>
        /// <returns>Chat list page on success, redirect to AccountController::Login or BadRequest</returns>
        [HttpGet("list")]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(List<ChatPreview>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Index()
        {
            try
            {
                Account account = await _utils.GetFromCookie(Request, _db);
                List<ChatPreview> cpvm = await LoadLastMsg(account.Id);
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
        [HttpGet("{toUserId}")]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.OK)]
        public IActionResult Chat(string toUserId)
        {
            try
            {
                return Ok(toUserId);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// This function add a message to chat history database
        /// </summary>
        /// <param name="fromUserID">Sender id</param>
        /// <param name="toUserID">Receiver id</param>
        /// <param name="filename">Name of the attached file if there's one</param>
        /// <param name="content">Message content</param>
        /// <param name="joined">Attached file content</param>
        /// <returns>A disctionnary with success or error</returns>
        [HttpPost]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(ChatMessage), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Create(CreateChatMessage message)
        {
            try
            {
                Account sender = await _db.Accounts!.FirstAsync(user => user.Id == message.FromUserId);
                Account receiver = await _db.Accounts!.FirstAsync(user => user.Id == message.ToUserID);
                if (sender == null)
                    return NotFound("Sender with id " + message.FromUserId + " not found");
                if (receiver == null)
                    return NotFound("Receiver with id " + message.ToUserID + " not found");
                var result = await _db.ChatMessages!.AddAsync(new ChatMessage(sender, receiver, message.Content, message.Joined, message.Filename));
                await _db.SaveChangesAsync();
                return Ok(result.Entity);
            } catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Get a chat history
        /// </summary>
        /// <param name="userIDOne">Sender or receiver id</param>
        /// <param name="userIDTwo">Sender or receiver id</param>
        /// <returns>A list of message from a chat</returns>
        [HttpGet("history")]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(List<ChatMessage>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> LoadHistory(string userIDOne, string userIDTwo)
        {
            try
            {
                return Ok(await _db.ChatMessages!.Include("SenderId").Include("ReceiverId").Where(message =>
                    (message.SenderId!.Id == userIDOne || message.SenderId.Id == userIDTwo) &&
                    (message.ReceiverId!.Id == userIDOne || message.ReceiverId.Id == userIDTwo)).ToListAsync());
            } catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Get the last message of a chat
        /// </summary>
        /// <param name="userID">User id of the connected user</param>
        /// <returns>ParseCloud<T> object containing result</returns>
        [HttpGet("lastMsg")]
        public async Task<List<ChatPreview>> LoadLastMsg(string userID)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Get a message by id
        /// </summary>
        /// <param name="msgID">The id of the message to get</param>
        /// <returns>ChatMessage on sucess or null</returns>
        [HttpGet]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ChatMessage), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetMsg(int msgID)
        {
            try
            {
                return Ok(await _db.ChatMessages!.FirstAsync(message => message.Id == msgID));
            } catch(Exception e)
            {
                return BadRequest(e.Message);
            }

        }

        /// <summary>
        /// Update a message from a chat
        /// </summary>
        /// <param name="msgID">The id of the message to update</param>
        /// <param name="content">New content of the message</param>
        /// <returns>Dictionnary with success message or error</returns>
        [HttpPatch]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ChatMessage), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateMsg(int msgID, string content)
        {
            try
            {
                var message = await _db.ChatMessages!.FirstAsync(message => message.Id == msgID);
                message.Content = content;
                _db.ChatMessages!.Update(message);
                await _db.SaveChangesAsync();
                return Ok(message);
            } catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Delete a message from a chat
        /// </summary>
        /// <param name="msgID">The id of the message to delete</param>
        /// <returns>Dictionnary with success message or error</returns>
        [HttpDelete]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteMsg(int msgID)
        {
            try
            {
                _db.ChatMessages!.Remove(await _db.ChatMessages.FirstAsync(message => message.Id == msgID));
                await _db.SaveChangesAsync();
                return Ok("Message with id " + msgID + " deleted");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }
    }
}
