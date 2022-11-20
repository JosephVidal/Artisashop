# EntreprisesApi.Model.V3InseeSireneEtablissementsDiffusiblesSiretGet200ResponseData

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**SiegeSocial** | **bool** | Indique si l&#39;établissement est le siège social de l&#39;entreprise. | 
**EtatAdministratif** | **string** | Cette valeur décrit l&#39;état administratif de l&#39;établissement, qui peut être :     - actif. Sauf exception, lors de son inscription au répertoire, tout établissement est à l&#39;état &#39;actif&#39;   - fermé. Cet état découle de la prise en compte d&#39;une déclaration de fermeture. Un établissement fermé peut être rouvert.     Plus d&#39;informations dans la documentation Insee de l&#39;API Sirene : https://www.sirene.fr/sirene/public/variable/etatAdministratifEtablissement | 
**DateFermeture** | **int?** | Cette valeur est renvoyée sous format timestamp | 
**ActivitePrincipale** | [**AttributsDeLActivitPrincipale**](AttributsDeLActivitPrincipale.md) |  | 
**TrancheEffectifSalarie** | [**TrancheDEffectifSalariDeLTablissement**](TrancheDEffectifSalariDeLTablissement.md) |  | 
**DiffusableCommercialement** | **bool** | Détermine si l&#39;établissement est non-diffusible. Cette API n&#39;appelant pas les non-diffusible, cette valeur est toujours à &#39;true&#39;. Pour récupérer des établissements non-diffusibles, référez-vous à la documentation de l&#39;API /insee/etablissements/:siren | 
**Enseigne** | **string** | L&#39;enseigne est l&#39;appellation désignant l&#39;emplacement ou le local dans lequel est exercée l&#39;activité. Un établissement peut posséder une enseigne, plusieurs enseignes ou aucune.     Cette variable est la concaténation séparée par des virgules des 3 champs \&quot;renvoyés\&quot; par l&#39;Insee. Plus d&#39;informations ici: https://www.sirene.fr/sirene/public/variable/enseigne1Etablissement | 
**UniteLegale** | [**UnitLGaleDeLTablissement**](UnitLGaleDeLTablissement.md) |  | 
**Adresse** | [**AdresseDeLTablissement**](AdresseDeLTablissement.md) |  | 
**DateCreation** | **int** |  | 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

