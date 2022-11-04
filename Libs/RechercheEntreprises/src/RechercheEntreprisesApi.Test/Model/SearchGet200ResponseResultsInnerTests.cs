/*
 * API Recherche d’entreprises
 *
 * # Bienvenue sur la documentation interactive d'API Recherche d’entreprises ! L’API Recherche d’entreprises permet à tout le monde de rechercher et de trouver  une entreprise française par sa dénomination, ou son adresse. ## Données accessibles dans l'API L’API étant totalement ouverte d'accès, elle comporte des limitations. Ainsi ne sont pas accessibles dans l'API : - les prédécesseurs et successeurs d'un établissement - les entreprises non-diffusibles - les entreprises qui se sont vues refuser leurs immatriculation au RCS  **Attention :** cette API ne permet pas d'accèder aux données complètes de  la  base Sirene, mais uniquement de rechercher une entreprise, par sa dénomination ou son adresse. Pour savoir comment obtenir les données complètes, consultez [notre fiche explicative.](https://api.gouv.fr/guides/quelle-api-sirene)  ## Commencer à utiliser l'API L'API est accessible à partir de cette adresse : [https://recherche-entreprises.api.gouv.fr](https://recherche-entreprises.api.gouv.fr)  **Attention :** Vous devez rajouter votre requête sur l’adresse. ## Limite des requêtes    Le serveur accepte un maximum de 7 requêtes par seconde. Au delà, un code 429 est renvoyé indiquant que la volumétrie d'appels a été dépassée.     ## Monitoring de l'API Une supervision du service en temps réel est disponible à cette adresse : [https://stats.uptimerobot.com/kXzwzfk7BE](https://stats.uptimerobot.com/kXzwzfk7BE) 
 *
 * The version of the OpenAPI document: 1.0.0
 * Contact: recherche-entreprises@api.gouv.fr
 * Generated by: https://github.com/openapitools/openapi-generator.git
 */


using Xunit;

using System;
using System.Linq;
using System.IO;
using System.Collections.Generic;
using RechercheEntreprisesApi.Api;
using RechercheEntreprisesApi.Model;
using RechercheEntreprisesApi.Client;
using System.Reflection;
using Newtonsoft.Json;

namespace RechercheEntreprisesApi.Test.Model
{
    /// <summary>
    ///  Class for testing SearchGet200ResponseResultsInner
    /// </summary>
    /// <remarks>
    /// This file is automatically generated by OpenAPI Generator (https://openapi-generator.tech).
    /// Please update the test case below to test the model.
    /// </remarks>
    public class SearchGet200ResponseResultsInnerTests : IDisposable
    {
        // TODO uncomment below to declare an instance variable for SearchGet200ResponseResultsInner
        //private SearchGet200ResponseResultsInner instance;

        public SearchGet200ResponseResultsInnerTests()
        {
            // TODO uncomment below to create an instance of SearchGet200ResponseResultsInner
            //instance = new SearchGet200ResponseResultsInner();
        }

        public void Dispose()
        {
            // Cleanup when everything is done.
        }

        /// <summary>
        /// Test an instance of SearchGet200ResponseResultsInner
        /// </summary>
        [Fact]
        public void SearchGet200ResponseResultsInnerInstanceTest()
        {
            // TODO uncomment below to test "IsType" SearchGet200ResponseResultsInner
            //Assert.IsType<SearchGet200ResponseResultsInner>(instance);
        }


        /// <summary>
        /// Test the property 'Siren'
        /// </summary>
        [Fact]
        public void SirenTest()
        {
            // TODO unit test for the property 'Siren'
        }
        /// <summary>
        /// Test the property 'Siege'
        /// </summary>
        [Fact]
        public void SiegeTest()
        {
            // TODO unit test for the property 'Siege'
        }
        /// <summary>
        /// Test the property 'DateCreation'
        /// </summary>
        [Fact]
        public void DateCreationTest()
        {
            // TODO unit test for the property 'DateCreation'
        }
        /// <summary>
        /// Test the property 'TrancheEffectifSalarie'
        /// </summary>
        [Fact]
        public void TrancheEffectifSalarieTest()
        {
            // TODO unit test for the property 'TrancheEffectifSalarie'
        }
        /// <summary>
        /// Test the property 'DateMiseAJour'
        /// </summary>
        [Fact]
        public void DateMiseAJourTest()
        {
            // TODO unit test for the property 'DateMiseAJour'
        }
        /// <summary>
        /// Test the property 'CategorieEntreprise'
        /// </summary>
        [Fact]
        public void CategorieEntrepriseTest()
        {
            // TODO unit test for the property 'CategorieEntreprise'
        }
        /// <summary>
        /// Test the property 'EtatAdministratif'
        /// </summary>
        [Fact]
        public void EtatAdministratifTest()
        {
            // TODO unit test for the property 'EtatAdministratif'
        }
        /// <summary>
        /// Test the property 'NomRaisonSociale'
        /// </summary>
        [Fact]
        public void NomRaisonSocialeTest()
        {
            // TODO unit test for the property 'NomRaisonSociale'
        }
        /// <summary>
        /// Test the property 'NatureJuridique'
        /// </summary>
        [Fact]
        public void NatureJuridiqueTest()
        {
            // TODO unit test for the property 'NatureJuridique'
        }
        /// <summary>
        /// Test the property 'ActivitePrincipale'
        /// </summary>
        [Fact]
        public void ActivitePrincipaleTest()
        {
            // TODO unit test for the property 'ActivitePrincipale'
        }
        /// <summary>
        /// Test the property 'SectionActivitePrincipale'
        /// </summary>
        [Fact]
        public void SectionActivitePrincipaleTest()
        {
            // TODO unit test for the property 'SectionActivitePrincipale'
        }
        /// <summary>
        /// Test the property 'EconomieSocialeSolidaire'
        /// </summary>
        [Fact]
        public void EconomieSocialeSolidaireTest()
        {
            // TODO unit test for the property 'EconomieSocialeSolidaire'
        }
        /// <summary>
        /// Test the property 'NomComplet'
        /// </summary>
        [Fact]
        public void NomCompletTest()
        {
            // TODO unit test for the property 'NomComplet'
        }
        /// <summary>
        /// Test the property 'NombreEtablissements'
        /// </summary>
        [Fact]
        public void NombreEtablissementsTest()
        {
            // TODO unit test for the property 'NombreEtablissements'
        }
        /// <summary>
        /// Test the property 'NombreEtablissementsOuverts'
        /// </summary>
        [Fact]
        public void NombreEtablissementsOuvertsTest()
        {
            // TODO unit test for the property 'NombreEtablissementsOuverts'
        }
        /// <summary>
        /// Test the property 'IsEntrepreneurIndividuel'
        /// </summary>
        [Fact]
        public void IsEntrepreneurIndividuelTest()
        {
            // TODO unit test for the property 'IsEntrepreneurIndividuel'
        }
        /// <summary>
        /// Test the property 'Dirigeants'
        /// </summary>
        [Fact]
        public void DirigeantsTest()
        {
            // TODO unit test for the property 'Dirigeants'
        }

    }

}
