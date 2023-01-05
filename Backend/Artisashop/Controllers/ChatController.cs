using System.Net;
using Artisashop.Hubs;
using Artisashop.Models;
using Artisashop.Models.ViewModel;
using Artisashop.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

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
                List<ChatPreview> chatPreviewReceiver = new();
                List<ChatPreview> chatPreviewSender = new();
                List<ChatPreview> chatPreview = new();
                var groupsReceiver = _db.ChatMessages!.Include(x => x.Sender).Include(x => x.Receiver).Where(x => x.Sender!.Id == account.Id).AsEnumerable().GroupBy(d => d.Receiver);
                var groupsSender = _db.ChatMessages!.Include(x => x.Sender).Include(x => x.Receiver).Where(x => x.Receiver!.Id == account.Id).AsEnumerable().GroupBy(d => d.Sender);
                foreach (var group in groupsReceiver) {
                    ChatMessage? mostRecent = group.OrderBy(x => x.CreatedAt).Last();
                    chatPreviewReceiver.Add(new(mostRecent!, mostRecent!.Sender!.Id == account.Id ? false : true));
                }
                foreach (var group in groupsSender) {
                    ChatMessage? mostRecent = group.OrderBy(x => x.CreatedAt).Last();
                    chatPreviewSender.Add(new(mostRecent!, mostRecent!.Sender!.Id == account.Id ? false : true));
                }
                foreach (ChatPreview CPR in chatPreviewReceiver) {
                    List<ChatPreview> CPS = chatPreviewSender.Where(x => x.LastMsg!.Sender!.Id == CPR.LastMsg!.Receiver!.Id).ToList();
                    if (CPS.Count() != 0) {
                        chatPreview.Add((CPR.LastMsg.CreatedAt > CPS[0].LastMsg.CreatedAt) ? CPR : CPS[0]);
                        chatPreviewSender.Remove(CPS[0]);
                    } else {
                        chatPreview.Add(CPR);
                    }
                }
                foreach (ChatPreview CPS in chatPreviewSender) {
                    chatPreview.Add(CPS);
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
            if (message == null)
            {
                return BadRequest("Message is null");
            }

            try
            {
                string[]? acceptedExt = new[]
                {
                    "doc", "dot", "wbk", "docx", "docm", "dotx", "dotm", "docb", "pdf", "wll", "wwl", "xls", "xlsm",
                    "xltx", "xltm", "xlsb", "xla", "xlam", "xll", "xlw", "ppt", "pot", "pps", "ppa", "ppam", "pptx",
                    "pptm", "potx", "potm", "ppam", "ppsx", "ppsm", "sldx", "sldm", "pa", "one", "pub", "xps",
                    "odt", "ods", "odp", "odg",
                    "xml", "json", "txt", "csv",
                    "jpeg", "jfif", "exif", "tiff", "gif", "bmp", "png", "ppm", "pgm", "pbm", "pnm", "webp", "heif",
                    "avif", "bpg", "deep", "drw", "ecw", "fits", "flif", "ico", "ilbm", "img", "liff", "nrrd", "pam",
                    "pcx", "pgf", "plbm", "sgi", "sid", "tga", "vicar", "xisf", "afphoto", "cd5", "clip", "cpt", "kra",
                    "mdp", "pdn", "psd", "psp", "sai", "xcf", "cgm", "svg", "afdesign", "ai", "cdr", "gem", "gle",
                    "hpgl", "hvif", "lottie", "mathml", "naplps", "odg", "pgml", "qcc", "regis", "rip", "vml", "xar",
                    "xps", "amf", "blend", "dgn", "dwg", "dxf", "flt", "fvrml", "gltf", "hsf", "iges", "imml", "ipa",
                    "jt", "ma", "mb", "obj", "opengex", "ply", "povray", "prc", "step", "skp", "stl", "u3d", "vrml",
                    "xaml", "xgl", "xvl", "xvrml", "x3d", "3d", "3df", "3dm", "3ds", "3dxml", "x3d", "eps", "ps",
                    "pict", "wmf", "emf", "swf", "xaml", "mpo", "pns", "jps",
                    "webm", "mkv", "flv", "vob", "ogv", "ogg", "drc", "gif", "gifv", "mng", "avi", "mts", "m2ts", "ts",
                    "mov", "qt", "wmv", "yuv", "rm", "rmvb", "viv", "asf", "amv", "mp4", "m4p", "m4v", "mpg", "mp2",
                    "mpeg", "mpe", "mpv", "mpg", "mpeg", "mpe", "mpv", "m2v", "m4v", "svi", "3gp", "3g2", "mxf", "roq",
                    "nsv", "flv", "f4v", "f4p", "f4a", "f4b"
                };
                ulong fileSize = (null == message.Joined)
                    ? 0UL
                    : Convert.ToUInt64(message.Joined.Length) * Convert.ToUInt64(sizeof(char));
                if ((null != message.Joined && null == message.Filename) ||
                    (null != message.Joined && (200UL * 1000000UL) >= fileSize &&
                     !(acceptedExt.Contains(Path.GetExtension(message?.Filename)?.Substring(1)))))
                    return BadRequest("Invalid joined file");
                //db:
                Account? sender = await _db.Users!.FirstOrDefaultAsync(user => user.Id == message!.FromUserId);
                Account? receiver = await _db.Users!.FirstOrDefaultAsync(user => user.Id == message!.ToUserID);
                if (sender == null)
                    return NotFound("Sender with id " + message!.FromUserId + " not found");
                if (receiver == null)
                    return NotFound("Receiver with id " + message!.ToUserID + " not found");
                ChatMessage dbMsg = new ChatMessage
                {
                    CreatedAt = DateTime.Now,
                    Sender = sender,
                    Receiver = receiver,
                    Content = message.Content != null ? message.Content : null,
                    Joined = message.Joined,
                    Filename = message.Filename,
                };
                var result = await _db.ChatMessages!.AddAsync(dbMsg);
                await _db.SaveChangesAsync();
                //chat hub:
                List<ChatUserDetail> toUserList =
                    ChatHub.connectedUsers.Where(x => x.UserID == message.ToUserID).ToList();
                List<ChatUserDetail> fromUserList =
                    ChatHub.connectedUsers.Where(x => x.UserID == message.FromUserId).ToList();
                foreach (ChatUserDetail elem in toUserList)
                    await _chatHub.Clients.Client(elem.ConnectionId).PrivateMessage(false, message.FromUserId!, message.Filename,
                        message.Content, DateTime.Now, message.Joined, dbMsg.Id);
                foreach (ChatUserDetail elem in fromUserList)
                    await _chatHub.Clients.Client(elem.ConnectionId).PrivateMessage(true, message.ToUserID!, message.Filename,
                        message.Content, DateTime.Now, message.Joined, dbMsg.Id);

                return Ok(result.Entity);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Get a chat history
        /// </summary>
        /// <param name="model"></param>
        /// <returns>A list of message from a chat</returns>
        [HttpGet("history")]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(List<ChatMessage>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetConversationHistory([FromQuery] string[] users)
        {
            if (users.Length != 2)
                return BadRequest("Query only accepts 2 users");

            var user1 = users[0];
            var user2 = users[1];

            try
            {
                List<ChatMessage> messages = await _db.ChatMessages!
                    .Include(x => x.Sender)
                    .Include(x => x.Receiver)
                    .Where(message =>
                        message.SenderId == user1 && message.ReceiverId == user2 ||
                        message.SenderId == user2 && message.ReceiverId == user1)
                    .ToListAsync();
                return Ok(messages);
            }
            catch (Exception e)
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
                ChatMessage? msg = await _db.ChatMessages!.FirstOrDefaultAsync(message => message.Id == msgId);

                if (msg == null)
                    return NotFound("Message with id " + msgId + " not found");
                return Ok(msg);
            }
            catch (Exception e)
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
        [HttpPatch]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ChatMessage), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateMsg(int msgId, string content)
        {
            try
            {
                //db:
                var message = await _db.ChatMessages!.FirstOrDefaultAsync(message => message.Id == msgId);

                if (message == null)
                    return NotFound("Message with id " + msgId + " not found");
                message.Content = content;
                _db.ChatMessages!.Update(message);
                await _db.SaveChangesAsync();
                //chat hub:
                List<ChatUserDetail> userList = ChatHub.connectedUsers
                    .Where(x => x.UserID == message.Sender?.Id || x.UserID == message.Receiver?.Id).ToList();
                foreach (ChatUserDetail elem in userList)
                    await _chatHub.Clients.Client(elem.ConnectionId).UpdateMsg(msgId, message.Content);

                return Ok(message);
            }
            catch (Exception e)
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
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteMsg(int msgId)
        {
            try
            {
                //db:
                var message = await _db.ChatMessages!.FirstOrDefaultAsync(message => message.Id == msgId);

                if (message == null)
                    return NotFound("Message with id " + msgId + " not found");

                _db.ChatMessages!.Remove(message);
                await _db.SaveChangesAsync();
                //chat hub:
                List<ChatUserDetail> userList = ChatHub.connectedUsers
                    .Where(x => x.UserID == message.Sender?.Id || x.UserID == message.Receiver?.Id).ToList();
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