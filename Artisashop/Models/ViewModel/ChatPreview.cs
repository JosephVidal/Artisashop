using Newtonsoft.Json;

namespace Artisashop.Models.ViewModel
{
    public class ChatPreview
    {
        public ChatPreview(Account user, ChatMessage lastMsg, bool receive, string url)
        {
            User = user;
            LastMsg = lastMsg;
            Receive = receive;
            Url = url;
        }

        [JsonProperty("user")]
        public Account User { get; set; }
        [JsonProperty("lastMsg")]
        public ChatMessage LastMsg { get; set; }
        [JsonProperty("receive")]
        public bool Receive { get; set; }
        [JsonProperty("url")]
        public string Url { get; set; }
    }
}
