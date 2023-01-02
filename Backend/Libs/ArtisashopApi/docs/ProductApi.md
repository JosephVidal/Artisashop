# ArtisashopApi.Api.ProductApi

All URIs are relative to *http://localhost*

| Method | HTTP request | Description |
|--------|--------------|-------------|
| [**ApiProductCreatePost**](ProductApi.md#apiproductcreatepost) | **POST** /api/Product/create |  |
| [**ApiProductDeleteProductIdDelete**](ProductApi.md#apiproductdeleteproductiddelete) | **DELETE** /api/Product/delete/{productId} |  |
| [**ApiProductGet**](ProductApi.md#apiproductget) | **GET** /api/Product |  |
| [**ApiProductInfoProductIdGet**](ProductApi.md#apiproductinfoproductidget) | **GET** /api/Product/info/{productId} |  |
| [**ApiProductUpdateProductIdPatch**](ProductApi.md#apiproductupdateproductidpatch) | **PATCH** /api/Product/update/{productId} |  |

<a name="apiproductcreatepost"></a>
# **ApiProductCreatePost**
> Product ApiProductCreatePost (CreateProduct? createProduct = null)



### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using ArtisashopApi.Api;
using ArtisashopApi.Client;
using ArtisashopApi.Model;

namespace Example
{
    public class ApiProductCreatePostExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "http://localhost";
            // Configure API key authorization: Bearer
            config.AddApiKey("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("Authorization", "Bearer");

            var apiInstance = new ProductApi(config);
            var createProduct = new CreateProduct?(); // CreateProduct? |  (optional) 

            try
            {
                Product result = apiInstance.ApiProductCreatePost(createProduct);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling ProductApi.ApiProductCreatePost: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the ApiProductCreatePostWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    ApiResponse<Product> response = apiInstance.ApiProductCreatePostWithHttpInfo(createProduct);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling ProductApi.ApiProductCreatePostWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **createProduct** | [**CreateProduct?**](CreateProduct?.md) |  | [optional]  |

### Return type

[**Product**](Product.md)

### Authorization

[Bearer](../README.md#Bearer)

### HTTP request headers

 - **Content-Type**: application/json, text/json, application/*+json
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **400** | Bad Request |  -  |
| **200** | Success |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="apiproductdeleteproductiddelete"></a>
# **ApiProductDeleteProductIdDelete**
> string ApiProductDeleteProductIdDelete (int productId)



### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using ArtisashopApi.Api;
using ArtisashopApi.Client;
using ArtisashopApi.Model;

namespace Example
{
    public class ApiProductDeleteProductIdDeleteExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "http://localhost";
            // Configure API key authorization: Bearer
            config.AddApiKey("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("Authorization", "Bearer");

            var apiInstance = new ProductApi(config);
            var productId = 56;  // int | 

            try
            {
                string result = apiInstance.ApiProductDeleteProductIdDelete(productId);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling ProductApi.ApiProductDeleteProductIdDelete: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the ApiProductDeleteProductIdDeleteWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    ApiResponse<string> response = apiInstance.ApiProductDeleteProductIdDeleteWithHttpInfo(productId);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling ProductApi.ApiProductDeleteProductIdDeleteWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **productId** | **int** |  |  |

### Return type

**string**

### Authorization

[Bearer](../README.md#Bearer)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **400** | Bad Request |  -  |
| **404** | Not Found |  -  |
| **200** | Success |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="apiproductget"></a>
# **ApiProductGet**
> List&lt;Product&gt; ApiProductGet (string? sellerId = null)



### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using ArtisashopApi.Api;
using ArtisashopApi.Client;
using ArtisashopApi.Model;

namespace Example
{
    public class ApiProductGetExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "http://localhost";
            // Configure API key authorization: Bearer
            config.AddApiKey("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("Authorization", "Bearer");

            var apiInstance = new ProductApi(config);
            var sellerId = "sellerId_example";  // string? |  (optional) 

            try
            {
                List<Product> result = apiInstance.ApiProductGet(sellerId);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling ProductApi.ApiProductGet: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the ApiProductGetWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    ApiResponse<List<Product>> response = apiInstance.ApiProductGetWithHttpInfo(sellerId);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling ProductApi.ApiProductGetWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **sellerId** | **string?** |  | [optional]  |

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
| **404** | Not Found |  -  |
| **200** | Success |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="apiproductinfoproductidget"></a>
# **ApiProductInfoProductIdGet**
> Product ApiProductInfoProductIdGet (int productId)



### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using ArtisashopApi.Api;
using ArtisashopApi.Client;
using ArtisashopApi.Model;

namespace Example
{
    public class ApiProductInfoProductIdGetExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "http://localhost";
            // Configure API key authorization: Bearer
            config.AddApiKey("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("Authorization", "Bearer");

            var apiInstance = new ProductApi(config);
            var productId = 56;  // int | 

            try
            {
                Product result = apiInstance.ApiProductInfoProductIdGet(productId);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling ProductApi.ApiProductInfoProductIdGet: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the ApiProductInfoProductIdGetWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    ApiResponse<Product> response = apiInstance.ApiProductInfoProductIdGetWithHttpInfo(productId);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling ProductApi.ApiProductInfoProductIdGetWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **productId** | **int** |  |  |

### Return type

[**Product**](Product.md)

### Authorization

[Bearer](../README.md#Bearer)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **400** | Bad Request |  -  |
| **404** | Not Found |  -  |
| **200** | Success |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="apiproductupdateproductidpatch"></a>
# **ApiProductUpdateProductIdPatch**
> Product ApiProductUpdateProductIdPatch (int productId, CreateProduct? createProduct = null)



### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using ArtisashopApi.Api;
using ArtisashopApi.Client;
using ArtisashopApi.Model;

namespace Example
{
    public class ApiProductUpdateProductIdPatchExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "http://localhost";
            // Configure API key authorization: Bearer
            config.AddApiKey("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("Authorization", "Bearer");

            var apiInstance = new ProductApi(config);
            var productId = 56;  // int | 
            var createProduct = new CreateProduct?(); // CreateProduct? |  (optional) 

            try
            {
                Product result = apiInstance.ApiProductUpdateProductIdPatch(productId, createProduct);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling ProductApi.ApiProductUpdateProductIdPatch: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the ApiProductUpdateProductIdPatchWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    ApiResponse<Product> response = apiInstance.ApiProductUpdateProductIdPatchWithHttpInfo(productId, createProduct);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling ProductApi.ApiProductUpdateProductIdPatchWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **productId** | **int** |  |  |
| **createProduct** | [**CreateProduct?**](CreateProduct?.md) |  | [optional]  |

### Return type

[**Product**](Product.md)

### Authorization

[Bearer](../README.md#Bearer)

### HTTP request headers

 - **Content-Type**: application/json, text/json, application/*+json
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **400** | Bad Request |  -  |
| **404** | Not Found |  -  |
| **200** | Success |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

