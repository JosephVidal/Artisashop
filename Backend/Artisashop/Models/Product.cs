using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;
using Artisashop.Models.ViewModel;

namespace Artisashop.Models
{
    public class Product
    {
        public Product()
        {
        }

        public Product(CreateProduct product, Account craftsman)
        {
            Name = product.Name;
            Price = product.Price;
            Description = product.Description;
            Quantity = product.Quantity;
            CraftsmanId = craftsman.Id;
            Craftsman = craftsman;
            Images = product.Images.Select(x => new ProductImage()
            {
                Content = x,
            }).ToList();
        }

        [Key] [Required] public int Id { get; set; }
        [Required] public string? Name { get; set; }
        [Required] public decimal? Price { get; set; }
        public string? Description { get; set; }
        [Required] public int Quantity { get; set; }
        [Required] public string? CraftsmanId { get; set; }
        [Required] public Account? Craftsman { get; set; }
        public List<ProductImage>? Images { get; set; }
        public virtual List<ProductStyle>? Styles { get; set; }
    }
}