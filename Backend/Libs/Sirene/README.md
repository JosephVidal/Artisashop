# SireneApi - the C# library for the API Sirene

<p><span style=\"color:red;\"> <b></b></p><br></span><span style=\"color:blue;\">
<b>Les tranches d’effectifs et les catégories d’entreprises du millésime 2020 sont désormais disponibles</b></span>
<br><br><span style=\"color:blue;\"><i>La documentation des services est désormais au format html (Cf. Onglet Documentation)</i></span></p>
<p><h4 class=\"add-margin-top-5x\"><b>Les données du répertoire Sirene depuis 1973</b></h4><p>API Sirene donne accès aux informations concernant les entreprises et les établissements enregistrés au répertoire interadministratif Sirene depuis sa création en 1973, y compris les unités fermées.</p> <p>La recherche peut être unitaire, multicritère, phonétique et porter sur les données courantes et historisées.</p> <p></p> <p>Les services actuellement disponibles interrogent :</p> <ul> <li> les unités légales (siren) </li> <li> les établissements (siret). </li> </ul> <p>Le service informations permet de connaître les dates de dernières mises à jour.</p> <p>Le service Liens de succession informe sur les prédécesseurs et les successeurs des établissements.</p> <p align=\"justify\" style=\"margin-top: 0.6cm\">Le service nonDiffusibles restitue les siren et siret des personnes physiques ayant demandé à être exclues de la diffusion publique conformément à l'article A123-96 du code de commerce. Les informations les concernant ne peuvent alors être rediffusées, ni utilisées à des fins de prospection. Les utilisateurs ayant un référentiel en interne peuvent ainsi le mettre à jour quotidiennement.</p> <p>La lettre <b>Sirene open data actualités</b> est destinée aux utilisateurs des données Sirene. Pour vous abonner, <a href=\"https://insee.fr/fr/information/1405555\">suivez ce lien</a>. Pour consulter les précédents numéros, <a href=\"https://insee.fr/fr/information/3711739\">cliquez ici</a>.</p>

This C# SDK is automatically generated by the [OpenAPI Generator](https://openapi-generator.tech) project:

- API version: 3.9
- SDK version: 1.0.0
- Build package: org.openapitools.codegen.languages.CSharpNetCoreClientCodegen

<a name="frameworks-supported"></a>
## Frameworks supported

<a name="dependencies"></a>
## Dependencies

