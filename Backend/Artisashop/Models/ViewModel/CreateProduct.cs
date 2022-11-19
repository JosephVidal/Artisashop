using System.ComponentModel.DataAnnotations;

namespace Artisashop.Models.ViewModel
{
    public class CreateProduct
    {
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? Description { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public int Quantity { get; set; }

        public List<string> Images { get; set; } = new List<string>();
        public List<Style> Styles { get; set; } = new List<Style>();
    }
}
