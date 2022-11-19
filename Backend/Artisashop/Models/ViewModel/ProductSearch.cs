namespace Artisashop.Models.ViewModel
{
    public class ProductSearch
    {
        public string? Name { get; set; }
        public string? Job { get; set; }
        public List<string>? Styles { get; set; }
        public GPSCoord? UserGPSCoord { get; set; }
        public double? Distance { get; set; }
    }
}
