# SireneApi.Model.PeriodeUniteLegale
Ensemble des variables historisées de l'unité légale entre dateDebut et dateFin

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**DateFin** | **DateTime** | Date de fin de la période, null pour la dernière période, format AAAA-MM-DD | [optional] 
**DateDebut** | **DateTime** | Date de début de la période, format AAAA-MM-DD | [optional] 
**EtatAdministratifUniteLegale** | **string** | État de l&#39;entreprise pendant la période (A&#x3D; entreprise active, C&#x3D; entreprise cessée) | [optional] 
**ChangementEtatAdministratifUniteLegale** | **bool** | Indicatrice de changement d&#39;état par rapport à la période précédente | [optional] 
**NomUniteLegale** | **string** | Nom de naissance pour les personnes physiques pour la période (null pour les personnes morales) | [optional] 
**ChangementNomUniteLegale** | **bool** | Indicatrice de changement du nom par rapport à la période précédente | [optional] 
**NomUsageUniteLegale** | **string** | Nom d’usage pour les personnes physiques si celui-ci existe, null pour les personnes morales | [optional] 
**ChangementNomUsageUniteLegale** | **bool** | Indicatrice de changement du nom d&#39;usage par rapport à la période précédente | [optional] 
**DenominationUniteLegale** | **string** | Raison sociale (personnes morales) | [optional] 
**ChangementDenominationUniteLegale** | **bool** | Indicatrice de changement de la dénomination par rapport à la période précédente | [optional] 
**DenominationUsuelle1UniteLegale** | **string** | Premier nom sous lequel l’entreprise est connue du public | [optional] 
**DenominationUsuelle2UniteLegale** | **string** | Deuxième nom sous lequel l’entreprise est connue du public | [optional] 
**DenominationUsuelle3UniteLegale** | **string** | Troisième nom sous lequel l’entreprise est connue du public | [optional] 
**ChangementDenominationUsuelleUniteLegale** | **bool** | Indicatrice de changement de la dénomination usuelle de l&#39;unité légale par rapport à la période précédente (un seul indicateur pour les trois variables denominationUsuelle1UniteLegale, denominationUsuelle2UniteLegale et denominationUsuelle3UniteLegale) | [optional] 
**CategorieJuridiqueUniteLegale** | **string** | Catégorie juridique de l&#39;entreprise (variable Null pour les personnes physiques. (&lt;a href&#x3D;&#39;https://www.insee.fr/fr/information/2028129&#39;&gt;la nomenclature sur insee.fr&lt;/a&gt;)) | [optional] 
**ChangementCategorieJuridiqueUniteLegale** | **bool** | Indicatrice de changement de la catégorie juridique par rapport à la période précédente | [optional] 
**ActivitePrincipaleUniteLegale** | **string** | Activité principale de l&#39;entreprise pendant la période (l&#39;APE est codifiée selon la &lt;a href&#x3D;&#39;https://www.insee.fr/fr/information/2406147&#39;&gt;nomenclature d&#39;Activités Française (NAF)&lt;/a&gt; | [optional] 
**NomenclatureActivitePrincipaleUniteLegale** | **string** | Nomenclature de l&#39;activité, permet de savoir à partir de quelle nomenclature est codifiée ActivitePrincipale | [optional] 
**ChangementActivitePrincipaleUniteLegale** | **bool** | Indicatrice de changement de l&#39;activité principale par rapport à la période précédente | [optional] 
**NicSiegeUniteLegale** | **string** | Identifiant du siège pour la période (le Siret du siège est obtenu en concaténant le numéro Siren et le Nic) | [optional] 
**ChangementNicSiegeUniteLegale** | **bool** | Indicatrice de changement du NIC du siège par rapport à la période précédente | [optional] 
**EconomieSocialeSolidaireUniteLegale** | **string** | Appartenance de l’unité légale au champ de l’économie sociale et solidaire (ESS) | [optional] 
**ChangementEconomieSocialeSolidaireUniteLegale** | **bool** | Indicatrice de changement de l&#39;ESS par rapport à la période précédente | [optional] 
**SocieteMissionUniteLegale** | **string** | Appartenance de l’unité légale au champ société à mission (SM) | [optional] 
**ChangementSocieteMissionUniteLegale** | **bool** | Indicatrice de changement du champ société à mission par rapport à la période précédente | [optional] 
**CaractereEmployeurUniteLegale** | **string** | Caractère employeur de l&#39;entreprise. Valeur courante&#x3D;O si au moins l&#39;un des établissements actifs de l&#39;unité légale emploie des salariés | [optional] 
**ChangementCaractereEmployeurUniteLegale** | **bool** | Indicatrice de changement du caractère employeur par rapport à la période précédente | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

