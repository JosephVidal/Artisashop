using System.ComponentModel.DataAnnotations;
using static Artisashop.Models.Basket;

namespace Artisashop.Models.ViewModel
{
    public class CreateBasket
    {
        [Key]
        public int Id { get; set; }
        [Key]
        public int ProductId { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public State CurrentState { get; set; }
    }
}
