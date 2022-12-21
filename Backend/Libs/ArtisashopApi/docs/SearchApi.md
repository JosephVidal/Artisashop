# ArtisashopApi.Api.SearchApi

All URIs are relative to *http://localhost*

| Method | HTTP request | Description |
|--------|--------------|-------------|
| [**ApiSearchCraftsmanGet**](SearchApi.md#apisearchcraftsmanget) | **GET** /api/search/craftsman |  |
| [**ApiSearchProductGet**](SearchApi.md#apisearchproductget) | **GET** /api/search/product |  |

<a name="apisearchcraftsmanget"></a>
# **ApiSearchCraftsmanGet**
> List&lt;Account&gt; ApiSearchCraftsmanGet (string? firstName = null, string? lastName = null, string? job = null, int? userGPSCoordId = null, double? userGPSCoordLatitude = null, double? userGPSCoordLongitude = null, double? distance = null)



### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using ArtisashopApi.Api;
using ArtisashopApi.Client;
using ArtisashopApi.Model;

namespace Example
{
    public class ApiSearchCraftsmanGetExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "http://localhost";
            // Configure API key authorization: Bearer
            config.AddApiKey("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("Authorization", "Bearer");

            var apiInstance = new SearchApi(config);
            var firstName = "firstName_example";  // string? |  (optional) 
            var lastName = "lastName_example";  // string? |  (optional) 
            var job = "job_example";  // string? |  (optional) 
            var userGPSCoordId = 56;  // int? |  (optional) 
            var userGPSCoordLatitude = 1.2D;  // double? |  (optional) 
            var userGPSCoordLongitude = 1.2D;  // double? |  (optional) 
            var distance = 1.2D;  // double? |  (optional) 

            try
            {
                List<Account> result = apiInstance.ApiSearchCraftsmanGet(firstName, lastName, job, userGPSCoordId, userGPSCoordLatitude, userGPSCoordLongitude, distance);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling SearchApi.ApiSearchCraftsmanGet: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the ApiSearchCraftsmanGetWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    ApiResponse<List<Account>> response = apiInstance.ApiSearchCraftsmanGetWithHttpInfo(firstName, lastName, job, userGPSCoordId, userGPSCoordLatitude, userGPSCoordLongitude, distance);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling SearchApi.ApiSearchCraftsmanGetWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **firstName** | **string?** |  | [optional]  |
| **lastName** | **string?** |  | [optional]  |
| **job** | **string?** |  | [optional]  |
| **userGPSCoordId** | **int?** |  | [optional]  |
| **userGPSCoordLatitude** | **double?** |  | [optional]  |
| **userGPSCoordLongitude** | **double?** |  | [optional]  |
| **distance** | **double?** |  | [optional]  |

### Return type

[**List&lt;Account&gt;**](Account.md)

### Authorization

[Bearer](../README.md#Bearer)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **400** | Bad Request |  -  |
| **200** | Success |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="apisearchproductget"></a>
# **ApiSearchProductGet**
> List&lt;Product&gt; ApiSearchProductGet (string? name = null, string? job = null, List<string>? styles = null, int? userGPSCoordId = null, double? userGPSCoordLatitude = null, double? userGPSCoordLongitude = null, double? distance = null)



### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using ArtisashopApi.Api;
using ArtisashopApi.Client;
using ArtisashopApi.Model;

namespace Example
{
    public class ApiSearchProductGetExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "http://localhost";
            // Configure API key authorization: Bearer
            config.AddApiKey("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("Authorization", "Bearer");

            var apiInstance = new SearchApi(config);
            var name = "name_example";  // string? |  (optional) 
            var job = "job_example";  // string? |  (optional) 
            var styles = new List<string>?(); // List<string>? |  (optional) 
            var userGPSCoordId = 56;  // int? |  (optional) 
            var userGPSCoordLatitude = 1.2D;  // double? |  (optional) 
            var userGPSCoordLongitude = 1.2D;  // double? |  (optional) 
            var distance = 1.2D;  // double? |  (optional) 

            try
            {
                List<Product> result = apiInstance.ApiSearchProductGet(name, job, styles, userGPSCoordId, userGPSCoordLatitude, userGPSCoordLongitude, distance);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling SearchApi.ApiSearchProductGet: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the ApiSearchProductGetWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    ApiResponse<List<Product>> response = apiInstance.ApiSearchProductGetWithHttpInfo(name, job, styles, userGPSCoordId, userGPSCoordLatitude, userGPSCoordLongitude, distance);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling SearchApi.ApiSearchProductGetWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **name** | **string?** |  | [optional]  |
| **job** | **string?** |  | [optional]  |
| **styles** | [**List&lt;string&gt;?**](string.md) |  | [optional]  |
| **userGPSCoordId** | **int?** |  | [optional]  |
| **userGPSCoordLatitude** | **double?** |  | [optional]  |
| **userGPSCoordLongitude** | **double?** |  | [optional]  |
| **distance** | **double?** |  | [optional]  |

### Return type

[**List&lt;Product&gt;**](Product.md)

### Authorization

[Bearer](../README.md#Bearer)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **400** | Bad Request |  -  |
| **200** | Success |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

