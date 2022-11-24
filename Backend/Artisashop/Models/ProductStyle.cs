namespace Artisashop.Models;

using System.ComponentModel.DataAnnotations;

public class ProductStyle
{
    public ProductStyle()
    {
    }

    public ProductStyle(string displayName)
    {
        DisplayName = displayName;
        NormalizedName = GetNormalizedName(displayName);
    }

    public int Id { get; set; }

    public int ProductId { get; set; }

    public virtual Product? Product { get; set; }

    public string NormalizedName { get; set; } = null!;

    // [Required]
    public string DisplayName { get; set; } = null!;

    /// <summary>
    /// Normalizes the name of the style.
    /// </summary>
    /// <param name="displayName"></param>
    /// <returns></returns>
    public static string GetNormalizedName(string displayName)
    {
        return displayName.ToLowerInvariant().Replace(" ", "-");
    }
}