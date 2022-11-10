# EntreprisesApi.Api.InformationsFinanciresApi

All URIs are relative to *https://entreprise.api.gouv.fr*

| Method | HTTP request | Description |
|--------|--------------|-------------|
| [**V3DgfipEtablissementsSiretChiffresAffairesGet**](InformationsFinanciresApi.md#v3dgfipetablissementssiretchiffresaffairesget) | **GET** /v3/dgfip/etablissements/{siret}/chiffres_affaires | Chiffre d&#39;affaires |
| [**V3DgfipUnitesLegalesSirenLiassesFiscalesYearGet**](InformationsFinanciresApi.md#v3dgfipuniteslegalessirenliassesfiscalesyearget) | **GET** /v3/dgfip/unites_legales/{siren}/liasses_fiscales/{year} | Liasses fiscales |

<a name="v3dgfipetablissementssiretchiffresaffairesget"></a>
# **V3DgfipEtablissementsSiretChiffresAffairesGet**
> V3DgfipEtablissementsSiretChiffresAffairesGet200Response V3DgfipEtablissementsSiretChiffresAffairesGet (string context, string recipient, string _object, string siret)

Chiffre d'affaires

Déclarations de chiffre d’affaires, des trois derniers exercices, faites auprès de la Direction générale des finances publiques (DGFIP).

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using EntreprisesApi.Api;
using EntreprisesApi.Client;
using EntreprisesApi.Model;

namespace Example
{
    public class V3DgfipEtablissementsSiretChiffresAffairesGetExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://entreprise.api.gouv.fr";
            // Configure Bearer token for authorization: jwt_bearer_token
            config.AccessToken = "YOUR_BEARER_TOKEN";

            var apiInstance = new InformationsFinanciresApi(config);
            var context = Context de test;  // string | \"**Cadre de la requête**  Par exemple : aides publiques, marchés publics ou gestion d’un référentiel tiers utilisé pour tel type d’application.\"
            var recipient = 13002526500013;  // string | \"**Bénéficiaire de l’appel**  SIRET de l’administration destinatrice des données.\"
            var _object = marché numéro 127;  // string | \"**La raison de l’appel ou l’identifiant de la procédure.**  L’identifiant peut être interne à votre organisation ou bien un numéro de marché publique, un nom de procédure ; l’essentiel est que celui-ci vous permette de tracer et de retrouver les informations relatives à l’appel. En effet, vous devez pouvoir justifier de la raison d’un appel auprès du fournisseur de données. Description courte ( < 50 caractères ).\"
            var siret = 41816609600069;  // string | Siret de l'établissement

            try
            {
                // Chiffre d'affaires
                V3DgfipEtablissementsSiretChiffresAffairesGet200Response result = apiInstance.V3DgfipEtablissementsSiretChiffresAffairesGet(context, recipient, _object, siret);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling InformationsFinanciresApi.V3DgfipEtablissementsSiretChiffresAffairesGet: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the V3DgfipEtablissementsSiretChiffresAffairesGetWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Chiffre d'affaires
    ApiResponse<V3DgfipEtablissementsSiretChiffresAffairesGet200Response> response = apiInstance.V3DgfipEtablissementsSiretChiffresAffairesGetWithHttpInfo(context, recipient, _object, siret);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling InformationsFinanciresApi.V3DgfipEtablissementsSiretChiffresAffairesGetWithHttpInfo: " + e.Message);
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

### Return type

[**V3DgfipEtablissementsSiretChiffresAffairesGet200Response**](V3DgfipEtablissementsSiretChiffresAffairesGet200Response.md)

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
| **200** | Exercices trouvés |  * RateLimit-Limit - La limite concernant l’endpoint appelé, soit le nombre de requête/minute. <br>  * RateLimit-Remaining - Le nombre d’appels restants durant la période courante d’une minute. <br>  * RateLimit-Reset - La fin de la période courante (en format timestamp) <br>  |
| **404** | Non trouvée |  -  |
| **422** | Paramètre(s) invalide(s) |  -  |
| **502** | Erreur du fournisseur |  -  |
| **504** | Erreur d&#39;intermédiaire |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="v3dgfipuniteslegalessirenliassesfiscalesyearget"></a>
# **V3DgfipUnitesLegalesSirenLiassesFiscalesYearGet**
> V3DgfipUnitesLegalesSirenLiassesFiscalesYearGet200Response V3DgfipUnitesLegalesSirenLiassesFiscalesYearGet (string context, string recipient, string _object, string siren, int year)

Liasses fiscales

Informations renseignées dans les liasses fiscales, issues des déclarations de résultat d’une entreprise auprès de la Direction générale des finances publiques (DGFIP).

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using EntreprisesApi.Api;
using EntreprisesApi.Client;
using EntreprisesApi.Model;

namespace Example
{
    public class V3DgfipUnitesLegalesSirenLiassesFiscalesYearGetExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://entreprise.api.gouv.fr";
            // Configure Bearer token for authorization: jwt_bearer_token
            config.AccessToken = "YOUR_BEARER_TOKEN";

            var apiInstance = new InformationsFinanciresApi(config);
            var context = Context de test;  // string | \"**Cadre de la requête**  Par exemple : aides publiques, marchés publics ou gestion d’un référentiel tiers utilisé pour tel type d’application.\"
            var recipient = 13002526500013;  // string | \"**Bénéficiaire de l’appel**  SIRET de l’administration destinatrice des données.\"
            var _object = marché numéro 127;  // string | \"**La raison de l’appel ou l’identifiant de la procédure.**  L’identifiant peut être interne à votre organisation ou bien un numéro de marché publique, un nom de procédure ; l’essentiel est que celui-ci vous permette de tracer et de retrouver les informations relatives à l’appel. En effet, vous devez pouvoir justifier de la raison d’un appel auprès du fournisseur de données. Description courte ( < 50 caractères ).\"
            var siren = "siren_example";  // string | 
            var year = 56;  // int | 

            try
            {
                // Liasses fiscales
                V3DgfipUnitesLegalesSirenLiassesFiscalesYearGet200Response result = apiInstance.V3DgfipUnitesLegalesSirenLiassesFiscalesYearGet(context, recipient, _object, siren, year);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling InformationsFinanciresApi.V3DgfipUnitesLegalesSirenLiassesFiscalesYearGet: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the V3DgfipUnitesLegalesSirenLiassesFiscalesYearGetWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Liasses fiscales
    ApiResponse<V3DgfipUnitesLegalesSirenLiassesFiscalesYearGet200Response> response = apiInstance.V3DgfipUnitesLegalesSirenLiassesFiscalesYearGetWithHttpInfo(context, recipient, _object, siren, year);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling InformationsFinanciresApi.V3DgfipUnitesLegalesSirenLiassesFiscalesYearGetWithHttpInfo: " + e.Message);
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
| **year** | **int** |  |  |

### Return type

[**V3DgfipUnitesLegalesSirenLiassesFiscalesYearGet200Response**](V3DgfipUnitesLegalesSirenLiassesFiscalesYearGet200Response.md)

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
| **502** | Erreur du fournisseur |  -  |
| **504** | Erreur d&#39;intermédiaire |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

