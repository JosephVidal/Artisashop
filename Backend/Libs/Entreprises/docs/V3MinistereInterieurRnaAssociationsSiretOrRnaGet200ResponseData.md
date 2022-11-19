# EntreprisesApi.Model.V3MinistereInterieurRnaAssociationsSiretOrRnaGet200ResponseData

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**RnaId** | **string** |  | 
**Titre** | **string** |  | 
**Objet** | **string** | Il s&#39;agit d&#39;une description courte mais exhaustive des activités de l&#39;organisme. | 
**Siret** | **string** |  | 
**SiretSiegeSocial** | **string** |  | 
**DateCreation** | **string** | Il s&#39;agit du jour de dépôt du dossier de création de l&#39;association à la Préfecture. | 
**DateDeclaration** | **string** | Jour de la dernière déclaration faîte par l&#39;association. | 
**DatePublication** | **string** | Jour de la publication au journal officiel de l&#39;avis de création de l&#39;association. Toutes les assoiations ne sont pas forcément &#39;déclarées&#39;. La publication au Journal Officiel permet à l&#39;association de devenir une personne morale, a contrario des &#39;associations de fait&#39;, non déclarées au JO. | 
**DateDissolution** | **string** | Si l&#39;association est dissolue, ce champ indique la date de dissolution, autrement, il est indiqué &#39;null&#39;. | 
**AdresseSiege** | [**V3MinistereInterieurRnaAssociationsSiretOrRnaGet200ResponseDataAdresseSiege**](V3MinistereInterieurRnaAssociationsSiretOrRnaGet200ResponseDataAdresseSiege.md) |  | 
**Etat** | **string** |  | 
**Groupement** | **string** | Trois modalités possibles : si l&#39;association n&#39;est pas un groupement, il est indiqué &#39;Simple&#39; ; si l&#39;association est un groupement, la valeur est &#39;Union&#39; ou &#39;Fédération&#39;. La valeur peut aussi être manquante (null) | 
**MiseAJour** | **string** |  | 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

