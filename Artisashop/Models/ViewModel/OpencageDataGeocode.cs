using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Artisashop.Models.ViewModel
{
    public class OpencageDataGeocode
    {
        public class RateInfo
        {
            [JsonProperty("limit")]
            [JsonPropertyName("limit")]
            public int Limit { get; set; }

            [JsonProperty("remaining")]
            [JsonPropertyName("remaining")]
            public int Remaining { get; set; }

            [JsonProperty("reset")]
            [JsonPropertyName("reset")]
            public int Reset { get; set; }
        }

        public class LicenseInfo
        {

            [JsonProperty("name")]
            [JsonPropertyName("name")]
            public int Name { get; set; }

            [JsonProperty("url")]
            [JsonPropertyName("url")]
            public int URL { get; set; }
        }

        public class SocialInfo
        {

            [JsonProperty("blog")]
            [JsonPropertyName("blog")]
            public string? Blog { get; set; }

            [JsonProperty("twitter")]
            [JsonPropertyName("twitter")]
            public string? Twitter { get; set; }
        }

        public class CreatedTimestampInfo
        {

            [JsonProperty("created_http")]
            [JsonPropertyName("created_http")]
            public string? CreatedHTTP { get; set; }

            [JsonProperty("created_unix")]
            [JsonPropertyName("created_unix")]
            public int CreatedUnix { get; set; }
        }

        public class ResultData
        {
            [JsonProperty("geometry")]
            [JsonPropertyName("geometry")]
            public GPSCoord? Geometry { get; set; }

            [JsonProperty("formatted")]
            [JsonPropertyName("formatted")]
            public string? Formatted { get; set; }

            [JsonProperty("confidence")]
            [JsonPropertyName("confidence")]
            public int Confidence { get; set; }
        }

        [JsonProperty("documentation")]
        [JsonPropertyName("documentation")]
        public string? Doc { get; set; }

        [JsonProperty("licenses")]
        [JsonPropertyName("licenses")]
        public List<LicenseInfo>? Licenses { get; set; }

        [JsonProperty("rate")]
        [JsonPropertyName("rate")]
        public RateInfo? Rate { get; set; }

        [JsonProperty("results")]
        [JsonPropertyName("results")]
        public List<ResultData>? Results { get; set; }

        [JsonProperty("total_results")]
        [JsonPropertyName("total_results")]
        public int TotalResults { get; set; }

        [JsonProperty("stay_informed")]
        [JsonPropertyName("stay_informed")]
        public SocialInfo? SocialLink { get; set; }

        [JsonProperty("thanks")]
        [JsonPropertyName("thanks")]
        public string? Thanks { get; set; }

        [JsonProperty("timestamp")]
        [JsonPropertyName("timestamp")]
        public CreatedTimestampInfo? CreatedTimestamp { get; set; }
    }
}
