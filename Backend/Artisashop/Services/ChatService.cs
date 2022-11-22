namespace Artisashop.Services;

using Base;
using Interface;
using Microsoft.EntityFrameworkCore;
using Models;
using Models.ViewModel.Chat;

public interface IChatService : ICrudRepository<ChatMessage, int>
{
    Task<IEnumerable<ConversationOverview>> GetConversationOverviewsAsync(string userId);
    Task<IEnumerable<ChatMessage>> GetConversationAsync(string user1, string user2);
    Task<ChatMessage> SendMessage(ChatMessage message);
}

public class ChatService : BaseCrudRepository<ChatMessage, int>, IChatService
{
    protected ChatService(StoreDbContext dbContext, DbSet<ChatMessage> dbSet) : base(dbContext, dbSet)
    {
    }

    public async Task<IEnumerable<ConversationOverview>> GetConversationOverviewsAsync(string userId)
    {
        var lastMessages = DbSet
            .Where(message => (message.SenderId == userId || message.ReceiverId == userId))
            .Include(message => message.Sender)
            .ThenInclude(user => user.ProfilePicture)
            .Include(message => message.Receiver)
            .ThenInclude(user => user.ProfilePicture)
            .GroupBy(message => message.SenderId == userId ? message.ReceiverId : message.SenderId)
            .Select(group => group.OrderByDescending(message => message.CreatedAt).First());

        var overviews = await lastMessages
            .Select(message => new ConversationOverview()
            {
                Interlocutor = (message.SenderId == userId ? message.Receiver : message.Sender)!, LastMessage = message
            })
            .ToListAsync();

        return overviews;
    }

    public async Task<IEnumerable<ChatMessage>> GetConversationAsync(string user1, string user2)
    {
        var messages = await DbSet
            .Where(message => (message.SenderId == user1 && message.ReceiverId == user2) ||
                              (message.SenderId == user2 && message.ReceiverId == user1))
            .Include(message => message.Sender)
            .ThenInclude(user => user!.ProfilePicture)
            .Include(message => message.Receiver)
            .ThenInclude(user => user!.ProfilePicture)
            .OrderBy(message => message.CreatedAt)
            .ToListAsync();

        throw new NotImplementedException();
    }

    public async Task<ChatMessage> SendMessage(ChatMessage message)
    {
        await DbSet.AddAsync(message);
        await DbContext.SaveChangesAsync();

        return message;
    }
}