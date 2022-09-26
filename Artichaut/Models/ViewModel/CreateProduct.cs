using System.ComponentModel.DataAnnotations;

namespace Artichaut.Models.ViewModel
{
    public class CreateProduct
    {
        public CreateProduct()
        {
            Images = new List<string>();
            Styles = new List<string>();
        }

        [Required]
        public string? Name { get; set; }
        [Required]
        public string? Description { get; set; }
        [Required]
        public double Price { get; set; }
        [Required]
        public int Quantity { get; set; }
        public List<string> Images { get; set; }
        public List<string> Styles { get; set; }
    }
}
