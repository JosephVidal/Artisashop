# SireneApi.Model.UniteLegaleEtablissement
Objet représentant les valeurs courante de l'unité légale de l'établissement

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
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
**EtatAdministratifUniteLegale** | **string** | État de l&#39;entreprise pendant la période (A&#x3D; entreprise active, C&#x3D; entreprise cessée) | [optional] 
**NomUniteLegale** | **string** | Nom de naissance pour les personnes physiques pour la période (null pour les personnes morales) | [optional] 
**DenominationUniteLegale** | **string** | Raison sociale (personnes morales) | [optional] 
**DenominationUsuelle1UniteLegale** | **string** | Premier nom sous lequel l’entreprise est connue du public | [optional] 
**DenominationUsuelle2UniteLegale** | **string** | Deuxième nom sous lequel l’entreprise est connue du public | [optional] 
**DenominationUsuelle3UniteLegale** | **string** | Troisième nom sous lequel l’entreprise est connue du public | [optional] 
**ActivitePrincipaleUniteLegale** | **string** | Activité principale de l&#39;entreprise pendant la période (l&#39;APE est codifiée selon la &lt;a href&#x3D;&#39;https://www.insee.fr/fr/information/2406147&#39;&gt;nomenclature d&#39;Activités Française (NAF)&lt;/a&gt; | [optional] 
**CategorieJuridiqueUniteLegale** | **string** | Catégorie juridique de l’entreprise (&#x3D;1000 pour les personnes physiques) | [optional] 
**NicSiegeUniteLegale** | **string** | Identifiant du siège pour la période (le Siret du siège est obtenu en concaténant le numéro Siren et le NIC) | [optional] 
**NomenclatureActivitePrincipaleUniteLegale** | **string** | Nomenclature de l&#39;activité, permet de savoir à partir de quelle nomenclature est codifiée ActivitePrincipale | [optional] 
**NomUsageUniteLegale** | **string** | Nom d’usage pour les personnes physiques sinon null | [optional] 
**EconomieSocialeSolidaireUniteLegale** | **string** | Appartenance de l’unité légale au champ de l’économie sociale et solidaire (ESS) | [optional] 
**SocieteMissionUniteLegale** | **string** | Appartenance de l’unité légale au champ societé à mission | [optional] [readonly] 
**CaractereEmployeurUniteLegale** | **string** | Caractère employeur de l&#39;entreprise. Valeur courante&#x3D;O si au moins l&#39;un des établissements actifs de l&#39;unité légale emploie des salariés | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

