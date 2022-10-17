using Newtonsoft.Json;

namespace Artisashop.Models.ViewModel
{
    public class ChatPreview
    {
        public ChatPreview(ChatMessage lastMsg, bool receive)
        {
            LastMsg = lastMsg;
            Receive = receive;
        }

        public ChatMessage LastMsg { get; set; }
        public bool Receive { get; set; }
    }
}
