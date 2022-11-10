using Artisashop;

public class FranceConnectConfiguration
{
    public const string ProviderScheme = "oidc_FranceConnect";
    public const string ProviderDisplayName = "FranceConnect";
    public string ClientId { get; set; } = null!;
    public string ClientSecret { get; set; } = null!;
    public string CallbackPath { get; set; } = null!;
    public string SignedOutCallbackPath { get; set; } = null!;
    public string DataCallbackPath { get; set; } = null!;
    public string Issuer { get; set; } = null!;
    public string AuthorizationEndpoint { get; set; } = null!;
    public string TokenEndpoint { get; set; } = null!;
    public string UserInfoEndpoint { get; set; } = null!;
    public string EndSessionEndpoint { get; set; } = null!;
    private int _EIdasLevel;
    public int EIdasLevel
    {
        get => _EIdasLevel;

        //Valid if between 1 & 3, invalid (set to 1 instead) otherwise
        set => _EIdasLevel = value > 0 && value < 4 ? value : 1;
    }
    public List<string> Scopes { get; set; } = new List<string>();
    public List<DataProvider> DataProviders { get; set; } = new List<DataProvider>();
}

public class DataProvider
{
    public string Name { get; set; } = null!;
    public List<string> Scopes { get; set; } = new List<string>();
    public string Endpoint { get; set; } = null!;
}