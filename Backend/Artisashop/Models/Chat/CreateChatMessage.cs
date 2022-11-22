namespace Artisashop.Models.ViewModel.Chat;

using System.ComponentModel.DataAnnotations;

public class CreateChatMessage
{
    [Required]
    public string? FromUserId { get; set; }

    [Required]
    public string? ToUserID { get; set; }

    public string? Filename { get; set; }

    [Required]
    public string? Content { get; set; }

    public string? Joined { get; set; }
}