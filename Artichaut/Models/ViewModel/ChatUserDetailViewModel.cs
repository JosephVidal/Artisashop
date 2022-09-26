using Newtonsoft.Json;

namespace Artichaut.Models.ViewModel
{
    public class ChatUserDetailViewModel
    {
        public ChatUserDetailViewModel(string connectionId, string userID, string username)
        {
            ConnectionId = connectionId;
            UserID = userID;
            Username = username;
        }

        [JsonProperty("connectionId")]
        public string ConnectionId { get; set; }
        [JsonProperty("userID")]
        public string UserID { get; set; }
        [JsonProperty("username")]
        public string Username { get; set; }
    }
}
