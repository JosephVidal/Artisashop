# EntreprisesApi.Model.V3DgfipUnitesLegalesSirenLiassesFiscalesYearGet200ResponseDataDeclarationsInner

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**NumeroImprime** | **string** | Numéro du formulaire de la liasse fiscale souscrit par l’unité légale. | 
**Regime** | [**RGimeDImpositionApplicableAuRSultatFiscalDeLUnitLGale**](RGimeDImpositionApplicableAuRSultatFiscalDeLUnitLGale.md) |  | 
**DateDeclaration** | **string** |  - Si télédéclaration : date de saisie   - Si dépôt papier : date de réception par les Services des Impôts des Entreprises | 
**DateFinExercice** | **string** | Équivalent à la date de fin de la période d&#39;imposition | 
**DureeExercice** | **decimal** | Durée de l’exercice fiscal calculée à partir des dates de début et de fin de la période d’imposition déclarées sur la déclaration souscrite par l&#39;unité légale.     Généralement cette valeur est de 365 jours, mais parfois 180 jours. Il y a une obligation fiscale déclarative au 31/12 de chaque année même s’il s’agit d’un dépôt provisoire. | 
**Millesime** | **string** | Code composé de 6 caractères:   - 4 caractères correspondant à l&#39;année de création ou modification du formulaire. Les valeurs possibles vont de 2006 à l&#39;année courante dès avril, l&#39;année précédente sinon.   - 2 caractères correspondant au numéro de version du formulaire, commençant à 01 | 
**Donnees** | [**List&lt;DonnEsDeLImprimInner&gt;**](DonnEsDeLImprimInner.md) | Chaque entrée du tableau correspondant à couple code / valeur, spécifique au numéro d&#39;imprimé référencé à la clé &#x60;numero_imprime&#x60; | 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

