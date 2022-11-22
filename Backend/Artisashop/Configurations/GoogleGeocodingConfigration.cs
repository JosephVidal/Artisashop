namespace Artisashop.Configurations;

using System.ComponentModel.DataAnnotations;

public class GoogleGeocodingConfigration
{
    [Required]
    public string ApiKey { get; set; } = null!;
}