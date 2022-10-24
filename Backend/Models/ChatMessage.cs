using System.ComponentModel.DataAnnotations;

namespace Backend.Models
{
    public class ChatMessage
    {
        public ChatMessage()
        {
        }

        public ChatMessage(Account senderId, Account receiverId, string? content, string? joined, string? filename)
        {
            Sender = senderId;
            Receiver = receiverId;
            Date = DateTime.Now;
            Content = content;
            Joined = joined;
            Filename = filename;
        }

        [Key]
        public int Id { get; set; }
        public Account? Sender { get; set; }
        public Account? Receiver { get; set; }
        public DateTime Date { get; set; }
        public string? Content { get; set; }
        public string? Joined { get; set; }
        public string? Filename { get; set; }
    }
}
