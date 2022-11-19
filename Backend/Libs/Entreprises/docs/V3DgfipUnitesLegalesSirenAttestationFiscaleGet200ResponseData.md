# EntreprisesApi.Model.V3DgfipUnitesLegalesSirenAttestationFiscaleGet200ResponseData

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**DocumentUrl** | **string** | Ce lien donne accès à l&#39;attestation fiscale, au format PDF. L&#39;attestation, toujours datée du 31/12 de l’année précédente, atteste que l&#39;entreprise est à jour de ses obligations fiscales jusqu&#39;à cette date.     Par exemple, vous appelez l&#39;API en mars 2022, l’attestation fiscale renvoyée indique que l’entreprise est à jour de ses obligations fiscales lui incombant au 31/12/2021.     L’attestation fiscale est valide un an sur une année civile (jusqu’au 31/12/AAAA). | 
**ExpiresIn** | **int** | Nombre de secondes avant l&#39;expiration de l&#39;url associée à l&#39;attribut document_url : cette durée correspond généralement à 3 mois. | 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

