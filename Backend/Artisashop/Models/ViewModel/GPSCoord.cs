using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Artisashop.Models.ViewModel
{
    public class GPSCoord
    {
        public GPSCoord()
        {
            Longitude = 0;
            Latitude = 0;
        }

        public GPSCoord(double longitude, double latitude)
        {
            Longitude = longitude;
            Latitude = latitude;
        }


        [Key]
        [Newtonsoft.Json.JsonIgnore]
        [System.Text.Json.Serialization.JsonIgnore]
        public int Id { get; set; }

        [JsonProperty("lat")]
        [JsonPropertyName("lat")]
        public double Latitude { get; set; }

        [JsonProperty("lng")]
        [JsonPropertyName("lng")]
        public double Longitude { get; set; }
    }
}