namespace Backend.Models.ViewModel
{
    public class Home
    {
        public Home()
        {
            CraftsmanSample = new();
            ProductSample = new();
        }

        public int CraftsmanNumber { get; set; }
        public int ProductNumber { get; set; }
        public List<Account> CraftsmanSample { get; set; }
        public List<Product> ProductSample { get; set; }
        public int Inscrit { get; set; }
    }
}
