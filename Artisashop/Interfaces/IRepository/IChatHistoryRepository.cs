using Artisashop.Models;
using Artisashop.Models.ViewModel;

namespace Artisashop.Interfaces.IRepository
{
    /// <summary>
    /// Interface for chat history repository
    /// </summary>
    public interface IChatHistoryRepository : IAsyncRepository<ChatMessage>
    {
        public Task<int> AddToHistory(string fromUserID, string toUserID, string filename, string msg, DateTime date, string? file = null);
        public List<ChatMessage> LoadHistory(string userIDOne, string userIDTwo);
        public Task<List<ChatPreviewViewModel>> LoadLastMsg(string userID);
        public Task<ChatMessage> GetMsg(int msgID);
        public Task<int> DeleteMsg(int msgID);
        public Task<int> UpdateMsg(int msgID, string content);
    }
}
