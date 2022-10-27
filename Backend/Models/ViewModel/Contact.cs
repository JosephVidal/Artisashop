using System.ComponentModel.DataAnnotations;

namespace Backend.Models.ViewModel
{
    public class Contact
    {
        public Contact()
        {
            ReceiverList = new List<string> {
                "Client",
                "Sales"
            };
        }

        [Required]
        public string? Subject { get; set; }
        [Required]
        public string? Email { get; set; }
        [Required]
        public string? Content { get; set; }
        [Required]
        public string? Receiver { get; set; }
        public readonly List<string> ReceiverList;
    }
}
