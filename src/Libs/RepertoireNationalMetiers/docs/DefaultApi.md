# RepertoireNationalMetiersApi.Api.DefaultApi

All URIs are relative to *https://api-rnm.artisanat.fr*

| Method | HTTP request | Description |
|--------|--------------|-------------|
| [**V2EntreprisesSirenGet**](DefaultApi.md#v2entreprisessirenget) | **GET** /v2/entreprises/{siren} | Renvoi un fichier JSON des données de l&#39;entreprise en fournissant le SIREN |

<a name="v2entreprisessirenget"></a>
# **V2EntreprisesSirenGet**
> Entreprise V2EntreprisesSirenGet (string siren, string? format = null)

Renvoi un fichier JSON des données de l'entreprise en fournissant le SIREN

Get document whith selected format JSON/HTML/PDF (default is JSON)

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using RepertoireNationalMetiersApi.Api;
using RepertoireNationalMetiersApi.Client;
using RepertoireNationalMetiersApi.Model;

namespace Example
{
    public class V2EntreprisesSirenGetExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://api-rnm.artisanat.fr";
            var apiInstance = new DefaultApi(config);
            var siren = "siren_example";  // string | The enterprise siren
            var format = "json";  // string? | The document format (optional) 

            try
            {
                // Renvoi un fichier JSON des données de l'entreprise en fournissant le SIREN
                Entreprise result = apiInstance.V2EntreprisesSirenGet(siren, format);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling DefaultApi.V2EntreprisesSirenGet: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the V2EntreprisesSirenGetWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Renvoi un fichier JSON des données de l'entreprise en fournissant le SIREN
    ApiResponse<Entreprise> response = apiInstance.V2EntreprisesSirenGetWithHttpInfo(siren, format);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling DefaultApi.V2EntreprisesSirenGetWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **siren** | **string** | The enterprise siren |  |
| **format** | **string?** | The document format | [optional]  |

### Return type

[**Entreprise**](Entreprise.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json; charset=utf-8


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Retour OK |  -  |
| **400** | Bad request. Un siren doit comporter 9 caractères. |  -  |
| **404** | Le SIREN fournis est incorrect ou ne correspond pas à une entreprise artisanale |  -  |
| **5XX** | Unexpected error |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

