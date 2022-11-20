# SireneApi.Model.ReponseInformations
Objet renvoyé en cas de requête demandant les informations sur le service

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**EtatService** | **string** | État actuel du service | [optional] 
**EtatsDesServices** | [**List&lt;EtatCollection&gt;**](EtatCollection.md) | Etats des services | [optional] 
**VersionService** | **string** | Numéro de la version | [optional] 
**JournalDesModifications** | **string** | Historique des versions de l&#39;API Sirene | [optional] 
**DatesDernieresMisesAJourDesDonnees** | [**List&lt;DatesMiseAJourDonnees&gt;**](DatesMiseAJourDonnees.md) | Dates des dernières mises à jour de chaque collection de données | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

