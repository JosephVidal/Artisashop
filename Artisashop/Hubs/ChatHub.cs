using Artisashop.Models;
using Microsoft.AspNetCore.SignalR;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System;
using Artisashop.Interfaces.IRepository;
using Artisashop.Models.ViewModel;
using Artisashop.Hubs.Clients;

namespace Artisashop.Hubs
{
    public class ChatHub : Hub<IChatClient>
    {
        static readonly List<ChatUserDetailViewModel> connectedUsers = new();
        private readonly IChatHistoryRepository _chatHistoryRepo;

        public ChatHub(IChatHistoryRepository chatHistoryRepo)
        {
            _chatHistoryRepo = chatHistoryRepo;
        }

        public async Task Connect(string userID, string username)
        {
            string id = Context.ConnectionId;

            if (!connectedUsers.Any(x => x.ConnectionId == id)) {
                if (!connectedUsers.Any(x => x.UserID == userID))
                    await Clients.AllExcept(id).UserConnection(userID);
                    //await Clients.AllExcept(id).SendAsync("UserConnection", userID);
                connectedUsers.Add(new ChatUserDetailViewModel(id, userID, username));
            }
            await Clients.Caller.OnConnected(userID, "Connected as " + username + " (" + userID + ")");
            //await Clients.Caller.SendAsync("OnConnected", userID, "Connected as " + username + " (" + userID + ")");
        }

        public override async Task OnConnectedAsync()
        {
            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception? e)
        {
            ChatUserDetailViewModel? item = connectedUsers.Where(x => x.ConnectionId == Context.ConnectionId).FirstOrDefault();
            if (item != null) {
                connectedUsers.Remove(item);
                if (!connectedUsers.Any(x => x.UserID == item.UserID)) {
                    await Clients.All.UserDisconntection(item.UserID);
                    //await Clients.All.SendAsync("UserDisconntection", item.UserID);
                }
            }
            await base.OnDisconnectedAsync(e);
        }

        public async Task SendPrivateMessage(string toUserID, string filename, string message, DateTime date, string? file = null)
        {
            string fromConnectionID = Context.ConnectionId;
            string fromUserID = connectedUsers.Where(x => x.ConnectionId == fromConnectionID).FirstOrDefault()!.UserID;
            int tmp = await _chatHistoryRepo.AddToHistory(fromUserID, toUserID, filename, message, date, file);
            List<ChatUserDetailViewModel> toUserList = connectedUsers.Where(x => x.UserID == toUserID).ToList();
            List<ChatUserDetailViewModel> fromUserList = connectedUsers.Where(x => x.UserID == fromUserID).ToList();
            foreach (ChatUserDetailViewModel elem in toUserList)
                await Clients.Client(elem.ConnectionId).PrivateMessage(false, filename, message, date, file, tmp);
                //await Clients.Client(elem.ConnectionId).SendAsync("PrivateMessage", false, filename, message, date, file, tmp["objectId"]);
            foreach (ChatUserDetailViewModel elem in fromUserList)
                await Clients.Client(elem.ConnectionId).PrivateMessage(true, filename, message, date, file, tmp);
                //await Clients.Client(elem.ConnectionId).SendAsync("PrivateMessage", true, filename, message, date, file, tmp["objectId"]);
        }

        public async Task LoadHistory(string currentUserID, string otherUserID)
        {
            List<ChatMessage> chatHistory = _chatHistoryRepo.LoadHistory(currentUserID, otherUserID);
            string connectionID = Context.ConnectionId;
            foreach (ChatMessage elem in chatHistory)
                await Clients.Client(connectionID).PrivateMessage((elem.SenderId?.Id == currentUserID), elem.Filename, elem.Content, elem.Date, elem.Joined, elem.Id);
                //await Clients.Client(connectionID).SendAsync("PrivateMessage", (elem.SenderId.ObjectId == currentUserID), elem.Filename, elem.Content, elem.Date.Iso, elem.Joined, elem.ObjectId);
        }

        public async Task DeleteMsg(int msgID)
        {
            ChatMessage msg = await _chatHistoryRepo.GetMsg(msgID);
            int result = await _chatHistoryRepo.DeleteMsg(msgID);
            if (result != 0) {
                List<ChatUserDetailViewModel> userList = connectedUsers.Where(x => (x.UserID == msg.SenderId?.Id || x.UserID == msg.ReceiverId?.Id)).ToList();
                foreach (ChatUserDetailViewModel elem in userList)
                    await Clients.Client(elem.ConnectionId).DeleteMsg(msgID);
                    //await Clients.Client(elem.ConnectionId).SendAsync("DeleteMsg", msgID);
            }
        }

        public async Task UpdateMsg(int msgID, string content)
        {
            ChatMessage msg = await _chatHistoryRepo.GetMsg(msgID);
            if (0 != (await _chatHistoryRepo.UpdateMsg(msgID, content))) {
                List<ChatUserDetailViewModel> userList = connectedUsers.Where(x => (x.UserID == msg.SenderId?.Id || x.UserID == msg.ReceiverId?.Id)).ToList();
                foreach (ChatUserDetailViewModel elem in userList)
                    await Clients.Client(elem.ConnectionId).UpdateMsg(msgID, content);
                    //await Clients.Client(elem.ConnectionId).SendAsync("UpdateMsg", msgID, content);
            }
        }
    }
}