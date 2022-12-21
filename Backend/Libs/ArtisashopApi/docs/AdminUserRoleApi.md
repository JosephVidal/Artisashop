# ArtisashopApi.Api.AdminUserRoleApi

All URIs are relative to *http://localhost*

| Method | HTTP request | Description |
|--------|--------------|-------------|
| [**ApiAdminUserRoleGet**](AdminUserRoleApi.md#apiadminuserroleget) | **GET** /api/admin/userRole |  |
| [**ApiAdminUserRoleIdDelete**](AdminUserRoleApi.md#apiadminuserroleiddelete) | **DELETE** /api/admin/userRole/{id} |  |
| [**ApiAdminUserRoleIdGet**](AdminUserRoleApi.md#apiadminuserroleidget) | **GET** /api/admin/userRole/{id} |  |
| [**ApiAdminUserRoleIdPut**](AdminUserRoleApi.md#apiadminuserroleidput) | **PUT** /api/admin/userRole/{id} |  |
| [**ApiAdminUserRolePost**](AdminUserRoleApi.md#apiadminuserrolepost) | **POST** /api/admin/userRole |  |

<a name="apiadminuserroleget"></a>
# **ApiAdminUserRoleGet**
> List&lt;StringIdentityUserRole&gt; ApiAdminUserRoleGet (string? filter = null, string? range = null, string? sort = null)



### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using ArtisashopApi.Api;
using ArtisashopApi.Client;
using ArtisashopApi.Model;

namespace Example
{
    public class ApiAdminUserRoleGetExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "http://localhost";
            // Configure API key authorization: Bearer
            config.AddApiKey("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("Authorization", "Bearer");

            var apiInstance = new AdminUserRoleApi(config);
            var filter = "\"\"";  // string? |  (optional)  (default to "")
            var range = "\"\"";  // string? |  (optional)  (default to "")
            var sort = "\"\"";  // string? |  (optional)  (default to "")

            try
            {
                List<StringIdentityUserRole> result = apiInstance.ApiAdminUserRoleGet(filter, range, sort);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling AdminUserRoleApi.ApiAdminUserRoleGet: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the ApiAdminUserRoleGetWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    ApiResponse<List<StringIdentityUserRole>> response = apiInstance.ApiAdminUserRoleGetWithHttpInfo(filter, range, sort);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling AdminUserRoleApi.ApiAdminUserRoleGetWithHttpInfo: " + e.Message);
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

[**List&lt;StringIdentityUserRole&gt;**](StringIdentityUserRole.md)

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

<a name="apiadminuserroleiddelete"></a>
# **ApiAdminUserRoleIdDelete**
> StringIdentityUserRole ApiAdminUserRoleIdDelete (int id)



### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using ArtisashopApi.Api;
using ArtisashopApi.Client;
using ArtisashopApi.Model;

namespace Example
{
    public class ApiAdminUserRoleIdDeleteExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "http://localhost";
            // Configure API key authorization: Bearer
            config.AddApiKey("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("Authorization", "Bearer");

            var apiInstance = new AdminUserRoleApi(config);
            var id = 56;  // int | 

            try
            {
                StringIdentityUserRole result = apiInstance.ApiAdminUserRoleIdDelete(id);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling AdminUserRoleApi.ApiAdminUserRoleIdDelete: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the ApiAdminUserRoleIdDeleteWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    ApiResponse<StringIdentityUserRole> response = apiInstance.ApiAdminUserRoleIdDeleteWithHttpInfo(id);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling AdminUserRoleApi.ApiAdminUserRoleIdDeleteWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **id** | **int** |  |  |

### Return type

[**StringIdentityUserRole**](StringIdentityUserRole.md)

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

<a name="apiadminuserroleidget"></a>
# **ApiAdminUserRoleIdGet**
> StringIdentityUserRole ApiAdminUserRoleIdGet (int id)



### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using ArtisashopApi.Api;
using ArtisashopApi.Client;
using ArtisashopApi.Model;

namespace Example
{
    public class ApiAdminUserRoleIdGetExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "http://localhost";
            // Configure API key authorization: Bearer
            config.AddApiKey("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("Authorization", "Bearer");

            var apiInstance = new AdminUserRoleApi(config);
            var id = 56;  // int | 

            try
            {
                StringIdentityUserRole result = apiInstance.ApiAdminUserRoleIdGet(id);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling AdminUserRoleApi.ApiAdminUserRoleIdGet: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the ApiAdminUserRoleIdGetWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    ApiResponse<StringIdentityUserRole> response = apiInstance.ApiAdminUserRoleIdGetWithHttpInfo(id);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling AdminUserRoleApi.ApiAdminUserRoleIdGetWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **id** | **int** |  |  |

### Return type

[**StringIdentityUserRole**](StringIdentityUserRole.md)

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

<a name="apiadminuserroleidput"></a>
# **ApiAdminUserRoleIdPut**
> StringIdentityUserRole ApiAdminUserRoleIdPut (int id, StringIdentityUserRole? stringIdentityUserRole = null)



### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using ArtisashopApi.Api;
using ArtisashopApi.Client;
using ArtisashopApi.Model;

namespace Example
{
    public class ApiAdminUserRoleIdPutExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "http://localhost";
            // Configure API key authorization: Bearer
            config.AddApiKey("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("Authorization", "Bearer");

            var apiInstance = new AdminUserRoleApi(config);
            var id = 56;  // int | 
            var stringIdentityUserRole = new StringIdentityUserRole?(); // StringIdentityUserRole? |  (optional) 

            try
            {
                StringIdentityUserRole result = apiInstance.ApiAdminUserRoleIdPut(id, stringIdentityUserRole);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling AdminUserRoleApi.ApiAdminUserRoleIdPut: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the ApiAdminUserRoleIdPutWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    ApiResponse<StringIdentityUserRole> response = apiInstance.ApiAdminUserRoleIdPutWithHttpInfo(id, stringIdentityUserRole);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling AdminUserRoleApi.ApiAdminUserRoleIdPutWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **id** | **int** |  |  |
| **stringIdentityUserRole** | [**StringIdentityUserRole?**](StringIdentityUserRole?.md) |  | [optional]  |

### Return type

[**StringIdentityUserRole**](StringIdentityUserRole.md)

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

<a name="apiadminuserrolepost"></a>
# **ApiAdminUserRolePost**
> StringIdentityUserRole ApiAdminUserRolePost (StringIdentityUserRole? stringIdentityUserRole = null)



### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using ArtisashopApi.Api;
using ArtisashopApi.Client;
using ArtisashopApi.Model;

namespace Example
{
    public class ApiAdminUserRolePostExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "http://localhost";
            // Configure API key authorization: Bearer
            config.AddApiKey("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("Authorization", "Bearer");

            var apiInstance = new AdminUserRoleApi(config);
            var stringIdentityUserRole = new StringIdentityUserRole?(); // StringIdentityUserRole? |  (optional) 

            try
            {
                StringIdentityUserRole result = apiInstance.ApiAdminUserRolePost(stringIdentityUserRole);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling AdminUserRoleApi.ApiAdminUserRolePost: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the ApiAdminUserRolePostWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    ApiResponse<StringIdentityUserRole> response = apiInstance.ApiAdminUserRolePostWithHttpInfo(stringIdentityUserRole);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling AdminUserRoleApi.ApiAdminUserRolePostWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **stringIdentityUserRole** | [**StringIdentityUserRole?**](StringIdentityUserRole?.md) |  | [optional]  |

### Return type

[**StringIdentityUserRole**](StringIdentityUserRole.md)

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

