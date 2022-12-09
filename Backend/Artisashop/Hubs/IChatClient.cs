namespace Artisashop.Hubs
{
    /// <summary>
    /// Define the function that can be called in the client app by the hub
    /// </summary>
    public interface IChatClient
    {
        /// <summary>
        /// When a new user is connected
        /// </summary>
        /// <param name="userID">new user ID</param>
        /// <returns></returns>
        Task UserConnection(string userID);
        /// <summary>
        /// When the current user is connected
        /// </summary>
        /// <param name="userID">user ID</param>
        /// <returns></returns>
        Task OnConnected(string userID);
        /// <summary>
        /// When a user is disconnected
        /// </summary>
        /// <param name="userID">user ID</param>
        /// <returns></returns>
        Task UserDisconntection(string userID);
        /// <summary>
        /// When you receive or send a new message
        /// </summary>
        /// <param name="isSendByMe">True if you send the message, False if you receive the message</param>
        /// <param name="otherUserID">other user ID</param>
        /// <param name="filename">filename</param>
        /// <param name="message">text content of the message</param>
        /// <param name="date">when the message have been sent</param>
        /// <param name="file">content of the file</param>
        /// <param name="msgID">message ID</param>
        /// <returns></returns>
        Task PrivateMessage(bool isSendByMe, string otherUserID, string? filename, string? message, DateTime date, string? file, int msgID);
        /// <summary>
        /// When a message is deleted
        /// </summary>
        /// <param name="msgID">message ID</param>
        /// <returns></returns>
        Task DeleteMsg(int msgID);
        /// <summary>
        /// When a message is updated
        /// </summary>
        /// <param name="msgID">message ID</param>
        /// <param name="content">new content</param>
        /// <returns></returns>
        Task UpdateMsg(int msgID, string content);
    }
}
