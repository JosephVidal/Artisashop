﻿using Newtonsoft.Json;

namespace Artisashop.Models.ViewModel
{
    public class ChatUserDetail
    {
        public ChatUserDetail(string connectionId, string userID, string username)
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
