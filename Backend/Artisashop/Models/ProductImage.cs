using System.ComponentModel.DataAnnotations;
using Artisashop.Models.Interface;

namespace Artisashop.Models;

public class ProductImage : IIdentifiable, ICreatedAt
{
    public int Id { get; set; }

    public int ProductId { get; set; }
    public virtual Product? Product { get; set; }

    [Required] public string? Content { get; set; }

    public DateTime? CreatedAt { get; set; }
}