# SireneApi.Model.Facette
Objet représentant une facette (un ensemble de comptages selon un champ, une requête ou une série d'intervalles)

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Nom** | **string** | Nom de la facette | [optional] 
**Manquants** | **int** | Nombre d&#39;éléments pour lesquels la facette vaut null | [optional] 
**Total** | **long** | Nombre total d&#39;éléments ayant une valeur non nulle pour la facette | [optional] 
**Modalites** | **int** | Nombre de valeurs distinctes pour la facette | [optional] 
**Avant** | **int** | Nombre d&#39;éléments dont la valeur est inférieure au premier intervalle, uniquement pour les facettes de type intervalle | [optional] 
**Apres** | **int** | Nombre d&#39;éléments dont la valeur est supérieure au dernier intervalle, uniquement pour les facettes de type intervalle | [optional] 
**Entre** | **int** | Nombre d&#39;élements compris entre la borne inférieure du premier intervalle et la borne supérieure du dernier intervalle, uniquement pour les facettes de type intervalle | [optional] 
**Comptages** | [**List&lt;Comptage&gt;**](Comptage.md) |  | [optional] 
**Facettes** | [**List&lt;Facette&gt;**](Facette.md) |  | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

