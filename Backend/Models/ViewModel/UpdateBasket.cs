using static Backend.Models.Basket;
using System.ComponentModel.DataAnnotations;

namespace Backend.Models.ViewModel
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
