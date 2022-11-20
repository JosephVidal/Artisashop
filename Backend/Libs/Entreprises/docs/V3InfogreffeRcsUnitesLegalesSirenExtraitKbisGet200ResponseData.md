# EntreprisesApi.Model.V3InfogreffeRcsUnitesLegalesSirenExtraitKbisGet200ResponseData

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**DateExtrait** | **string** | Il s&#39;agit de la date d&#39;émission de l&#39;extrait RCS. | 
**DateImmatriculation** | **string** | Il s&#39;agit du jour d&#39;immatriculation de l&#39;entreprise au RCS. À compter de cette date, les sociétés jouissent de la personnalité morale. Cette date d&#39;immatriculation n&#39;est pas la même que celle délivrée par l&#39;Insee. Elle ne correspond pas non plus à la date du début d&#39;activité. | 
**MandatairesSociaux** | [**List&lt;MandatairesSociauxInner&gt;**](MandatairesSociauxInner.md) | Liste des mandataires sociaux d&#39;une société inscrite au RCS. Certaines informations telles que la date de naissance complète ne figurent pas dans cette API. Pour plus d&#39;exhaustivité, appeler l&#39;API Mandataires sociaux - Infogreffe. | 
**Observations** | [**List&lt;EnsembleDesObservationsDuGreffierInner&gt;**](EnsembleDesObservationsDuGreffierInner.md) | Ce champ regroupe tous les messages laissés par le greffier et inscrits dans les observations. | 
**NomCommercial** | **string** |  | 
**EtablissementPrincipal** | [**InformationsDeLTablissementPrincipal**](InformationsDeLTablissementPrincipal.md) |  | 
**Capital** | [**CapitalDeLEntreprise**](CapitalDeLEntreprise.md) |  | 
**Greffe** | [**Greffe**](Greffe.md) |  | 
**PersonnePhysique** | [**PersonnePhysique**](PersonnePhysique.md) |  | 
**PersonneMorale** | [**PersonneMorale**](PersonneMorale.md) |  | 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

