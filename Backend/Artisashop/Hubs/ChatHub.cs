using Artisashop.Models.ViewModel;
using Microsoft.AspNetCore.SignalR;

namespace Artisashop.Hubs
{
    /// <summary>
    /// Handles the dynamic chat using SignalR
    /// </summary>
    public class ChatHub : Hub<IChatClient>
    {
        /// <summary>
        /// list of connected users to the chat
        /// </summary>
        public static readonly List<ChatUserDetail> connectedUsers = new();

        public ChatHub()
        {
        }

        /// <summary>
        /// Called when a user connect themself to the chat
        /// </summary>
        /// <param name="userID">ID of the user</param>
        /// <param name="username">username use in the chat by the user</param>
        /// <returns></returns>
        public async Task Connect(string userID, string username)
        {
            string id = Context.ConnectionId;

            if (!connectedUsers.Any(x => x.ConnectionId == id))
            {
                if (!connectedUsers.Any(x => x.UserID == userID))
                    await Clients.AllExcept(id).UserConnection(userID);
                //await Clients.AllExcept(id).SendAsync("UserConnection", userID);
                connectedUsers.Add(new ChatUserDetail(id, userID, username));
            }
            await Clients.Caller.OnConnected(userID);
            //await Clients.Caller.SendAsync("OnConnected", userID, "Connected as " + username + " (" + userID + ")");
        }

        /// <summary>
        /// Called by SignalR when a new client connect themself to the hub
        /// </summary>
        /// <returns></returns>
        public override async Task OnConnectedAsync()
        {
            await base.OnConnectedAsync();
        }

        /// <summary>
        /// Called by SignalR when a new client disconnect themself to the hub
        /// </summary>
        /// <returns></returns>
        public override async Task OnDisconnectedAsync(Exception? e)
        {
            ChatUserDetail? item = connectedUsers.Where(x => x.ConnectionId == Context.ConnectionId).FirstOrDefault();
            if (item != null)
            {
                connectedUsers.Remove(item);
                if (!connectedUsers.Any(x => x.UserID == item.UserID))
                {
                    await Clients.All.UserDisconnection(item.UserID);
                    //await Clients.All.SendAsync("UserDisconntection", item.UserID);
                }
            }
            await base.OnDisconnectedAsync(e);
        }

        /*public async Task SendPrivateMessage(string toUserID, string filename, string message, DateTime date, string? file = null)
        {
            string fromConnectionID = Context.ConnectionId;
            string fromUserID = connectedUsers.Where(x => x.ConnectionId == fromConnectionID).FirstOrDefault()!.UserID;
            //int tmp = await _chatHistoryRepo.AddToHistory(fromUserID, toUserID, filename, message, date, file);
            List<ChatUserDetail> toUserList = connectedUsers.Where(x => x.UserID == toUserID).ToList();
            List<ChatUserDetail> fromUserList = connectedUsers.Where(x => x.UserID == fromUserID).ToList();
            foreach (ChatUserDetail elem in toUserList)
                await Clients.Client(elem.ConnectionId).PrivateMessage(false, filename, message, date, file, tmp);
                //await Clients.Client(elem.ConnectionId).SendAsync("PrivateMessage", false, filename, message, date, file, tmp["objectId"]);
            foreach (ChatUserDetail elem in fromUserList)
                await Clients.Client(elem.ConnectionId).PrivateMessage(true, filename, message, date, file, tmp);
                //await Clients.Client(elem.ConnectionId).SendAsync("PrivateMessage", true, filename, message, date, file, tmp["objectId"]);
        }

        public async Task DeleteMsg(int msgID)
        {
            ChatMessage msg = await _chatHistoryRepo.GetMsg(msgID);
            int result = await _chatHistoryRepo.DeleteMsg(msgID);
            if (result != 0) {
                List<ChatUserDetail> userList = connectedUsers.Where(x => (x.UserID == msg.SenderId?.Id || x.UserID == msg.ReceiverId?.Id)).ToList();
                foreach (ChatUserDetail elem in userList)
                    await Clients.Client(elem.ConnectionId).DeleteMsg(msgID);
                    //await Clients.Client(elem.ConnectionId).SendAsync("DeleteMsg", msgID);
            }
        }

        public async Task UpdateMsg(int msgID, string content)
        {
            ChatMessage msg = await _chatHistoryRepo.GetMsg(msgID);
            if (0 != (await _chatHistoryRepo.UpdateMsg(msgID, content))) {
                List<ChatUserDetail> userList = connectedUsers.Where(x => (x.UserID == msg.SenderId?.Id || x.UserID == msg.ReceiverId?.Id)).ToList();
                foreach (ChatUserDetail elem in userList)
                    await Clients.Client(elem.ConnectionId).UpdateMsg(msgID, content);
                    //await Clients.Client(elem.ConnectionId).SendAsync("UpdateMsg", msgID, content);
            }
        }*/
    }
}