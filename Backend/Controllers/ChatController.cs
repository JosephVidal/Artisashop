using Backend.Hubs;
using Backend.Models;
using Backend.Models.ViewModel;
using Backend.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Net;

namespace Backend.Controllers
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
            try {
                string[]? acceptedExt = new[] {
                    "doc", "dot", "wbk", "docx", "docm", "dotx", "dotm", "docb", "pdf", "wll", "wwl", "xls", "xlsm", "xltx", "xltm", "xlsb", "xla", "xlam", "xll", "xlw", "ppt", "pot", "pps", "ppa", "ppam", "pptx", "pptm", "potx", "potm", "ppam", "ppsx", "ppsm", "sldx", "sldm", "pa", "one", "pub", "xps",
                    "odt", "ods", "odp", "odg",
                    "xml", "json", "txt", "csv",
                    "jpeg", "jfif", "exif", "tiff", "gif", "bmp", "png", "ppm", "pgm", "pbm", "pnm", "webp", "heif", "avif", "bpg", "deep", "drw", "ecw", "fits", "flif", "ico", "ilbm", "img", "liff", "nrrd", "pam", "pcx", "pgf", "plbm", "sgi", "sid", "tga", "vicar", "xisf", "afphoto", "cd5", "clip", "cpt", "kra", "mdp", "pdn", "psd", "psp", "sai", "xcf", "cgm", "svg", "afdesign", "ai", "cdr", "gem", "gle", "hpgl", "hvif", "lottie", "mathml", "naplps", "odg", "pgml", "qcc", "regis", "rip", "vml", "xar", "xps", "amf", "blend", "dgn", "dwg", "dxf", "flt", "fvrml", "gltf", "hsf" , "iges", "imml", "ipa", "jt", "ma", "mb", "obj", "opengex", "ply", "povray", "prc", "step", "skp", "stl", "u3d", "vrml", "xaml", "xgl", "xvl", "xvrml", "x3d", "3d", "3df", "3dm", "3ds", "3dxml", "x3d", "eps", "ps", "pict", "wmf", "emf", "swf", "xaml", "mpo", "pns", "jps",
                    "webm", "mkv", "flv", "vob", "ogv", "ogg", "drc", "gif", "gifv", "mng", "avi", "mts", "m2ts", "ts", "mov", "qt", "wmv", "yuv", "rm", "rmvb", "viv", "asf", "amv", "mp4", "m4p", "m4v", "mpg", "mp2", "mpeg", "mpe", "mpv", "mpg", "mpeg", "mpe", "mpv", "m2v", "m4v", "svi", "3gp", "3g2", "mxf", "roq", "nsv", "flv", "f4v", "f4p", "f4a", "f4b"
                };
                ulong fileSize = (null == message.Joined) ? 0UL : Convert.ToUInt64(message.Joined.Length) * Convert.ToUInt64(sizeof(char));
                if ((null != message.Joined && null == message.Filename) || 
                    (null != message.Joined && (200UL * 1000000UL) >= fileSize && !(acceptedExt.Contains(Path.GetExtension(message?.Filename)?.Substring(1)))))
                    return BadRequest("Invalid joined file");
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
            }
            catch (Exception e)
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
                    message.Sender!.Id == model.UserIDOne && message.Receiver!.Id == model.UserIDTwo ||
                    message.Receiver!.Id == model.UserIDOne && message.Sender!.Id == model.UserIDTwo).ToListAsync();
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
                return Ok(await _db.ChatMessages!.FirstAsync(message => message.Id == msgId));
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
                var message = await _db.ChatMessages!.FirstAsync(message => message.Id == msgId);
                message.Content = content;
                _db.ChatMessages!.Update(message);
                await _db.SaveChangesAsync();
                //chat hub:
                List<ChatUserDetail> userList = ChatHub.connectedUsers.Where(x => x.UserID == message.Sender?.Id || x.UserID == message.Receiver?.Id).ToList();
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
                List<ChatUserDetail> userList = ChatHub.connectedUsers.Where(x => x.UserID == message.Sender?.Id || x.UserID == message.Receiver?.Id).ToList();
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
