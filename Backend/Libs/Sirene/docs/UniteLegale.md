# SireneApi.Model.UniteLegale
Objet représentant une unité légale et son historique

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Score** | **float** | Score de l&#39;élément parmi l&#39;ensemble des éléments répondant à la requête, plus le score est élevé, plus l&#39;élément est haut placé. Le score n&#39;a pas de signification en dehors de la requête et n&#39;est pas comparable aux score d&#39;autres requêtes | [optional] 
**Siren** | **string** | Numéro Siren de l&#39;entreprise, toujours renseigné | [optional] 
**StatutDiffusionUniteLegale** | **string** | Statut de diffusion de l’unité légale | [optional] 
**UnitePurgeeUniteLegale** | **bool** | True si l&#39;unité est une unité purgée | [optional] 
**DateCreationUniteLegale** | **string** | Date de création de l&#39;unité légale, au format AAAA-MM-JJ | [optional] 
**SigleUniteLegale** | **string** | Sigle de l&#39;unité légale | [optional] 
**SexeUniteLegale** | **string** | Sexe pour les personnes physiques sinon null | [optional] 
**Prenom1UniteLegale** | **string** | Premier prénom déclaré pour une personne physique, peut être null dans le cas d&#39;une unité purgée | [optional] 
**Prenom2UniteLegale** | **string** | Deuxième prénom déclaré pour une personne physique | [optional] 
**Prenom3UniteLegale** | **string** | Troisième prénom déclaré pour une personne physique | [optional] 
**Prenom4UniteLegale** | **string** | Quatrième prénom déclaré pour une personne physique | [optional] 
**PrenomUsuelUniteLegale** | **string** | Prénom usuel pour les personne physiques, correspond généralement au Prenom1 | [optional] 
**PseudonymeUniteLegale** | **string** | Pseudonyme pour les personnes physiques | [optional] 
**IdentifiantAssociationUniteLegale** | **string** | Numéro au Répertoire National des Associations | [optional] 
**TrancheEffectifsUniteLegale** | **string** | Tranche d&#39;effectif salarié de l&#39;unité légale, valorisé uniquement si l&#39;année correspondante est supérieure ou égale à l&#39;année d&#39;interrogation-3 (sinon, NN) | [optional] 
**AnneeEffectifsUniteLegale** | **string** | Année de validité de la tranche d&#39;effectif salarié de l&#39;unité légale, valorisée uniquement si l&#39;année est supérieure ou égale à l&#39;année d&#39;interrogation-3 (sinon, null) | [optional] 
**DateDernierTraitementUniteLegale** | **string** | Date de la dernière mise à jour effectuée au répertoire Sirene sur le Siren concerné, format AAAA-MM-JJTHH:MM:SS | [optional] 
**NombrePeriodesUniteLegale** | **int** | Nombre de périodes dans la vie de l&#39;unité légale | [optional] 
**CategorieEntreprise** | **string** | Catégorie à laquelle appartient l&#39;entreprise : Petite ou moyenne entreprise, Entreprise de taille intermédiaire, Grande entreprise | [optional] 
**AnneeCategorieEntreprise** | **string** | Année de validité de la catégorie d&#39;entreprise | [optional] 
**PeriodesUniteLegale** | [**List&lt;PeriodeUniteLegale&gt;**](PeriodeUniteLegale.md) |  | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

