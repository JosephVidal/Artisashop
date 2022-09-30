using static Artisashop.Models.Basket;
using System.ComponentModel.DataAnnotations.Schema;
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
        public DeliveryOption? DeliveryOpt { get; set; }
        [Required]
        public State? CurrentState { get; set; }
    }
}
