using static Backend.Models.Basket;
using System.ComponentModel.DataAnnotations;

namespace Backend.Models.ViewModel
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
        public double? Price { get; set; }
        public string? Description { get; set; }
    }
}
