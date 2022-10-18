using Artisashop.Hubs;
using Artisashop.Hubs.Clients;
using Artisashop.Models;
using Artisashop.Models.ViewModel;
using Artisashop.Services;
using Duende.IdentityServer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Polly;
using System.Net;
using System.Text.RegularExpressions;

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
        private readonly IHubContext<ChatHub, IChatClient> _chatHub;

        public ChatController(StoreDbContext db, IHubContext<ChatHub, IChatClient> chathub)
        {
            _db = db;
            _chatHub = chathub;
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
                List<ChatPreview> chatPreview = new();
                var groups = _db.ChatMessages!.Include(x => x.Sender).Include(x => x.Receiver).AsEnumerable().GroupBy(d => d.Sender);
                foreach (var group in groups)
                {
                    ChatMessage? mostRecent = group.Last();
                    chatPreview.Add(new(mostRecent!, mostRecent!.Sender!.Id == account.Id ? false : true));
                }
                return Ok(chatPreview);
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
        public async Task<IActionResult> Create([FromBody] CreateChatMessage message)
        {
            try
            {
                //db:
                Account sender = await _db.Accounts!.FirstAsync(user => user.Id == message.FromUserId);
                Account receiver = await _db.Accounts!.FirstAsync(user => user.Id == message.ToUserID);
                if (sender == null)
                    return NotFound("Sender with id " + message.FromUserId + " not found");
                if (receiver == null)
                    return NotFound("Receiver with id " + message.ToUserID + " not found");
                ChatMessage dbMsg = new ChatMessage(sender, receiver, message.Content, message.Joined, message.Filename);
                var result = await _db.ChatMessages!.AddAsync(dbMsg);
                await _db.SaveChangesAsync();
                //chat hub:
                List<ChatUserDetail> toUserList = ChatHub.connectedUsers.Where(x => x.UserID == message.ToUserID).ToList();
                List<ChatUserDetail> fromUserList = ChatHub.connectedUsers.Where(x => x.UserID == message.FromUserId).ToList();
                foreach (ChatUserDetail elem in toUserList)
                    await _chatHub.Clients.Client(elem.ConnectionId).PrivateMessage(false, message.Filename, message.Content, DateTime.Now, message.Joined, dbMsg.Id);
                foreach (ChatUserDetail elem in fromUserList)
                    await _chatHub.Clients.Client(elem.ConnectionId).PrivateMessage(true, message.Filename, message.Content, DateTime.Now, message.Joined, dbMsg.Id);

                return Ok(result.Entity);
            } catch (Exception e)
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
        public async Task<IActionResult> LoadHistory([FromBody] ChatHistory model)
        {
            try
            {
                List<ChatMessage> messages = await _db.ChatMessages!.Include("Sender").Include("Receiver").Where(message =>
                    (message.Sender!.Id == model.UserIDOne && message.Receiver!.Id == model.UserIDTwo) ||
                    (message.Receiver!.Id == model.UserIDOne && message.Sender!.Id == model.UserIDTwo)).ToListAsync();
                return Ok(messages);
            } catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Get a message by id
        /// </summary>
        /// <param name="msgID">The id of the message to get</param>
        /// <returns>ChatMessage on sucess or null</returns>
        [HttpGet("{msgId:int}")]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ChatMessage), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetMsg(int msgId)
        {
            try
            {
                return Ok(await _db.ChatMessages!.FirstAsync(message => message.Id == msgId));
            } catch(Exception e)
            {
                return BadRequest(e.Message);
            }

        }

        /// <summary>
        /// Update a message from a chat
        /// </summary>
        /// <param name="msgId">The id of the message to update</param>
        /// <param name="content">New content of the message</param>
        /// <returns>Dictionnary with success message or error</returns>
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ChatMessage), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateMsg(int msgId, string content)
        {
            try
            {
                //db:
                var message = await _db.ChatMessages!.FirstAsync(message => message.Id == msgId);
                message.Content = content;
                _db.ChatMessages!.Update(message);
                await _db.SaveChangesAsync();
                //chat hub:
                List<ChatUserDetail> userList = ChatHub.connectedUsers.Where(x => (x.UserID == message.Sender?.Id || x.UserID == message.Receiver?.Id)).ToList();
                foreach (ChatUserDetail elem in userList)
                    await _chatHub.Clients.Client(elem.ConnectionId).UpdateMsg(msgId, message.Content);

                return Ok(message);
            } catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Delete a message from a chat
        /// </summary>
        /// <param name="msgId">The id of the message to delete</param>
        /// <returns>Dictionnary with success message or error</returns>
        [HttpDelete("{msgId:int}")]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteMsg(int msgId)
        {
            try
            {
                //db:
                var message = await _db.ChatMessages!.FirstAsync(message => message.Id == msgId);
                _db.ChatMessages!.Remove(message);
                await _db.SaveChangesAsync();
                //chat hub:
                List<ChatUserDetail> userList = ChatHub.connectedUsers.Where(x => (x.UserID == message.Sender?.Id || x.UserID == message.Receiver?.Id)).ToList();
                foreach (ChatUserDetail elem in userList)
                    await _chatHub.Clients.Client(elem.ConnectionId).DeleteMsg(msgId);

                return Ok("Message with id " + msgId + " deleted");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }
    }
}
