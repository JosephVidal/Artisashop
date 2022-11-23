namespace Artisashop.Models;

using System.ComponentModel.DataAnnotations;

public class ProductImage
{
    public int Id { get; set; }
    
    public int ProductId { get; set; }
    public virtual Product? Product { get; set; }

    /// <summary>
    /// The bytes of the image.
    /// TODO: Use minio or something else to store the image.
    /// </summary>
    public string? Content { get; set; }

    /// <summary>
    /// The name of the image
    /// </summary>
    public string? Name { get; set; }

    /// <summary>
    /// The file path of the image
    /// </summary>
    public string? ImagePath { get; set; }
}