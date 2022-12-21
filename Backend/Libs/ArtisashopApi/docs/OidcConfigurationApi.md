# ArtisashopApi.Api.OidcConfigurationApi

All URIs are relative to *http://localhost*

| Method | HTTP request | Description |
|--------|--------------|-------------|
| [**ConfigurationClientIdGet**](OidcConfigurationApi.md#configurationclientidget) | **GET** /_configuration/{clientId} |  |

<a name="configurationclientidget"></a>
# **ConfigurationClientIdGet**
> void ConfigurationClientIdGet (string clientId)



### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using ArtisashopApi.Api;
using ArtisashopApi.Client;
using ArtisashopApi.Model;

namespace Example
{
    public class ConfigurationClientIdGetExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "http://localhost";
            // Configure API key authorization: Bearer
            config.AddApiKey("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("Authorization", "Bearer");

            var apiInstance = new OidcConfigurationApi(config);
            var clientId = "clientId_example";  // string | 

            try
            {
                apiInstance.ConfigurationClientIdGet(clientId);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling OidcConfigurationApi.ConfigurationClientIdGet: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the ConfigurationClientIdGetWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    apiInstance.ConfigurationClientIdGetWithHttpInfo(clientId);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling OidcConfigurationApi.ConfigurationClientIdGetWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **clientId** | **string** |  |  |

### Return type

void (empty response body)

### Authorization

[Bearer](../README.md#Bearer)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: Not defined


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Success |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

