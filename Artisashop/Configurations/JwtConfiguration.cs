namespace Artisashop.Configurations;

using System.ComponentModel.DataAnnotations;

public class JwtConfiguration
{
    [Required(ErrorMessage = "Audience required", AllowEmptyStrings = false)]
    public string Audience { get; set; } = "";

    [Required(ErrorMessage = "Issuer required", AllowEmptyStrings = false)]
    public string Issuer { get; set; } = "";

    [Required(ErrorMessage = "Key required", AllowEmptyStrings = false)]
    public string Key { get; set; } = "";
}