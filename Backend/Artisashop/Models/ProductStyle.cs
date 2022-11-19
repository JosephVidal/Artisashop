namespace Artisashop.Models;

using Artisashop.Models.Interface;

public class ProductStyle : IIdentifiable
{
    public ProductStyle()
    {
    }

    public ProductStyle(int productId, int styleId)
    {
        ProductId = productId;
        StyleId = styleId;
    }

    public ProductStyle(Product product, Style style)
    {
        ProductId = product.Id;
        StyleId = style.Id;
    }

    public int Id { get; set; }

    public int ProductId { get; set; }
    public virtual Product? Product { get; set; }

    public int StyleId { get; set; }
    public virtual Style? Style { get; set; }
}