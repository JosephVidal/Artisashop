# RechercheEntreprisesApi.Api.RechercheGographiqueApi

All URIs are relative to *https://recherche-entreprises.api.gouv.fr*

| Method | HTTP request | Description |
|--------|--------------|-------------|
| [**NearPointGet**](RechercheGographiqueApi.md#nearpointget) | **GET** /near_point | Recherche géographique |

<a name="nearpointget"></a>
# **NearPointGet**
> NearPointGet200Response NearPointGet (float lat, float _long, float? radius = null, string activitePrincipale = null, string sectionActivitePrincipale = null, int? page = null, int? perPage = null)

Recherche géographique

Cet endpoint prend en paramètre une latitude (:lat) et une longitude (:long) et renvoie les unités légales autour de ces coordonnées.  Vous pouvez également préciser un paramètre radius en km(défaut: 5 km).  **Paramètres d'appel :** latitude, longitude, radius, activité principale et section d'activité principale de l'entreprise.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using RechercheEntreprisesApi.Api;
using RechercheEntreprisesApi.Client;
using RechercheEntreprisesApi.Model;

namespace Example
{
    public class NearPointGetExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://recherche-entreprises.api.gouv.fr";
            var apiInstance = new RechercheGographiqueApi(config);
            var lat = 3.4F;  // float | Latitude
            var _long = 3.4F;  // float | Longitude
            var radius = 5F;  // float? | Radius de recherche (optional)  (default to 5F)
            var activitePrincipale = "activitePrincipale_example";  // string | <a href=https://www.sirene.fr/sirene/public/variable/apet700-rev2>Le code NAF ou code APE, un code d'activité suivant la nomenclature de l'INSEE</a> (optional) 
            var sectionActivitePrincipale = "A";  // string | <a href=https://www.insee.fr/fr/information/2120875>Section de  l'activité principale :</a>   * `A` - Agriculture, sylviculture et pêche   * `B` - Industries extractives   * `C` - Industrie manufacturière   * `D` - Production et distribution d'électricité, de gaz, de vapeur et d'air conditionné   * `E` - Production et distribution d'eau ; assainissement, gestion des déchets et dépollution   * `F` -  Construction   * `G` -  Commerce ; réparation d'automobiles et de motocycles   * `H` -  Transports et entreposage   * `I` -  Hébergement et restauration   * `J` -  Information et communication   * `K` -  Activités financières et d'assurance   * `L` -  Activités immobilières   * `M` -  Activités spécialisées, scientifiques et techniques   * `N` -  Activités de services administratifs et de soutien   * `O` -  Administration publique   * `P` -  Enseignement   * `Q` -  Santé humaine et action sociale   * `R` -  Arts, spectacles et activités récréatives   * `S` -  Autres activités de services   * `T` -  Activités des ménages en tant qu'employeurs ; activités indifférenciées des ménages en tant que producteurs de biens et services pour usage propre   * `U` -  Activités extra-territoriales  (optional) 
            var page = 1;  // int? | Le numéro de la page à retourner (optional)  (default to 1)
            var perPage = 10;  // int? | Le nombre de résultats par page (optional)  (default to 10)

            try
            {
                // Recherche géographique
                NearPointGet200Response result = apiInstance.NearPointGet(lat, _long, radius, activitePrincipale, sectionActivitePrincipale, page, perPage);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling RechercheGographiqueApi.NearPointGet: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the NearPointGetWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Recherche géographique
    ApiResponse<NearPointGet200Response> response = apiInstance.NearPointGetWithHttpInfo(lat, _long, radius, activitePrincipale, sectionActivitePrincipale, page, perPage);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling RechercheGographiqueApi.NearPointGetWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **lat** | **float** | Latitude |  |
| **_long** | **float** | Longitude |  |
| **radius** | **float?** | Radius de recherche | [optional] [default to 5F] |
| **activitePrincipale** | **string** | &lt;a href&#x3D;https://www.sirene.fr/sirene/public/variable/apet700-rev2&gt;Le code NAF ou code APE, un code d&#39;activité suivant la nomenclature de l&#39;INSEE&lt;/a&gt; | [optional]  |
| **sectionActivitePrincipale** | **string** | &lt;a href&#x3D;https://www.insee.fr/fr/information/2120875&gt;Section de  l&#39;activité principale :&lt;/a&gt;   * &#x60;A&#x60; - Agriculture, sylviculture et pêche   * &#x60;B&#x60; - Industries extractives   * &#x60;C&#x60; - Industrie manufacturière   * &#x60;D&#x60; - Production et distribution d&#39;électricité, de gaz, de vapeur et d&#39;air conditionné   * &#x60;E&#x60; - Production et distribution d&#39;eau ; assainissement, gestion des déchets et dépollution   * &#x60;F&#x60; -  Construction   * &#x60;G&#x60; -  Commerce ; réparation d&#39;automobiles et de motocycles   * &#x60;H&#x60; -  Transports et entreposage   * &#x60;I&#x60; -  Hébergement et restauration   * &#x60;J&#x60; -  Information et communication   * &#x60;K&#x60; -  Activités financières et d&#39;assurance   * &#x60;L&#x60; -  Activités immobilières   * &#x60;M&#x60; -  Activités spécialisées, scientifiques et techniques   * &#x60;N&#x60; -  Activités de services administratifs et de soutien   * &#x60;O&#x60; -  Administration publique   * &#x60;P&#x60; -  Enseignement   * &#x60;Q&#x60; -  Santé humaine et action sociale   * &#x60;R&#x60; -  Arts, spectacles et activités récréatives   * &#x60;S&#x60; -  Autres activités de services   * &#x60;T&#x60; -  Activités des ménages en tant qu&#39;employeurs ; activités indifférenciées des ménages en tant que producteurs de biens et services pour usage propre   * &#x60;U&#x60; -  Activités extra-territoriales  | [optional]  |
| **page** | **int?** | Le numéro de la page à retourner | [optional] [default to 1] |
| **perPage** | **int?** | Le nombre de résultats par page | [optional] [default to 10] |

### Return type

[**NearPointGet200Response**](NearPointGet200Response.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | La liste des entreprises correspondantes à la recherche. |  -  |
| **400** | Requête incorrecte. |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

