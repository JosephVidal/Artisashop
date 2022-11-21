using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Artisashop.Models.Enum;

namespace Artisashop.Models
{
    public class Basket
    {
        public Basket()
        {
        }

        [Key]
        public int Id { get; set; }
        
        [Required]
        public string? AccountId { get; set; }
        
        [Required]
        public Account? Account { get; set; }
        
        [Required]
        public int ProductId { get; set; }
        
        [Required]
        public Product? Product { get; set; }
        
        [Required]
        public int Quantity { get; set; }
        
        [Required]
        public DeliveryOption DeliveryOpt { get; set; }
        
        [Required]
        public DeliveryState CurrentState { get; set; }

        public List<BasketPossibleState>? PossibleState { get; set; }

    }
}
