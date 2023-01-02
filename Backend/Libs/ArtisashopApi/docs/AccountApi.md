# ArtisashopApi.Api.AccountApi

All URIs are relative to *http://localhost*

| Method | HTTP request | Description |
|--------|--------------|-------------|
| [**ApiAccountDelete**](AccountApi.md#apiaccountdelete) | **DELETE** /api/account |  |
| [**ApiAccountExternalLoginCallbackGet**](AccountApi.md#apiaccountexternallogincallbackget) | **GET** /api/account/external-login-callback |  |
| [**ApiAccountExternalLoginPost**](AccountApi.md#apiaccountexternalloginpost) | **POST** /api/account/external-login |  |
| [**ApiAccountGet**](AccountApi.md#apiaccountget) | **GET** /api/account |  |
| [**ApiAccountIdGet**](AccountApi.md#apiaccountidget) | **GET** /api/account/{id} |  |
| [**ApiAccountIdRoleRolePost**](AccountApi.md#apiaccountidrolerolepost) | **POST** /api/account/{id}/role/{role} |  |
| [**ApiAccountLoginPost**](AccountApi.md#apiaccountloginpost) | **POST** /api/account/login |  |
| [**ApiAccountPatch**](AccountApi.md#apiaccountpatch) | **PATCH** /api/account |  |
| [**ApiAccountPost**](AccountApi.md#apiaccountpost) | **POST** /api/account |  |

<a name="apiaccountdelete"></a>
# **ApiAccountDelete**
> string ApiAccountDelete ()



### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using ArtisashopApi.Api;
using ArtisashopApi.Client;
using ArtisashopApi.Model;

namespace Example
{
    public class ApiAccountDeleteExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "http://localhost";
            // Configure API key authorization: Bearer
            config.AddApiKey("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("Authorization", "Bearer");

            var apiInstance = new AccountApi(config);

            try
            {
                string result = apiInstance.ApiAccountDelete();
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling AccountApi.ApiAccountDelete: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the ApiAccountDeleteWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    ApiResponse<string> response = apiInstance.ApiAccountDeleteWithHttpInfo();
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling AccountApi.ApiAccountDeleteWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters
This endpoint does not need any parameter.
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
| **200** | Success |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="apiaccountexternallogincallbackget"></a>
# **ApiAccountExternalLoginCallbackGet**
> ExternalLoginConfirmationViewModel ApiAccountExternalLoginCallbackGet (string? returnUrl = null)



### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using ArtisashopApi.Api;
using ArtisashopApi.Client;
using ArtisashopApi.Model;

namespace Example
{
    public class ApiAccountExternalLoginCallbackGetExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "http://localhost";
            // Configure API key authorization: Bearer
            config.AddApiKey("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("Authorization", "Bearer");

            var apiInstance = new AccountApi(config);
            var returnUrl = "returnUrl_example";  // string? |  (optional) 

            try
            {
                ExternalLoginConfirmationViewModel result = apiInstance.ApiAccountExternalLoginCallbackGet(returnUrl);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling AccountApi.ApiAccountExternalLoginCallbackGet: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the ApiAccountExternalLoginCallbackGetWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    ApiResponse<ExternalLoginConfirmationViewModel> response = apiInstance.ApiAccountExternalLoginCallbackGetWithHttpInfo(returnUrl);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling AccountApi.ApiAccountExternalLoginCallbackGetWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **returnUrl** | **string?** |  | [optional]  |

### Return type

[**ExternalLoginConfirmationViewModel**](ExternalLoginConfirmationViewModel.md)

### Authorization

[Bearer](../README.md#Bearer)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Success |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="apiaccountexternalloginpost"></a>
# **ApiAccountExternalLoginPost**
> void ApiAccountExternalLoginPost (string? provider = null, string? returnUrl = null)



### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using ArtisashopApi.Api;
using ArtisashopApi.Client;
using ArtisashopApi.Model;

namespace Example
{
    public class ApiAccountExternalLoginPostExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "http://localhost";
            // Configure API key authorization: Bearer
            config.AddApiKey("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("Authorization", "Bearer");

            var apiInstance = new AccountApi(config);
            var provider = "provider_example";  // string? |  (optional) 
            var returnUrl = "returnUrl_example";  // string? |  (optional) 

            try
            {
                apiInstance.ApiAccountExternalLoginPost(provider, returnUrl);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling AccountApi.ApiAccountExternalLoginPost: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the ApiAccountExternalLoginPostWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    apiInstance.ApiAccountExternalLoginPostWithHttpInfo(provider, returnUrl);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling AccountApi.ApiAccountExternalLoginPostWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **provider** | **string?** |  | [optional]  |
| **returnUrl** | **string?** |  | [optional]  |

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

<a name="apiaccountget"></a>
# **ApiAccountGet**
> Account ApiAccountGet ()



### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using ArtisashopApi.Api;
using ArtisashopApi.Client;
using ArtisashopApi.Model;

namespace Example
{
    public class ApiAccountGetExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "http://localhost";
            // Configure API key authorization: Bearer
            config.AddApiKey("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("Authorization", "Bearer");

            var apiInstance = new AccountApi(config);

            try
            {
                Account result = apiInstance.ApiAccountGet();
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling AccountApi.ApiAccountGet: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the ApiAccountGetWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    ApiResponse<Account> response = apiInstance.ApiAccountGetWithHttpInfo();
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling AccountApi.ApiAccountGetWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters
This endpoint does not need any parameter.
### Return type

[**Account**](Account.md)

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

<a name="apiaccountidget"></a>
# **ApiAccountIdGet**
> GetAccountResult ApiAccountIdGet (string id)



### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using ArtisashopApi.Api;
using ArtisashopApi.Client;
using ArtisashopApi.Model;

namespace Example
{
    public class ApiAccountIdGetExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "http://localhost";
            // Configure API key authorization: Bearer
            config.AddApiKey("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("Authorization", "Bearer");

            var apiInstance = new AccountApi(config);
            var id = "id_example";  // string | 

            try
            {
                GetAccountResult result = apiInstance.ApiAccountIdGet(id);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling AccountApi.ApiAccountIdGet: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the ApiAccountIdGetWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    ApiResponse<GetAccountResult> response = apiInstance.ApiAccountIdGetWithHttpInfo(id);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling AccountApi.ApiAccountIdGetWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **id** | **string** |  |  |

### Return type

[**GetAccountResult**](GetAccountResult.md)

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

<a name="apiaccountidrolerolepost"></a>
# **ApiAccountIdRoleRolePost**
> GetAccountResult ApiAccountIdRoleRolePost (string id, string role, bool? isDeleted = null)



### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using ArtisashopApi.Api;
using ArtisashopApi.Client;
using ArtisashopApi.Model;

namespace Example
{
    public class ApiAccountIdRoleRolePostExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "http://localhost";
            // Configure API key authorization: Bearer
            config.AddApiKey("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("Authorization", "Bearer");

            var apiInstance = new AccountApi(config);
            var id = "id_example";  // string | 
            var role = "role_example";  // string | 
            var isDeleted = true;  // bool? |  (optional) 

            try
            {
                GetAccountResult result = apiInstance.ApiAccountIdRoleRolePost(id, role, isDeleted);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling AccountApi.ApiAccountIdRoleRolePost: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the ApiAccountIdRoleRolePostWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    ApiResponse<GetAccountResult> response = apiInstance.ApiAccountIdRoleRolePostWithHttpInfo(id, role, isDeleted);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling AccountApi.ApiAccountIdRoleRolePostWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **id** | **string** |  |  |
| **role** | **string** |  |  |
| **isDeleted** | **bool?** |  | [optional]  |

### Return type

[**GetAccountResult**](GetAccountResult.md)

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

<a name="apiaccountloginpost"></a>
# **ApiAccountLoginPost**
> AccountToken ApiAccountLoginPost (Login? login = null)



### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using ArtisashopApi.Api;
using ArtisashopApi.Client;
using ArtisashopApi.Model;

namespace Example
{
    public class ApiAccountLoginPostExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "http://localhost";
            // Configure API key authorization: Bearer
            config.AddApiKey("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("Authorization", "Bearer");

            var apiInstance = new AccountApi(config);
            var login = new Login?(); // Login? |  (optional) 

            try
            {
                AccountToken result = apiInstance.ApiAccountLoginPost(login);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling AccountApi.ApiAccountLoginPost: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the ApiAccountLoginPostWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    ApiResponse<AccountToken> response = apiInstance.ApiAccountLoginPostWithHttpInfo(login);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling AccountApi.ApiAccountLoginPostWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **login** | [**Login?**](Login?.md) |  | [optional]  |

### Return type

[**AccountToken**](AccountToken.md)

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

<a name="apiaccountpatch"></a>
# **ApiAccountPatch**
> Account ApiAccountPatch (UpdateAccount? updateAccount = null)



### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using ArtisashopApi.Api;
using ArtisashopApi.Client;
using ArtisashopApi.Model;

namespace Example
{
    public class ApiAccountPatchExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "http://localhost";
            // Configure API key authorization: Bearer
            config.AddApiKey("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("Authorization", "Bearer");

            var apiInstance = new AccountApi(config);
            var updateAccount = new UpdateAccount?(); // UpdateAccount? |  (optional) 

            try
            {
                Account result = apiInstance.ApiAccountPatch(updateAccount);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling AccountApi.ApiAccountPatch: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the ApiAccountPatchWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    ApiResponse<Account> response = apiInstance.ApiAccountPatchWithHttpInfo(updateAccount);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling AccountApi.ApiAccountPatchWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **updateAccount** | [**UpdateAccount?**](UpdateAccount?.md) |  | [optional]  |

### Return type

[**Account**](Account.md)

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

<a name="apiaccountpost"></a>
# **ApiAccountPost**
> AccountToken ApiAccountPost (Register? register = null)



### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using ArtisashopApi.Api;
using ArtisashopApi.Client;
using ArtisashopApi.Model;

namespace Example
{
    public class ApiAccountPostExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "http://localhost";
            // Configure API key authorization: Bearer
            config.AddApiKey("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("Authorization", "Bearer");

            var apiInstance = new AccountApi(config);
            var register = new Register?(); // Register? |  (optional) 

            try
            {
                AccountToken result = apiInstance.ApiAccountPost(register);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling AccountApi.ApiAccountPost: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the ApiAccountPostWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    ApiResponse<AccountToken> response = apiInstance.ApiAccountPostWithHttpInfo(register);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling AccountApi.ApiAccountPostWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **register** | [**Register?**](Register?.md) |  | [optional]  |

### Return type

[**AccountToken**](AccountToken.md)

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

