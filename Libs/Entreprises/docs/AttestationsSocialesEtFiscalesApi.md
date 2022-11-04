# EntreprisesApi.Api.AttestationsSocialesEtFiscalesApi

All URIs are relative to *https://entreprise.api.gouv.fr*

| Method | HTTP request | Description |
|--------|--------------|-------------|
| [**V3CnetpUnitesLegalesSirenAttestationCotisationsCongesPayesChomageIntemperiesGet**](AttestationsSocialesEtFiscalesApi.md#v3cnetpuniteslegalessirenattestationcotisationscongespayeschomageintemperiesget) | **GET** /v3/cnetp/unites_legales/{siren}/attestation_cotisations_conges_payes_chomage_intemperies | Attestation de cotisations congés payés &amp; chômage-intempéries |
| [**V3DgfipUnitesLegalesSirenAttestationFiscaleGet**](AttestationsSocialesEtFiscalesApi.md#v3dgfipuniteslegalessirenattestationfiscaleget) | **GET** /v3/dgfip/unites_legales/{siren}/attestation_fiscale | Attestation fiscale |
| [**V3FntpUnitesLegalesSirenCarteProfessionnelleTravauxPublicsGet**](AttestationsSocialesEtFiscalesApi.md#v3fntpuniteslegalessirencarteprofessionnelletravauxpublicsget) | **GET** /v3/fntp/unites_legales/{siren}/carte_professionnelle_travaux_publics | Carte professionnelle travaux publics |
| [**V3MsaEtablissementsSiretConformiteCotisationsGet**](AttestationsSocialesEtFiscalesApi.md#v3msaetablissementssiretconformitecotisationsget) | **GET** /v3/msa/etablissements/{siret}/conformite_cotisations | Conformité cotisations de sécurité sociale agricole |
| [**V3ProbtpEtablissementsSiretAttestationCotisationsRetraiteGet**](AttestationsSocialesEtFiscalesApi.md#v3probtpetablissementssiretattestationcotisationsretraiteget) | **GET** /v3/probtp/etablissements/{siret}/attestation_cotisations_retraite | Conformité cotisations retraite bâtiment |
| [**V3ProbtpEtablissementsSiretConformiteCotisationsRetraiteGet**](AttestationsSocialesEtFiscalesApi.md#v3probtpetablissementssiretconformitecotisationsretraiteget) | **GET** /v3/probtp/etablissements/{siret}/conformite_cotisations_retraite | Conformités des cotisations retraites |
| [**V3UrssafUnitesLegalesSirenAttestationVigilanceGet**](AttestationsSocialesEtFiscalesApi.md#v3urssafuniteslegalessirenattestationvigilanceget) | **GET** /v3/urssaf/unites_legales/{siren}/attestation_vigilance | Attestation de vigilance |

<a name="v3cnetpuniteslegalessirenattestationcotisationscongespayeschomageintemperiesget"></a>
# **V3CnetpUnitesLegalesSirenAttestationCotisationsCongesPayesChomageIntemperiesGet**
> V3CnetpUnitesLegalesSirenAttestationCotisationsCongesPayesChomageIntemperiesGet200Response V3CnetpUnitesLegalesSirenAttestationCotisationsCongesPayesChomageIntemperiesGet (string context, string recipient, string _object, string siren)

Attestation de cotisations congés payés & chômage-intempéries

Attestation de cotisations, délivrée par la Caisse nationale des entrepreneurs de travaux publics (CNETP), attestant le respect des obligations relatives aux congés payés et au chômage-intempéries.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using EntreprisesApi.Api;
using EntreprisesApi.Client;
using EntreprisesApi.Model;

namespace Example
{
    public class V3CnetpUnitesLegalesSirenAttestationCotisationsCongesPayesChomageIntemperiesGetExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://entreprise.api.gouv.fr";
            // Configure Bearer token for authorization: jwt_bearer_token
            config.AccessToken = "YOUR_BEARER_TOKEN";

            var apiInstance = new AttestationsSocialesEtFiscalesApi(config);
            var context = Context de test;  // string | \"**Cadre de la requête**  Par exemple : aides publiques, marchés publics ou gestion d’un référentiel tiers utilisé pour tel type d’application.\"
            var recipient = 13002526500013;  // string | \"**Bénéficiaire de l’appel**  SIRET de l’administration destinatrice des données.\"
            var _object = marché numéro 127;  // string | \"**La raison de l’appel ou l’identifiant de la procédure.**  L’identifiant peut être interne à votre organisation ou bien un numéro de marché publique, un nom de procédure ; l’essentiel est que celui-ci vous permette de tracer et de retrouver les informations relatives à l’appel. En effet, vous devez pouvoir justifier de la raison d’un appel auprès du fournisseur de données. Description courte ( < 50 caractères ).\"
            var siren = "siren_example";  // string | 

            try
            {
                // Attestation de cotisations congés payés & chômage-intempéries
                V3CnetpUnitesLegalesSirenAttestationCotisationsCongesPayesChomageIntemperiesGet200Response result = apiInstance.V3CnetpUnitesLegalesSirenAttestationCotisationsCongesPayesChomageIntemperiesGet(context, recipient, _object, siren);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling AttestationsSocialesEtFiscalesApi.V3CnetpUnitesLegalesSirenAttestationCotisationsCongesPayesChomageIntemperiesGet: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the V3CnetpUnitesLegalesSirenAttestationCotisationsCongesPayesChomageIntemperiesGetWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Attestation de cotisations congés payés & chômage-intempéries
    ApiResponse<V3CnetpUnitesLegalesSirenAttestationCotisationsCongesPayesChomageIntemperiesGet200Response> response = apiInstance.V3CnetpUnitesLegalesSirenAttestationCotisationsCongesPayesChomageIntemperiesGetWithHttpInfo(context, recipient, _object, siren);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling AttestationsSocialesEtFiscalesApi.V3CnetpUnitesLegalesSirenAttestationCotisationsCongesPayesChomageIntemperiesGetWithHttpInfo: " + e.Message);
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

[**V3CnetpUnitesLegalesSirenAttestationCotisationsCongesPayesChomageIntemperiesGet200Response**](V3CnetpUnitesLegalesSirenAttestationCotisationsCongesPayesChomageIntemperiesGet200Response.md)

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
| **200** | Certificat trouvé |  * RateLimit-Limit - La limite concernant l’endpoint appelé, soit le nombre de requête/minute. <br>  * RateLimit-Remaining - Le nombre d’appels restants durant la période courante d’une minute. <br>  * RateLimit-Reset - La fin de la période courante (en format timestamp) <br>  |
| **422** | Paramètre(s) invalide(s) |  -  |
| **502** | Erreur du fournisseur |  -  |
| **404** | Non trouvé |  -  |
| **504** | Erreur d&#39;intermédiaire |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="v3dgfipuniteslegalessirenattestationfiscaleget"></a>
# **V3DgfipUnitesLegalesSirenAttestationFiscaleGet**
> V3DgfipUnitesLegalesSirenAttestationFiscaleGet200Response V3DgfipUnitesLegalesSirenAttestationFiscaleGet (string siren, string context, string recipient, string _object, string? cacheControl = null)

Attestation fiscale

Attestation fiscale délivrée par la Direction générale des finances publiques (DGFIP), indiquant que l’entreprise est à jour de ses obligations fiscales.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using EntreprisesApi.Api;
using EntreprisesApi.Client;
using EntreprisesApi.Model;

namespace Example
{
    public class V3DgfipUnitesLegalesSirenAttestationFiscaleGetExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://entreprise.api.gouv.fr";
            // Configure Bearer token for authorization: jwt_bearer_token
            config.AccessToken = "YOUR_BEARER_TOKEN";

            var apiInstance = new AttestationsSocialesEtFiscalesApi(config);
            var siren = 418166096;  // string | Siren de l'entreprise
            var context = Context de test;  // string | \"**Cadre de la requête**  Par exemple : aides publiques, marchés publics ou gestion d’un référentiel tiers utilisé pour tel type d’application.\"
            var recipient = 13002526500013;  // string | \"**Bénéficiaire de l’appel**  SIRET de l’administration destinatrice des données.\"
            var _object = marché numéro 127;  // string | \"**La raison de l’appel ou l’identifiant de la procédure.**  L’identifiant peut être interne à votre organisation ou bien un numéro de marché publique, un nom de procédure ; l’essentiel est que celui-ci vous permette de tracer et de retrouver les informations relatives à l’appel. En effet, vous devez pouvoir justifier de la raison d’un appel auprès du fournisseur de données. Description courte ( < 50 caractères ).\"
            var cacheControl = "cacheControl_example";  // string? | Si cette valeur est fixée à \"no-cache\", le système de cache est alors ignoré et la donnée est directement récupérée depuis le fournisseur de données. (optional) 

            try
            {
                // Attestation fiscale
                V3DgfipUnitesLegalesSirenAttestationFiscaleGet200Response result = apiInstance.V3DgfipUnitesLegalesSirenAttestationFiscaleGet(siren, context, recipient, _object, cacheControl);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling AttestationsSocialesEtFiscalesApi.V3DgfipUnitesLegalesSirenAttestationFiscaleGet: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the V3DgfipUnitesLegalesSirenAttestationFiscaleGetWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Attestation fiscale
    ApiResponse<V3DgfipUnitesLegalesSirenAttestationFiscaleGet200Response> response = apiInstance.V3DgfipUnitesLegalesSirenAttestationFiscaleGetWithHttpInfo(siren, context, recipient, _object, cacheControl);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling AttestationsSocialesEtFiscalesApi.V3DgfipUnitesLegalesSirenAttestationFiscaleGetWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **siren** | **string** | Siren de l&#39;entreprise |  |
| **context** | **string** | \&quot;**Cadre de la requête**  Par exemple : aides publiques, marchés publics ou gestion d’un référentiel tiers utilisé pour tel type d’application.\&quot; |  |
| **recipient** | **string** | \&quot;**Bénéficiaire de l’appel**  SIRET de l’administration destinatrice des données.\&quot; |  |
| **_object** | **string** | \&quot;**La raison de l’appel ou l’identifiant de la procédure.**  L’identifiant peut être interne à votre organisation ou bien un numéro de marché publique, un nom de procédure ; l’essentiel est que celui-ci vous permette de tracer et de retrouver les informations relatives à l’appel. En effet, vous devez pouvoir justifier de la raison d’un appel auprès du fournisseur de données. Description courte ( &lt; 50 caractères ).\&quot; |  |
| **cacheControl** | **string?** | Si cette valeur est fixée à \&quot;no-cache\&quot;, le système de cache est alors ignoré et la donnée est directement récupérée depuis le fournisseur de données. | [optional]  |

### Return type

[**V3DgfipUnitesLegalesSirenAttestationFiscaleGet200Response**](V3DgfipUnitesLegalesSirenAttestationFiscaleGet200Response.md)

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
| **200** | Attestation fiscale trouvée |  * X-Response-Cached - Indique si la réponse a été caché. <br>  * X-Cache-Expires-in - Secondes avant que le cache n&#39;expire. Si le cache est vide, ce header est vide (mais présent). <br>  * RateLimit-Limit - La limite concernant l’endpoint appelé, soit le nombre de requête/minute. <br>  * RateLimit-Remaining - Le nombre d’appels restants durant la période courante d’une minute. <br>  * RateLimit-Reset - La fin de la période courante (en format timestamp) <br>  |
| **404** | Non trouvée |  -  |
| **422** | Paramètre(s) invalide(s) |  -  |
| **502** | Erreur du fournisseur |  -  |
| **504** | Erreur d&#39;intermédiaire |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="v3fntpuniteslegalessirencarteprofessionnelletravauxpublicsget"></a>
# **V3FntpUnitesLegalesSirenCarteProfessionnelleTravauxPublicsGet**
> V3FntpUnitesLegalesSirenCarteProfessionnelleTravauxPublicsGet200Response V3FntpUnitesLegalesSirenCarteProfessionnelleTravauxPublicsGet (string context, string recipient, string _object, string siren)

Carte professionnelle travaux publics

Carte professionnelle d'entrepreneur de travaux publics, délivrée à une entreprise en règle de ses obligations sociales, administratives et juridiques.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using EntreprisesApi.Api;
using EntreprisesApi.Client;
using EntreprisesApi.Model;

namespace Example
{
    public class V3FntpUnitesLegalesSirenCarteProfessionnelleTravauxPublicsGetExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://entreprise.api.gouv.fr";
            // Configure Bearer token for authorization: jwt_bearer_token
            config.AccessToken = "YOUR_BEARER_TOKEN";

            var apiInstance = new AttestationsSocialesEtFiscalesApi(config);
            var context = Context de test;  // string | \"**Cadre de la requête**  Par exemple : aides publiques, marchés publics ou gestion d’un référentiel tiers utilisé pour tel type d’application.\"
            var recipient = 13002526500013;  // string | \"**Bénéficiaire de l’appel**  SIRET de l’administration destinatrice des données.\"
            var _object = marché numéro 127;  // string | \"**La raison de l’appel ou l’identifiant de la procédure.**  L’identifiant peut être interne à votre organisation ou bien un numéro de marché publique, un nom de procédure ; l’essentiel est que celui-ci vous permette de tracer et de retrouver les informations relatives à l’appel. En effet, vous devez pouvoir justifier de la raison d’un appel auprès du fournisseur de données. Description courte ( < 50 caractères ).\"
            var siren = "siren_example";  // string | 

            try
            {
                // Carte professionnelle travaux publics
                V3FntpUnitesLegalesSirenCarteProfessionnelleTravauxPublicsGet200Response result = apiInstance.V3FntpUnitesLegalesSirenCarteProfessionnelleTravauxPublicsGet(context, recipient, _object, siren);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling AttestationsSocialesEtFiscalesApi.V3FntpUnitesLegalesSirenCarteProfessionnelleTravauxPublicsGet: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the V3FntpUnitesLegalesSirenCarteProfessionnelleTravauxPublicsGetWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Carte professionnelle travaux publics
    ApiResponse<V3FntpUnitesLegalesSirenCarteProfessionnelleTravauxPublicsGet200Response> response = apiInstance.V3FntpUnitesLegalesSirenCarteProfessionnelleTravauxPublicsGetWithHttpInfo(context, recipient, _object, siren);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling AttestationsSocialesEtFiscalesApi.V3FntpUnitesLegalesSirenCarteProfessionnelleTravauxPublicsGetWithHttpInfo: " + e.Message);
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

[**V3FntpUnitesLegalesSirenCarteProfessionnelleTravauxPublicsGet200Response**](V3FntpUnitesLegalesSirenCarteProfessionnelleTravauxPublicsGet200Response.md)

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
| **200** | Carte professionnelle trouvée |  * RateLimit-Limit - La limite concernant l’endpoint appelé, soit le nombre de requête/minute. <br>  * RateLimit-Remaining - Le nombre d’appels restants durant la période courante d’une minute. <br>  * RateLimit-Reset - La fin de la période courante (en format timestamp) <br>  |
| **422** | Paramètre(s) invalide(s) |  -  |
| **502** | Erreur du fournisseur |  -  |
| **404** | Non trouvée |  -  |
| **504** | Erreur d&#39;intermédiaire |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="v3msaetablissementssiretconformitecotisationsget"></a>
# **V3MsaEtablissementsSiretConformiteCotisationsGet**
> V3MsaEtablissementsSiretConformiteCotisationsGet200Response V3MsaEtablissementsSiretConformiteCotisationsGet (string siret, string context, string recipient, string _object)

Conformité cotisations de sécurité sociale agricole

Statut des cotisations sociales d'une entreprise indiquant si elle est en règle auprès de la sécurité sociale agricole (MSA).

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using EntreprisesApi.Api;
using EntreprisesApi.Client;
using EntreprisesApi.Model;

namespace Example
{
    public class V3MsaEtablissementsSiretConformiteCotisationsGetExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://entreprise.api.gouv.fr";
            // Configure Bearer token for authorization: jwt_bearer_token
            config.AccessToken = "YOUR_BEARER_TOKEN";

            var apiInstance = new AttestationsSocialesEtFiscalesApi(config);
            var siret = 41816609600069;  // string | Siret de l'établissement
            var context = Context de test;  // string | \"**Cadre de la requête**  Par exemple : aides publiques, marchés publics ou gestion d’un référentiel tiers utilisé pour tel type d’application.\"
            var recipient = 13002526500013;  // string | \"**Bénéficiaire de l’appel**  SIRET de l’administration destinatrice des données.\"
            var _object = marché numéro 127;  // string | \"**La raison de l’appel ou l’identifiant de la procédure.**  L’identifiant peut être interne à votre organisation ou bien un numéro de marché publique, un nom de procédure ; l’essentiel est que celui-ci vous permette de tracer et de retrouver les informations relatives à l’appel. En effet, vous devez pouvoir justifier de la raison d’un appel auprès du fournisseur de données. Description courte ( < 50 caractères ).\"

            try
            {
                // Conformité cotisations de sécurité sociale agricole
                V3MsaEtablissementsSiretConformiteCotisationsGet200Response result = apiInstance.V3MsaEtablissementsSiretConformiteCotisationsGet(siret, context, recipient, _object);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling AttestationsSocialesEtFiscalesApi.V3MsaEtablissementsSiretConformiteCotisationsGet: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the V3MsaEtablissementsSiretConformiteCotisationsGetWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Conformité cotisations de sécurité sociale agricole
    ApiResponse<V3MsaEtablissementsSiretConformiteCotisationsGet200Response> response = apiInstance.V3MsaEtablissementsSiretConformiteCotisationsGetWithHttpInfo(siret, context, recipient, _object);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling AttestationsSocialesEtFiscalesApi.V3MsaEtablissementsSiretConformiteCotisationsGetWithHttpInfo: " + e.Message);
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

[**V3MsaEtablissementsSiretConformiteCotisationsGet200Response**](V3MsaEtablissementsSiretConformiteCotisationsGet200Response.md)

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

<a name="v3probtpetablissementssiretattestationcotisationsretraiteget"></a>
# **V3ProbtpEtablissementsSiretAttestationCotisationsRetraiteGet**
> V3CnetpUnitesLegalesSirenAttestationCotisationsCongesPayesChomageIntemperiesGet200Response V3ProbtpEtablissementsSiretAttestationCotisationsRetraiteGet (string siret, string context, string recipient, string _object)

Conformité cotisations retraite bâtiment

Attestation délivrée par la Protection sociale du bâtiment et des travaux publics (PROBTP), indiquant que l'entreprise est à jour de ses cotisations.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using EntreprisesApi.Api;
using EntreprisesApi.Client;
using EntreprisesApi.Model;

namespace Example
{
    public class V3ProbtpEtablissementsSiretAttestationCotisationsRetraiteGetExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://entreprise.api.gouv.fr";
            // Configure Bearer token for authorization: jwt_bearer_token
            config.AccessToken = "YOUR_BEARER_TOKEN";

            var apiInstance = new AttestationsSocialesEtFiscalesApi(config);
            var siret = 41816609600069;  // string | Siret de l'établissement
            var context = Context de test;  // string | \"**Cadre de la requête**  Par exemple : aides publiques, marchés publics ou gestion d’un référentiel tiers utilisé pour tel type d’application.\"
            var recipient = 13002526500013;  // string | \"**Bénéficiaire de l’appel**  SIRET de l’administration destinatrice des données.\"
            var _object = marché numéro 127;  // string | \"**La raison de l’appel ou l’identifiant de la procédure.**  L’identifiant peut être interne à votre organisation ou bien un numéro de marché publique, un nom de procédure ; l’essentiel est que celui-ci vous permette de tracer et de retrouver les informations relatives à l’appel. En effet, vous devez pouvoir justifier de la raison d’un appel auprès du fournisseur de données. Description courte ( < 50 caractères ).\"

            try
            {
                // Conformité cotisations retraite bâtiment
                V3CnetpUnitesLegalesSirenAttestationCotisationsCongesPayesChomageIntemperiesGet200Response result = apiInstance.V3ProbtpEtablissementsSiretAttestationCotisationsRetraiteGet(siret, context, recipient, _object);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling AttestationsSocialesEtFiscalesApi.V3ProbtpEtablissementsSiretAttestationCotisationsRetraiteGet: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the V3ProbtpEtablissementsSiretAttestationCotisationsRetraiteGetWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Conformité cotisations retraite bâtiment
    ApiResponse<V3CnetpUnitesLegalesSirenAttestationCotisationsCongesPayesChomageIntemperiesGet200Response> response = apiInstance.V3ProbtpEtablissementsSiretAttestationCotisationsRetraiteGetWithHttpInfo(siret, context, recipient, _object);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling AttestationsSocialesEtFiscalesApi.V3ProbtpEtablissementsSiretAttestationCotisationsRetraiteGetWithHttpInfo: " + e.Message);
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

[**V3CnetpUnitesLegalesSirenAttestationCotisationsCongesPayesChomageIntemperiesGet200Response**](V3CnetpUnitesLegalesSirenAttestationCotisationsCongesPayesChomageIntemperiesGet200Response.md)

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
| **200** | Attestation found |  * RateLimit-Limit - La limite concernant l’endpoint appelé, soit le nombre de requête/minute. <br>  * RateLimit-Remaining - Le nombre d’appels restants durant la période courante d’une minute. <br>  * RateLimit-Reset - La fin de la période courante (en format timestamp) <br>  |
| **422** | Paramètre(s) invalide(s) |  -  |
| **502** | Erreur du fournisseur |  -  |
| **404** | Attestation non trouvée |  -  |
| **504** | Erreur d&#39;intermédiaire |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="v3probtpetablissementssiretconformitecotisationsretraiteget"></a>
# **V3ProbtpEtablissementsSiretConformiteCotisationsRetraiteGet**
> V3ProbtpEtablissementsSiretConformiteCotisationsRetraiteGet200Response V3ProbtpEtablissementsSiretConformiteCotisationsRetraiteGet (string context, string recipient, string _object, string siret)

Conformités des cotisations retraites

Savoir si une entreprise est à jour de ses cotisations retraite à la Protection Sociale du Bâtiment et des Travaux publics (PROBTP).

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using EntreprisesApi.Api;
using EntreprisesApi.Client;
using EntreprisesApi.Model;

namespace Example
{
    public class V3ProbtpEtablissementsSiretConformiteCotisationsRetraiteGetExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://entreprise.api.gouv.fr";
            // Configure Bearer token for authorization: jwt_bearer_token
            config.AccessToken = "YOUR_BEARER_TOKEN";

            var apiInstance = new AttestationsSocialesEtFiscalesApi(config);
            var context = Context de test;  // string | \"**Cadre de la requête**  Par exemple : aides publiques, marchés publics ou gestion d’un référentiel tiers utilisé pour tel type d’application.\"
            var recipient = 13002526500013;  // string | \"**Bénéficiaire de l’appel**  SIRET de l’administration destinatrice des données.\"
            var _object = marché numéro 127;  // string | \"**La raison de l’appel ou l’identifiant de la procédure.**  L’identifiant peut être interne à votre organisation ou bien un numéro de marché publique, un nom de procédure ; l’essentiel est que celui-ci vous permette de tracer et de retrouver les informations relatives à l’appel. En effet, vous devez pouvoir justifier de la raison d’un appel auprès du fournisseur de données. Description courte ( < 50 caractères ).\"
            var siret = "siret_example";  // string | 

            try
            {
                // Conformités des cotisations retraites
                V3ProbtpEtablissementsSiretConformiteCotisationsRetraiteGet200Response result = apiInstance.V3ProbtpEtablissementsSiretConformiteCotisationsRetraiteGet(context, recipient, _object, siret);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling AttestationsSocialesEtFiscalesApi.V3ProbtpEtablissementsSiretConformiteCotisationsRetraiteGet: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the V3ProbtpEtablissementsSiretConformiteCotisationsRetraiteGetWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Conformités des cotisations retraites
    ApiResponse<V3ProbtpEtablissementsSiretConformiteCotisationsRetraiteGet200Response> response = apiInstance.V3ProbtpEtablissementsSiretConformiteCotisationsRetraiteGetWithHttpInfo(context, recipient, _object, siret);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling AttestationsSocialesEtFiscalesApi.V3ProbtpEtablissementsSiretConformiteCotisationsRetraiteGetWithHttpInfo: " + e.Message);
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
| **siret** | **string** |  |  |

### Return type

[**V3ProbtpEtablissementsSiretConformiteCotisationsRetraiteGet200Response**](V3ProbtpEtablissementsSiretConformiteCotisationsRetraiteGet200Response.md)

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

<a name="v3urssafuniteslegalessirenattestationvigilanceget"></a>
# **V3UrssafUnitesLegalesSirenAttestationVigilanceGet**
> V3UrssafUnitesLegalesSirenAttestationVigilanceGet200Response V3UrssafUnitesLegalesSirenAttestationVigilanceGet (string siren, string context, string recipient, string _object, string? cacheControl = null)

Attestation de vigilance

Attestation sociale délivrée à une entreprise acquittée de ses obligations de cotisations et contributions sociales auprès de l'URSSAF Caisse nationale.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using EntreprisesApi.Api;
using EntreprisesApi.Client;
using EntreprisesApi.Model;

namespace Example
{
    public class V3UrssafUnitesLegalesSirenAttestationVigilanceGetExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://entreprise.api.gouv.fr";
            // Configure Bearer token for authorization: jwt_bearer_token
            config.AccessToken = "YOUR_BEARER_TOKEN";

            var apiInstance = new AttestationsSocialesEtFiscalesApi(config);
            var siren = 418166096;  // string | Siren de l'entreprise
            var context = Context de test;  // string | \"**Cadre de la requête**  Par exemple : aides publiques, marchés publics ou gestion d’un référentiel tiers utilisé pour tel type d’application.\"
            var recipient = 13002526500013;  // string | \"**Bénéficiaire de l’appel**  SIRET de l’administration destinatrice des données.\"
            var _object = marché numéro 127;  // string | \"**La raison de l’appel ou l’identifiant de la procédure.**  L’identifiant peut être interne à votre organisation ou bien un numéro de marché publique, un nom de procédure ; l’essentiel est que celui-ci vous permette de tracer et de retrouver les informations relatives à l’appel. En effet, vous devez pouvoir justifier de la raison d’un appel auprès du fournisseur de données. Description courte ( < 50 caractères ).\"
            var cacheControl = "cacheControl_example";  // string? | Si cette valeur est fixée à \"no-cache\", le système de cache est alors ignoré et la donnée est directement récupérée depuis le fournisseur de données. (optional) 

            try
            {
                // Attestation de vigilance
                V3UrssafUnitesLegalesSirenAttestationVigilanceGet200Response result = apiInstance.V3UrssafUnitesLegalesSirenAttestationVigilanceGet(siren, context, recipient, _object, cacheControl);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling AttestationsSocialesEtFiscalesApi.V3UrssafUnitesLegalesSirenAttestationVigilanceGet: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the V3UrssafUnitesLegalesSirenAttestationVigilanceGetWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Attestation de vigilance
    ApiResponse<V3UrssafUnitesLegalesSirenAttestationVigilanceGet200Response> response = apiInstance.V3UrssafUnitesLegalesSirenAttestationVigilanceGetWithHttpInfo(siren, context, recipient, _object, cacheControl);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling AttestationsSocialesEtFiscalesApi.V3UrssafUnitesLegalesSirenAttestationVigilanceGetWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **siren** | **string** | Siren de l&#39;entreprise |  |
| **context** | **string** | \&quot;**Cadre de la requête**  Par exemple : aides publiques, marchés publics ou gestion d’un référentiel tiers utilisé pour tel type d’application.\&quot; |  |
| **recipient** | **string** | \&quot;**Bénéficiaire de l’appel**  SIRET de l’administration destinatrice des données.\&quot; |  |
| **_object** | **string** | \&quot;**La raison de l’appel ou l’identifiant de la procédure.**  L’identifiant peut être interne à votre organisation ou bien un numéro de marché publique, un nom de procédure ; l’essentiel est que celui-ci vous permette de tracer et de retrouver les informations relatives à l’appel. En effet, vous devez pouvoir justifier de la raison d’un appel auprès du fournisseur de données. Description courte ( &lt; 50 caractères ).\&quot; |  |
| **cacheControl** | **string?** | Si cette valeur est fixée à \&quot;no-cache\&quot;, le système de cache est alors ignoré et la donnée est directement récupérée depuis le fournisseur de données. | [optional]  |

### Return type

[**V3UrssafUnitesLegalesSirenAttestationVigilanceGet200Response**](V3UrssafUnitesLegalesSirenAttestationVigilanceGet200Response.md)

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
| **200** | Entreprise found |  * X-Response-Cached - Indique si la réponse a été caché. <br>  * X-Cache-Expires-in - Secondes avant que le cache n&#39;expire. Si le cache est vide, ce header est vide (mais présent). <br>  * RateLimit-Limit - La limite concernant l’endpoint appelé, soit le nombre de requête/minute. <br>  * RateLimit-Remaining - Le nombre d’appels restants durant la période courante d’une minute. <br>  * RateLimit-Reset - La fin de la période courante (en format timestamp) <br>  |
| **422** | Paramètre(s) invalide(s) |  -  |
| **502** | Erreur du fournisseur |  -  |
| **404** | Entreprise non trouvée |  -  |
| **504** | Erreur d&#39;intermédiaire |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

