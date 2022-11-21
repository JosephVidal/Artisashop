namespace Artisashop.Hubs;

public interface IChatClient
{
    Task UserConnection(string userID);
    Task OnConnected(string userID, string content);
    Task UserDisconntection(string userID);
    Task PrivateMessage(bool isSendByMe, string? filename, string? message, DateTime date, string? file, int msgID);
    Task DeleteMsg(int msgID);
    Task UpdateMsg(int msgID, string content);
}