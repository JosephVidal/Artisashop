# RechercheEntreprisesApi.Api.RechercheTextuelleApi

All URIs are relative to *https://recherche-entreprises.api.gouv.fr*

| Method | HTTP request | Description |
|--------|--------------|-------------|
| [**SearchGet**](RechercheTextuelleApi.md#searchget) | **GET** /search | Recherche textuelle |

<a name="searchget"></a>
# **SearchGet**
> SearchGet200Response SearchGet (string? q = null, string? codePostal = null, string? departement = null, string? codeCommune = null, string? activitePrincipale = null, string? sectionActivitePrincipale = null, string? isEntrepreneurIndividuel = null, string? trancheEffectifSalarie = null, string? nomDirigeant = null, string? prenomsDirigeant = null, DateTime? dateNaissanceDirigeantMin = null, DateTime? dateNaissanceDirigeantMax = null, int? page = null, int? perPage = null)

Recherche textuelle

Cet endpoint permet de récupérer les unités légales correspondantes à la  recherche textuelle effectuée sur la dénomination ou l'adresse.  **Paramètres d'appel :** dénomination de l'entreprise, code postal, code commune, activité  principale et section d'activité principale de l'entreprise, entrepreneur  individuel, tranche d'effectif salarié, nom de dirigeant, prénom(s) de  dirigeant et les valeurs minimale et maximale de la date de naissance de  dirigeant. 

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using RechercheEntreprisesApi.Api;
using RechercheEntreprisesApi.Client;
using RechercheEntreprisesApi.Model;

namespace Example
{
    public class SearchGetExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://recherche-entreprises.api.gouv.fr";
            var apiInstance = new RechercheTextuelleApi(config);
            var q = "q_example";  // string? | Termes de la recherche (dénomination et/ou adresse) (optional) 
            var codePostal = "codePostal_example";  // string? | <a href=https://www.sirene.fr/sirene/public/variable/codpos>Code postal en 5 chiffres</a> (optional) 
            var departement = "departement_example";  // string? |  (optional) 
            var codeCommune = "codeCommune_example";  // string? | <a href=https://www.insee.fr/fr/information/2114819>Code commune (INSEE) en 5 caractères</a> (optional) 
            var activitePrincipale = "activitePrincipale_example";  // string? | <a href=https://www.sirene.fr/sirene/public/variable/apet700-rev2>Le code NAF ou code APE, un code d'activité suivant la nomenclature de l'INSEE</a> (optional) 
            var sectionActivitePrincipale = "A";  // string? | <a href=https://www.insee.fr/fr/information/2120875>Section de  l'activité principale :</a>    * `A` - Agriculture, sylviculture et pêche   * `B` - Industries extractives   * `C` - Industrie manufacturière   * `D` - Production et distribution d'électricité, de gaz, de vapeur et d'air conditionné   * `E` - Production et distribution d'eau ; assainissement, gestion des déchets et dépollution   * `F` -  Construction   * `G` -  Commerce ; réparation d'automobiles et de motocycles   * `H` -  Transports et entreposage   * `I` -  Hébergement et restauration   * `J` -  Information et communication   * `K` -  Activités financières et d'assurance   * `L` -  Activités immobilières   * `M` -  Activités spécialisées, scientifiques et techniques   * `N` -  Activités de services administratifs et de soutien   * `O` -  Administration publique   * `P` -  Enseignement   * `Q` -  Santé humaine et action sociale   * `R` -  Arts, spectacles et activités récréatives   * `S` -  Autres activités de services   * `T` -  Activités des ménages en tant qu'employeurs ; activités indifférenciées des ménages en tant que producteurs de biens et services pour usage propre   * `U` -  Activités extra-territoriales  (optional) 
            var isEntrepreneurIndividuel = "yes";  // string? | Uniquement les entreprises individuelles (optional) 
            var trancheEffectifSalarie = "trancheEffectifSalarie_example";  // string? | <a href=https://www.sirene.fr/sirene/public/variable/tefen>Tranche d'effectif salarié de l'entreprise</a> (optional) 
            var nomDirigeant = "nomDirigeant_example";  // string? | Nom du dirigeant (optional) 
            var prenomsDirigeant = "prenomsDirigeant_example";  // string? | Prenom(s) du dirigeant (optional) 
            var dateNaissanceDirigeantMin = DateTime.Parse("2013-10-20");  // DateTime? | Valeur minimale de la date de naissance du dirigeant (optional) 
            var dateNaissanceDirigeantMax = DateTime.Parse("2013-10-20");  // DateTime? | Valeur maximale de la date de naissance du dirigeant (optional) 
            var page = 1;  // int? | Le numéro de la page à retourner (optional)  (default to 1)
            var perPage = 1;  // int? | Le nombre de résultats par page (optional)  (default to 1)

            try
            {
                // Recherche textuelle
                SearchGet200Response result = apiInstance.SearchGet(q, codePostal, departement, codeCommune, activitePrincipale, sectionActivitePrincipale, isEntrepreneurIndividuel, trancheEffectifSalarie, nomDirigeant, prenomsDirigeant, dateNaissanceDirigeantMin, dateNaissanceDirigeantMax, page, perPage);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling RechercheTextuelleApi.SearchGet: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the SearchGetWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Recherche textuelle
    ApiResponse<SearchGet200Response> response = apiInstance.SearchGetWithHttpInfo(q, codePostal, departement, codeCommune, activitePrincipale, sectionActivitePrincipale, isEntrepreneurIndividuel, trancheEffectifSalarie, nomDirigeant, prenomsDirigeant, dateNaissanceDirigeantMin, dateNaissanceDirigeantMax, page, perPage);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling RechercheTextuelleApi.SearchGetWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **q** | **string?** | Termes de la recherche (dénomination et/ou adresse) | [optional]  |
| **codePostal** | **string?** | &lt;a href&#x3D;https://www.sirene.fr/sirene/public/variable/codpos&gt;Code postal en 5 chiffres&lt;/a&gt; | [optional]  |
| **departement** | **string?** |  | [optional]  |
| **codeCommune** | **string?** | &lt;a href&#x3D;https://www.insee.fr/fr/information/2114819&gt;Code commune (INSEE) en 5 caractères&lt;/a&gt; | [optional]  |
| **activitePrincipale** | **string?** | &lt;a href&#x3D;https://www.sirene.fr/sirene/public/variable/apet700-rev2&gt;Le code NAF ou code APE, un code d&#39;activité suivant la nomenclature de l&#39;INSEE&lt;/a&gt; | [optional]  |
| **sectionActivitePrincipale** | **string?** | &lt;a href&#x3D;https://www.insee.fr/fr/information/2120875&gt;Section de  l&#39;activité principale :&lt;/a&gt;    * &#x60;A&#x60; - Agriculture, sylviculture et pêche   * &#x60;B&#x60; - Industries extractives   * &#x60;C&#x60; - Industrie manufacturière   * &#x60;D&#x60; - Production et distribution d&#39;électricité, de gaz, de vapeur et d&#39;air conditionné   * &#x60;E&#x60; - Production et distribution d&#39;eau ; assainissement, gestion des déchets et dépollution   * &#x60;F&#x60; -  Construction   * &#x60;G&#x60; -  Commerce ; réparation d&#39;automobiles et de motocycles   * &#x60;H&#x60; -  Transports et entreposage   * &#x60;I&#x60; -  Hébergement et restauration   * &#x60;J&#x60; -  Information et communication   * &#x60;K&#x60; -  Activités financières et d&#39;assurance   * &#x60;L&#x60; -  Activités immobilières   * &#x60;M&#x60; -  Activités spécialisées, scientifiques et techniques   * &#x60;N&#x60; -  Activités de services administratifs et de soutien   * &#x60;O&#x60; -  Administration publique   * &#x60;P&#x60; -  Enseignement   * &#x60;Q&#x60; -  Santé humaine et action sociale   * &#x60;R&#x60; -  Arts, spectacles et activités récréatives   * &#x60;S&#x60; -  Autres activités de services   * &#x60;T&#x60; -  Activités des ménages en tant qu&#39;employeurs ; activités indifférenciées des ménages en tant que producteurs de biens et services pour usage propre   * &#x60;U&#x60; -  Activités extra-territoriales  | [optional]  |
| **isEntrepreneurIndividuel** | **string?** | Uniquement les entreprises individuelles | [optional]  |
| **trancheEffectifSalarie** | **string?** | &lt;a href&#x3D;https://www.sirene.fr/sirene/public/variable/tefen&gt;Tranche d&#39;effectif salarié de l&#39;entreprise&lt;/a&gt; | [optional]  |
| **nomDirigeant** | **string?** | Nom du dirigeant | [optional]  |
| **prenomsDirigeant** | **string?** | Prenom(s) du dirigeant | [optional]  |
| **dateNaissanceDirigeantMin** | **DateTime?** | Valeur minimale de la date de naissance du dirigeant | [optional]  |
| **dateNaissanceDirigeantMax** | **DateTime?** | Valeur maximale de la date de naissance du dirigeant | [optional]  |
| **page** | **int?** | Le numéro de la page à retourner | [optional] [default to 1] |
| **perPage** | **int?** | Le nombre de résultats par page | [optional] [default to 1] |

### Return type

[**SearchGet200Response**](SearchGet200Response.md)

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

