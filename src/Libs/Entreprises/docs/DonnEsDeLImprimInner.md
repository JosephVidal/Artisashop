# EntreprisesApi.Model.DonnEsDeLImprimInner

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Code** | **string** | Code permettant d&#39;identifier la donnée, constitué de 2 lettres de AA à ZZ (cf. Code EDI) | [optional] 
**CodeEDI** | **string** | Le code EDI est utilisé lorsque la liasses fiscale a été souscrite via la filière EDI/TDFC. Il permet l’échange des données de nature comptable et/ou fiscale avec la norme EDIFACT entre la DGFIP et les utilisateurs des téléprocédures EDI  | [optional] 
**CodeAbsolu** | **string** | Ce code interne à la DGFIP identifie une seule donnée sur un seul formulaire | [optional] 
**CodeTypeDonnee** | **string** | Ce code détermine la nature de la donnée, le nombre et type des caractères qu’elle peut contenir | [optional] 
**Intitule** | **string** | Intitulé de la donnée. Désigne une donnée correspondant à une case à cocher présente en haut de certains tableaux de la liasse fiscale | [optional] 
**CodeNref** | **string** |  | 
**Valeurs** | **List&lt;string&gt;** | Si une entrée de l&#39;imprimé est répétable, le tableau contient plusieurs entrées et sont ordonnées en fonction de l&#39;indice de répétition. | 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

