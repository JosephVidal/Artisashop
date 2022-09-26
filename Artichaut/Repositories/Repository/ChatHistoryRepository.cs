using Artichaut.Interfaces.IRepository;
using Artichaut.Models;
using Artichaut.Models.ViewModel;
using Microsoft.EntityFrameworkCore;

namespace Artichaut.Repositories.Repository
{
    /// <summary>
    /// Contains methods for chat interactions
    /// </summary>
    public class ChatHistoryRepository : IChatHistoryRepository
    {
        private readonly StoreDbContext _db = new();

        /// <summary>
        /// This function add a message to chat history database
        /// </summary>
        /// <param name="fromUserID">Sender id</param>
        /// <param name="toUserID">Receiver id</param>
        /// <param name="filename">Name of the attached file if there's one</param>
        /// <param name="msg">Message content</param>
        /// <param name="date">Date when message has been sent</param>
        /// <param name="file">Attached file content</param>
        /// <returns>A disctionnary with success or error</returns>
        public async Task<int> AddToHistory(string fromUserID, string toUserID, string filename, string content, DateTime date, string? joined = null)
        {
            Account sender = await _db.Accounts!.FirstAsync(user => user.Id == fromUserID);
            Account receiver = await _db.Accounts!.FirstAsync(user => user.Id == toUserID);
            if (sender == null)
                throw new Exception("Sender not found, id: " + fromUserID);
            if (receiver == null)
                throw new Exception("Receiver not found, id: " + fromUserID);
            await _db.ChatMessages!.AddAsync(new ChatMessage(sender, receiver, content, joined, filename));
            return await _db.SaveChangesAsync();
        }

        /// <summary>
        /// Get a chat history
        /// </summary>
        /// <param name="userIDOne">Sender or receiver id</param>
        /// <param name="userIDTwo">Sender or receiver id</param>
        /// <returns>A list of message from a chat</returns>
        public List<ChatMessage> LoadHistory(string userIDOne, string userIDTwo)
        {
            return _db.ChatMessages!.Include("SenderId").Include("ReceiverId").Where(message =>
                (message.SenderId!.Id == userIDOne || message.SenderId.Id == userIDTwo) &&
                (message.ReceiverId!.Id == userIDOne || message.ReceiverId.Id == userIDTwo)).ToList();
        }

        /// <summary>
        /// Get the last message of a chat
        /// </summary>
        /// <param name="userID">User id of the connected user</param>
        /// <returns>ParseCloud<T> object containing result</returns>
        public async Task<List<ChatPreviewViewModel>> LoadLastMsg(string userID)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Get a message by id
        /// </summary>
        /// <param name="msgID">The id of the message to get</param>
        /// <param name="sessionToken">Token that verifies if a user identity</param>
        /// <returns>ChatMessage on sucess or null</returns>
        public async Task<ChatMessage> GetMsg(int msgID)
        {
            return await _db.ChatMessages!.FirstAsync(message => message.Id == msgID);
        }

        /// <summary>
        /// Delete a message from a chat
        /// </summary>
        /// <param name="msgID">The id of the message to delete</param>
        /// <returns>Dictionnary with success message or error</returns>
        public async Task<int> DeleteMsg(int msgID)
        {
            _db.ChatMessages!.Remove(await _db.ChatMessages.FirstAsync(message => message.Id == msgID));

            return await _db.SaveChangesAsync();
        }

        /// <summary>
        /// Update a message from a chat
        /// </summary>
        /// <param name="msgID">The id of the message to update</param>
        /// <param name="content">New content of the message</param>
        /// <returns>Dictionnary with success message or error</returns>
        public async Task<int> UpdateMsg(int msgID, string content)
        {
            var message = await _db.ChatMessages!.FirstAsync(message => message.Id == msgID);
            message.Content = content;
            _db.ChatMessages!.Update(message);

            return await _db.SaveChangesAsync();
        }
    }
}
