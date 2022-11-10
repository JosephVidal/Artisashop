# SireneApi.Model.PeriodeEtablissement
Ensemble des variables historisées de l'établissement entre dateDebut et dateFin

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**DateFin** | **DateTime** | Date de fin de la période, null pour la dernière période, format AAAA-MM-DD | [optional] 
**DateDebut** | **DateTime** | Date de début de la période, format AAAA-MM-DD | [optional] 
**EtatAdministratifEtablissement** | **string** | État administratif de l&#39;établissement pendant la période (A&#x3D; établissement actif ; F&#x3D; établissement fermé) | [optional] 
**ChangementEtatAdministratifEtablissement** | **bool** | Indicatrice de changement de l&#39;état administratif de l&#39;établissement par rapport à la période précédente | [optional] 
**Enseigne1Etablissement** | **string** | Première ligne d&#39;enseigne | [optional] 
**Enseigne2Etablissement** | **string** | Deuxième ligne d&#39;enseigne | [optional] 
**Enseigne3Etablissement** | **string** | Troisième ligne d&#39;enseigne | [optional] 
**ChangementEnseigneEtablissement** | **bool** | Indicatrice de changement de l&#39;enseigne de l&#39;établissement par rapport à la période précédente (un seul indicateur pour les trois variables Enseigne1, Enseigne2 et Enseigne3) | [optional] 
**DenominationUsuelleEtablissement** | **string** | Nom sous lequel l’activité de l’établissement est connu du public  | [optional] 
**ChangementDenominationUsuelleEtablissement** | **bool** | Indicatrice de changement de la dénomination usuelle de l’établissement par rapport à la période précédente | [optional] 
**ActivitePrincipaleEtablissement** | **string** | Activité principale de l&#39;établissement pendant la période (l&#39;APE est codifiée selon la &lt;a href&#x3D;&#39;https://www.insee.fr/fr/information/2406147&#39;&gt;nomenclature d&#39;Activités Française (NAF)&lt;/a&gt; | [optional] 
**NomenclatureActivitePrincipaleEtablissement** | **string** | Nomenclature de l&#39;activité, permet de savoir à partir de quelle nomenclature est codifiée ActivitePrincipaleEtablissement | [optional] 
**ChangementActivitePrincipaleEtablissement** | **bool** | Indicatrice de changement de l&#39;activité principale de l&#39;établissement par rapport à la période précédente | [optional] 
**CaractereEmployeurEtablissement** | **string** | Caractère employeur de l&#39;établissement (O&#x3D;oui ; N&#x3D;non ; null&#x3D;sans objet) | [optional] 
**ChangementCaractereEmployeurEtablissement** | **bool** | Indicatrice de changement du caractère employeur de l&#39;établissement par rapport à la période précédente | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

