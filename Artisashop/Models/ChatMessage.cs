using System.ComponentModel.DataAnnotations;

namespace Artisashop.Models
{
    public class ChatMessage
    {
        protected ChatMessage()
        {
        }

        public ChatMessage(Account senderId, Account receiverId, string? content, string? joined, string? filename)
        {
            SenderId = senderId;
            ReceiverId = receiverId;
            Date = DateTime.Now;
            Content = content;
            Joined = joined;
            Filename = filename;
        }

        [Key]
        public int Id { get; set; }
        public Account? SenderId { get; set; }
        public Account? ReceiverId { get; set; }
        public DateTime Date { get; set; }
        public string? Content { get; set; }
        public string? Joined { get; set; }
        public string? Filename { get; set; }
    }
}
