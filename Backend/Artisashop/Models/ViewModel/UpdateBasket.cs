using System.ComponentModel.DataAnnotations;
using Artisashop.Models.Enums;
using static Artisashop.Models.BasketItem;

namespace Artisashop.Models.ViewModel
{
    public class UpdateBasket
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        public int? Quantity { get; set; }
        
        [Required]
        public DeliveryOption? DeliveryOpt { get; set; }
        
        [Required]
        public DeliveryState? CurrentState { get; set; }
    }
}
