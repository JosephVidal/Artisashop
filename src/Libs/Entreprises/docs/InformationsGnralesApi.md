# EntreprisesApi.Api.InformationsGnralesApi

All URIs are relative to *https://entreprise.api.gouv.fr*

| Method | HTTP request | Description |
|--------|--------------|-------------|
| [**V3CmaFranceRnmUnitesLegalesSirenGet**](InformationsGnralesApi.md#v3cmafrancernmuniteslegalessirenget) | **GET** /v3/cma_france/rnm/unites_legales/{siren} | Données du RNM d&#39;une entreprise artisanale |
| [**V3DouanesEtablissementsSiretOrEoriImmatriculationsEoriGet**](InformationsGnralesApi.md#v3douanesetablissementssiretoreoriimmatriculationseoriget) | **GET** /v3/douanes/etablissements/{siret_or_eori}/immatriculations_eori | Immatriculation EORI |
| [**V3EuropeanCommissionUnitesLegalesSirenNumeroTvaGet**](InformationsGnralesApi.md#v3europeancommissionuniteslegalessirennumerotvaget) | **GET** /v3/european_commission/unites_legales/{siren}/numero_tva | N°TVA intracommunautaire français |
| [**V3FabriqueNumeriqueMinisteresSociauxEtablissementsSiretConventionsCollectivesGet**](InformationsGnralesApi.md#v3fabriquenumeriqueministeressociauxetablissementssiretconventionscollectivesget) | **GET** /v3/fabrique_numerique_ministeres_sociaux/etablissements/{siret}/conventions_collectives | Conventions collectives |
| [**V3InfogreffeRcsUnitesLegalesSirenExtraitKbisGet**](InformationsGnralesApi.md#v3infogreffercsuniteslegalessirenextraitkbisget) | **GET** /v3/infogreffe/rcs/unites_legales/{siren}/extrait_kbis | Extrait RCS |
| [**V3InfogreffeRcsUnitesLegalesSirenMandatairesSociauxGet**](InformationsGnralesApi.md#v3infogreffercsuniteslegalessirenmandatairessociauxget) | **GET** /v3/infogreffe/rcs/unites_legales/{siren}/mandataires_sociaux | Mandataires sociaux |
| [**V3InpiUnitesLegalesSirenActesGet**](InformationsGnralesApi.md#v3inpiuniteslegalessirenactesget) | **GET** /v3/inpi/unites_legales/{siren}/actes | Actes |
| [**V3InseeSireneEtablissementsDiffusiblesSiretAdresseGet**](InformationsGnralesApi.md#v3inseesireneetablissementsdiffusiblessiretadresseget) | **GET** /v3/insee/sirene/etablissements/diffusibles/{siret}/adresse | Adresse établissement diffusible |
| [**V3InseeSireneEtablissementsDiffusiblesSiretGet**](InformationsGnralesApi.md#v3inseesireneetablissementsdiffusiblessiretget) | **GET** /v3/insee/sirene/etablissements/diffusibles/{siret} | Données établissement diffusible |
| [**V3InseeSireneEtablissementsSiretAdresseGet**](InformationsGnralesApi.md#v3inseesireneetablissementssiretadresseget) | **GET** /v3/insee/sirene/etablissements/{siret}/adresse | Adresse établissement |
| [**V3InseeSireneEtablissementsSiretGet**](InformationsGnralesApi.md#v3inseesireneetablissementssiretget) | **GET** /v3/insee/sirene/etablissements/{siret} | Données établissement |
| [**V3InseeSireneUnitesLegalesDiffusiblesSirenGet**](InformationsGnralesApi.md#v3inseesireneuniteslegalesdiffusiblessirenget) | **GET** /v3/insee/sirene/unites_legales/diffusibles/{siren} | Données unité légale diffusible |
| [**V3InseeSireneUnitesLegalesDiffusiblesSirenSiegeSocialGet**](InformationsGnralesApi.md#v3inseesireneuniteslegalesdiffusiblessirensiegesocialget) | **GET** /v3/insee/sirene/unites_legales/diffusibles/{siren}/siege_social | Données siège social diffusible |
| [**V3InseeSireneUnitesLegalesSirenGet**](InformationsGnralesApi.md#v3inseesireneuniteslegalessirenget) | **GET** /v3/insee/sirene/unites_legales/{siren} | Données unité légale |
| [**V3InseeSireneUnitesLegalesSirenSiegeSocialGet**](InformationsGnralesApi.md#v3inseesireneuniteslegalessirensiegesocialget) | **GET** /v3/insee/sirene/unites_legales/{siren}/siege_social | Données siège social |
| [**V3MinistereInterieurRnaAssociationsSiretOrRnaDocumentsGet**](InformationsGnralesApi.md#v3ministereinterieurrnaassociationssiretorrnadocumentsget) | **GET** /v3/ministere_interieur/rna/associations/{siret_or_rna}/documents | Divers documents d&#39;une association |
| [**V3MinistereInterieurRnaAssociationsSiretOrRnaGet**](InformationsGnralesApi.md#v3ministereinterieurrnaassociationssiretorrnaget) | **GET** /v3/ministere_interieur/rna/associations/{siret_or_rna} | Données du RNA d&#39;une association |

<a name="v3cmafrancernmuniteslegalessirenget"></a>
# **V3CmaFranceRnmUnitesLegalesSirenGet**
> V3CmaFranceRnmUnitesLegalesSirenGet200Response V3CmaFranceRnmUnitesLegalesSirenGet (string siren, string context, string recipient, string _object)

Données du RNM d'une entreprise artisanale

Informations de référence d'une entreprise artisanale enregistrée au répertoire national des métiers (RNM).

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using EntreprisesApi.Api;
using EntreprisesApi.Client;
using EntreprisesApi.Model;

namespace Example
{
    public class V3CmaFranceRnmUnitesLegalesSirenGetExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://entreprise.api.gouv.fr";
            // Configure Bearer token for authorization: jwt_bearer_token
            config.AccessToken = "YOUR_BEARER_TOKEN";

            var apiInstance = new InformationsGnralesApi(config);
            var siren = 418166096;  // string | Siren de l'entreprise
            var context = Context de test;  // string | \"**Cadre de la requête**  Par exemple : aides publiques, marchés publics ou gestion d’un référentiel tiers utilisé pour tel type d’application.\"
            var recipient = 13002526500013;  // string | \"**Bénéficiaire de l’appel**  SIRET de l’administration destinatrice des données.\"
            var _object = marché numéro 127;  // string | \"**La raison de l’appel ou l’identifiant de la procédure.**  L’identifiant peut être interne à votre organisation ou bien un numéro de marché publique, un nom de procédure ; l’essentiel est que celui-ci vous permette de tracer et de retrouver les informations relatives à l’appel. En effet, vous devez pouvoir justifier de la raison d’un appel auprès du fournisseur de données. Description courte ( < 50 caractères ).\"

            try
            {
                // Données du RNM d'une entreprise artisanale
                V3CmaFranceRnmUnitesLegalesSirenGet200Response result = apiInstance.V3CmaFranceRnmUnitesLegalesSirenGet(siren, context, recipient, _object);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling InformationsGnralesApi.V3CmaFranceRnmUnitesLegalesSirenGet: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the V3CmaFranceRnmUnitesLegalesSirenGetWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Données du RNM d'une entreprise artisanale
    ApiResponse<V3CmaFranceRnmUnitesLegalesSirenGet200Response> response = apiInstance.V3CmaFranceRnmUnitesLegalesSirenGetWithHttpInfo(siren, context, recipient, _object);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling InformationsGnralesApi.V3CmaFranceRnmUnitesLegalesSirenGetWithHttpInfo: " + e.Message);
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

### Return type

[**V3CmaFranceRnmUnitesLegalesSirenGet200Response**](V3CmaFranceRnmUnitesLegalesSirenGet200Response.md)

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
| **200** | Entreprise found |  * RateLimit-Limit - La limite concernant l’endpoint appelé, soit le nombre de requête/minute. <br>  * RateLimit-Remaining - Le nombre d’appels restants durant la période courante d’une minute. <br>  * RateLimit-Reset - La fin de la période courante (en format timestamp) <br>  |
| **422** | Paramètre(s) invalide(s) |  -  |
| **404** | Entreprise non trouvée |  -  |
| **502** | Erreur du fournisseur |  -  |
| **504** | Erreur d&#39;intermédiaire |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="v3douanesetablissementssiretoreoriimmatriculationseoriget"></a>
# **V3DouanesEtablissementsSiretOrEoriImmatriculationsEoriGet**
> V3DouanesEtablissementsSiretOrEoriImmatriculationsEoriGet200Response V3DouanesEtablissementsSiretOrEoriImmatriculationsEoriGet (string siretOrEori, string context, string recipient, string _object)

Immatriculation EORI

État du numéro EORI d'une entreprise indiquant si celle-ci est immatriculée auprès des douanes dans le cadre de l’import/export en Union Européenne. 

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using EntreprisesApi.Api;
using EntreprisesApi.Client;
using EntreprisesApi.Model;

namespace Example
{
    public class V3DouanesEtablissementsSiretOrEoriImmatriculationsEoriGetExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://entreprise.api.gouv.fr";
            // Configure Bearer token for authorization: jwt_bearer_token
            config.AccessToken = "YOUR_BEARER_TOKEN";

            var apiInstance = new InformationsGnralesApi(config);
            var siretOrEori = 16002307300010;  // string | Siret ou numéro EORI de l'entreprise
            var context = Context de test;  // string | \"**Cadre de la requête**  Par exemple : aides publiques, marchés publics ou gestion d’un référentiel tiers utilisé pour tel type d’application.\"
            var recipient = 13002526500013;  // string | \"**Bénéficiaire de l’appel**  SIRET de l’administration destinatrice des données.\"
            var _object = marché numéro 127;  // string | \"**La raison de l’appel ou l’identifiant de la procédure.**  L’identifiant peut être interne à votre organisation ou bien un numéro de marché publique, un nom de procédure ; l’essentiel est que celui-ci vous permette de tracer et de retrouver les informations relatives à l’appel. En effet, vous devez pouvoir justifier de la raison d’un appel auprès du fournisseur de données. Description courte ( < 50 caractères ).\"

            try
            {
                // Immatriculation EORI
                V3DouanesEtablissementsSiretOrEoriImmatriculationsEoriGet200Response result = apiInstance.V3DouanesEtablissementsSiretOrEoriImmatriculationsEoriGet(siretOrEori, context, recipient, _object);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling InformationsGnralesApi.V3DouanesEtablissementsSiretOrEoriImmatriculationsEoriGet: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the V3DouanesEtablissementsSiretOrEoriImmatriculationsEoriGetWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Immatriculation EORI
    ApiResponse<V3DouanesEtablissementsSiretOrEoriImmatriculationsEoriGet200Response> response = apiInstance.V3DouanesEtablissementsSiretOrEoriImmatriculationsEoriGetWithHttpInfo(siretOrEori, context, recipient, _object);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling InformationsGnralesApi.V3DouanesEtablissementsSiretOrEoriImmatriculationsEoriGetWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **siretOrEori** | **string** | Siret ou numéro EORI de l&#39;entreprise |  |
| **context** | **string** | \&quot;**Cadre de la requête**  Par exemple : aides publiques, marchés publics ou gestion d’un référentiel tiers utilisé pour tel type d’application.\&quot; |  |
| **recipient** | **string** | \&quot;**Bénéficiaire de l’appel**  SIRET de l’administration destinatrice des données.\&quot; |  |
| **_object** | **string** | \&quot;**La raison de l’appel ou l’identifiant de la procédure.**  L’identifiant peut être interne à votre organisation ou bien un numéro de marché publique, un nom de procédure ; l’essentiel est que celui-ci vous permette de tracer et de retrouver les informations relatives à l’appel. En effet, vous devez pouvoir justifier de la raison d’un appel auprès du fournisseur de données. Description courte ( &lt; 50 caractères ).\&quot; |  |

### Return type

[**V3DouanesEtablissementsSiretOrEoriImmatriculationsEoriGet200Response**](V3DouanesEtablissementsSiretOrEoriImmatriculationsEoriGet200Response.md)

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
| **200** | Entité trouvée |  * RateLimit-Limit - La limite concernant l’endpoint appelé, soit le nombre de requête/minute. <br>  * RateLimit-Remaining - Le nombre d’appels restants durant la période courante d’une minute. <br>  * RateLimit-Reset - La fin de la période courante (en format timestamp) <br>  |
| **422** | Paramètre(s) invalide(s) |  -  |
| **404** | Non trouvée |  -  |
| **502** | Erreur du fournisseur |  -  |
| **504** | Erreur d&#39;intermédiaire |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="v3europeancommissionuniteslegalessirennumerotvaget"></a>
# **V3EuropeanCommissionUnitesLegalesSirenNumeroTvaGet**
> V3EuropeanCommissionUnitesLegalesSirenNumeroTvaGet200Response V3EuropeanCommissionUnitesLegalesSirenNumeroTvaGet (string context, string recipient, string _object, string siren)

N°TVA intracommunautaire français

Numéro de TVA intracommunautaire français, vérifié auprès de la Commission européenne.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using EntreprisesApi.Api;
using EntreprisesApi.Client;
using EntreprisesApi.Model;

namespace Example
{
    public class V3EuropeanCommissionUnitesLegalesSirenNumeroTvaGetExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://entreprise.api.gouv.fr";
            // Configure Bearer token for authorization: jwt_bearer_token
            config.AccessToken = "YOUR_BEARER_TOKEN";

            var apiInstance = new InformationsGnralesApi(config);
            var context = Context de test;  // string | \"**Cadre de la requête**  Par exemple : aides publiques, marchés publics ou gestion d’un référentiel tiers utilisé pour tel type d’application.\"
            var recipient = 13002526500013;  // string | \"**Bénéficiaire de l’appel**  SIRET de l’administration destinatrice des données.\"
            var _object = marché numéro 127;  // string | \"**La raison de l’appel ou l’identifiant de la procédure.**  L’identifiant peut être interne à votre organisation ou bien un numéro de marché publique, un nom de procédure ; l’essentiel est que celui-ci vous permette de tracer et de retrouver les informations relatives à l’appel. En effet, vous devez pouvoir justifier de la raison d’un appel auprès du fournisseur de données. Description courte ( < 50 caractères ).\"
            var siren = "siren_example";  // string | 

            try
            {
                // N°TVA intracommunautaire français
                V3EuropeanCommissionUnitesLegalesSirenNumeroTvaGet200Response result = apiInstance.V3EuropeanCommissionUnitesLegalesSirenNumeroTvaGet(context, recipient, _object, siren);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling InformationsGnralesApi.V3EuropeanCommissionUnitesLegalesSirenNumeroTvaGet: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the V3EuropeanCommissionUnitesLegalesSirenNumeroTvaGetWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // N°TVA intracommunautaire français
    ApiResponse<V3EuropeanCommissionUnitesLegalesSirenNumeroTvaGet200Response> response = apiInstance.V3EuropeanCommissionUnitesLegalesSirenNumeroTvaGetWithHttpInfo(context, recipient, _object, siren);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling InformationsGnralesApi.V3EuropeanCommissionUnitesLegalesSirenNumeroTvaGetWithHttpInfo: " + e.Message);
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

[**V3EuropeanCommissionUnitesLegalesSirenNumeroTvaGet200Response**](V3EuropeanCommissionUnitesLegalesSirenNumeroTvaGet200Response.md)

### Authorization

[jwt_bearer_token](../README.md#jwt_bearer_token)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **401** | Non autorisé |  -  |
| **200** | Numéro de TVA trouvé |  * RateLimit-Limit - La limite concernant l’endpoint appelé, soit le nombre de requête/minute. <br>  * RateLimit-Remaining - Le nombre d’appels restants durant la période courante d’une minute. <br>  * RateLimit-Reset - La fin de la période courante (en format timestamp) <br>  |
| **404** | Non trouvée |  -  |
| **422** | Paramètre(s) invalide(s) |  -  |
| **502** | Erreur du fournisseur |  -  |
| **504** | Erreur d&#39;intermédiaire |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="v3fabriquenumeriqueministeressociauxetablissementssiretconventionscollectivesget"></a>
# **V3FabriqueNumeriqueMinisteresSociauxEtablissementsSiretConventionsCollectivesGet**
> V3FabriqueNumeriqueMinisteresSociauxEtablissementsSiretConventionsCollectivesGet200Response V3FabriqueNumeriqueMinisteresSociauxEtablissementsSiretConventionsCollectivesGet (string context, string recipient, string _object, string siret)

Conventions collectives

Identifiants des conventions collectives d’un établissement et lien vers les textes en vigueur.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using EntreprisesApi.Api;
using EntreprisesApi.Client;
using EntreprisesApi.Model;

namespace Example
{
    public class V3FabriqueNumeriqueMinisteresSociauxEtablissementsSiretConventionsCollectivesGetExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://entreprise.api.gouv.fr";
            // Configure Bearer token for authorization: jwt_bearer_token
            config.AccessToken = "YOUR_BEARER_TOKEN";

            var apiInstance = new InformationsGnralesApi(config);
            var context = Context de test;  // string | \"**Cadre de la requête**  Par exemple : aides publiques, marchés publics ou gestion d’un référentiel tiers utilisé pour tel type d’application.\"
            var recipient = 13002526500013;  // string | \"**Bénéficiaire de l’appel**  SIRET de l’administration destinatrice des données.\"
            var _object = marché numéro 127;  // string | \"**La raison de l’appel ou l’identifiant de la procédure.**  L’identifiant peut être interne à votre organisation ou bien un numéro de marché publique, un nom de procédure ; l’essentiel est que celui-ci vous permette de tracer et de retrouver les informations relatives à l’appel. En effet, vous devez pouvoir justifier de la raison d’un appel auprès du fournisseur de données. Description courte ( < 50 caractères ).\"
            var siret = 41816609600069;  // string | Siret de l'établissement

            try
            {
                // Conventions collectives
                V3FabriqueNumeriqueMinisteresSociauxEtablissementsSiretConventionsCollectivesGet200Response result = apiInstance.V3FabriqueNumeriqueMinisteresSociauxEtablissementsSiretConventionsCollectivesGet(context, recipient, _object, siret);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling InformationsGnralesApi.V3FabriqueNumeriqueMinisteresSociauxEtablissementsSiretConventionsCollectivesGet: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the V3FabriqueNumeriqueMinisteresSociauxEtablissementsSiretConventionsCollectivesGetWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Conventions collectives
    ApiResponse<V3FabriqueNumeriqueMinisteresSociauxEtablissementsSiretConventionsCollectivesGet200Response> response = apiInstance.V3FabriqueNumeriqueMinisteresSociauxEtablissementsSiretConventionsCollectivesGetWithHttpInfo(context, recipient, _object, siret);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling InformationsGnralesApi.V3FabriqueNumeriqueMinisteresSociauxEtablissementsSiretConventionsCollectivesGetWithHttpInfo: " + e.Message);
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

[**V3FabriqueNumeriqueMinisteresSociauxEtablissementsSiretConventionsCollectivesGet200Response**](V3FabriqueNumeriqueMinisteresSociauxEtablissementsSiretConventionsCollectivesGet200Response.md)

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

<a name="v3infogreffercsuniteslegalessirenextraitkbisget"></a>
# **V3InfogreffeRcsUnitesLegalesSirenExtraitKbisGet**
> V3InfogreffeRcsUnitesLegalesSirenExtraitKbisGet200Response V3InfogreffeRcsUnitesLegalesSirenExtraitKbisGet (string context, string recipient, string _object, string siren)

Extrait RCS

Extrait d'une partie des données du registre du commerce et des sociétés (RCS) ; ainsi que les commentaires laissés par les greffiers.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using EntreprisesApi.Api;
using EntreprisesApi.Client;
using EntreprisesApi.Model;

namespace Example
{
    public class V3InfogreffeRcsUnitesLegalesSirenExtraitKbisGetExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://entreprise.api.gouv.fr";
            // Configure Bearer token for authorization: jwt_bearer_token
            config.AccessToken = "YOUR_BEARER_TOKEN";

            var apiInstance = new InformationsGnralesApi(config);
            var context = Context de test;  // string | \"**Cadre de la requête**  Par exemple : aides publiques, marchés publics ou gestion d’un référentiel tiers utilisé pour tel type d’application.\"
            var recipient = 13002526500013;  // string | \"**Bénéficiaire de l’appel**  SIRET de l’administration destinatrice des données.\"
            var _object = marché numéro 127;  // string | \"**La raison de l’appel ou l’identifiant de la procédure.**  L’identifiant peut être interne à votre organisation ou bien un numéro de marché publique, un nom de procédure ; l’essentiel est que celui-ci vous permette de tracer et de retrouver les informations relatives à l’appel. En effet, vous devez pouvoir justifier de la raison d’un appel auprès du fournisseur de données. Description courte ( < 50 caractères ).\"
            var siren = 418166096;  // string | Siren de l'entreprise

            try
            {
                // Extrait RCS
                V3InfogreffeRcsUnitesLegalesSirenExtraitKbisGet200Response result = apiInstance.V3InfogreffeRcsUnitesLegalesSirenExtraitKbisGet(context, recipient, _object, siren);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling InformationsGnralesApi.V3InfogreffeRcsUnitesLegalesSirenExtraitKbisGet: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the V3InfogreffeRcsUnitesLegalesSirenExtraitKbisGetWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Extrait RCS
    ApiResponse<V3InfogreffeRcsUnitesLegalesSirenExtraitKbisGet200Response> response = apiInstance.V3InfogreffeRcsUnitesLegalesSirenExtraitKbisGetWithHttpInfo(context, recipient, _object, siren);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling InformationsGnralesApi.V3InfogreffeRcsUnitesLegalesSirenExtraitKbisGetWithHttpInfo: " + e.Message);
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
| **siren** | **string** | Siren de l&#39;entreprise |  |

### Return type

[**V3InfogreffeRcsUnitesLegalesSirenExtraitKbisGet200Response**](V3InfogreffeRcsUnitesLegalesSirenExtraitKbisGet200Response.md)

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
| **200** | Entreprise trouvée (personne physique) |  * RateLimit-Limit - La limite concernant l’endpoint appelé, soit le nombre de requête/minute. <br>  * RateLimit-Remaining - Le nombre d’appels restants durant la période courante d’une minute. <br>  * RateLimit-Reset - La fin de la période courante (en format timestamp) <br>  |
| **422** | Paramètre(s) invalide(s) |  -  |
| **404** | Non trouvée |  -  |
| **502** | Erreur du fournisseur |  -  |
| **504** | Erreur d&#39;intermédiaire |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="v3infogreffercsuniteslegalessirenmandatairessociauxget"></a>
# **V3InfogreffeRcsUnitesLegalesSirenMandatairesSociauxGet**
> V3InfogreffeRcsUnitesLegalesSirenMandatairesSociauxGet200Response V3InfogreffeRcsUnitesLegalesSirenMandatairesSociauxGet (string siren, string context, string recipient, string _object)

Mandataires sociaux

Liste des mandataires sociaux d'une société inscrite au RCS, délivrée par Infogreffe.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using EntreprisesApi.Api;
using EntreprisesApi.Client;
using EntreprisesApi.Model;

namespace Example
{
    public class V3InfogreffeRcsUnitesLegalesSirenMandatairesSociauxGetExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://entreprise.api.gouv.fr";
            // Configure Bearer token for authorization: jwt_bearer_token
            config.AccessToken = "YOUR_BEARER_TOKEN";

            var apiInstance = new InformationsGnralesApi(config);
            var siren = 418166096;  // string | Siren de l'entreprise
            var context = Context de test;  // string | \"**Cadre de la requête**  Par exemple : aides publiques, marchés publics ou gestion d’un référentiel tiers utilisé pour tel type d’application.\"
            var recipient = 13002526500013;  // string | \"**Bénéficiaire de l’appel**  SIRET de l’administration destinatrice des données.\"
            var _object = marché numéro 127;  // string | \"**La raison de l’appel ou l’identifiant de la procédure.**  L’identifiant peut être interne à votre organisation ou bien un numéro de marché publique, un nom de procédure ; l’essentiel est que celui-ci vous permette de tracer et de retrouver les informations relatives à l’appel. En effet, vous devez pouvoir justifier de la raison d’un appel auprès du fournisseur de données. Description courte ( < 50 caractères ).\"

            try
            {
                // Mandataires sociaux
                V3InfogreffeRcsUnitesLegalesSirenMandatairesSociauxGet200Response result = apiInstance.V3InfogreffeRcsUnitesLegalesSirenMandatairesSociauxGet(siren, context, recipient, _object);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling InformationsGnralesApi.V3InfogreffeRcsUnitesLegalesSirenMandatairesSociauxGet: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the V3InfogreffeRcsUnitesLegalesSirenMandatairesSociauxGetWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Mandataires sociaux
    ApiResponse<V3InfogreffeRcsUnitesLegalesSirenMandatairesSociauxGet200Response> response = apiInstance.V3InfogreffeRcsUnitesLegalesSirenMandatairesSociauxGetWithHttpInfo(siren, context, recipient, _object);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling InformationsGnralesApi.V3InfogreffeRcsUnitesLegalesSirenMandatairesSociauxGetWithHttpInfo: " + e.Message);
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

### Return type

[**V3InfogreffeRcsUnitesLegalesSirenMandatairesSociauxGet200Response**](V3InfogreffeRcsUnitesLegalesSirenMandatairesSociauxGet200Response.md)

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
| **200** | Entité trouvée |  * RateLimit-Limit - La limite concernant l’endpoint appelé, soit le nombre de requête/minute. <br>  * RateLimit-Remaining - Le nombre d’appels restants durant la période courante d’une minute. <br>  * RateLimit-Reset - La fin de la période courante (en format timestamp) <br>  |
| **422** | Paramètre(s) invalide(s) |  -  |
| **404** | Entreprise non trouvée |  -  |
| **502** | Erreur du fournisseur |  -  |
| **504** | Erreur d&#39;intermédiaire |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="v3inpiuniteslegalessirenactesget"></a>
# **V3InpiUnitesLegalesSirenActesGet**
> V3InpiUnitesLegalesSirenActesGet200Response V3InpiUnitesLegalesSirenActesGet (string context, string recipient, string _object, string siren)

Actes

Actes issus des greffes et archivés à l’Institut national de propriété industrielle (Inpi). 

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using EntreprisesApi.Api;
using EntreprisesApi.Client;
using EntreprisesApi.Model;

namespace Example
{
    public class V3InpiUnitesLegalesSirenActesGetExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://entreprise.api.gouv.fr";
            // Configure Bearer token for authorization: jwt_bearer_token
            config.AccessToken = "YOUR_BEARER_TOKEN";

            var apiInstance = new InformationsGnralesApi(config);
            var context = Context de test;  // string | \"**Cadre de la requête**  Par exemple : aides publiques, marchés publics ou gestion d’un référentiel tiers utilisé pour tel type d’application.\"
            var recipient = 13002526500013;  // string | \"**Bénéficiaire de l’appel**  SIRET de l’administration destinatrice des données.\"
            var _object = marché numéro 127;  // string | \"**La raison de l’appel ou l’identifiant de la procédure.**  L’identifiant peut être interne à votre organisation ou bien un numéro de marché publique, un nom de procédure ; l’essentiel est que celui-ci vous permette de tracer et de retrouver les informations relatives à l’appel. En effet, vous devez pouvoir justifier de la raison d’un appel auprès du fournisseur de données. Description courte ( < 50 caractères ).\"
            var siren = "siren_example";  // string | 

            try
            {
                // Actes
                V3InpiUnitesLegalesSirenActesGet200Response result = apiInstance.V3InpiUnitesLegalesSirenActesGet(context, recipient, _object, siren);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling InformationsGnralesApi.V3InpiUnitesLegalesSirenActesGet: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the V3InpiUnitesLegalesSirenActesGetWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Actes
    ApiResponse<V3InpiUnitesLegalesSirenActesGet200Response> response = apiInstance.V3InpiUnitesLegalesSirenActesGetWithHttpInfo(context, recipient, _object, siren);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling InformationsGnralesApi.V3InpiUnitesLegalesSirenActesGetWithHttpInfo: " + e.Message);
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

[**V3InpiUnitesLegalesSirenActesGet200Response**](V3InpiUnitesLegalesSirenActesGet200Response.md)

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
| **200** | Actes trouvés |  * RateLimit-Limit - La limite concernant l’endpoint appelé, soit le nombre de requête/minute. <br>  * RateLimit-Remaining - Le nombre d’appels restants durant la période courante d’une minute. <br>  * RateLimit-Reset - La fin de la période courante (en format timestamp) <br>  |
| **422** | Paramètre(s) invalide(s) |  -  |
| **404** | Actes non trouvés |  -  |
| **502** | Erreur du fournisseur |  -  |
| **504** | Erreur d&#39;intermédiaire |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="v3inseesireneetablissementsdiffusiblessiretadresseget"></a>
# **V3InseeSireneEtablissementsDiffusiblesSiretAdresseGet**
> V3InseeSireneEtablissementsSiretAdresseGet200Response V3InseeSireneEtablissementsDiffusiblesSiretAdresseGet (string siret, string context, string recipient, string _object)

Adresse établissement diffusible

Adresse d'un établissement diffusible inscrit au répertoire Sirene.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using EntreprisesApi.Api;
using EntreprisesApi.Client;
using EntreprisesApi.Model;

namespace Example
{
    public class V3InseeSireneEtablissementsDiffusiblesSiretAdresseGetExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://entreprise.api.gouv.fr";
            // Configure Bearer token for authorization: jwt_bearer_token
            config.AccessToken = "YOUR_BEARER_TOKEN";

            var apiInstance = new InformationsGnralesApi(config);
            var siret = 41816609600069;  // string | Siret de l'établissement
            var context = Context de test;  // string | \"**Cadre de la requête**  Par exemple : aides publiques, marchés publics ou gestion d’un référentiel tiers utilisé pour tel type d’application.\"
            var recipient = 13002526500013;  // string | \"**Bénéficiaire de l’appel**  SIRET de l’administration destinatrice des données.\"
            var _object = marché numéro 127;  // string | \"**La raison de l’appel ou l’identifiant de la procédure.**  L’identifiant peut être interne à votre organisation ou bien un numéro de marché publique, un nom de procédure ; l’essentiel est que celui-ci vous permette de tracer et de retrouver les informations relatives à l’appel. En effet, vous devez pouvoir justifier de la raison d’un appel auprès du fournisseur de données. Description courte ( < 50 caractères ).\"

            try
            {
                // Adresse établissement diffusible
                V3InseeSireneEtablissementsSiretAdresseGet200Response result = apiInstance.V3InseeSireneEtablissementsDiffusiblesSiretAdresseGet(siret, context, recipient, _object);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling InformationsGnralesApi.V3InseeSireneEtablissementsDiffusiblesSiretAdresseGet: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the V3InseeSireneEtablissementsDiffusiblesSiretAdresseGetWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Adresse établissement diffusible
    ApiResponse<V3InseeSireneEtablissementsSiretAdresseGet200Response> response = apiInstance.V3InseeSireneEtablissementsDiffusiblesSiretAdresseGetWithHttpInfo(siret, context, recipient, _object);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling InformationsGnralesApi.V3InseeSireneEtablissementsDiffusiblesSiretAdresseGetWithHttpInfo: " + e.Message);
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

[**V3InseeSireneEtablissementsSiretAdresseGet200Response**](V3InseeSireneEtablissementsSiretAdresseGet200Response.md)

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
| **200** | Etablissement trouvé |  -  |
| **422** | Paramètre(s) invalide(s) |  -  |
| **404** | Non trouvé |  -  |
| **502** | Erreur du fournisseur |  -  |
| **504** | Erreur d&#39;intermédiaire |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="v3inseesireneetablissementsdiffusiblessiretget"></a>
# **V3InseeSireneEtablissementsDiffusiblesSiretGet**
> V3InseeSireneEtablissementsDiffusiblesSiretGet200Response V3InseeSireneEtablissementsDiffusiblesSiretGet (string siret, string context, string recipient, string _object)

Données établissement diffusible

Informations générales concernant un établissement diffusible inscrit au répertoire Sirene.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using EntreprisesApi.Api;
using EntreprisesApi.Client;
using EntreprisesApi.Model;

namespace Example
{
    public class V3InseeSireneEtablissementsDiffusiblesSiretGetExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://entreprise.api.gouv.fr";
            // Configure Bearer token for authorization: jwt_bearer_token
            config.AccessToken = "YOUR_BEARER_TOKEN";

            var apiInstance = new InformationsGnralesApi(config);
            var siret = 41816609600069;  // string | Siret de l'établissement
            var context = Context de test;  // string | \"**Cadre de la requête**  Par exemple : aides publiques, marchés publics ou gestion d’un référentiel tiers utilisé pour tel type d’application.\"
            var recipient = 13002526500013;  // string | \"**Bénéficiaire de l’appel**  SIRET de l’administration destinatrice des données.\"
            var _object = marché numéro 127;  // string | \"**La raison de l’appel ou l’identifiant de la procédure.**  L’identifiant peut être interne à votre organisation ou bien un numéro de marché publique, un nom de procédure ; l’essentiel est que celui-ci vous permette de tracer et de retrouver les informations relatives à l’appel. En effet, vous devez pouvoir justifier de la raison d’un appel auprès du fournisseur de données. Description courte ( < 50 caractères ).\"

            try
            {
                // Données établissement diffusible
                V3InseeSireneEtablissementsDiffusiblesSiretGet200Response result = apiInstance.V3InseeSireneEtablissementsDiffusiblesSiretGet(siret, context, recipient, _object);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling InformationsGnralesApi.V3InseeSireneEtablissementsDiffusiblesSiretGet: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the V3InseeSireneEtablissementsDiffusiblesSiretGetWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Données établissement diffusible
    ApiResponse<V3InseeSireneEtablissementsDiffusiblesSiretGet200Response> response = apiInstance.V3InseeSireneEtablissementsDiffusiblesSiretGetWithHttpInfo(siret, context, recipient, _object);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling InformationsGnralesApi.V3InseeSireneEtablissementsDiffusiblesSiretGetWithHttpInfo: " + e.Message);
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

[**V3InseeSireneEtablissementsDiffusiblesSiretGet200Response**](V3InseeSireneEtablissementsDiffusiblesSiretGet200Response.md)

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
| **200** | EtablissementDiffusable trouvé |  * RateLimit-Limit - La limite concernant l’endpoint appelé, soit le nombre de requête/minute. <br>  * RateLimit-Remaining - Le nombre d’appels restants durant la période courante d’une minute. <br>  * RateLimit-Reset - La fin de la période courante (en format timestamp) <br>  |
| **422** | Paramètre(s) invalide(s) |  -  |
| **404** | Non trouvé |  -  |
| **502** | Erreur du fournisseur |  -  |
| **504** | Erreur d&#39;intermédiaire |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="v3inseesireneetablissementssiretadresseget"></a>
# **V3InseeSireneEtablissementsSiretAdresseGet**
> V3InseeSireneEtablissementsSiretAdresseGet200Response V3InseeSireneEtablissementsSiretAdresseGet (string siret, string context, string recipient, string _object)

Adresse établissement

Adresse d'un établissement inscrit au répertoire Sirene. Tous les établissements sont appelables, y compris les non-diffusibles.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using EntreprisesApi.Api;
using EntreprisesApi.Client;
using EntreprisesApi.Model;

namespace Example
{
    public class V3InseeSireneEtablissementsSiretAdresseGetExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://entreprise.api.gouv.fr";
            // Configure Bearer token for authorization: jwt_bearer_token
            config.AccessToken = "YOUR_BEARER_TOKEN";

            var apiInstance = new InformationsGnralesApi(config);
            var siret = 41816609600069;  // string | Siret de l'établissement
            var context = Context de test;  // string | \"**Cadre de la requête**  Par exemple : aides publiques, marchés publics ou gestion d’un référentiel tiers utilisé pour tel type d’application.\"
            var recipient = 13002526500013;  // string | \"**Bénéficiaire de l’appel**  SIRET de l’administration destinatrice des données.\"
            var _object = marché numéro 127;  // string | \"**La raison de l’appel ou l’identifiant de la procédure.**  L’identifiant peut être interne à votre organisation ou bien un numéro de marché publique, un nom de procédure ; l’essentiel est que celui-ci vous permette de tracer et de retrouver les informations relatives à l’appel. En effet, vous devez pouvoir justifier de la raison d’un appel auprès du fournisseur de données. Description courte ( < 50 caractères ).\"

            try
            {
                // Adresse établissement
                V3InseeSireneEtablissementsSiretAdresseGet200Response result = apiInstance.V3InseeSireneEtablissementsSiretAdresseGet(siret, context, recipient, _object);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling InformationsGnralesApi.V3InseeSireneEtablissementsSiretAdresseGet: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the V3InseeSireneEtablissementsSiretAdresseGetWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Adresse établissement
    ApiResponse<V3InseeSireneEtablissementsSiretAdresseGet200Response> response = apiInstance.V3InseeSireneEtablissementsSiretAdresseGetWithHttpInfo(siret, context, recipient, _object);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling InformationsGnralesApi.V3InseeSireneEtablissementsSiretAdresseGetWithHttpInfo: " + e.Message);
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

[**V3InseeSireneEtablissementsSiretAdresseGet200Response**](V3InseeSireneEtablissementsSiretAdresseGet200Response.md)

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
| **200** | Etablissement trouvé |  -  |
| **422** | Paramètre(s) invalide(s) |  -  |
| **404** | Non trouvé |  -  |
| **502** | Erreur du fournisseur |  -  |
| **504** | Erreur d&#39;intermédiaire |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="v3inseesireneetablissementssiretget"></a>
# **V3InseeSireneEtablissementsSiretGet**
> V3InseeSireneEtablissementsSiretGet200Response V3InseeSireneEtablissementsSiretGet (string siret, string context, string recipient, string _object)

Données établissement

Informations générales concernant un établissement inscrit au répertoire Sirene. Tous les établissements sont appelables, y compris les non-diffusibles.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using EntreprisesApi.Api;
using EntreprisesApi.Client;
using EntreprisesApi.Model;

namespace Example
{
    public class V3InseeSireneEtablissementsSiretGetExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://entreprise.api.gouv.fr";
            // Configure Bearer token for authorization: jwt_bearer_token
            config.AccessToken = "YOUR_BEARER_TOKEN";

            var apiInstance = new InformationsGnralesApi(config);
            var siret = 41816609600069;  // string | Siret de l'établissement
            var context = Context de test;  // string | \"**Cadre de la requête**  Par exemple : aides publiques, marchés publics ou gestion d’un référentiel tiers utilisé pour tel type d’application.\"
            var recipient = 13002526500013;  // string | \"**Bénéficiaire de l’appel**  SIRET de l’administration destinatrice des données.\"
            var _object = marché numéro 127;  // string | \"**La raison de l’appel ou l’identifiant de la procédure.**  L’identifiant peut être interne à votre organisation ou bien un numéro de marché publique, un nom de procédure ; l’essentiel est que celui-ci vous permette de tracer et de retrouver les informations relatives à l’appel. En effet, vous devez pouvoir justifier de la raison d’un appel auprès du fournisseur de données. Description courte ( < 50 caractères ).\"

            try
            {
                // Données établissement
                V3InseeSireneEtablissementsSiretGet200Response result = apiInstance.V3InseeSireneEtablissementsSiretGet(siret, context, recipient, _object);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling InformationsGnralesApi.V3InseeSireneEtablissementsSiretGet: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the V3InseeSireneEtablissementsSiretGetWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Données établissement
    ApiResponse<V3InseeSireneEtablissementsSiretGet200Response> response = apiInstance.V3InseeSireneEtablissementsSiretGetWithHttpInfo(siret, context, recipient, _object);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling InformationsGnralesApi.V3InseeSireneEtablissementsSiretGetWithHttpInfo: " + e.Message);
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

[**V3InseeSireneEtablissementsSiretGet200Response**](V3InseeSireneEtablissementsSiretGet200Response.md)

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
| **200** | Etablissement trouvé |  * RateLimit-Limit - La limite concernant l’endpoint appelé, soit le nombre de requête/minute. <br>  * RateLimit-Remaining - Le nombre d’appels restants durant la période courante d’une minute. <br>  * RateLimit-Reset - La fin de la période courante (en format timestamp) <br>  |
| **422** | Paramètre(s) invalide(s) |  -  |
| **404** | Non trouvé |  -  |
| **502** | Erreur du fournisseur |  -  |
| **504** | Erreur d&#39;intermédiaire |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="v3inseesireneuniteslegalesdiffusiblessirenget"></a>
# **V3InseeSireneUnitesLegalesDiffusiblesSirenGet**
> V3InseeSireneUnitesLegalesDiffusiblesSirenGet200Response V3InseeSireneUnitesLegalesDiffusiblesSirenGet (string siren, string context, string recipient, string _object)

Données unité légale diffusible

Informations de référence d'une unité légale (entreprise, association ou administration) diffusible, inscrite au répertoire Sirene.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using EntreprisesApi.Api;
using EntreprisesApi.Client;
using EntreprisesApi.Model;

namespace Example
{
    public class V3InseeSireneUnitesLegalesDiffusiblesSirenGetExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://entreprise.api.gouv.fr";
            // Configure Bearer token for authorization: jwt_bearer_token
            config.AccessToken = "YOUR_BEARER_TOKEN";

            var apiInstance = new InformationsGnralesApi(config);
            var siren = 418166096;  // string | Siren de l'entreprise
            var context = Context de test;  // string | \"**Cadre de la requête**  Par exemple : aides publiques, marchés publics ou gestion d’un référentiel tiers utilisé pour tel type d’application.\"
            var recipient = 13002526500013;  // string | \"**Bénéficiaire de l’appel**  SIRET de l’administration destinatrice des données.\"
            var _object = marché numéro 127;  // string | \"**La raison de l’appel ou l’identifiant de la procédure.**  L’identifiant peut être interne à votre organisation ou bien un numéro de marché publique, un nom de procédure ; l’essentiel est que celui-ci vous permette de tracer et de retrouver les informations relatives à l’appel. En effet, vous devez pouvoir justifier de la raison d’un appel auprès du fournisseur de données. Description courte ( < 50 caractères ).\"

            try
            {
                // Données unité légale diffusible
                V3InseeSireneUnitesLegalesDiffusiblesSirenGet200Response result = apiInstance.V3InseeSireneUnitesLegalesDiffusiblesSirenGet(siren, context, recipient, _object);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling InformationsGnralesApi.V3InseeSireneUnitesLegalesDiffusiblesSirenGet: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the V3InseeSireneUnitesLegalesDiffusiblesSirenGetWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Données unité légale diffusible
    ApiResponse<V3InseeSireneUnitesLegalesDiffusiblesSirenGet200Response> response = apiInstance.V3InseeSireneUnitesLegalesDiffusiblesSirenGetWithHttpInfo(siren, context, recipient, _object);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling InformationsGnralesApi.V3InseeSireneUnitesLegalesDiffusiblesSirenGetWithHttpInfo: " + e.Message);
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

### Return type

[**V3InseeSireneUnitesLegalesDiffusiblesSirenGet200Response**](V3InseeSireneUnitesLegalesDiffusiblesSirenGet200Response.md)

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
| **200** | Unité légale trouvée |  * RateLimit-Limit - La limite concernant l’endpoint appelé, soit le nombre de requête/minute. <br>  * RateLimit-Remaining - Le nombre d’appels restants durant la période courante d’une minute. <br>  * RateLimit-Reset - La fin de la période courante (en format timestamp) <br>  |
| **422** | Paramètre(s) invalide(s) |  -  |
| **404** | Non trouvée |  -  |
| **502** | Erreur du fournisseur |  -  |
| **504** | Erreur d&#39;intermédiaire |  -  |
| **451** | Indisponible pour des raisons légales |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="v3inseesireneuniteslegalesdiffusiblessirensiegesocialget"></a>
# **V3InseeSireneUnitesLegalesDiffusiblesSirenSiegeSocialGet**
> V3InseeSireneEtablissementsDiffusiblesSiretGet200Response V3InseeSireneUnitesLegalesDiffusiblesSirenSiegeSocialGet (string siren, string context, string recipient, string _object)

Données siège social diffusible

Informations générales concernant le siège d'une unité légale diffusible inscrite au répertoire Sirene.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using EntreprisesApi.Api;
using EntreprisesApi.Client;
using EntreprisesApi.Model;

namespace Example
{
    public class V3InseeSireneUnitesLegalesDiffusiblesSirenSiegeSocialGetExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://entreprise.api.gouv.fr";
            // Configure Bearer token for authorization: jwt_bearer_token
            config.AccessToken = "YOUR_BEARER_TOKEN";

            var apiInstance = new InformationsGnralesApi(config);
            var siren = 418166096;  // string | Siren de l'entreprise
            var context = Context de test;  // string | \"**Cadre de la requête**  Par exemple : aides publiques, marchés publics ou gestion d’un référentiel tiers utilisé pour tel type d’application.\"
            var recipient = 13002526500013;  // string | \"**Bénéficiaire de l’appel**  SIRET de l’administration destinatrice des données.\"
            var _object = marché numéro 127;  // string | \"**La raison de l’appel ou l’identifiant de la procédure.**  L’identifiant peut être interne à votre organisation ou bien un numéro de marché publique, un nom de procédure ; l’essentiel est que celui-ci vous permette de tracer et de retrouver les informations relatives à l’appel. En effet, vous devez pouvoir justifier de la raison d’un appel auprès du fournisseur de données. Description courte ( < 50 caractères ).\"

            try
            {
                // Données siège social diffusible
                V3InseeSireneEtablissementsDiffusiblesSiretGet200Response result = apiInstance.V3InseeSireneUnitesLegalesDiffusiblesSirenSiegeSocialGet(siren, context, recipient, _object);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling InformationsGnralesApi.V3InseeSireneUnitesLegalesDiffusiblesSirenSiegeSocialGet: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the V3InseeSireneUnitesLegalesDiffusiblesSirenSiegeSocialGetWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Données siège social diffusible
    ApiResponse<V3InseeSireneEtablissementsDiffusiblesSiretGet200Response> response = apiInstance.V3InseeSireneUnitesLegalesDiffusiblesSirenSiegeSocialGetWithHttpInfo(siren, context, recipient, _object);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling InformationsGnralesApi.V3InseeSireneUnitesLegalesDiffusiblesSirenSiegeSocialGetWithHttpInfo: " + e.Message);
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

### Return type

[**V3InseeSireneEtablissementsDiffusiblesSiretGet200Response**](V3InseeSireneEtablissementsDiffusiblesSiretGet200Response.md)

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
| **200** | Établissement trouvé |  * RateLimit-Limit - La limite concernant l’endpoint appelé, soit le nombre de requête/minute. <br>  * RateLimit-Remaining - Le nombre d’appels restants durant la période courante d’une minute. <br>  * RateLimit-Reset - La fin de la période courante (en format timestamp) <br>  |
| **422** | Paramètre(s) invalide(s) |  -  |
| **404** | Non trouvé |  -  |
| **502** | Erreur du fournisseur |  -  |
| **504** | Erreur d&#39;intermédiaire |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="v3inseesireneuniteslegalessirenget"></a>
# **V3InseeSireneUnitesLegalesSirenGet**
> V3InseeSireneUnitesLegalesSirenGet200Response V3InseeSireneUnitesLegalesSirenGet (string siren, string context, string recipient, string _object)

Données unité légale

Informations de référence d'une unité légale (entreprise, association ou administration) inscrite au répertoire Sirene. Toutes les unités légales sont appelables, y compris les non-diffusibles.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using EntreprisesApi.Api;
using EntreprisesApi.Client;
using EntreprisesApi.Model;

namespace Example
{
    public class V3InseeSireneUnitesLegalesSirenGetExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://entreprise.api.gouv.fr";
            // Configure Bearer token for authorization: jwt_bearer_token
            config.AccessToken = "YOUR_BEARER_TOKEN";

            var apiInstance = new InformationsGnralesApi(config);
            var siren = 418166096;  // string | Siren de l'entreprise
            var context = Context de test;  // string | \"**Cadre de la requête**  Par exemple : aides publiques, marchés publics ou gestion d’un référentiel tiers utilisé pour tel type d’application.\"
            var recipient = 13002526500013;  // string | \"**Bénéficiaire de l’appel**  SIRET de l’administration destinatrice des données.\"
            var _object = marché numéro 127;  // string | \"**La raison de l’appel ou l’identifiant de la procédure.**  L’identifiant peut être interne à votre organisation ou bien un numéro de marché publique, un nom de procédure ; l’essentiel est que celui-ci vous permette de tracer et de retrouver les informations relatives à l’appel. En effet, vous devez pouvoir justifier de la raison d’un appel auprès du fournisseur de données. Description courte ( < 50 caractères ).\"

            try
            {
                // Données unité légale
                V3InseeSireneUnitesLegalesSirenGet200Response result = apiInstance.V3InseeSireneUnitesLegalesSirenGet(siren, context, recipient, _object);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling InformationsGnralesApi.V3InseeSireneUnitesLegalesSirenGet: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the V3InseeSireneUnitesLegalesSirenGetWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Données unité légale
    ApiResponse<V3InseeSireneUnitesLegalesSirenGet200Response> response = apiInstance.V3InseeSireneUnitesLegalesSirenGetWithHttpInfo(siren, context, recipient, _object);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling InformationsGnralesApi.V3InseeSireneUnitesLegalesSirenGetWithHttpInfo: " + e.Message);
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

### Return type

[**V3InseeSireneUnitesLegalesSirenGet200Response**](V3InseeSireneUnitesLegalesSirenGet200Response.md)

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
| **200** | Unité légale trouvée |  * RateLimit-Limit - La limite concernant l’endpoint appelé, soit le nombre de requête/minute. <br>  * RateLimit-Remaining - Le nombre d’appels restants durant la période courante d’une minute. <br>  * RateLimit-Reset - La fin de la période courante (en format timestamp) <br>  |
| **422** | Paramètre(s) invalide(s) |  -  |
| **404** | Non trouvée |  -  |
| **502** | Erreur du fournisseur |  -  |
| **504** | Erreur d&#39;intermédiaire |  -  |
| **451** | Indisponible pour des raisons légales |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="v3inseesireneuniteslegalessirensiegesocialget"></a>
# **V3InseeSireneUnitesLegalesSirenSiegeSocialGet**
> V3InseeSireneEtablissementsSiretGet200Response V3InseeSireneUnitesLegalesSirenSiegeSocialGet (string siren, string context, string recipient, string _object)

Données siège social

Informations générales concernant le siège social d'une unité légale inscrite au répertoire Sirene. Tous les sièges sociaux sont appelables, y compris les non-diffusibles.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using EntreprisesApi.Api;
using EntreprisesApi.Client;
using EntreprisesApi.Model;

namespace Example
{
    public class V3InseeSireneUnitesLegalesSirenSiegeSocialGetExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://entreprise.api.gouv.fr";
            // Configure Bearer token for authorization: jwt_bearer_token
            config.AccessToken = "YOUR_BEARER_TOKEN";

            var apiInstance = new InformationsGnralesApi(config);
            var siren = 418166096;  // string | Siren de l'entreprise
            var context = Context de test;  // string | \"**Cadre de la requête**  Par exemple : aides publiques, marchés publics ou gestion d’un référentiel tiers utilisé pour tel type d’application.\"
            var recipient = 13002526500013;  // string | \"**Bénéficiaire de l’appel**  SIRET de l’administration destinatrice des données.\"
            var _object = marché numéro 127;  // string | \"**La raison de l’appel ou l’identifiant de la procédure.**  L’identifiant peut être interne à votre organisation ou bien un numéro de marché publique, un nom de procédure ; l’essentiel est que celui-ci vous permette de tracer et de retrouver les informations relatives à l’appel. En effet, vous devez pouvoir justifier de la raison d’un appel auprès du fournisseur de données. Description courte ( < 50 caractères ).\"

            try
            {
                // Données siège social
                V3InseeSireneEtablissementsSiretGet200Response result = apiInstance.V3InseeSireneUnitesLegalesSirenSiegeSocialGet(siren, context, recipient, _object);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling InformationsGnralesApi.V3InseeSireneUnitesLegalesSirenSiegeSocialGet: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the V3InseeSireneUnitesLegalesSirenSiegeSocialGetWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Données siège social
    ApiResponse<V3InseeSireneEtablissementsSiretGet200Response> response = apiInstance.V3InseeSireneUnitesLegalesSirenSiegeSocialGetWithHttpInfo(siren, context, recipient, _object);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling InformationsGnralesApi.V3InseeSireneUnitesLegalesSirenSiegeSocialGetWithHttpInfo: " + e.Message);
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

### Return type

[**V3InseeSireneEtablissementsSiretGet200Response**](V3InseeSireneEtablissementsSiretGet200Response.md)

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
| **200** | Établissement trouvé |  * RateLimit-Limit - La limite concernant l’endpoint appelé, soit le nombre de requête/minute. <br>  * RateLimit-Remaining - Le nombre d’appels restants durant la période courante d’une minute. <br>  * RateLimit-Reset - La fin de la période courante (en format timestamp) <br>  |
| **422** | Paramètre(s) invalide(s) |  -  |
| **404** | Non trouvé |  -  |
| **502** | Erreur du fournisseur |  -  |
| **504** | Erreur d&#39;intermédiaire |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="v3ministereinterieurrnaassociationssiretorrnadocumentsget"></a>
# **V3MinistereInterieurRnaAssociationsSiretOrRnaDocumentsGet**
> V3MinistereInterieurRnaAssociationsSiretOrRnaDocumentsGet200Response V3MinistereInterieurRnaAssociationsSiretOrRnaDocumentsGet (string siretOrRna, string context, string recipient, string _object)

Divers documents d'une association

Divers documents administratifs en PDF tels que les statuts, le récépissé de déclaration de création, la liste des dirigeants...

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using EntreprisesApi.Api;
using EntreprisesApi.Client;
using EntreprisesApi.Model;

namespace Example
{
    public class V3MinistereInterieurRnaAssociationsSiretOrRnaDocumentsGetExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://entreprise.api.gouv.fr";
            // Configure Bearer token for authorization: jwt_bearer_token
            config.AccessToken = "YOUR_BEARER_TOKEN";

            var apiInstance = new InformationsGnralesApi(config);
            var siretOrRna = W751212517;  // string | Siret de l'association ou le numéro RNA
            var context = Context de test;  // string | \"**Cadre de la requête**  Par exemple : aides publiques, marchés publics ou gestion d’un référentiel tiers utilisé pour tel type d’application.\"
            var recipient = 13002526500013;  // string | \"**Bénéficiaire de l’appel**  SIRET de l’administration destinatrice des données.\"
            var _object = marché numéro 127;  // string | \"**La raison de l’appel ou l’identifiant de la procédure.**  L’identifiant peut être interne à votre organisation ou bien un numéro de marché publique, un nom de procédure ; l’essentiel est que celui-ci vous permette de tracer et de retrouver les informations relatives à l’appel. En effet, vous devez pouvoir justifier de la raison d’un appel auprès du fournisseur de données. Description courte ( < 50 caractères ).\"

            try
            {
                // Divers documents d'une association
                V3MinistereInterieurRnaAssociationsSiretOrRnaDocumentsGet200Response result = apiInstance.V3MinistereInterieurRnaAssociationsSiretOrRnaDocumentsGet(siretOrRna, context, recipient, _object);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling InformationsGnralesApi.V3MinistereInterieurRnaAssociationsSiretOrRnaDocumentsGet: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the V3MinistereInterieurRnaAssociationsSiretOrRnaDocumentsGetWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Divers documents d'une association
    ApiResponse<V3MinistereInterieurRnaAssociationsSiretOrRnaDocumentsGet200Response> response = apiInstance.V3MinistereInterieurRnaAssociationsSiretOrRnaDocumentsGetWithHttpInfo(siretOrRna, context, recipient, _object);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling InformationsGnralesApi.V3MinistereInterieurRnaAssociationsSiretOrRnaDocumentsGetWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **siretOrRna** | **string** | Siret de l&#39;association ou le numéro RNA |  |
| **context** | **string** | \&quot;**Cadre de la requête**  Par exemple : aides publiques, marchés publics ou gestion d’un référentiel tiers utilisé pour tel type d’application.\&quot; |  |
| **recipient** | **string** | \&quot;**Bénéficiaire de l’appel**  SIRET de l’administration destinatrice des données.\&quot; |  |
| **_object** | **string** | \&quot;**La raison de l’appel ou l’identifiant de la procédure.**  L’identifiant peut être interne à votre organisation ou bien un numéro de marché publique, un nom de procédure ; l’essentiel est que celui-ci vous permette de tracer et de retrouver les informations relatives à l’appel. En effet, vous devez pouvoir justifier de la raison d’un appel auprès du fournisseur de données. Description courte ( &lt; 50 caractères ).\&quot; |  |

### Return type

[**V3MinistereInterieurRnaAssociationsSiretOrRnaDocumentsGet200Response**](V3MinistereInterieurRnaAssociationsSiretOrRnaDocumentsGet200Response.md)

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
| **200** | Document Association found |  * RateLimit-Limit - La limite concernant l’endpoint appelé, soit le nombre de requête/minute. <br>  * RateLimit-Remaining - Le nombre d’appels restants durant la période courante d’une minute. <br>  * RateLimit-Reset - La fin de la période courante (en format timestamp) <br>  |
| **422** | Paramètre(s) invalide(s) |  -  |
| **502** | Erreur du fournisseur |  -  |
| **404** | Association not found |  -  |
| **504** | Erreur d&#39;intermédiaire |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="v3ministereinterieurrnaassociationssiretorrnaget"></a>
# **V3MinistereInterieurRnaAssociationsSiretOrRnaGet**
> V3MinistereInterieurRnaAssociationsSiretOrRnaGet200Response V3MinistereInterieurRnaAssociationsSiretOrRnaGet (string siretOrRna, string context, string recipient, string _object)

Données du RNA d'une association

Informations issues du répertoire national des associations (RNA), telles que la date de création, l’adresse du siège et les dirigeants.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using EntreprisesApi.Api;
using EntreprisesApi.Client;
using EntreprisesApi.Model;

namespace Example
{
    public class V3MinistereInterieurRnaAssociationsSiretOrRnaGetExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://entreprise.api.gouv.fr";
            // Configure Bearer token for authorization: jwt_bearer_token
            config.AccessToken = "YOUR_BEARER_TOKEN";

            var apiInstance = new InformationsGnralesApi(config);
            var siretOrRna = W751212517;  // string | Siret de l'association ou le numéro RNA
            var context = Context de test;  // string | \"**Cadre de la requête**  Par exemple : aides publiques, marchés publics ou gestion d’un référentiel tiers utilisé pour tel type d’application.\"
            var recipient = 13002526500013;  // string | \"**Bénéficiaire de l’appel**  SIRET de l’administration destinatrice des données.\"
            var _object = marché numéro 127;  // string | \"**La raison de l’appel ou l’identifiant de la procédure.**  L’identifiant peut être interne à votre organisation ou bien un numéro de marché publique, un nom de procédure ; l’essentiel est que celui-ci vous permette de tracer et de retrouver les informations relatives à l’appel. En effet, vous devez pouvoir justifier de la raison d’un appel auprès du fournisseur de données. Description courte ( < 50 caractères ).\"

            try
            {
                // Données du RNA d'une association
                V3MinistereInterieurRnaAssociationsSiretOrRnaGet200Response result = apiInstance.V3MinistereInterieurRnaAssociationsSiretOrRnaGet(siretOrRna, context, recipient, _object);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling InformationsGnralesApi.V3MinistereInterieurRnaAssociationsSiretOrRnaGet: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the V3MinistereInterieurRnaAssociationsSiretOrRnaGetWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Données du RNA d'une association
    ApiResponse<V3MinistereInterieurRnaAssociationsSiretOrRnaGet200Response> response = apiInstance.V3MinistereInterieurRnaAssociationsSiretOrRnaGetWithHttpInfo(siretOrRna, context, recipient, _object);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling InformationsGnralesApi.V3MinistereInterieurRnaAssociationsSiretOrRnaGetWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **siretOrRna** | **string** | Siret de l&#39;association ou le numéro RNA |  |
| **context** | **string** | \&quot;**Cadre de la requête**  Par exemple : aides publiques, marchés publics ou gestion d’un référentiel tiers utilisé pour tel type d’application.\&quot; |  |
| **recipient** | **string** | \&quot;**Bénéficiaire de l’appel**  SIRET de l’administration destinatrice des données.\&quot; |  |
| **_object** | **string** | \&quot;**La raison de l’appel ou l’identifiant de la procédure.**  L’identifiant peut être interne à votre organisation ou bien un numéro de marché publique, un nom de procédure ; l’essentiel est que celui-ci vous permette de tracer et de retrouver les informations relatives à l’appel. En effet, vous devez pouvoir justifier de la raison d’un appel auprès du fournisseur de données. Description courte ( &lt; 50 caractères ).\&quot; |  |

### Return type

[**V3MinistereInterieurRnaAssociationsSiretOrRnaGet200Response**](V3MinistereInterieurRnaAssociationsSiretOrRnaGet200Response.md)

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
| **200** | Association found |  * RateLimit-Limit - La limite concernant l’endpoint appelé, soit le nombre de requête/minute. <br>  * RateLimit-Remaining - Le nombre d’appels restants durant la période courante d’une minute. <br>  * RateLimit-Reset - La fin de la période courante (en format timestamp) <br>  |
| **422** | Paramètre(s) invalide(s) |  -  |
| **404** | Association not found |  -  |
| **504** | Erreur d&#39;intermédiaire |  -  |
| **502** | Erreur du fournisseur |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

