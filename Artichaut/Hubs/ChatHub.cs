using Artichaut.Models.ViewModel;
using Microsoft.AspNetCore.SignalR;

namespace Artichaut.Hubs;

public class ChatHub : Hub
{
    public HashSet<ConnectedUserViewModel> ConnectedUsers { get; set; } = new();

    public ChatHub()
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