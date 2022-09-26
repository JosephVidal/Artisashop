using Newtonsoft.Json;

namespace Artichaut.Models.ViewModel
{
    public class ChatPreviewViewModel
    {
        public ChatPreviewViewModel(Account user, ChatMessage lastMsg, bool receive, string url)
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
