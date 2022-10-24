using static Artisashop.Models.Basket;
using System.ComponentModel.DataAnnotations;

namespace Artisashop.Models.ViewModel
{
    public class UpdateCustomOrder
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int? Quantity { get; set; }
        [Required]
        public Basket.DeliveryOption? DeliveryOpt { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public double? Price { get; set; }
        public string? Description { get; set; }
    }
}
