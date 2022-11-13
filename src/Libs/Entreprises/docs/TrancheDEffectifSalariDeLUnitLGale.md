# EntreprisesApi.Model.TrancheDEffectifSalariDeLUnitLGale

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Code** | **string** | Le code effectif indique la tranche d&#39;effectif salarié de l&#39;unité légale. Le nombre de salarié est déterminé en fonction de l&#39;effectif de chacun des établissements de l&#39;unité légale :     - NN : Unités non employeuses (pas de salarié au cours de l&#39;année de référence et pas d&#39;effectif au 31/12). Cette tranche peut contenir quelques effectifs inconnus   - 00 : 0 salarié (n&#39;ayant pas d&#39;effectif au 31/12 mais ayant employé des salariés au cours de l&#39;année de référence)   - 01 : 1 ou 2 salariés   - 02 : 3 à 5 salariés   - 03 : 6 à 9 salariés   - 11 : 10 à 19 salariés   - 12 : 20 à 49 salariés   - 21 : 50 à 99 salariés   - 22 : 100 à 199 salariés   - 31 : 200 à 249 salariés   - 32 : 250 à 499 salariés   - 41 : 500 à 999 salariés   - 42 : 1 000 à 1 999 salariés   - 51 : 2 000 à 4 999 salariés   - 52 : 5 000 à 9 999 salariés   - 53 : 10 000 salariés et plus     Plus d&#39;informations dans la documentation Insee de l&#39;API Sirene : https://www.sirene.fr/sirene/public/variable/tefen.     L&#39;effectif exact de l&#39;entreprise, mensuel et annuel, est disponible au travers de l&#39;[API Effectifs - URSSAF Caisse nationale](TODO). Si votre jeton contient ce droit d&#39;accès, nous vous recommandons d&#39;utiliser cette API. Ces données étant protégées, leur cadre d&#39;utilisation est différent de la tranche effectif fournie par l&#39;Insee, qui elle est une donnée publique. | 
**Intitule** | **string** |  | 
**DateReference** | **string** |  | 
**De** | **int?** |  | 
**A** | **int?** |  | 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

