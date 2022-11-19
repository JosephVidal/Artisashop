# SireneApi.Api.InformationsApi

All URIs are relative to *https://api.insee.fr/entreprises/sirene/V3*

| Method | HTTP request | Description |
|--------|--------------|-------------|
| [**Informations**](InformationsApi.md#informations) | **GET** /informations | État du service, dates de mise à jour et numéro de version |

<a name="informations"></a>
# **Informations**
> ReponseInformations Informations ()

État du service, dates de mise à jour et numéro de version

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using SireneApi.Api;
using SireneApi.Client;
using SireneApi.Model;

namespace Example
{
    public class InformationsExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://api.insee.fr/entreprises/sirene/V3";
            var apiInstance = new InformationsApi(config);

            try
            {
                // État du service, dates de mise à jour et numéro de version
                ReponseInformations result = apiInstance.Informations();
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling InformationsApi.Informations: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the InformationsWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // État du service, dates de mise à jour et numéro de version
    ApiResponse<ReponseInformations> response = apiInstance.InformationsWithHttpInfo();
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling InformationsApi.InformationsWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters
This endpoint does not need any parameter.
### Return type

[**ReponseInformations**](ReponseInformations.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | successful operation |  -  |
| **503** | Service indisponible |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

