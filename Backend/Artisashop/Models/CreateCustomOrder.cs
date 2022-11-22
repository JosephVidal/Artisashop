namespace Artisashop.Models.ViewModel;

using System.ComponentModel.DataAnnotations;

public class CreateCustomOrder
{
    [Required] public string CraftsmanId { get; set; } = null!;

    [Required] public string Name { get; set; } = null!;

    [Required] public string Description { get; set; } = null!;

    public List<string>? Images { get; set; }

    public List<string>? Styles { get; set; }

    public int Quantity { get; set; } = 1;

    public decimal? Price { get; set; }
}