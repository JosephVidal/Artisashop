using System.ComponentModel.DataAnnotations.Schema;

namespace Artisashop.Configurations;

using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;

public class JwtConfiguration
{
    [JsonPropertyName("Audience")]
    [Required(ErrorMessage = "Audience required", AllowEmptyStrings = false)]
    public string Audience { get; set; } = "";

    [JsonPropertyName("Issuer")]
    [Required(ErrorMessage = "Issuer required", AllowEmptyStrings = false)]
    public string Issuer { get; set; } = "";

    [JsonPropertyName("Key")]
    [Required(ErrorMessage = "Key required", AllowEmptyStrings = false)]
    public string Key { get; set; } = "";

    [JsonPropertyName("ExpireDays")]
    [Required(ErrorMessage = "Expiration required", AllowEmptyStrings = false)]
    public int Expiration { get; set; } = 0;
}