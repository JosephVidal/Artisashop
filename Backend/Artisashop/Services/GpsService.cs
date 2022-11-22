namespace Artisashop.Services;

using System.Net.Http.Headers;
using Configurations;
using Models.ViewModel;
using Newtonsoft.Json;

public interface IGpsService
{
    Task<GpsCoordinates?> GetGPSFromAddressAsync(string address);
}

public class GpsService : IGpsService
{
    private readonly GoogleGeocodingConfigration _googleGeocodingConfigration;
    private readonly HttpClient _httpClient;


    public GpsService(GoogleGeocodingConfigration googleGeocodingConfigration)
    {
        _googleGeocodingConfigration = googleGeocodingConfigration;
        _httpClient = new HttpClient();
        _httpClient.BaseAddress = new Uri("https://api.opencagedata.com/");
        _httpClient.DefaultRequestHeaders.Accept.Clear();
        _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
    }
    
    public async Task<GpsCoordinates?> GetGPSFromAddressAsync(string address)
    {
        var response = await _httpClient.GetAsync($"geocode/v1/json?q={address}&key={_googleGeocodingConfigration.ApiKey}");
        var content = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<GpsCoordinates>(content);
    }

}