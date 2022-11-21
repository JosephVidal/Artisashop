using System.ComponentModel.DataAnnotations;
using Artisashop.Models.Enums;
using static Artisashop.Models.BasketItem;

namespace Artisashop.Models.ViewModel
{
    public class UpdateCustomOrder
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        public int? Quantity { get; set; }
        
        [Required]
        public DeliveryOption? DeliveryOpt { get; set; }
        
        [Required]
        public string? Name { get; set; }
        
        [Required]
        public decimal? Price { get; set; }
        
        public string? Description { get; set; }
    }
}
