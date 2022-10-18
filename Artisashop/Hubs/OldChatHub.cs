using Artisashop.Models.ViewModel;
using Microsoft.AspNetCore.SignalR;

namespace Artisashop.OldHubs;

public class OldChatHub : Hub
{
    public HashSet<ConnectedUser> ConnectedUsers { get; set; } = new();

    public OldChatHub()
    {
    }

    public static class Methods
    {
        public const string ReceiveMessage = "ReceiveMessage";
    }

    public async Task Connect(string userId)
    {
        var id = Context.ConnectionId;
    }

    public override async Task OnConnectedAsync()
    {
        await base.OnConnectedAsync();
    }

    public override Task OnDisconnectedAsync(Exception? exception)
    {
        var connectionId = Context.ConnectionId;


        return base.OnDisconnectedAsync(exception);
    }

    public async Task SendMessage(string userId, string message)
    {
        await Clients.Others.SendAsync(Methods.ReceiveMessage, userId, message);
    }
}