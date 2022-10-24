using System.ComponentModel.DataAnnotations;

namespace Backend.Models.ViewModel
{
    public class CreateCustomOrder
    {
        public CreateCustomOrder(string craftsmanId, string name, string desc, int quantity)
        {
            CraftsmanId = craftsmanId;
            Name = name;
            Desc = desc;
            Quantity = quantity;
        }

        [Required]
        public string CraftsmanId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Desc { get; set; }
        [Required]
        public int Quantity { get; set; }

    }
}
