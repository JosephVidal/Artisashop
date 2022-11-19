# EntreprisesApi.Api.CertificationsProfessionnellesApi

All URIs are relative to *https://entreprise.api.gouv.fr*

| Method | HTTP request | Description |
|--------|--------------|-------------|
| [**V3AdemeEtablissementsSiretCertificationRgeGet**](CertificationsProfessionnellesApi.md#v3ademeetablissementssiretcertificationrgeget) | **GET** /v3/ademe/etablissements/{siret}/certification_rge | Certification RGE |
| [**V3OpqibiUnitesLegalesSirenCertificationIngenierieGet**](CertificationsProfessionnellesApi.md#v3opqibiuniteslegalessirencertificationingenierieget) | **GET** /v3/opqibi/unites_legales/{siren}/certification_ingenierie | Certification d&#39;ingénierie OPQIBI |
| [**V3QualibatEtablissementsSiretCertificationBatimentGet**](CertificationsProfessionnellesApi.md#v3qualibatetablissementssiretcertificationbatimentget) | **GET** /v3/qualibat/etablissements/{siret}/certification_batiment | Certification Qualibat |

<a name="v3ademeetablissementssiretcertificationrgeget"></a>
# **V3AdemeEtablissementsSiretCertificationRgeGet**
> V3AdemeEtablissementsSiretCertificationRgeGet200Response V3AdemeEtablissementsSiretCertificationRgeGet (string context, string recipient, string _object, string siret, decimal? limit = null)

Certification RGE

Certifications RGE (Reconnu Garant de l'Environnement), d'un établissement, délivrée par l'Ademe.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using EntreprisesApi.Api;
using EntreprisesApi.Client;
using EntreprisesApi.Model;

namespace Example
{
    public class V3AdemeEtablissementsSiretCertificationRgeGetExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://entreprise.api.gouv.fr";
            // Configure Bearer token for authorization: jwt_bearer_token
            config.AccessToken = "YOUR_BEARER_TOKEN";

            var apiInstance = new CertificationsProfessionnellesApi(config);
            var context = Context de test;  // string | \"**Cadre de la requête**  Par exemple : aides publiques, marchés publics ou gestion d’un référentiel tiers utilisé pour tel type d’application.\"
            var recipient = 13002526500013;  // string | \"**Bénéficiaire de l’appel**  SIRET de l’administration destinatrice des données.\"
            var _object = marché numéro 127;  // string | \"**La raison de l’appel ou l’identifiant de la procédure.**  L’identifiant peut être interne à votre organisation ou bien un numéro de marché publique, un nom de procédure ; l’essentiel est que celui-ci vous permette de tracer et de retrouver les informations relatives à l’appel. En effet, vous devez pouvoir justifier de la raison d’un appel auprès du fournisseur de données. Description courte ( < 50 caractères ).\"
            var siret = 41816609600069;  // string | Siret de l'établissement
            var limit = 100;  // decimal? | Limite le nombre de résultats retournés. Valeur entre 1 et 1000 (Défault 1000) (optional) 

            try
            {
                // Certification RGE
                V3AdemeEtablissementsSiretCertificationRgeGet200Response result = apiInstance.V3AdemeEtablissementsSiretCertificationRgeGet(context, recipient, _object, siret, limit);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling CertificationsProfessionnellesApi.V3AdemeEtablissementsSiretCertificationRgeGet: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the V3AdemeEtablissementsSiretCertificationRgeGetWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Certification RGE
    ApiResponse<V3AdemeEtablissementsSiretCertificationRgeGet200Response> response = apiInstance.V3AdemeEtablissementsSiretCertificationRgeGetWithHttpInfo(context, recipient, _object, siret, limit);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling CertificationsProfessionnellesApi.V3AdemeEtablissementsSiretCertificationRgeGetWithHttpInfo: " + e.Message);
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
| **siret** | **string** | Siret de l&#39;établissement |  |
| **limit** | **decimal?** | Limite le nombre de résultats retournés. Valeur entre 1 et 1000 (Défault 1000) | [optional]  |

### Return type

[**V3AdemeEtablissementsSiretCertificationRgeGet200Response**](V3AdemeEtablissementsSiretCertificationRgeGet200Response.md)

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
| **200** | Entreprise trouvée |  * RateLimit-Limit - La limite concernant l’endpoint appelé, soit le nombre de requête/minute. <br>  * RateLimit-Remaining - Le nombre d’appels restants durant la période courante d’une minute. <br>  * RateLimit-Reset - La fin de la période courante (en format timestamp) <br>  |
| **422** | Paramètre(s) invalide(s) |  -  |
| **404** | Non trouvée |  -  |
| **502** | Erreur du fournisseur |  -  |
| **504** | Erreur d&#39;intermédiaire |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="v3opqibiuniteslegalessirencertificationingenierieget"></a>
# **V3OpqibiUnitesLegalesSirenCertificationIngenierieGet**
> V3OpqibiUnitesLegalesSirenCertificationIngenierieGet200Response V3OpqibiUnitesLegalesSirenCertificationIngenierieGet (string context, string recipient, string _object, string siren)

Certification d'ingénierie OPQIBI

Certification délivrée par l'association OPQIBI, attestant des différentes qualifications d'ingénierie d'une unité légale. 

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using EntreprisesApi.Api;
using EntreprisesApi.Client;
using EntreprisesApi.Model;

namespace Example
{
    public class V3OpqibiUnitesLegalesSirenCertificationIngenierieGetExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://entreprise.api.gouv.fr";
            // Configure Bearer token for authorization: jwt_bearer_token
            config.AccessToken = "YOUR_BEARER_TOKEN";

            var apiInstance = new CertificationsProfessionnellesApi(config);
            var context = Context de test;  // string | \"**Cadre de la requête**  Par exemple : aides publiques, marchés publics ou gestion d’un référentiel tiers utilisé pour tel type d’application.\"
            var recipient = 13002526500013;  // string | \"**Bénéficiaire de l’appel**  SIRET de l’administration destinatrice des données.\"
            var _object = marché numéro 127;  // string | \"**La raison de l’appel ou l’identifiant de la procédure.**  L’identifiant peut être interne à votre organisation ou bien un numéro de marché publique, un nom de procédure ; l’essentiel est que celui-ci vous permette de tracer et de retrouver les informations relatives à l’appel. En effet, vous devez pouvoir justifier de la raison d’un appel auprès du fournisseur de données. Description courte ( < 50 caractères ).\"
            var siren = "siren_example";  // string | 

            try
            {
                // Certification d'ingénierie OPQIBI
                V3OpqibiUnitesLegalesSirenCertificationIngenierieGet200Response result = apiInstance.V3OpqibiUnitesLegalesSirenCertificationIngenierieGet(context, recipient, _object, siren);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling CertificationsProfessionnellesApi.V3OpqibiUnitesLegalesSirenCertificationIngenierieGet: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the V3OpqibiUnitesLegalesSirenCertificationIngenierieGetWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Certification d'ingénierie OPQIBI
    ApiResponse<V3OpqibiUnitesLegalesSirenCertificationIngenierieGet200Response> response = apiInstance.V3OpqibiUnitesLegalesSirenCertificationIngenierieGetWithHttpInfo(context, recipient, _object, siren);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling CertificationsProfessionnellesApi.V3OpqibiUnitesLegalesSirenCertificationIngenierieGetWithHttpInfo: " + e.Message);
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

### Return type

[**V3OpqibiUnitesLegalesSirenCertificationIngenierieGet200Response**](V3OpqibiUnitesLegalesSirenCertificationIngenierieGet200Response.md)

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
| **200** | Entreprise trouvée |  * RateLimit-Limit - La limite concernant l’endpoint appelé, soit le nombre de requête/minute. <br>  * RateLimit-Remaining - Le nombre d’appels restants durant la période courante d’une minute. <br>  * RateLimit-Reset - La fin de la période courante (en format timestamp) <br>  |
| **422** | Paramètre(s) invalide(s) |  -  |
| **404** | Non trouvée |  -  |
| **502** | Erreur du fournisseur |  -  |
| **504** | Erreur d&#39;intermédiaire |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="v3qualibatetablissementssiretcertificationbatimentget"></a>
# **V3QualibatEtablissementsSiretCertificationBatimentGet**
> V3QualibatEtablissementsSiretCertificationBatimentGet200Response V3QualibatEtablissementsSiretCertificationBatimentGet (string siret, string context, string recipient, string _object)

Certification Qualibat

Certification délivrée par l'association Qualibat, attestant de la qualification d’une entreprise dans le bâtiment.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using EntreprisesApi.Api;
using EntreprisesApi.Client;
using EntreprisesApi.Model;

namespace Example
{
    public class V3QualibatEtablissementsSiretCertificationBatimentGetExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://entreprise.api.gouv.fr";
            // Configure Bearer token for authorization: jwt_bearer_token
            config.AccessToken = "YOUR_BEARER_TOKEN";

            var apiInstance = new CertificationsProfessionnellesApi(config);
            var siret = 41816609600069;  // string | Siret de l'établissement
            var context = Context de test;  // string | \"**Cadre de la requête**  Par exemple : aides publiques, marchés publics ou gestion d’un référentiel tiers utilisé pour tel type d’application.\"
            var recipient = 13002526500013;  // string | \"**Bénéficiaire de l’appel**  SIRET de l’administration destinatrice des données.\"
            var _object = marché numéro 127;  // string | \"**La raison de l’appel ou l’identifiant de la procédure.**  L’identifiant peut être interne à votre organisation ou bien un numéro de marché publique, un nom de procédure ; l’essentiel est que celui-ci vous permette de tracer et de retrouver les informations relatives à l’appel. En effet, vous devez pouvoir justifier de la raison d’un appel auprès du fournisseur de données. Description courte ( < 50 caractères ).\"

            try
            {
                // Certification Qualibat
                V3QualibatEtablissementsSiretCertificationBatimentGet200Response result = apiInstance.V3QualibatEtablissementsSiretCertificationBatimentGet(siret, context, recipient, _object);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling CertificationsProfessionnellesApi.V3QualibatEtablissementsSiretCertificationBatimentGet: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the V3QualibatEtablissementsSiretCertificationBatimentGetWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Certification Qualibat
    ApiResponse<V3QualibatEtablissementsSiretCertificationBatimentGet200Response> response = apiInstance.V3QualibatEtablissementsSiretCertificationBatimentGetWithHttpInfo(siret, context, recipient, _object);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling CertificationsProfessionnellesApi.V3QualibatEtablissementsSiretCertificationBatimentGetWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **siret** | **string** | Siret de l&#39;établissement |  |
| **context** | **string** | \&quot;**Cadre de la requête**  Par exemple : aides publiques, marchés publics ou gestion d’un référentiel tiers utilisé pour tel type d’application.\&quot; |  |
| **recipient** | **string** | \&quot;**Bénéficiaire de l’appel**  SIRET de l’administration destinatrice des données.\&quot; |  |
| **_object** | **string** | \&quot;**La raison de l’appel ou l’identifiant de la procédure.**  L’identifiant peut être interne à votre organisation ou bien un numéro de marché publique, un nom de procédure ; l’essentiel est que celui-ci vous permette de tracer et de retrouver les informations relatives à l’appel. En effet, vous devez pouvoir justifier de la raison d’un appel auprès du fournisseur de données. Description courte ( &lt; 50 caractères ).\&quot; |  |

### Return type

[**V3QualibatEtablissementsSiretCertificationBatimentGet200Response**](V3QualibatEtablissementsSiretCertificationBatimentGet200Response.md)

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
| **200** | Certification trouvée |  * RateLimit-Limit - La limite concernant l’endpoint appelé, soit le nombre de requête/minute. <br>  * RateLimit-Remaining - Le nombre d’appels restants durant la période courante d’une minute. <br>  * RateLimit-Reset - La fin de la période courante (en format timestamp) <br>  |
| **422** | Paramètre(s) invalide(s) |  -  |
| **502** | Erreur du fournisseur |  -  |
| **404** | Certification non trouvée |  -  |
| **504** | Erreur d&#39;intermédiaire |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

