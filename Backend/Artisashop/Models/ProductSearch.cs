namespace Artisashop.Models.ViewModel
{
    public class ProductSearch
    {
        public string? Name { get; set; }

        public string? Job { get; set; }

        public List<string>? Styles { get; set; }

        public List<int>? StyleIds { get; set; }

        public GpsCoordinates? UserGPSCoord { get; set; }

        public double? Distance { get; set; }
    }
}