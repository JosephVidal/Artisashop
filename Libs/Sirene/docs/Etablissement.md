# SireneApi.Model.Etablissement
Objet représentant un établissement et son historique

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Score** | **float** | Score de l&#39;élément parmi l&#39;ensemble des éléments répondant à la requête, plus le score est élevé, plus l&#39;élément est haut placé. Le score n&#39;a pas de signification en dehors de la requête et n&#39;est pas comparable aux score d&#39;autres requêtes | [optional] 
**Siren** | **string** | Numéro Siren de l&#39;entreprise à laquelle appartient l&#39;établissement | [optional] 
**Nic** | **string** | Numéro interne de classement de l&#39;établissement | [optional] 
**Siret** | **string** | Numéro Siret de l’établissement (toujours renseigné) | [optional] 
**StatutDiffusionEtablissement** | **string** | Statut de diffusion de l&#39;établissement | [optional] 
**DateCreationEtablissement** | **string** | Date de création de l&#39;établissement, format AAAA-MM-JJ | [optional] 
**TrancheEffectifsEtablissement** | **string** | Tranche d’effectif salarié de l’établissement, valorisée uniquement si l’année correspondante est supérieure ou égale à l’année d’interrogation -3 (sinon, NN) | [optional] 
**AnneeEffectifsEtablissement** | **string** | Année de la tranche d’effectif salarié de l’établissement, valorisée uniquement si l&#39;année est supérieure ou égale à l’année d’interrogation -3 (sinon, null) | [optional] 
**ActivitePrincipaleRegistreMetiersEtablissement** | **string** | Code de l’activité exercée par l’artisan inscrit au registre des métiers. L’APRM est codifiée selon la nomenclature d’Activités Française de l’Artisanat (NAFA) | [optional] 
**DateDernierTraitementEtablissement** | **string** | Date de la dernière mise à jour effectuée au répertoire Sirene sur le Siret concerné (AAAA-MM-JJTHH:MM:SS) | [optional] 
**EtablissementSiege** | **bool** | Indicatrice précisant si le Siret est celui de l’établissement siège ou non | [optional] 
**NombrePeriodesEtablissement** | **int** | Nombre de périodes dans la vie de l&#39;établissement | [optional] 
**UniteLegale** | [**UniteLegaleEtablissement**](UniteLegaleEtablissement.md) |  | [optional] 
**AdresseEtablissement** | [**Adresse**](Adresse.md) |  | [optional] 
**Adresse2Etablissement** | [**AdresseComplementaire**](AdresseComplementaire.md) |  | [optional] 
**PeriodesEtablissement** | [**List&lt;PeriodeEtablissement&gt;**](PeriodeEtablissement.md) |  | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

