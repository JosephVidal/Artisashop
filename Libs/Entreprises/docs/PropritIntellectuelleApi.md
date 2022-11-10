# EntreprisesApi.Api.PropritIntellectuelleApi

All URIs are relative to *https://entreprise.api.gouv.fr*

| Method | HTTP request | Description |
|--------|--------------|-------------|
| [**V3InpiUnitesLegalesSirenBrevetsGet**](PropritIntellectuelleApi.md#v3inpiuniteslegalessirenbrevetsget) | **GET** /v3/inpi/unites_legales/{siren}/brevets | Brevets déposés |
| [**V3InpiUnitesLegalesSirenMarquesGet**](PropritIntellectuelleApi.md#v3inpiuniteslegalessirenmarquesget) | **GET** /v3/inpi/unites_legales/{siren}/marques | Marques déposées |
| [**V3InpiUnitesLegalesSirenModelesGet**](PropritIntellectuelleApi.md#v3inpiuniteslegalessirenmodelesget) | **GET** /v3/inpi/unites_legales/{siren}/modeles | Modèles déposés |

<a name="v3inpiuniteslegalessirenbrevetsget"></a>
# **V3InpiUnitesLegalesSirenBrevetsGet**
> V3InpiUnitesLegalesSirenBrevetsGet200Response V3InpiUnitesLegalesSirenBrevetsGet (string context, string recipient, string _object, string siren, decimal? limit = null)

Brevets déposés

Nombre de brevets déposés par l'entreprise (lorsque le SIREN a été spécifié) et informations sur les brevets les plus récents. 

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using EntreprisesApi.Api;
using EntreprisesApi.Client;
using EntreprisesApi.Model;

namespace Example
{
    public class V3InpiUnitesLegalesSirenBrevetsGetExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://entreprise.api.gouv.fr";
            // Configure Bearer token for authorization: jwt_bearer_token
            config.AccessToken = "YOUR_BEARER_TOKEN";

            var apiInstance = new PropritIntellectuelleApi(config);
            var context = Context de test;  // string | \"**Cadre de la requête**  Par exemple : aides publiques, marchés publics ou gestion d’un référentiel tiers utilisé pour tel type d’application.\"
            var recipient = 13002526500013;  // string | \"**Bénéficiaire de l’appel**  SIRET de l’administration destinatrice des données.\"
            var _object = marché numéro 127;  // string | \"**La raison de l’appel ou l’identifiant de la procédure.**  L’identifiant peut être interne à votre organisation ou bien un numéro de marché publique, un nom de procédure ; l’essentiel est que celui-ci vous permette de tracer et de retrouver les informations relatives à l’appel. En effet, vous devez pouvoir justifier de la raison d’un appel auprès du fournisseur de données. Description courte ( < 50 caractères ).\"
            var siren = "siren_example";  // string | 
            var limit = 10;  // decimal? | Limite le nombre de résultats retournés. Valeur entre 1 et 20 (Défaut 5) (optional) 

            try
            {
                // Brevets déposés
                V3InpiUnitesLegalesSirenBrevetsGet200Response result = apiInstance.V3InpiUnitesLegalesSirenBrevetsGet(context, recipient, _object, siren, limit);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling PropritIntellectuelleApi.V3InpiUnitesLegalesSirenBrevetsGet: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the V3InpiUnitesLegalesSirenBrevetsGetWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Brevets déposés
    ApiResponse<V3InpiUnitesLegalesSirenBrevetsGet200Response> response = apiInstance.V3InpiUnitesLegalesSirenBrevetsGetWithHttpInfo(context, recipient, _object, siren, limit);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling PropritIntellectuelleApi.V3InpiUnitesLegalesSirenBrevetsGetWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **context** | **string** | \&quot;**Cadre de la requête**  Par exemple : aides publiques, marchés publics ou gestion d’un référentiel tiers utilisé pour tel type d’application.\&quot; |  |
| **recipient** | **string** | \&quot;**Bénéficiaire de l’appel**  SIRET de l’administration destinatrice des données.\&quot; |  |
| **_object** | **string** | \&quot;**La raison de l’appel ou l’identifiant de la procédure.**  L’identifiant peut être interne à votre organisation ou bien un numéro de marché publique, un nom de procédure ; l’essentiel est que celui-ci vous permette de tracer et de retrouver les informations relatives à l’appel. En effet, vous devez pouvoir justifier de la raison d’un appel auprès du fournisseur de données. Description courte ( &lt; 50 caractères ).\&quot; |  |
| **siren** | **string** |  |  |
| **limit** | **decimal?** | Limite le nombre de résultats retournés. Valeur entre 1 et 20 (Défaut 5) | [optional]  |

### Return type

[**V3InpiUnitesLegalesSirenBrevetsGet200Response**](V3InpiUnitesLegalesSirenBrevetsGet200Response.md)

### Authorization

[jwt_bearer_token](../README.md#jwt_bearer_token)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **401** | Non autorisé |  -  |
| **403** | Accès interdit |  -  |
| **200** | Brevets trouvés |  * RateLimit-Limit - La limite concernant l’endpoint appelé, soit le nombre de requête/minute. <br>  * RateLimit-Remaining - Le nombre d’appels restants durant la période courante d’une minute. <br>  * RateLimit-Reset - La fin de la période courante (en format timestamp) <br>  |
| **422** | Paramètre(s) invalide(s) |  -  |
| **404** | Brevets non trouvés |  -  |
| **502** | Erreur du fournisseur |  -  |
| **504** | Erreur d&#39;intermédiaire |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="v3inpiuniteslegalessirenmarquesget"></a>
# **V3InpiUnitesLegalesSirenMarquesGet**
> V3InpiUnitesLegalesSirenMarquesGet200Response V3InpiUnitesLegalesSirenMarquesGet (string context, string recipient, string _object, string siren, decimal? limit = null)

Marques déposées

Nombre de marques déposées par l'entreprise (lorsque le SIREN a été spécifié) et informations sur les marques les plus récentes. 

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using EntreprisesApi.Api;
using EntreprisesApi.Client;
using EntreprisesApi.Model;

namespace Example
{
    public class V3InpiUnitesLegalesSirenMarquesGetExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://entreprise.api.gouv.fr";
            // Configure Bearer token for authorization: jwt_bearer_token
            config.AccessToken = "YOUR_BEARER_TOKEN";

            var apiInstance = new PropritIntellectuelleApi(config);
            var context = Context de test;  // string | \"**Cadre de la requête**  Par exemple : aides publiques, marchés publics ou gestion d’un référentiel tiers utilisé pour tel type d’application.\"
            var recipient = 13002526500013;  // string | \"**Bénéficiaire de l’appel**  SIRET de l’administration destinatrice des données.\"
            var _object = marché numéro 127;  // string | \"**La raison de l’appel ou l’identifiant de la procédure.**  L’identifiant peut être interne à votre organisation ou bien un numéro de marché publique, un nom de procédure ; l’essentiel est que celui-ci vous permette de tracer et de retrouver les informations relatives à l’appel. En effet, vous devez pouvoir justifier de la raison d’un appel auprès du fournisseur de données. Description courte ( < 50 caractères ).\"
            var siren = "siren_example";  // string | 
            var limit = 10;  // decimal? | Limite le nombre de résultats retournés. Valeur entre 1 et 20 (Défaut 5) (optional) 

            try
            {
                // Marques déposées
                V3InpiUnitesLegalesSirenMarquesGet200Response result = apiInstance.V3InpiUnitesLegalesSirenMarquesGet(context, recipient, _object, siren, limit);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling PropritIntellectuelleApi.V3InpiUnitesLegalesSirenMarquesGet: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the V3InpiUnitesLegalesSirenMarquesGetWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Marques déposées
    ApiResponse<V3InpiUnitesLegalesSirenMarquesGet200Response> response = apiInstance.V3InpiUnitesLegalesSirenMarquesGetWithHttpInfo(context, recipient, _object, siren, limit);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling PropritIntellectuelleApi.V3InpiUnitesLegalesSirenMarquesGetWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **context** | **string** | \&quot;**Cadre de la requête**  Par exemple : aides publiques, marchés publics ou gestion d’un référentiel tiers utilisé pour tel type d’application.\&quot; |  |
| **recipient** | **string** | \&quot;**Bénéficiaire de l’appel**  SIRET de l’administration destinatrice des données.\&quot; |  |
| **_object** | **string** | \&quot;**La raison de l’appel ou l’identifiant de la procédure.**  L’identifiant peut être interne à votre organisation ou bien un numéro de marché publique, un nom de procédure ; l’essentiel est que celui-ci vous permette de tracer et de retrouver les informations relatives à l’appel. En effet, vous devez pouvoir justifier de la raison d’un appel auprès du fournisseur de données. Description courte ( &lt; 50 caractères ).\&quot; |  |
| **siren** | **string** |  |  |
| **limit** | **decimal?** | Limite le nombre de résultats retournés. Valeur entre 1 et 20 (Défaut 5) | [optional]  |

### Return type

[**V3InpiUnitesLegalesSirenMarquesGet200Response**](V3InpiUnitesLegalesSirenMarquesGet200Response.md)

### Authorization

[jwt_bearer_token](../README.md#jwt_bearer_token)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **401** | Non autorisé |  -  |
| **403** | Accès interdit |  -  |
| **200** | Marques trouvées |  * RateLimit-Limit - La limite concernant l’endpoint appelé, soit le nombre de requête/minute. <br>  * RateLimit-Remaining - Le nombre d’appels restants durant la période courante d’une minute. <br>  * RateLimit-Reset - La fin de la période courante (en format timestamp) <br>  |
| **422** | Paramètre(s) invalide(s) |  -  |
| **404** | Marques non trouvées |  -  |
| **502** | Erreur du fournisseur |  -  |
| **504** | Erreur d&#39;intermédiaire |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="v3inpiuniteslegalessirenmodelesget"></a>
# **V3InpiUnitesLegalesSirenModelesGet**
> V3InpiUnitesLegalesSirenModelesGet200Response V3InpiUnitesLegalesSirenModelesGet (string context, string recipient, string _object, string siren, decimal? limit = null)

Modèles déposés

Nombre de modèles déposés par l'entreprise (lorsque le SIREN a été spécifié) et informations sur les modèles les plus récents. 

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using EntreprisesApi.Api;
using EntreprisesApi.Client;
using EntreprisesApi.Model;

namespace Example
{
    public class V3InpiUnitesLegalesSirenModelesGetExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://entreprise.api.gouv.fr";
            // Configure Bearer token for authorization: jwt_bearer_token
            config.AccessToken = "YOUR_BEARER_TOKEN";

            var apiInstance = new PropritIntellectuelleApi(config);
            var context = Context de test;  // string | \"**Cadre de la requête**  Par exemple : aides publiques, marchés publics ou gestion d’un référentiel tiers utilisé pour tel type d’application.\"
            var recipient = 13002526500013;  // string | \"**Bénéficiaire de l’appel**  SIRET de l’administration destinatrice des données.\"
            var _object = marché numéro 127;  // string | \"**La raison de l’appel ou l’identifiant de la procédure.**  L’identifiant peut être interne à votre organisation ou bien un numéro de marché publique, un nom de procédure ; l’essentiel est que celui-ci vous permette de tracer et de retrouver les informations relatives à l’appel. En effet, vous devez pouvoir justifier de la raison d’un appel auprès du fournisseur de données. Description courte ( < 50 caractères ).\"
            var siren = "siren_example";  // string | 
            var limit = 10;  // decimal? | Limite le nombre de résultats retournés. Valeur entre 1 et 20 (Défaut 5) (optional) 

            try
            {
                // Modèles déposés
                V3InpiUnitesLegalesSirenModelesGet200Response result = apiInstance.V3InpiUnitesLegalesSirenModelesGet(context, recipient, _object, siren, limit);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling PropritIntellectuelleApi.V3InpiUnitesLegalesSirenModelesGet: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the V3InpiUnitesLegalesSirenModelesGetWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Modèles déposés
    ApiResponse<V3InpiUnitesLegalesSirenModelesGet200Response> response = apiInstance.V3InpiUnitesLegalesSirenModelesGetWithHttpInfo(context, recipient, _object, siren, limit);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling PropritIntellectuelleApi.V3InpiUnitesLegalesSirenModelesGetWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **context** | **string** | \&quot;**Cadre de la requête**  Par exemple : aides publiques, marchés publics ou gestion d’un référentiel tiers utilisé pour tel type d’application.\&quot; |  |
| **recipient** | **string** | \&quot;**Bénéficiaire de l’appel**  SIRET de l’administration destinatrice des données.\&quot; |  |
| **_object** | **string** | \&quot;**La raison de l’appel ou l’identifiant de la procédure.**  L’identifiant peut être interne à votre organisation ou bien un numéro de marché publique, un nom de procédure ; l’essentiel est que celui-ci vous permette de tracer et de retrouver les informations relatives à l’appel. En effet, vous devez pouvoir justifier de la raison d’un appel auprès du fournisseur de données. Description courte ( &lt; 50 caractères ).\&quot; |  |
| **siren** | **string** |  |  |
| **limit** | **decimal?** | Limite le nombre de résultats retournés. Valeur entre 1 et 20 (Défaut 5) | [optional]  |

### Return type

[**V3InpiUnitesLegalesSirenModelesGet200Response**](V3InpiUnitesLegalesSirenModelesGet200Response.md)

### Authorization

[jwt_bearer_token](../README.md#jwt_bearer_token)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **401** | Non autorisé |  -  |
| **403** | Accès interdit |  -  |
| **200** | Modèles trouvés |  * RateLimit-Limit - La limite concernant l’endpoint appelé, soit le nombre de requête/minute. <br>  * RateLimit-Remaining - Le nombre d’appels restants durant la période courante d’une minute. <br>  * RateLimit-Reset - La fin de la période courante (en format timestamp) <br>  |
| **422** | Paramètre(s) invalide(s) |  -  |
| **404** | Modèles non trouvés |  -  |
| **502** | Erreur du fournisseur |  -  |
| **504** | Erreur d&#39;intermédiaire |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