- [RestSharp](https://www.nuget.org/packages/RestSharp) - 106.13.0 or later
- [Json.NET](https://www.nuget.org/packages/Newtonsoft.Json/) - 13.0.1 or later
- [JsonSubTypes](https://www.nuget.org/packages/JsonSubTypes/) - 1.8.0 or later
- [System.ComponentModel.Annotations](https://www.nuget.org/packages/System.ComponentModel.Annotations) - 5.0.0 or later

The DLLs included in the package may not be the latest version. We recommend using [NuGet](https://docs.nuget.org/consume/installing-nuget) to obtain the latest version of the packages:
```
Install-Package RestSharp
Install-Package Newtonsoft.Json
Install-Package JsonSubTypes
Install-Package System.ComponentModel.Annotations
```

NOTE: RestSharp versions greater than 105.1.0 have a bug which causes file uploads to fail. See [RestSharp#742](https://github.com/restsharp/RestSharp/issues/742).
NOTE: RestSharp for .Net Core creates a new socket for each api call, which can lead to a socket exhaustion problem. See [RestSharp#1406](https://github.com/restsharp/RestSharp/issues/1406).

<a name="installation"></a>
## Installation
Run the following command to generate the DLL
- [Mac/Linux] `/bin/sh build.sh`
- [Windows] `build.bat`

Then include the DLL (under the `bin` folder) in the C# project, and use the namespaces:
```csharp
using SireneApi.Api;
using SireneApi.Client;
using SireneApi.Model;
```
<a name="packaging"></a>
## Packaging

A `.nuspec` is included with the project. You can follow the Nuget quickstart to [create](https://docs.microsoft.com/en-us/nuget/quickstart/create-and-publish-a-package#create-the-package) and [publish](https://docs.microsoft.com/en-us/nuget/quickstart/create-and-publish-a-package#publish-the-package) packages.

This `.nuspec` uses placeholders from the `.csproj`, so build the `.csproj` directly:

```
nuget pack -Build -OutputDirectory out SireneApi.csproj
```

Then, publish to a [local feed](https://docs.microsoft.com/en-us/nuget/hosting-packages/local-feeds) or [other host](https://docs.microsoft.com/en-us/nuget/hosting-packages/overview) and consume the new package via Nuget as usual.

<a name="usage"></a>
## Usage

To use the API client with a HTTP proxy, setup a `System.Net.WebProxy`
```csharp
Configuration c = new Configuration();
System.Net.WebProxy webProxy = new System.Net.WebProxy("http://myProxyUrl:80/");
webProxy.Credentials = System.Net.CredentialCache.DefaultCredentials;
c.Proxy = webProxy;
```

<a name="getting-started"></a>
## Getting Started

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using SireneApi.Api;
using SireneApi.Client;
using SireneApi.Model;

namespace Example
{
    public class Example
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
            catch (ApiException e)
            {
                Debug.Print("Exception when calling EtablissementApi.FindBySiret: " + e.Message );
                Debug.Print("Status Code: "+ e.ErrorCode);
                Debug.Print(e.StackTrace);
            }

        }
    }
}
```

<a name="documentation-for-api-endpoints"></a>
## Documentation for API Endpoints

All URIs are relative to *https://api.insee.fr/entreprises/sirene/V3*

Class | Method | HTTP request | Description
------------ | ------------- | ------------- | -------------
*EtablissementApi* | [**FindBySiret**](docs/EtablissementApi.md#findbysiret) | **GET** /siret/{siret} | Recherche d'un établissement par son numéro Siret
*EtablissementApi* | [**FindLiensSuccessionByQ**](docs/EtablissementApi.md#findlienssuccessionbyq) | **GET** /siret/liensSuccession | Recherche multicritère sur les liens de succession
*EtablissementApi* | [**FindSiretByQ**](docs/EtablissementApi.md#findsiretbyq) | **GET** /siret | Recherche multicritère d'établissements
*EtablissementApi* | [**FindSiretByQPost**](docs/EtablissementApi.md#findsiretbyqpost) | **POST** /siret | Recherche multicritère d'établissements
*EtablissementApi* | [**FindSiretNonDiffusiblesByQ**](docs/EtablissementApi.md#findsiretnondiffusiblesbyq) | **GET** /siret/nonDiffusibles | Recherche sur les non diffusibles
*InformationsApi* | [**Informations**](docs/InformationsApi.md#informations) | **GET** /informations | État du service, dates de mise à jour et numéro de version
*UniteLegaleApi* | [**FindBySiren**](docs/UniteLegaleApi.md#findbysiren) | **GET** /siren/{siren} | Recherche d'une unité légale par son numéro Siren (9 chiffres)
*UniteLegaleApi* | [**FindRefusImmatriculationRCSByQ**](docs/UniteLegaleApi.md#findrefusimmatriculationrcsbyq) | **GET** /siren/refusImmatriculationRcs | Recherche sur les refus d'immatriculation au RCS
*UniteLegaleApi* | [**FindSirenByQ**](docs/UniteLegaleApi.md#findsirenbyq) | **GET** /siren | Recherche multicritère d'unités légales
*UniteLegaleApi* | [**FindSirenByQPost**](docs/UniteLegaleApi.md#findsirenbyqpost) | **POST** /siren | Recherche multicritère d'unités légales
*UniteLegaleApi* | [**FindSirenNonDiffusiblesByQ**](docs/UniteLegaleApi.md#findsirennondiffusiblesbyq) | **GET** /siren/nonDiffusibles | Recherche sur les non diffusibles


<a name="documentation-for-models"></a>
## Documentation for Models

 - [Model.Adresse](docs/Adresse.md)
 - [Model.AdresseComplementaire](docs/AdresseComplementaire.md)
 - [Model.Comptage](docs/Comptage.md)
 - [Model.DatesMiseAJourDonnees](docs/DatesMiseAJourDonnees.md)
 - [Model.Etablissement](docs/Etablissement.md)
 - [Model.EtablissementNonDiffusible](docs/EtablissementNonDiffusible.md)
 - [Model.EtatCollection](docs/EtatCollection.md)
 - [Model.Facette](docs/Facette.md)
 - [Model.Header](docs/Header.md)
 - [Model.LienSuccession](docs/LienSuccession.md)
 - [Model.PeriodeEtablissement](docs/PeriodeEtablissement.md)
 - [Model.PeriodeUniteLegale](docs/PeriodeUniteLegale.md)
 - [Model.RefusImmatriculationRCS](docs/RefusImmatriculationRCS.md)
 - [Model.Reponse](docs/Reponse.md)
 - [Model.ReponseEtablissement](docs/ReponseEtablissement.md)
 - [Model.ReponseEtablissementAllOf](docs/ReponseEtablissementAllOf.md)
 - [Model.ReponseEtablissements](docs/ReponseEtablissements.md)
 - [Model.ReponseEtablissementsAllOf](docs/ReponseEtablissementsAllOf.md)
 - [Model.ReponseEtablissementsNonDiffusibles](docs/ReponseEtablissementsNonDiffusibles.md)
 - [Model.ReponseInformations](docs/ReponseInformations.md)
 - [Model.ReponseLienSuccession](docs/ReponseLienSuccession.md)
 - [Model.ReponseRefusImmatriculationRCS](docs/ReponseRefusImmatriculationRCS.md)
 - [Model.ReponseUniteLegale](docs/ReponseUniteLegale.md)
 - [Model.ReponseUniteLegaleAllOf](docs/ReponseUniteLegaleAllOf.md)
 - [Model.ReponseUnitesLegales](docs/ReponseUnitesLegales.md)
 - [Model.ReponseUnitesLegalesAllOf](docs/ReponseUnitesLegalesAllOf.md)
 - [Model.ReponseUnitesLegalesNonDiffusibles](docs/ReponseUnitesLegalesNonDiffusibles.md)
 - [Model.UniteLegale](docs/UniteLegale.md)
 - [Model.UniteLegaleEtablissement](docs/UniteLegaleEtablissement.md)
 - [Model.UniteLegaleNonDiffusible](docs/UniteLegaleNonDiffusible.md)


<a name="documentation-for-authorization"></a>
## Documentation for Authorization

<a name="default"></a>
### default

- **Type**: OAuth
- **Flow**: implicit
- **Authorization URL**: undefined/authorize
- **Scopes**: N/A

