using Backend.Models.Interface;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models
{
    public class Bill : ICreatedAt
    {
        public Bill(string craftsmanName, string consumerName, string productName, int quantity, double priceTot)
        {
            CraftsmanName = craftsmanName;
            ConsumerName = consumerName;
            ProductName = productName;
            Quantity = quantity;
            PriceTot = priceTot;
        }

        [Key]
        public int Id { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime? CreatedAt { get; set; }
        public string CraftsmanName { get; set; }
        public string ConsumerName { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public double PriceTot { get; set; }
    }
}
