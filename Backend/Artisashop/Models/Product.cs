namespace Artisashop.Models;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;
using Artisashop.Models.ViewModel;
using Interface;

public class Product : IIdentifiable<int>, ICreatedAt, IUpdatedAt
{
    [Key] [Required] public int Id { get; set; }
    [Required] public string? Name { get; set; }
    [Required] public decimal? Price { get; set; }
    public string? Description { get; set; }
    [Required] public int Quantity { get; set; }
    [Required] public string? CraftsmanId { get; set; }
    [Required] public Account? Craftsman { get; set; }

    public virtual List<ProductImage>? Images { get; set; } = new List<ProductImage>();

    public virtual List<ProductStyle>? Styles { get; set; } = new List<ProductStyle>();

    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public DateTime? CreatedAt { get; set; }

    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public DateTime? UpdatedAt { get; set; }
}