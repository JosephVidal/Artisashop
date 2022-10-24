using static Artisashop.Models.Basket;
using System.ComponentModel.DataAnnotations;

namespace Artisashop.Models.ViewModel
{
    public class UpdateBasket
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int? Quantity { get; set; }
        [Required]
        public Basket.DeliveryOption? DeliveryOpt { get; set; }
        [Required]
        public Basket.State? CurrentState { get; set; }
    }
}
