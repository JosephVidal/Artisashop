namespace Artichaut.Models.ViewModel
{
    public class ContactViewModel
    {
        public ContactViewModel()
        {
            ReceiverList = new List<string> {
                "Client",
                "Sales"
            };
        }

        public string? Subject { get; set; }
        public string? Email { get; set; }
        public string? Content { get; set; }
        public string? Receiver { get; set; }
        public readonly List<string> ReceiverList;
    }
}
