# EntreprisesApi.Model.V3InseeSireneUnitesLegalesSirenGet200ResponseData

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**SiretSiegeSocial** | **string** |  | 
**Type** | **string** | Indique si l&#39;unité légale est une personne morale ou une personne physique. Cette valeur est déterminée à l&#39;aide du code juridique : &#39;1000&#39; correspondant à une personne physique. | 
**PersonneMoraleAttributs** | [**AttributsDeLaPersonneMorale**](AttributsDeLaPersonneMorale.md) |  | 
**PersonnePhysiqueAttributs** | [**AttributsDeLaPersonnePhysique**](AttributsDeLaPersonnePhysique.md) |  | 
**CategorieEntreprise** | **string** | Il s&#39;agit d&#39;une variable statistique calculée par l&#39;Insee. Elle ne peut prendre que 3 valeurs:     - GE: Grande Entreprise   - ETI: Entreprise de Taille Intermédiaire   - PME: Petite ou Moyenne Entreprise     Celle-ci peut-être &#39;null&#39; dans certains cas : quand il s’agit d’une unité légale nouvellement créée, ou bien d’une unité légale cessée, ou encore d’une unité légale hors champ du calcul de la catégorie (unité légale agricole ou ne faisant pas partie du système productif).     Définition de &#39;catégorie d&#39;entreprise&#39; par l&#39;Insee : https://www.insee.fr/fr/metadonnees/definition/c1057 | 
**DiffusableCommercialement** | **bool** | Indique si l&#39;unité légale est :     - une unité légale diffusible : &#39;true&#39;   - une unité légale non-diffusible : &#39;false&#39;. Dans ce cas, les informations obtenues ne doivent en aucun cas être accessibles au grand public.     Plus d&#39;informations sur les conditions de diffusion : LIEN TODO | 
**FormeJuridique** | [**AttributsDeLaFormeJuridique**](AttributsDeLaFormeJuridique.md) |  | 
**ActivitePrincipale** | [**AttributsDeLActivitPrincipale1**](AttributsDeLActivitPrincipale1.md) |  | 
**TrancheEffectifSalarie** | [**TrancheDEffectifSalariDeLUnitLGale**](TrancheDEffectifSalariDeLUnitLGale.md) |  | 
**EtatAdministratif** | **string** | Cette valeur décrit l&#39;état administratif de l&#39;unité légale, qui peut être :     - cessée. Le passage à l&#39;état « Cessée » découle de la prise en compte d&#39;une déclaration de cessation administrative. Pour les personnes morales, cela correspond au dépôt de la déclaration de disparition de la personne morale. Pour les personnes physiques, cela correspond soit à la prise en compte de la déclaration de cessation d&#39;activité déposée par l&#39;exploitant soit au décès de l&#39;exploitant conformément à la réglementation.   - active. En dehors des cas explicités ci-dessus, l&#39;unité légale est toujours à l&#39;état administratif « Active ».     Plus d&#39;informations dans la documentation Insee de l&#39;API Sirene : https://www.sirene.fr/sirene/public/variable/etatAdministratifUniteLegale | 
**DateCreation** | **int** | La date de création correspond à la date qui figure dans les statuts de l&#39;entreprise qui sont déposés au centre de formalité des entreprises (CFE) compétent. Cette valeur est renvoyée sous format timestamp.     Saufpour les unités purgées, la date de création n&#39;est jamais à &#39;null&#39;. Si elle est non renseignée, elle sera au 01/01/1900.     Plus d&#39;informations dans la documentation Insee de l&#39;API Sirene : https://www.sirene.fr/sirene/public/variable/dateCreationUniteLegale | 
**DateCessation** | **int?** | Cette valeur est renvoyée sous format timestamp. Si l&#39;entreprise est juridique active, cette valeur est à &#39;null&#39;. | 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

