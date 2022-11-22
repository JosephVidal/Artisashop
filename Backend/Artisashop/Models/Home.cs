namespace Artisashop.Models.ViewModel;

using Artisashop.Models;

public class Home
{
    public Home()
    {
        CraftsmanSample = new();
        ProductSample = new();
    }

    public int CraftsmanNumber { get; set; }
    public int ProductNumber { get; set; }
    public List<Artisashop.Models.Account> CraftsmanSample { get; set; }
    public List<Product> ProductSample { get; set; }
    public int Inscrit { get; set; }
    public int Sales { get; set; }
}
