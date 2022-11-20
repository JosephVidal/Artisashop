# EntreprisesApi.Model.AttributsDeLActivitPrincipale

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Code** | **string** | Le code APE (activité principale exercée) permet d&#39;identifier la branche d&#39;activité principale. Il est attribué par l&#39;Insee lors de l&#39;immatriculation ou la déclaration d&#39;activité de l&#39;entreprise. Ce code de 4 chiffres + 1 lettre est extrait de la nomenclature d&#39;activité française (NAF) de l&#39;Insee.     À noter qu&#39;un établissement n&#39;ayant pas encore de code APE peut se voir affecter la valeur &#39;00.00Z&#39; de manière provisoire.     Plus d&#39;informations métier : https://entreprendre.service-public.fr/vosdroits/F33050 Nomemclature d&#39;activité française - NAF rév.2 de l&#39;Insee : https://www.insee.fr/fr/information/2120875 | 
**Libelle** | **string** | Libellé associé au code APE. Si le code n&#39;est pas renseigné dans la nomenclature &#39;Naf Rév2&#39; (nomenclature en vigueur), le libellé n&#39;est pas renseigné ici. Si le code ne correspond à aucun libellé au sein de la nomenclature &#39;Naf Rév2&#39;, la valeur &#39;non référencé&#39; est utilisée.     Nomemclature d&#39;activité française - NAF rév.2 de l&#39;Insee : https://www.insee.fr/fr/information/2406147 | 
**Nomenclature** | **string** | Ce champ indique le nom de la nomenclature associée au code APE. | 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

