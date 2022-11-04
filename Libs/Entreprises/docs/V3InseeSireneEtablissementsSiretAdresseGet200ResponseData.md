# EntreprisesApi.Model.V3InseeSireneEtablissementsSiretAdresseGet200ResponseData

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**NumeroVoie** | **string** |  | 
**IndiceRepetitionVoie** | **string** | Plus d&#39;informations dans la documentation Insee de l&#39;API Sirene : https://www.sirene.fr/sirene/public/variable/indrep | 
**TypeVoie** | **string** | Le type de la voie de localisation est indiquée en abrégé et en majuscules. L&#39;information n&#39;est pas toujours renseignée. Pour certaines petites communes, l&#39;information n&#39;existe pas.     Plus d&#39;informations dans la documentation Insee de l&#39;API Sirene : https://www.sirene.fr/sirene/public/variable/typvoie | 
**LibelleVoie** | **string** |  | 
**ComplementAdresse** | **string** | Le complément d&#39;adresse correspond à des éléments situés à l&#39;extérieur du bâtiment qui permettent de compléter l&#39;adresse (résidence, bâtiment, entrée, etc..) | 
**CodeCommune** | **string** | Le code commune désigne le code de la commune de localisation de l&#39;établissement. Le code renvoyé correspond à la date de l&#39;appel, ce qui implique que toute modification du code commune est repercutée sur l&#39;ensemble des établissements concernés, y compris ceux qui sont fermés. Cette valeur est à &#39;null&#39; pour les entreprises à l&#39;étranger.     Les codes sont listés dans la table d&#39;appartenance géographique fournie par l&#39;Insee et disponible ici: https://www.insee.fr/fr/information/2028028 | 
**CodePostal** | **string** |  | 
**DistributionSpeciale** | **string** | La distribution spéciale reprend les éléments particuliers qui accompagnent une adresse de distribution spéciale, la modalité la plus connue étant les adresses en &#39;CEDEX&#39;.     Plus d&#39;informations dans la documentation Insee de l&#39;API Sirene : * https://www.sirene.fr/sirene/public/variable/distributionSpecialeEtablissement * https://www.sirene.fr/sirene/public/variable/l5-disp | 
**CodeCedex** | **string** | Plus d&#39;informations : https://fr.wikipedia.org/wiki/Courrier_d%27entreprise_%C3%A0_distribution_exceptionnelle | 
**LibelleCedex** | **string** | Ce champ indique le libellé correspondant au code cedex de l&#39;établissement. Si le code cedex est à &#39;null&#39;, ce champ est également à &#39;null&#39;. | 
**LibelleCommune** | **string** | Cette valeur est à &#39;null&#39; pour les établissements à l&#39;étranger. | 
**LibelleCommuneEtranger** | **string** | Cette valeur est à &#39;null&#39; pour les établissements en France. | 
**CodePaysEtranger** | **string** | La nomenclature des codes pays se trouve ici: https://www.insee.fr/fr/information/2028273 | 
**LibellePaysEtranger** | **string** |  | 
**AcheminementPostal** | [**LMentsConstitutifsDeLAdressePostalePourSonAcheminement**](LMentsConstitutifsDeLAdressePostalePourSonAcheminement.md) |  | 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

