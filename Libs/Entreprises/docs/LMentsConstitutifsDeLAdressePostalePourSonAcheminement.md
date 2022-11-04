# EntreprisesApi.Model.LMentsConstitutifsDeLAdressePostalePourSonAcheminement
Il ne s'agit pas d'un traitement RNVP mais simplement d'une réorganisation des éléments renvoyé par l'Insee pour faciliter l'affichage des adresses postales

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**L1** | **string** | Si l&#39;établissement correspond à une personne morale: la dénomination sociale de la personne morale. Le cas contraire: cette variable est vide. | 
**L2** | **string** | Si l&#39;établissement correspond à une personne physique: concaténation du nom et prénom | 
**L3** | **string** | Complément d&#39;adresse comme décrit dans la clé &#x60;complement_adresse&#x60; | 
**L4** | **string** | Concaténation du numéro de voie, d&#39;indice de répétition, du type de voie et du libellé de la voie | 
**L5** | **string** | Distribution spéciale comme décrit dans la clé &#x60;distribution_speciale&#x60; | 
**L6** | **string** | Si le code cedex est existant: code cedex accompagné de son libellé ; sinon, si le pays est en France: code postal accompagné de son libellé, sinon : libellé de la commune de l&#39;établissement situé à l&#39;étranger | 
**L7** | **string** | Pays de l&#39;établissement | 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

