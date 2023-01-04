using System.ComponentModel.DataAnnotations;

namespace Artisashop.Models.ViewModel
{
    public class CreateChatMessage
    {
        [Required]
        public string? FromUserId { get; set; }
        [Required]
        public string? ToUserID { get; set; }
        [Required]
        public string? Content { get; set; }
        public IFormFile? File { get; set; }
    }
}
