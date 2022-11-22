namespace Artisashop.Models.ViewModel.Chat;

/// <summary>
/// Returns an overview of a conversation.
/// </summary>
public class ConversationOverview
{
    public required Account Interlocutor { get; set; }

    public required ChatMessage LastMessage { get; set; }
}