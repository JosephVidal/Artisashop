namespace Artisashop.Models;

using Artisashop.Models.Interface;

public class ProductStyle : IIdentifiable
{
    public int Id { get; set; }

    public int ProductId { get; set; }
    public virtual Product? Product { get; set; }

    public int StyleId { get; set; }
    public virtual Style? Style { get; set; }
}