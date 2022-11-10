# SireneApi.Api.UniteLegaleApi

All URIs are relative to *https://api.insee.fr/entreprises/sirene/V3*

| Method | HTTP request | Description |
|--------|--------------|-------------|
| [**FindBySiren**](UniteLegaleApi.md#findbysiren) | **GET** /siren/{siren} | Recherche d&#39;une unité légale par son numéro Siren (9 chiffres) |
| [**FindRefusImmatriculationRCSByQ**](UniteLegaleApi.md#findrefusimmatriculationrcsbyq) | **GET** /siren/refusImmatriculationRcs | Recherche sur les refus d&#39;immatriculation au RCS |
| [**FindSirenByQ**](UniteLegaleApi.md#findsirenbyq) | **GET** /siren | Recherche multicritère d&#39;unités légales |
| [**FindSirenByQPost**](UniteLegaleApi.md#findsirenbyqpost) | **POST** /siren | Recherche multicritère d&#39;unités légales |
| [**FindSirenNonDiffusiblesByQ**](UniteLegaleApi.md#findsirennondiffusiblesbyq) | **GET** /siren/nonDiffusibles | Recherche sur les non diffusibles |

<a name="findbysiren"></a>
# **FindBySiren**
> ReponseUniteLegale FindBySiren (string siren, string? date = null, string? champs = null, bool? masquerValeursNulles = null)

Recherche d'une unité légale par son numéro Siren (9 chiffres)

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using SireneApi.Api;
using SireneApi.Client;
using SireneApi.Model;

namespace Example
{
    public class FindBySirenExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://api.insee.fr/entreprises/sirene/V3";
            var apiInstance = new UniteLegaleApi(config);
            var siren = "siren_example";  // string | Identifiant de l'unité légale (9 chiffres)
            var date = "date_example";  // string? | Date à laquelle s'appliqueront les critères de recherche sur les champs historisés, format AAAA-MM-JJ. Voir la <a href=\"https://www.sirene.fr/static-resources/doc/INSEE_Documentation-Extrait_dates.pdf\">documentation</a> (optional) 
            var champs = "champs_example";  // string? | Liste des champs demandés, séparés par des virgules. Voir la <a href=\"https://www.sirene.fr/static-resources/doc/INSEE_Documentation-champs-siren.pdf\">liste</a> (optional) 
            var masquerValeursNulles = true;  // bool? | Masque (true) ou affiche (false, par défaut) les attributs qui n'ont pas de valeur (optional) 

            try
            {
                // Recherche d'une unité légale par son numéro Siren (9 chiffres)
                ReponseUniteLegale result = apiInstance.FindBySiren(siren, date, champs, masquerValeursNulles);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling UniteLegaleApi.FindBySiren: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the FindBySirenWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Recherche d'une unité légale par son numéro Siren (9 chiffres)
    ApiResponse<ReponseUniteLegale> response = apiInstance.FindBySirenWithHttpInfo(siren, date, champs, masquerValeursNulles);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling UniteLegaleApi.FindBySirenWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **siren** | **string** | Identifiant de l&#39;unité légale (9 chiffres) |  |
| **date** | **string?** | Date à laquelle s&#39;appliqueront les critères de recherche sur les champs historisés, format AAAA-MM-JJ. Voir la &lt;a href&#x3D;\&quot;https://www.sirene.fr/static-resources/doc/INSEE_Documentation-Extrait_dates.pdf\&quot;&gt;documentation&lt;/a&gt; | [optional]  |
| **champs** | **string?** | Liste des champs demandés, séparés par des virgules. Voir la &lt;a href&#x3D;\&quot;https://www.sirene.fr/static-resources/doc/INSEE_Documentation-champs-siren.pdf\&quot;&gt;liste&lt;/a&gt; | [optional]  |
| **masquerValeursNulles** | **bool?** | Masque (true) ou affiche (false, par défaut) les attributs qui n&#39;ont pas de valeur | [optional]  |

### Return type

[**ReponseUniteLegale**](ReponseUniteLegale.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | successful operation |  -  |
| **301** | Unité légale fermée pour cause de doublon |  -  |
| **400** | Nombre incorrect de paramètres ou les paramètres sont mal formatés |  -  |
| **401** | Jeton d&#39;accès manquant ou invalide |  -  |
| **403** | Droits insuffisants pour consulter les données de cette unité |  -  |
| **404** | Entreprise non trouvée dans la base Sirene (si le paramètre date n&#39;a pas été utilisé, cela peut signifier que le numéro de 9 chiffres ne correspond pas à un Siren présent dans la base ; si le paramètre a été utilisé, le Siren peut exister mais la date de création est postérieure au paramètre date) |  -  |
| **406** | Le paramètre &#39;Accept&#39; de l&#39;en-tête HTTP contient une valeur non prévue |  -  |
| **429** | Quota d&#39;interrogations de l&#39;API dépassé |  -  |
| **500** | Erreur interne du serveur |  -  |
| **503** | Service indisponible |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="findrefusimmatriculationrcsbyq"></a>
# **FindRefusImmatriculationRCSByQ**
> ReponseRefusImmatriculationRCS FindRefusImmatriculationRCSByQ (string? q = null, int? nombre = null, int? debut = null)

Recherche sur les refus d'immatriculation au RCS

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using SireneApi.Api;
using SireneApi.Client;
using SireneApi.Model;

namespace Example
{
    public class FindRefusImmatriculationRCSByQExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://api.insee.fr/entreprises/sirene/V3";
            var apiInstance = new UniteLegaleApi(config);
            var q = "q_example";  // string? | Contenu de la requête multicritères, voir la <a href=\"https://www.sirene.fr/static-resources/doc/INSEE_Documentation-Extrait_q-rr.pdf\">documentation</a> pour plus de précisions (optional) 
            var nombre = 56;  // int? | Nombre d'éléments demandés dans la réponse, défaut 20 (optional) 
            var debut = 56;  // int? | Rang du premier élément demandé dans la réponse, défaut 0 (optional) 

            try
            {
                // Recherche sur les refus d'immatriculation au RCS
                ReponseRefusImmatriculationRCS result = apiInstance.FindRefusImmatriculationRCSByQ(q, nombre, debut);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling UniteLegaleApi.FindRefusImmatriculationRCSByQ: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the FindRefusImmatriculationRCSByQWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Recherche sur les refus d'immatriculation au RCS
    ApiResponse<ReponseRefusImmatriculationRCS> response = apiInstance.FindRefusImmatriculationRCSByQWithHttpInfo(q, nombre, debut);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling UniteLegaleApi.FindRefusImmatriculationRCSByQWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **q** | **string?** | Contenu de la requête multicritères, voir la &lt;a href&#x3D;\&quot;https://www.sirene.fr/static-resources/doc/INSEE_Documentation-Extrait_q-rr.pdf\&quot;&gt;documentation&lt;/a&gt; pour plus de précisions | [optional]  |
| **nombre** | **int?** | Nombre d&#39;éléments demandés dans la réponse, défaut 20 | [optional]  |
| **debut** | **int?** | Rang du premier élément demandé dans la réponse, défaut 0 | [optional]  |

### Return type

[**ReponseRefusImmatriculationRCS**](ReponseRefusImmatriculationRCS.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json, text/csv


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | successful operation |  -  |
| **301** | Entreprise doublon |  -  |
| **400** | Nombre incorrect de paramètres ou les paramètres sont mal formatés |  -  |
| **401** | Jeton d&#39;accès manquant ou invalide |  -  |
| **404** | Entreprise non trouvée dans la base Sirene (si le paramètre date n&#39;a pas été utilisé, cela peut signifier que le numéro de 9 chiffres ne correspond pas à un Siren présent dans la base ; si le paramètre a été utilisé, le Siren peut exister mais la date de création est postérieure au paramètre date) |  -  |
| **406** | Le paramètre &#39;Accept&#39; de l&#39;en-tête HTTP contient une valeur non prévue |  -  |
| **429** | Quota d&#39;interrogations de l&#39;API dépassé |  -  |
| **500** | Erreur interne du serveur |  -  |
| **503** | Service indisponible |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="findsirenbyq"></a>
# **FindSirenByQ**
> ReponseUnitesLegales FindSirenByQ (string? q = null, string? date = null, string? champs = null, bool? masquerValeursNulles = null, string? facetteChamp = null, string? tri = null, int? nombre = null, int? debut = null, string? curseur = null)

Recherche multicritère d'unités légales

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using SireneApi.Api;
using SireneApi.Client;
using SireneApi.Model;

namespace Example
{
    public class FindSirenByQExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://api.insee.fr/entreprises/sirene/V3";
            var apiInstance = new UniteLegaleApi(config);
            var q = "q_example";  // string? | Contenu de la requête multicritères, voir la <a href=\"https://www.sirene.fr/static-resources/doc/INSEE_Documentation-Extrait_q.pdf\">documentation</a> pour plus de précisions (optional) 
            var date = "date_example";  // string? | Date à laquelle s'appliqueront les critères de recherche sur les champs historisés, format AAAA-MM-JJ. Voir la <a href=\"https://www.sirene.fr/static-resources/doc/INSEE_Documentation-Extrait_dates.pdf\">documentation</a> (optional) 
            var champs = "champs_example";  // string? | Liste des champs demandés, séparés par des virgules. Voir la <a href=\"https://www.sirene.fr/static-resources/doc/INSEE_Documentation-champs-siren.pdf\">liste</a> (optional) 
            var masquerValeursNulles = true;  // bool? | Masque (true) ou affiche (false, par défaut) les attributs qui n'ont pas de valeur (optional) 
            var facetteChamp = "facetteChamp_example";  // string? | Liste des champs sur lesquels des comptages seront effectués, séparés par des virgules. Voir la <a href=\"https://www.sirene.fr/static-resources/doc/INSEE_Documentation-Extrait_facettes.pdf\">documentation</a> (optional) 
            var tri = "tri_example";  // string? | Champs sur lesquels des tris seront effectués, séparés par des virgules. Voir la <a target=_blank href=\"https://www.sirene.fr/static-resources/doc/INSEE_Documentation-Extrait_tri.pdf\">documentation</a> (optional) 
            var nombre = 56;  // int? | Nombre d'éléments demandés dans la réponse, défaut 20 (optional) 
            var debut = 56;  // int? | Rang du premier élément demandé dans la réponse, défaut 0 (optional) 
            var curseur = "curseur_example";  // string? | Paramètre utilisé pour la pagination profonde, voir la Voir la <a href=\"https://www.sirene.fr/static-resources/doc/INSEE_Documentation-Extrait_curseurs.pdf\">documentation</a> pour plus de précisions (optional) 

            try
            {
                // Recherche multicritère d'unités légales
                ReponseUnitesLegales result = apiInstance.FindSirenByQ(q, date, champs, masquerValeursNulles, facetteChamp, tri, nombre, debut, curseur);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling UniteLegaleApi.FindSirenByQ: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the FindSirenByQWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Recherche multicritère d'unités légales
    ApiResponse<ReponseUnitesLegales> response = apiInstance.FindSirenByQWithHttpInfo(q, date, champs, masquerValeursNulles, facetteChamp, tri, nombre, debut, curseur);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling UniteLegaleApi.FindSirenByQWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **q** | **string?** | Contenu de la requête multicritères, voir la &lt;a href&#x3D;\&quot;https://www.sirene.fr/static-resources/doc/INSEE_Documentation-Extrait_q.pdf\&quot;&gt;documentation&lt;/a&gt; pour plus de précisions | [optional]  |
| **date** | **string?** | Date à laquelle s&#39;appliqueront les critères de recherche sur les champs historisés, format AAAA-MM-JJ. Voir la &lt;a href&#x3D;\&quot;https://www.sirene.fr/static-resources/doc/INSEE_Documentation-Extrait_dates.pdf\&quot;&gt;documentation&lt;/a&gt; | [optional]  |
| **champs** | **string?** | Liste des champs demandés, séparés par des virgules. Voir la &lt;a href&#x3D;\&quot;https://www.sirene.fr/static-resources/doc/INSEE_Documentation-champs-siren.pdf\&quot;&gt;liste&lt;/a&gt; | [optional]  |
| **masquerValeursNulles** | **bool?** | Masque (true) ou affiche (false, par défaut) les attributs qui n&#39;ont pas de valeur | [optional]  |
| **facetteChamp** | **string?** | Liste des champs sur lesquels des comptages seront effectués, séparés par des virgules. Voir la &lt;a href&#x3D;\&quot;https://www.sirene.fr/static-resources/doc/INSEE_Documentation-Extrait_facettes.pdf\&quot;&gt;documentation&lt;/a&gt; | [optional]  |
| **tri** | **string?** | Champs sur lesquels des tris seront effectués, séparés par des virgules. Voir la &lt;a target&#x3D;_blank href&#x3D;\&quot;https://www.sirene.fr/static-resources/doc/INSEE_Documentation-Extrait_tri.pdf\&quot;&gt;documentation&lt;/a&gt; | [optional]  |
| **nombre** | **int?** | Nombre d&#39;éléments demandés dans la réponse, défaut 20 | [optional]  |
| **debut** | **int?** | Rang du premier élément demandé dans la réponse, défaut 0 | [optional]  |
| **curseur** | **string?** | Paramètre utilisé pour la pagination profonde, voir la Voir la &lt;a href&#x3D;\&quot;https://www.sirene.fr/static-resources/doc/INSEE_Documentation-Extrait_curseurs.pdf\&quot;&gt;documentation&lt;/a&gt; pour plus de précisions | [optional]  |

### Return type

[**ReponseUnitesLegales**](ReponseUnitesLegales.md)

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
| **404** | Entreprise non trouvée dans la base Sirene (si le paramètre date n&#39;a pas été utilisé, cela peut signifier que le numéro de 9 chiffres ne correspond pas à un Siren présent dans la base ; si le paramètre a été utilisé, le Siren peut exister mais la date de création est postérieure au paramètre date) |  -  |
| **406** | Le paramètre &#39;Accept&#39; de l&#39;en-tête HTTP contient une valeur non prévue |  -  |
| **414** | Requête trop longue |  -  |
| **429** | Quota d&#39;interrogations de l&#39;API dépassé |  -  |
| **500** | Erreur interne du serveur |  -  |
| **503** | Service indisponible |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="findsirenbyqpost"></a>
# **FindSirenByQPost**
> ReponseUnitesLegales FindSirenByQPost (string? q = null, string? date = null, string? champs = null, bool? masquerValeursNulles = null, string? facetteChamp = null, string? tri = null, int? nombre = null, int? debut = null, string? curseur = null)

Recherche multicritère d'unités légales

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using SireneApi.Api;
using SireneApi.Client;
using SireneApi.Model;

namespace Example
{
    public class FindSirenByQPostExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://api.insee.fr/entreprises/sirene/V3";
            var apiInstance = new UniteLegaleApi(config);
            var q = "q_example";  // string? | Contenu de la requête multicritères, voir la <a href=\\\"https://www.sirene.fr/static-resources/doc/INSEE_Documentation-Extrait_q.pdf\\\">documentation</a> pour plus de précisions (optional) 
            var date = "date_example";  // string? | Date à laquelle s'appliqueront les critères de recherche sur les champs historisés, format AAAA-MM-JJ. Voir la <a href=\\\"https://www.sirene.fr/static-resources/doc/INSEE_Documentation-Extrait_dates.pdf\\\">documentation</a> (optional) 
            var champs = "champs_example";  // string? | Liste des champs demandés, séparés par des virgules. Voir la <a href=\\\"https://www.sirene.fr/static-resources/doc/INSEE_Documentation-champs-siren.pdf\\\">liste</a> (optional) 
            var masquerValeursNulles = true;  // bool? | Masque (true) ou affiche (false, par défaut) les attributs qui n'ont pas de valeur (optional) 
            var facetteChamp = "facetteChamp_example";  // string? | Liste des champs sur lesquels des comptages seront effectués, séparés par des virgules. Voir la <a href=\\\"https://www.sirene.fr/static-resources/doc/INSEE_Documentation-Extrait_facettes.pdf\\\">documentation</a> (optional) 
            var tri = "tri_example";  // string? | Champs sur lesquels des tris seront effectués, séparés par des virgules. Voir la <a target=_blank href=\\\"https://www.sirene.fr/static-resources/doc/INSEE_Documentation-Extrait_tri.pdf\\\">documentation</a> (optional) 
            var nombre = 56;  // int? | Nombre d'éléments demandés dans la réponse, défaut 20 (optional) 
            var debut = 56;  // int? | Rang du premier élément demandé dans la réponse, défaut 0 (optional) 
            var curseur = "curseur_example";  // string? | Paramètre utilisé pour la pagination profonde, voir la Voir la <a href=\\\"https://www.sirene.fr/static-resources/doc/INSEE_Documentation-Extrait_curseurs.pdf\\\">documentation</a> pour plus de précisions (optional) 

            try
            {
                // Recherche multicritère d'unités légales
                ReponseUnitesLegales result = apiInstance.FindSirenByQPost(q, date, champs, masquerValeursNulles, facetteChamp, tri, nombre, debut, curseur);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling UniteLegaleApi.FindSirenByQPost: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the FindSirenByQPostWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Recherche multicritère d'unités légales
    ApiResponse<ReponseUnitesLegales> response = apiInstance.FindSirenByQPostWithHttpInfo(q, date, champs, masquerValeursNulles, facetteChamp, tri, nombre, debut, curseur);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling UniteLegaleApi.FindSirenByQPostWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **q** | **string?** | Contenu de la requête multicritères, voir la &lt;a href&#x3D;\\\&quot;https://www.sirene.fr/static-resources/doc/INSEE_Documentation-Extrait_q.pdf\\\&quot;&gt;documentation&lt;/a&gt; pour plus de précisions | [optional]  |
| **date** | **string?** | Date à laquelle s&#39;appliqueront les critères de recherche sur les champs historisés, format AAAA-MM-JJ. Voir la &lt;a href&#x3D;\\\&quot;https://www.sirene.fr/static-resources/doc/INSEE_Documentation-Extrait_dates.pdf\\\&quot;&gt;documentation&lt;/a&gt; | [optional]  |
| **champs** | **string?** | Liste des champs demandés, séparés par des virgules. Voir la &lt;a href&#x3D;\\\&quot;https://www.sirene.fr/static-resources/doc/INSEE_Documentation-champs-siren.pdf\\\&quot;&gt;liste&lt;/a&gt; | [optional]  |
| **masquerValeursNulles** | **bool?** | Masque (true) ou affiche (false, par défaut) les attributs qui n&#39;ont pas de valeur | [optional]  |
| **facetteChamp** | **string?** | Liste des champs sur lesquels des comptages seront effectués, séparés par des virgules. Voir la &lt;a href&#x3D;\\\&quot;https://www.sirene.fr/static-resources/doc/INSEE_Documentation-Extrait_facettes.pdf\\\&quot;&gt;documentation&lt;/a&gt; | [optional]  |
| **tri** | **string?** | Champs sur lesquels des tris seront effectués, séparés par des virgules. Voir la &lt;a target&#x3D;_blank href&#x3D;\\\&quot;https://www.sirene.fr/static-resources/doc/INSEE_Documentation-Extrait_tri.pdf\\\&quot;&gt;documentation&lt;/a&gt; | [optional]  |
| **nombre** | **int?** | Nombre d&#39;éléments demandés dans la réponse, défaut 20 | [optional]  |
| **debut** | **int?** | Rang du premier élément demandé dans la réponse, défaut 0 | [optional]  |
| **curseur** | **string?** | Paramètre utilisé pour la pagination profonde, voir la Voir la &lt;a href&#x3D;\\\&quot;https://www.sirene.fr/static-resources/doc/INSEE_Documentation-Extrait_curseurs.pdf\\\&quot;&gt;documentation&lt;/a&gt; pour plus de précisions | [optional]  |

### Return type

[**ReponseUnitesLegales**](ReponseUnitesLegales.md)

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
| **404** | Entreprise non trouvée dans la base Sirene (si le paramètre date n&#39;a pas été utilisé, cela peut signifier que le numéro de 9 chiffres ne correspond pas à un Siren présent dans la base ; si le paramètre a été utilisé, le Siren peut exister mais la date de création est postérieure au paramètre date) |  -  |
| **406** | Le paramètre &#39;Accept&#39; de l&#39;en-tête HTTP contient une valeur non prévue |  -  |
| **414** | Requête trop longue |  -  |
| **429** | Quota d&#39;interrogations de l&#39;API dépassé |  -  |
| **500** | Erreur interne du serveur |  -  |
| **503** | Service indisponible |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="findsirennondiffusiblesbyq"></a>
# **FindSirenNonDiffusiblesByQ**
> ReponseUnitesLegalesNonDiffusibles FindSirenNonDiffusiblesByQ (string? q = null, int? nombre = null, int? debut = null, string? curseur = null, string? champs = null)

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
    public class FindSirenNonDiffusiblesByQExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://api.insee.fr/entreprises/sirene/V3";
            var apiInstance = new UniteLegaleApi(config);
            var q = "q_example";  // string? | Contenu de la requête multicritères, voir la <a href=\"https://www.sirene.fr/static-resources/doc/INSEE_Documentation-Extrait_q-nd.pdf\">documentation</a> pour plus de précisions (optional) 
            var nombre = 56;  // int? | Nombre d'éléments demandés dans la réponse, défaut 20 (optional) 
            var debut = 56;  // int? | Rang du premier élément demandé dans la réponse, défaut 0 (optional) 
            var curseur = "curseur_example";  // string? | Paramètre utilisé pour la pagination profonde, voir la Voir la <a href=\"https://www.sirene.fr/static-resources/doc/INSEE_Documentation-Extrait_curseurs.pdf\">documentation</a> pour plus de précisions (optional) 
            var champs = "champs_example";  // string? | Liste des champs demandés, séparés par des virgules. Voir la <a href=\"https://www.sirene.fr/static-resources/doc/INSEE_Documentation-champs-siren.pdf\">liste</a> (optional) 

            try
            {
                // Recherche sur les non diffusibles
                ReponseUnitesLegalesNonDiffusibles result = apiInstance.FindSirenNonDiffusiblesByQ(q, nombre, debut, curseur, champs);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling UniteLegaleApi.FindSirenNonDiffusiblesByQ: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the FindSirenNonDiffusiblesByQWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Recherche sur les non diffusibles
    ApiResponse<ReponseUnitesLegalesNonDiffusibles> response = apiInstance.FindSirenNonDiffusiblesByQWithHttpInfo(q, nombre, debut, curseur, champs);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling UniteLegaleApi.FindSirenNonDiffusiblesByQWithHttpInfo: " + e.Message);
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
| **champs** | **string?** | Liste des champs demandés, séparés par des virgules. Voir la &lt;a href&#x3D;\&quot;https://www.sirene.fr/static-resources/doc/INSEE_Documentation-champs-siren.pdf\&quot;&gt;liste&lt;/a&gt; | [optional]  |

### Return type

[**ReponseUnitesLegalesNonDiffusibles**](ReponseUnitesLegalesNonDiffusibles.md)

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
| **404** | Entreprise non trouvée dans la base Sirene (si le paramètre date n&#39;a pas été utilisé, cela peut signifier que le numéro de 9 chiffres ne correspond pas à un Siren présent dans la base ; si le paramètre a été utilisé, le Siren peut exister mais la date de création est postérieure au paramètre date) |  -  |
| **406** | Le paramètre &#39;Accept&#39; de l&#39;en-tête HTTP contient une valeur non prévue |  -  |
| **414** | Requête trop longue |  -  |
| **429** | Quota d&#39;interrogations de l&#39;API dépassé |  -  |
| **500** | Erreur interne du serveur |  -  |
| **503** | Service indisponible |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

