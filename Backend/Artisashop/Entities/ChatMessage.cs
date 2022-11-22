namespace Artisashop.Models;

using System.ComponentModel.DataAnnotations;
using Artisashop.Models.Interface;

public class ChatMessage : IIdentifiable<int>, ICreatedAt
{
    public int Id { get; set; }

    public Account? Sender { get; set; }
    public string SenderId { get; set; } = null!;

    public Account? Receiver { get; set; }
    public string ReceiverId { get; set; } = null!;

    public DateTime? CreatedAt { get; set; }

    public string? Content { get; set; }
    public string? Joined { get; set; }
    public string? Filename { get; set; }
}