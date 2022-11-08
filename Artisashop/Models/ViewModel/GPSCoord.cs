namespace Artisashop.Models.ViewModel
{
    public class GPSCoord
    {
        public GPSCoord()
        {
            Longitude = 0;
            Latitude = 0;
        }
        public GPSCoord(double longitude, double latitude)
        {
            Longitude = longitude;
            Latitude = latitude;
        }

        public double Longitude { get; set; }
        public double Latitude { get; set; }
    }
}
