namespace Artisashop.Models
{
    public class Billing
    {
        public Billing(double price, Account buyer, Product product, int sellerId, Account seller)
        {
            Date = DateTime.Now;
            Price = price;
            BuyerId = buyer.Id;
            Buyer = buyer;
            ProductId = product.Id;
            Product = product;
            SellerId = sellerId;
            Seller = seller;
        }

        public int Id { get; set; }
        public DateTime Date { get; set; }
        public double Price { get; set; }
        public string BuyerId { get; set; }
        public Account Buyer { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int SellerId { get; set; }
        public Account Seller { get; set; }
    }
}
