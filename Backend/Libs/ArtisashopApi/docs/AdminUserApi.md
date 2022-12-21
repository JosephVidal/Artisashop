# ArtisashopApi.Api.AdminUserApi

All URIs are relative to *http://localhost*

| Method | HTTP request | Description |
|--------|--------------|-------------|
| [**ApiAdminUserGet**](AdminUserApi.md#apiadminuserget) | **GET** /api/admin/user |  |
| [**ApiAdminUserIdDelete**](AdminUserApi.md#apiadminuseriddelete) | **DELETE** /api/admin/user/{id} |  |
| [**ApiAdminUserIdGet**](AdminUserApi.md#apiadminuseridget) | **GET** /api/admin/user/{id} |  |
| [**ApiAdminUserIdPut**](AdminUserApi.md#apiadminuseridput) | **PUT** /api/admin/user/{id} |  |
| [**ApiAdminUserPost**](AdminUserApi.md#apiadminuserpost) | **POST** /api/admin/user |  |

<a name="apiadminuserget"></a>
# **ApiAdminUserGet**
> List&lt;Account&gt; ApiAdminUserGet (string? filter = null, string? range = null, string? sort = null)



### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using ArtisashopApi.Api;
using ArtisashopApi.Client;
using ArtisashopApi.Model;

namespace Example
{
    public class ApiAdminUserGetExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "http://localhost";
            // Configure API key authorization: Bearer
            config.AddApiKey("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("Authorization", "Bearer");

            var apiInstance = new AdminUserApi(config);
            var filter = "\"\"";  // string? |  (optional)  (default to "")
            var range = "\"\"";  // string? |  (optional)  (default to "")
            var sort = "\"\"";  // string? |  (optional)  (default to "")

            try
            {
                List<Account> result = apiInstance.ApiAdminUserGet(filter, range, sort);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling AdminUserApi.ApiAdminUserGet: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the ApiAdminUserGetWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    ApiResponse<List<Account>> response = apiInstance.ApiAdminUserGetWithHttpInfo(filter, range, sort);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling AdminUserApi.ApiAdminUserGetWithHttpInfo: " + e.Message);
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

[**List&lt;Account&gt;**](Account.md)

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

<a name="apiadminuseriddelete"></a>
# **ApiAdminUserIdDelete**
> Account ApiAdminUserIdDelete (string id)



### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using ArtisashopApi.Api;
using ArtisashopApi.Client;
using ArtisashopApi.Model;

namespace Example
{
    public class ApiAdminUserIdDeleteExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "http://localhost";
            // Configure API key authorization: Bearer
            config.AddApiKey("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("Authorization", "Bearer");

            var apiInstance = new AdminUserApi(config);
            var id = "id_example";  // string | 

            try
            {
                Account result = apiInstance.ApiAdminUserIdDelete(id);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling AdminUserApi.ApiAdminUserIdDelete: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the ApiAdminUserIdDeleteWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    ApiResponse<Account> response = apiInstance.ApiAdminUserIdDeleteWithHttpInfo(id);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling AdminUserApi.ApiAdminUserIdDeleteWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **id** | **string** |  |  |

### Return type

[**Account**](Account.md)

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

<a name="apiadminuseridget"></a>
# **ApiAdminUserIdGet**
> Account ApiAdminUserIdGet (string id)



### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using ArtisashopApi.Api;
using ArtisashopApi.Client;
using ArtisashopApi.Model;

namespace Example
{
    public class ApiAdminUserIdGetExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "http://localhost";
            // Configure API key authorization: Bearer
            config.AddApiKey("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("Authorization", "Bearer");

            var apiInstance = new AdminUserApi(config);
            var id = "id_example";  // string | 

            try
            {
                Account result = apiInstance.ApiAdminUserIdGet(id);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling AdminUserApi.ApiAdminUserIdGet: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the ApiAdminUserIdGetWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    ApiResponse<Account> response = apiInstance.ApiAdminUserIdGetWithHttpInfo(id);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling AdminUserApi.ApiAdminUserIdGetWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **id** | **string** |  |  |

### Return type

[**Account**](Account.md)

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

<a name="apiadminuseridput"></a>
# **ApiAdminUserIdPut**
> Account ApiAdminUserIdPut (string id, Account? account = null)



### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using ArtisashopApi.Api;
using ArtisashopApi.Client;
using ArtisashopApi.Model;

namespace Example
{
    public class ApiAdminUserIdPutExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "http://localhost";
            // Configure API key authorization: Bearer
            config.AddApiKey("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("Authorization", "Bearer");

            var apiInstance = new AdminUserApi(config);
            var id = "id_example";  // string | 
            var account = new Account?(); // Account? |  (optional) 

            try
            {
                Account result = apiInstance.ApiAdminUserIdPut(id, account);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling AdminUserApi.ApiAdminUserIdPut: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the ApiAdminUserIdPutWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    ApiResponse<Account> response = apiInstance.ApiAdminUserIdPutWithHttpInfo(id, account);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling AdminUserApi.ApiAdminUserIdPutWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **id** | **string** |  |  |
| **account** | [**Account?**](Account?.md) |  | [optional]  |

### Return type

[**Account**](Account.md)

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

<a name="apiadminuserpost"></a>
# **ApiAdminUserPost**
> Account ApiAdminUserPost (Account? account = null)



### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using ArtisashopApi.Api;
using ArtisashopApi.Client;
using ArtisashopApi.Model;

namespace Example
{
    public class ApiAdminUserPostExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "http://localhost";
            // Configure API key authorization: Bearer
            config.AddApiKey("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("Authorization", "Bearer");

            var apiInstance = new AdminUserApi(config);
            var account = new Account?(); // Account? |  (optional) 

            try
            {
                Account result = apiInstance.ApiAdminUserPost(account);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling AdminUserApi.ApiAdminUserPost: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the ApiAdminUserPostWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    ApiResponse<Account> response = apiInstance.ApiAdminUserPostWithHttpInfo(account);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling AdminUserApi.ApiAdminUserPostWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **account** | [**Account?**](Account?.md) |  | [optional]  |

### Return type

[**Account**](Account.md)

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

