# SireneApi.Api.EtablissementApi

All URIs are relative to *https://api.insee.fr/entreprises/sirene/V3*

| Method | HTTP request | Description |
|--------|--------------|-------------|
| [**FindBySiret**](EtablissementApi.md#findbysiret) | **GET** /siret/{siret} | Recherche d&#39;un établissement par son numéro Siret |
| [**FindLiensSuccessionByQ**](EtablissementApi.md#findlienssuccessionbyq) | **GET** /siret/liensSuccession | Recherche multicritère sur les liens de succession |
| [**FindSiretByQ**](EtablissementApi.md#findsiretbyq) | **GET** /siret | Recherche multicritère d&#39;établissements |
| [**FindSiretByQPost**](EtablissementApi.md#findsiretbyqpost) | **POST** /siret | Recherche multicritère d&#39;établissements |
| [**FindSiretNonDiffusiblesByQ**](EtablissementApi.md#findsiretnondiffusiblesbyq) | **GET** /siret/nonDiffusibles | Recherche sur les non diffusibles |

<a name="findbysiret"></a>
# **FindBySiret**
> ReponseEtablissement FindBySiret (string siret, string? date = null, string? champs = null, bool? masquerValeursNulles = null)

Recherche d'un établissement par son numéro Siret

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using SireneApi.Api;
using SireneApi.Client;
using SireneApi.Model;

namespace Example
{
    public class FindBySiretExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://api.insee.fr/entreprises/sirene/V3";
            var apiInstance = new EtablissementApi(config);
            var siret = "siret_example";  // string | Identifiant de l'établissement (14 chiffres)
            var date = "date_example";  // string? | Date à laquelle s'appliqueront les critères de recherche sur les champs historisés, format AAAA-MM-JJ. Voir la <a href=\"https://www.sirene.fr/static-resources/doc/INSEE_Documentation-Extrait_dates.pdf\">documentation</a> (optional) 
            var champs = "champs_example";  // string? | Liste des champs demandés, séparés par des virgules. Voir la <a href=\"https://www.sirene.fr/static-resources/doc/INSEE_Documentation-champs-siret.pdf\">liste</a> (optional) 
            var masquerValeursNulles = true;  // bool? | Masque (true) ou affiche (false, par défaut) les attributs qui n'ont pas de valeur (optional) 

            try
            {
                // Recherche d'un établissement par son numéro Siret
                ReponseEtablissement result = apiInstance.FindBySiret(siret, date, champs, masquerValeursNulles);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling EtablissementApi.FindBySiret: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the FindBySiretWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Recherche d'un établissement par son numéro Siret
    ApiResponse<ReponseEtablissement> response = apiInstance.FindBySiretWithHttpInfo(siret, date, champs, masquerValeursNulles);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling EtablissementApi.FindBySiretWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **siret** | **string** | Identifiant de l&#39;établissement (14 chiffres) |  |
| **date** | **string?** | Date à laquelle s&#39;appliqueront les critères de recherche sur les champs historisés, format AAAA-MM-JJ. Voir la &lt;a href&#x3D;\&quot;https://www.sirene.fr/static-resources/doc/INSEE_Documentation-Extrait_dates.pdf\&quot;&gt;documentation&lt;/a&gt; | [optional]  |
| **champs** | **string?** | Liste des champs demandés, séparés par des virgules. Voir la &lt;a href&#x3D;\&quot;https://www.sirene.fr/static-resources/doc/INSEE_Documentation-champs-siret.pdf\&quot;&gt;liste&lt;/a&gt; | [optional]  |
| **masquerValeursNulles** | **bool?** | Masque (true) ou affiche (false, par défaut) les attributs qui n&#39;ont pas de valeur | [optional]  |

### Return type

[**ReponseEtablissement**](ReponseEtablissement.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | successful operation |  -  |
| **301** | Établissement d&#39;une unité légale fermée pour cause de doublon |  -  |
| **400** | Nombre incorrect de paramètres ou les paramètres sont mal formatés |  -  |
| **401** | Jeton d&#39;accès manquant ou invalide |  -  |
| **403** | Droits insuffisants pour consulter les données de cette unité |  -  |
| **404** | Entreprise non trouvée dans la base Sirene (si le paramètre date n&#39;a pas été utilisé, cela peut signifier que le numéro de 14 chiffres ne correspond pas à un Siret présent dans la base ; si le paramètre date a été utilisé, le Siret peut exister mais la date de création est postérieure au paramètre date) |  -  |
| **406** | Le paramètre &#39;Accept&#39; de l&#39;en-tête HTTP contient une valeur non prévue |  -  |
| **429** | Quota d&#39;interrogations de l&#39;API dépassé |  -  |
| **500** | Erreur interne du serveur |  -  |
| **503** | Service indisponible |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="findlienssuccessionbyq"></a>
# **FindLiensSuccessionByQ**
> ReponseLienSuccession FindLiensSuccessionByQ (string? q = null, string? tri = null, int? nombre = null, int? debut = null, string? curseur = null)

Recherche multicritère sur les liens de succession

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using SireneApi.Api;
using SireneApi.Client;
using SireneApi.Model;

namespace Example
{
    public class FindLiensSuccessionByQExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://api.insee.fr/entreprises/sirene/V3";
            var apiInstance = new EtablissementApi(config);
            var q = "q_example";  // string? | Contenu de la requête multicritères, voir la <a href=\"https://www.sirene.fr/static-resources/doc/INSEE_Documentation-Extrait_q-ls.pdf\">documentation</a> pour plus de précisions (optional) 
            var tri = "successeur";  // string? | Permet de trier sur la variable siretEtablissementSuccesseur au lieu de siretEtablissementPredecesseur (optional) 
            var nombre = 56;  // int? | Nombre d'éléments demandés dans la réponse, défaut 20 (optional) 
            var debut = 56;  // int? | Rang du premier élément demandé dans la réponse, défaut 0 (optional) 
            var curseur = "curseur_example";  // string? | Paramètre utilisé pour la pagination profonde, voir la Voir la <a href=\"https://www.sirene.fr/static-resources/doc/INSEE_Documentation-Extrait_curseurs.pdf\">documentation</a> pour plus de précisions (optional) 

            try
            {
                // Recherche multicritère sur les liens de succession
                ReponseLienSuccession result = apiInstance.FindLiensSuccessionByQ(q, tri, nombre, debut, curseur);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling EtablissementApi.FindLiensSuccessionByQ: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the FindLiensSuccessionByQWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Recherche multicritère sur les liens de succession
    ApiResponse<ReponseLienSuccession> response = apiInstance.FindLiensSuccessionByQWithHttpInfo(q, tri, nombre, debut, curseur);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling EtablissementApi.FindLiensSuccessionByQWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **q** | **string?** | Contenu de la requête multicritères, voir la &lt;a href&#x3D;\&quot;https://www.sirene.fr/static-resources/doc/INSEE_Documentation-Extrait_q-ls.pdf\&quot;&gt;documentation&lt;/a&gt; pour plus de précisions | [optional]  |
| **tri** | **string?** | Permet de trier sur la variable siretEtablissementSuccesseur au lieu de siretEtablissementPredecesseur | [optional]  |
| **nombre** | **int?** | Nombre d&#39;éléments demandés dans la réponse, défaut 20 | [optional]  |
| **debut** | **int?** | Rang du premier élément demandé dans la réponse, défaut 0 | [optional]  |
| **curseur** | **string?** | Paramètre utilisé pour la pagination profonde, voir la Voir la &lt;a href&#x3D;\&quot;https://www.sirene.fr/static-resources/doc/INSEE_Documentation-Extrait_curseurs.pdf\&quot;&gt;documentation&lt;/a&gt; pour plus de précisions | [optional]  |

### Return type

[**ReponseLienSuccession**](ReponseLienSuccession.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json, text/csv


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | successful operation |  -  |
| **400** | Nombre incorrect de paramètres ou les paramètres sont mal formatés |  -  |
| **401** | Jeton d&#39;accès manquant ou invalide |  -  |
| **404** | Entreprise non trouvée dans la base Sirene (si le paramètre date n&#39;a pas été utilisé, cela peut signifier que le numéro de 14 chiffres ne correspond pas à un Siret présent dans la base ; si le paramètre date a été utilisé, le Siret peut exister mais la date de création est postérieure au paramètre date) |  -  |
| **406** | Le paramètre &#39;Accept&#39; de l&#39;en-tête HTTP contient une valeur non prévue |  -  |
| **414** | Requête trop longue |  -  |
| **429** | Quota d&#39;interrogations de l&#39;API dépassé |  -  |
| **500** | Erreur interne du serveur |  -  |
| **503** | Service indisponible |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="findsiretbyq"></a>
# **FindSiretByQ**
> ReponseEtablissements FindSiretByQ (string? q = null, string? date = null, string? champs = null, bool? masquerValeursNulles = null, string? facetteChamp = null, string? tri = null, int? nombre = null, int? debut = null, string? curseur = null)

Recherche multicritère d'établissements

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using SireneApi.Api;
using SireneApi.Client;
using SireneApi.Model;

namespace Example
{
    public class FindSiretByQExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://api.insee.fr/entreprises/sirene/V3";
            var apiInstance = new EtablissementApi(config);
            var q = "q_example";  // string? | Contenu de la requête multicritères, voir la <a href=\"https://www.sirene.fr/static-resources/doc/INSEE_Documentation-Extrait_q.pdf\">documentation</a> pour plus de précisions (optional) 
            var date = "date_example";  // string? | Date à laquelle s'appliqueront les critères de recherche sur les champs historisés, format AAAA-MM-JJ. Voir la <a href=\"https://www.sirene.fr/static-resources/doc/INSEE_Documentation-Extrait_dates.pdf\">documentation</a> (optional) 
            var champs = "champs_example";  // string? | Liste des champs demandés, séparés par des virgules. Voir la <a href=\"https://www.sirene.fr/static-resources/doc/INSEE_Documentation-champs-siret.pdf\">liste</a> (optional) 
            var masquerValeursNulles = true;  // bool? | Masque (true) ou affiche (false, par défaut) les attributs qui n'ont pas de valeur (optional) 
            var facetteChamp = "facetteChamp_example";  // string? | Liste des champs sur lesquels des comptages seront effectués, séparés par des virgules. Voir la <a href=\"https://www.sirene.fr/static-resources/doc/INSEE_Documentation-Extrait_facettes.pdf\">documentation</a> (optional) 
            var tri = "tri_example";  // string? | Champs sur lesquels des tris seront effectués, séparés par des virgules. Voir la <a target=_blank href=\"https://www.sirene.fr/static-resources/doc/INSEE_Documentation-Extrait_tri.pdf\">documentation</a> (optional) 
            var nombre = 56;  // int? | Nombre d'éléments demandés dans la réponse, défaut 20 (optional) 
            var debut = 56;  // int? | Rang du premier élément demandé dans la réponse, défaut 0 (optional) 
            var curseur = "curseur_example";  // string? | Paramètre utilisé pour la pagination profonde, voir la Voir la <a href=\"https://www.sirene.fr/static-resources/doc/INSEE_Documentation-Extrait_curseurs.pdf\">documentation</a> pour plus de précisions (optional) 

            try
            {
                // Recherche multicritère d'établissements
                ReponseEtablissements result = apiInstance.FindSiretByQ(q, date, champs, masquerValeursNulles, facetteChamp, tri, nombre, debut, curseur);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling EtablissementApi.FindSiretByQ: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the FindSiretByQWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Recherche multicritère d'établissements
    ApiResponse<ReponseEtablissements> response = apiInstance.FindSiretByQWithHttpInfo(q, date, champs, masquerValeursNulles, facetteChamp, tri, nombre, debut, curseur);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling EtablissementApi.FindSiretByQWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **q** | **string?** | Contenu de la requête multicritères, voir la &lt;a href&#x3D;\&quot;https://www.sirene.fr/static-resources/doc/INSEE_Documentation-Extrait_q.pdf\&quot;&gt;documentation&lt;/a&gt; pour plus de précisions | [optional]  |
| **date** | **string?** | Date à laquelle s&#39;appliqueront les critères de recherche sur les champs historisés, format AAAA-MM-JJ. Voir la &lt;a href&#x3D;\&quot;https://www.sirene.fr/static-resources/doc/INSEE_Documentation-Extrait_dates.pdf\&quot;&gt;documentation&lt;/a&gt; | [optional]  |
| **champs** | **string?** | Liste des champs demandés, séparés par des virgules. Voir la &lt;a href&#x3D;\&quot;https://www.sirene.fr/static-resources/doc/INSEE_Documentation-champs-siret.pdf\&quot;&gt;liste&lt;/a&gt; | [optional]  |
| **masquerValeursNulles** | **bool?** | Masque (true) ou affiche (false, par défaut) les attributs qui n&#39;ont pas de valeur | [optional]  |
| **facetteChamp** | **string?** | Liste des champs sur lesquels des comptages seront effectués, séparés par des virgules. Voir la &lt;a href&#x3D;\&quot;https://www.sirene.fr/static-resources/doc/INSEE_Documentation-Extrait_facettes.pdf\&quot;&gt;documentation&lt;/a&gt; | [optional]  |
| **tri** | **string?** | Champs sur lesquels des tris seront effectués, séparés par des virgules. Voir la &lt;a target&#x3D;_blank href&#x3D;\&quot;https://www.sirene.fr/static-resources/doc/INSEE_Documentation-Extrait_tri.pdf\&quot;&gt;documentation&lt;/a&gt; | [optional]  |
| **nombre** | **int?** | Nombre d&#39;éléments demandés dans la réponse, défaut 20 | [optional]  |
| **debut** | **int?** | Rang du premier élément demandé dans la réponse, défaut 0 | [optional]  |
| **curseur** | **string?** | Paramètre utilisé pour la pagination profonde, voir la Voir la &lt;a href&#x3D;\&quot;https://www.sirene.fr/static-resources/doc/INSEE_Documentation-Extrait_curseurs.pdf\&quot;&gt;documentation&lt;/a&gt; pour plus de précisions | [optional]  |

### Return type

[**ReponseEtablissements**](ReponseEtablissements.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json, text/csv


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | successful operation |  -  |
| **400** | Nombre incorrect de paramètres ou les paramètres sont mal formatés |  -  |
| **401** | Jeton d&#39;accès manquant ou invalide |  -  |
| **404** | Entreprise non trouvée dans la base Sirene (si le paramètre date n&#39;a pas été utilisé, cela peut signifier que le numéro de 14 chiffres ne correspond pas à un Siret présent dans la base ; si le paramètre date a été utilisé, le Siret peut exister mais la date de création est postérieure au paramètre date) |  -  |
| **406** | Le paramètre &#39;Accept&#39; de l&#39;en-tête HTTP contient une valeur non prévue |  -  |
| **414** | Requête trop longue |  -  |
| **429** | Quota d&#39;interrogations de l&#39;API dépassé |  -  |
| **500** | Erreur interne du serveur |  -  |
| **503** | Service indisponible |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="findsiretbyqpost"></a>
# **FindSiretByQPost**
> ReponseEtablissements FindSiretByQPost (string? q = null, string? date = null, string? champs = null, bool? masquerValeursNulles = null, string? facetteChamp = null, string? tri = null, int? nombre = null, int? debut = null, string? curseur = null)

Recherche multicritère d'établissements

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using SireneApi.Api;
using SireneApi.Client;
using SireneApi.Model;

namespace Example
{
    public class FindSiretByQPostExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://api.insee.fr/entreprises/sirene/V3";
            var apiInstance = new EtablissementApi(config);
            var q = "q_example";  // string? | Contenu de la requête multicritères, voir la <a href=\\\"https://www.sirene.fr/static-resources/doc/INSEE_Documentation-Extrait_q.pdf\\\">documentation</a> pour plus de précisions (optional) 
            var date = "date_example";  // string? | Date à laquelle s'appliqueront les critères de recherche sur les champs historisés, format AAAA-MM-JJ. Voir la <a href=\\\"https://www.sirene.fr/static-resources/doc/INSEE_Documentation-Extrait_dates.pdf\\\">documentation</a> (optional) 
            var champs = "champs_example";  // string? | Liste des champs demandés, séparés par des virgules. Voir la <a href=\\\"https://www.sirene.fr/static-resources/doc/INSEE_Documentation-champs-siret.pdf\\\">liste</a> (optional) 
            var masquerValeursNulles = true;  // bool? | Masque (true) ou affiche (false, par défaut) les attributs qui n'ont pas de valeur (optional) 
            var facetteChamp = "facetteChamp_example";  // string? | Liste des champs sur lesquels des comptages seront effectués, séparés par des virgules. Voir la <a href=\\\"https://www.sirene.fr/static-resources/doc/INSEE_Documentation-Extrait_facettes.pdf\\\">documentation</a> (optional) 
            var tri = "tri_example";  // string? | Champs sur lesquels des tris seront effectués, séparés par des virgules. Voir la <a target=_blank href=\\\"https://www.sirene.fr/static-resources/doc/INSEE_Documentation-Extrait_tri.pdf\\\">documentation</a> (optional) 
            var nombre = 56;  // int? | Nombre d'éléments demandés dans la réponse, défaut 20 (optional) 
            var debut = 56;  // int? | Rang du premier élément demandé dans la réponse, défaut 0 (optional) 
            var curseur = "curseur_example";  // string? | Paramètre utilisé pour la pagination profonde, voir la Voir la <a href=\\\"https://www.sirene.fr/static-resources/doc/INSEE_Documentation-Extrait_curseurs.pdf\\\">documentation</a> pour plus de précisions (optional) 

            try
            {
                // Recherche multicritère d'établissements
                ReponseEtablissements result = apiInstance.FindSiretByQPost(q, date, champs, masquerValeursNulles, facetteChamp, tri, nombre, debut, curseur);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling EtablissementApi.FindSiretByQPost: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the FindSiretByQPostWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Recherche multicritère d'établissements
    ApiResponse<ReponseEtablissements> response = apiInstance.FindSiretByQPostWithHttpInfo(q, date, champs, masquerValeursNulles, facetteChamp, tri, nombre, debut, curseur);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling EtablissementApi.FindSiretByQPostWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **q** | **string?** | Contenu de la requête multicritères, voir la &lt;a href&#x3D;\\\&quot;https://www.sirene.fr/static-resources/doc/INSEE_Documentation-Extrait_q.pdf\\\&quot;&gt;documentation&lt;/a&gt; pour plus de précisions | [optional]  |
| **date** | **string?** | Date à laquelle s&#39;appliqueront les critères de recherche sur les champs historisés, format AAAA-MM-JJ. Voir la &lt;a href&#x3D;\\\&quot;https://www.sirene.fr/static-resources/doc/INSEE_Documentation-Extrait_dates.pdf\\\&quot;&gt;documentation&lt;/a&gt; | [optional]  |
| **champs** | **string?** | Liste des champs demandés, séparés par des virgules. Voir la &lt;a href&#x3D;\\\&quot;https://www.sirene.fr/static-resources/doc/INSEE_Documentation-champs-siret.pdf\\\&quot;&gt;liste&lt;/a&gt; | [optional]  |
| **masquerValeursNulles** | **bool?** | Masque (true) ou affiche (false, par défaut) les attributs qui n&#39;ont pas de valeur | [optional]  |
| **facetteChamp** | **string?** | Liste des champs sur lesquels des comptages seront effectués, séparés par des virgules. Voir la &lt;a href&#x3D;\\\&quot;https://www.sirene.fr/static-resources/doc/INSEE_Documentation-Extrait_facettes.pdf\\\&quot;&gt;documentation&lt;/a&gt; | [optional]  |
| **tri** | **string?** | Champs sur lesquels des tris seront effectués, séparés par des virgules. Voir la &lt;a target&#x3D;_blank href&#x3D;\\\&quot;https://www.sirene.fr/static-resources/doc/INSEE_Documentation-Extrait_tri.pdf\\\&quot;&gt;documentation&lt;/a&gt; | [optional]  |
| **nombre** | **int?** | Nombre d&#39;éléments demandés dans la réponse, défaut 20 | [optional]  |
| **debut** | **int?** | Rang du premier élément demandé dans la réponse, défaut 0 | [optional]  |
| **curseur** | **string?** | Paramètre utilisé pour la pagination profonde, voir la Voir la &lt;a href&#x3D;\\\&quot;https://www.sirene.fr/static-resources/doc/INSEE_Documentation-Extrait_curseurs.pdf\\\&quot;&gt;documentation&lt;/a&gt; pour plus de précisions | [optional]  |

### Return type

[**ReponseEtablissements**](ReponseEtablissements.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/x-www-form-urlencoded
 - **Accept**: application/json, text/csv


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | successful operation |  -  |
| **400** | Nombre incorrect de paramètres ou les paramètres sont mal formatés |  -  |
| **401** | Jeton d&#39;accès manquant ou invalide |  -  |
| **404** | Entreprise non trouvée dans la base Sirene (si le paramètre date n&#39;a pas été utilisé, cela peut signifier que le numéro de 14 chiffres ne correspond pas à un Siret présent dans la base ; si le paramètre date a été utilisé, le Siret peut exister mais la date de création est postérieure au paramètre date) |  -  |
| **406** | Le paramètre &#39;Accept&#39; de l&#39;en-tête HTTP contient une valeur non prévue |  -  |
| **414** | Requête trop longue |  -  |
| **429** | Quota d&#39;interrogations de l&#39;API dépassé |  -  |
| **500** | Erreur interne du serveur |  -  |
| **503** | Service indisponible |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="findsiretnondiffusiblesbyq"></a>
# **FindSiretNonDiffusiblesByQ**
> ReponseEtablissementsNonDiffusibles FindSiretNonDiffusiblesByQ (string? q = null, int? nombre = null, int? debut = null, string? curseur = null, string? champs = null)

Recherche sur les non diffusibles

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using SireneApi.Api;
using SireneApi.Client;
using SireneApi.Model;

namespace Example
{
    public class FindSiretNonDiffusiblesByQExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://api.insee.fr/entreprises/sirene/V3";
            var apiInstance = new EtablissementApi(config);
            var q = "q_example";  // string? | Contenu de la requête multicritères, voir la <a href=\"https://www.sirene.fr/static-resources/doc/INSEE_Documentation-Extrait_q-nd.pdf\">documentation</a> pour plus de précisions (optional) 
            var nombre = 56;  // int? | Nombre d'éléments demandés dans la réponse, défaut 20 (optional) 
            var debut = 56;  // int? | Rang du premier élément demandé dans la réponse, défaut 0 (optional) 
            var curseur = "curseur_example";  // string? | Paramètre utilisé pour la pagination profonde, voir la Voir la <a href=\"https://www.sirene.fr/static-resources/doc/INSEE_Documentation-Extrait_curseurs.pdf\">documentation</a> pour plus de précisions (optional) 
            var champs = "champs_example";  // string? | Liste des champs demandés, séparés par des virgules. Voir la <a href=\"https://www.sirene.fr/static-resources/doc/INSEE_Documentation-champs-siret.pdf\">liste</a> (optional) 

            try
            {
                // Recherche sur les non diffusibles
                ReponseEtablissementsNonDiffusibles result = apiInstance.FindSiretNonDiffusiblesByQ(q, nombre, debut, curseur, champs);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling EtablissementApi.FindSiretNonDiffusiblesByQ: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the FindSiretNonDiffusiblesByQWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Recherche sur les non diffusibles
    ApiResponse<ReponseEtablissementsNonDiffusibles> response = apiInstance.FindSiretNonDiffusiblesByQWithHttpInfo(q, nombre, debut, curseur, champs);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling EtablissementApi.FindSiretNonDiffusiblesByQWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **q** | **string?** | Contenu de la requête multicritères, voir la &lt;a href&#x3D;\&quot;https://www.sirene.fr/static-resources/doc/INSEE_Documentation-Extrait_q-nd.pdf\&quot;&gt;documentation&lt;/a&gt; pour plus de précisions | [optional]  |
| **nombre** | **int?** | Nombre d&#39;éléments demandés dans la réponse, défaut 20 | [optional]  |
| **debut** | **int?** | Rang du premier élément demandé dans la réponse, défaut 0 | [optional]  |
| **curseur** | **string?** | Paramètre utilisé pour la pagination profonde, voir la Voir la &lt;a href&#x3D;\&quot;https://www.sirene.fr/static-resources/doc/INSEE_Documentation-Extrait_curseurs.pdf\&quot;&gt;documentation&lt;/a&gt; pour plus de précisions | [optional]  |
| **champs** | **string?** | Liste des champs demandés, séparés par des virgules. Voir la &lt;a href&#x3D;\&quot;https://www.sirene.fr/static-resources/doc/INSEE_Documentation-champs-siret.pdf\&quot;&gt;liste&lt;/a&gt; | [optional]  |

### Return type

[**ReponseEtablissementsNonDiffusibles**](ReponseEtablissementsNonDiffusibles.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json, text/csv


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | successful operation |  -  |
| **400** | Nombre incorrect de paramètres ou les paramètres sont mal formatés |  -  |
| **401** | Jeton d&#39;accès manquant ou invalide |  -  |
| **404** | Entreprise non trouvée dans la base Sirene (si le paramètre date n&#39;a pas été utilisé, cela peut signifier que le numéro de 14 chiffres ne correspond pas à un Siret présent dans la base ; si le paramètre date a été utilisé, le Siret peut exister mais la date de création est postérieure au paramètre date) |  -  |
| **406** | Le paramètre &#39;Accept&#39; de l&#39;en-tête HTTP contient une valeur non prévue |  -  |
| **414** | Requête trop longue |  -  |
| **429** | Quota d&#39;interrogations de l&#39;API dépassé |  -  |
| **500** | Erreur interne du serveur |  -  |
| **503** | Service indisponible |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

