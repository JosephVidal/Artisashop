# ArtisashopApi.Api.AdminProductImageApi

All URIs are relative to *http://localhost*

| Method | HTTP request | Description |
|--------|--------------|-------------|
| [**ApiAdminProductImageGet**](AdminProductImageApi.md#apiadminproductimageget) | **GET** /api/admin/productImage |  |
| [**ApiAdminProductImageIdDelete**](AdminProductImageApi.md#apiadminproductimageiddelete) | **DELETE** /api/admin/productImage/{id} |  |
| [**ApiAdminProductImageIdGet**](AdminProductImageApi.md#apiadminproductimageidget) | **GET** /api/admin/productImage/{id} |  |
| [**ApiAdminProductImageIdPut**](AdminProductImageApi.md#apiadminproductimageidput) | **PUT** /api/admin/productImage/{id} |  |
| [**ApiAdminProductImagePost**](AdminProductImageApi.md#apiadminproductimagepost) | **POST** /api/admin/productImage |  |

<a name="apiadminproductimageget"></a>
# **ApiAdminProductImageGet**
> List&lt;ProductImage&gt; ApiAdminProductImageGet (string? filter = null, string? range = null, string? sort = null)



### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using ArtisashopApi.Api;
using ArtisashopApi.Client;
using ArtisashopApi.Model;

namespace Example
{
    public class ApiAdminProductImageGetExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "http://localhost";
            // Configure API key authorization: Bearer
            config.AddApiKey("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("Authorization", "Bearer");

            var apiInstance = new AdminProductImageApi(config);
            var filter = "\"\"";  // string? |  (optional)  (default to "")
            var range = "\"\"";  // string? |  (optional)  (default to "")
            var sort = "\"\"";  // string? |  (optional)  (default to "")

            try
            {
                List<ProductImage> result = apiInstance.ApiAdminProductImageGet(filter, range, sort);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling AdminProductImageApi.ApiAdminProductImageGet: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the ApiAdminProductImageGetWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    ApiResponse<List<ProductImage>> response = apiInstance.ApiAdminProductImageGetWithHttpInfo(filter, range, sort);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling AdminProductImageApi.ApiAdminProductImageGetWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **filter** | **string?** |  | [optional] [default to &quot;&quot;] |
| **range** | **string?** |  | [optional] [default to &quot;&quot;] |
| **sort** | **string?** |  | [optional] [default to &quot;&quot;] |

### Return type

[**List&lt;ProductImage&gt;**](ProductImage.md)

### Authorization

[Bearer](../README.md#Bearer)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: text/plain, application/json, text/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Success |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="apiadminproductimageiddelete"></a>
# **ApiAdminProductImageIdDelete**
> ProductImage ApiAdminProductImageIdDelete (int id)



### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using ArtisashopApi.Api;
using ArtisashopApi.Client;
using ArtisashopApi.Model;

namespace Example
{
    public class ApiAdminProductImageIdDeleteExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "http://localhost";
            // Configure API key authorization: Bearer
            config.AddApiKey("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("Authorization", "Bearer");

            var apiInstance = new AdminProductImageApi(config);
            var id = 56;  // int | 

            try
            {
                ProductImage result = apiInstance.ApiAdminProductImageIdDelete(id);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling AdminProductImageApi.ApiAdminProductImageIdDelete: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the ApiAdminProductImageIdDeleteWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    ApiResponse<ProductImage> response = apiInstance.ApiAdminProductImageIdDeleteWithHttpInfo(id);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling AdminProductImageApi.ApiAdminProductImageIdDeleteWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **id** | **int** |  |  |

### Return type

[**ProductImage**](ProductImage.md)

### Authorization

[Bearer](../README.md#Bearer)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: text/plain, application/json, text/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Success |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="apiadminproductimageidget"></a>
# **ApiAdminProductImageIdGet**
> ProductImage ApiAdminProductImageIdGet (int id)



### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using ArtisashopApi.Api;
using ArtisashopApi.Client;
using ArtisashopApi.Model;

namespace Example
{
    public class ApiAdminProductImageIdGetExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "http://localhost";
            // Configure API key authorization: Bearer
            config.AddApiKey("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("Authorization", "Bearer");

            var apiInstance = new AdminProductImageApi(config);
            var id = 56;  // int | 

            try
            {
                ProductImage result = apiInstance.ApiAdminProductImageIdGet(id);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling AdminProductImageApi.ApiAdminProductImageIdGet: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the ApiAdminProductImageIdGetWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    ApiResponse<ProductImage> response = apiInstance.ApiAdminProductImageIdGetWithHttpInfo(id);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling AdminProductImageApi.ApiAdminProductImageIdGetWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **id** | **int** |  |  |

### Return type

[**ProductImage**](ProductImage.md)

### Authorization

[Bearer](../README.md#Bearer)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: text/plain, application/json, text/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Success |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="apiadminproductimageidput"></a>
# **ApiAdminProductImageIdPut**
> ProductImage ApiAdminProductImageIdPut (int id, ProductImage? productImage = null)



### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using ArtisashopApi.Api;
using ArtisashopApi.Client;
using ArtisashopApi.Model;

namespace Example
{
    public class ApiAdminProductImageIdPutExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "http://localhost";
            // Configure API key authorization: Bearer
            config.AddApiKey("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("Authorization", "Bearer");

            var apiInstance = new AdminProductImageApi(config);
            var id = 56;  // int | 
            var productImage = new ProductImage?(); // ProductImage? |  (optional) 

            try
            {
                ProductImage result = apiInstance.ApiAdminProductImageIdPut(id, productImage);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling AdminProductImageApi.ApiAdminProductImageIdPut: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the ApiAdminProductImageIdPutWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    ApiResponse<ProductImage> response = apiInstance.ApiAdminProductImageIdPutWithHttpInfo(id, productImage);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling AdminProductImageApi.ApiAdminProductImageIdPutWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **id** | **int** |  |  |
| **productImage** | [**ProductImage?**](ProductImage?.md) |  | [optional]  |

### Return type

[**ProductImage**](ProductImage.md)

### Authorization

[Bearer](../README.md#Bearer)

### HTTP request headers

 - **Content-Type**: application/json, text/json, application/*+json
 - **Accept**: text/plain, application/json, text/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Success |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="apiadminproductimagepost"></a>
# **ApiAdminProductImagePost**
> ProductImage ApiAdminProductImagePost (ProductImage? productImage = null)



### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using ArtisashopApi.Api;
using ArtisashopApi.Client;
using ArtisashopApi.Model;

namespace Example
{
    public class ApiAdminProductImagePostExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "http://localhost";
            // Configure API key authorization: Bearer
            config.AddApiKey("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("Authorization", "Bearer");

            var apiInstance = new AdminProductImageApi(config);
            var productImage = new ProductImage?(); // ProductImage? |  (optional) 

            try
            {
                ProductImage result = apiInstance.ApiAdminProductImagePost(productImage);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling AdminProductImageApi.ApiAdminProductImagePost: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the ApiAdminProductImagePostWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    ApiResponse<ProductImage> response = apiInstance.ApiAdminProductImagePostWithHttpInfo(productImage);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling AdminProductImageApi.ApiAdminProductImagePostWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **productImage** | [**ProductImage?**](ProductImage?.md) |  | [optional]  |

### Return type

[**ProductImage**](ProductImage.md)

### Authorization

[Bearer](../README.md#Bearer)

### HTTP request headers

 - **Content-Type**: application/json, text/json, application/*+json
 - **Accept**: text/plain, application/json, text/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Success |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

