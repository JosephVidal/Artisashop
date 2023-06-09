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
    ///  Class for testing SearchGet200Response
    /// </summary>
    /// <remarks>
    /// This file is automatically generated by OpenAPI Generator (https://openapi-generator.tech).
    /// Please update the test case below to test the model.
    /// </remarks>
    public class SearchGet200ResponseTests : IDisposable
    {
        // TODO uncomment below to declare an instance variable for SearchGet200Response
        //private SearchGet200Response instance;

        public SearchGet200ResponseTests()
        {
            // TODO uncomment below to create an instance of SearchGet200Response
            //instance = new SearchGet200Response();
        }

        public void Dispose()
        {
            // Cleanup when everything is done.
        }

        /// <summary>
        /// Test an instance of SearchGet200Response
        /// </summary>
        [Fact]
        public void SearchGet200ResponseInstanceTest()
        {
            // TODO uncomment below to test "IsType" SearchGet200Response
            //Assert.IsType<SearchGet200Response>(instance);
        }


        /// <summary>
        /// Test the property 'Results'
        /// </summary>
        [Fact]
        public void ResultsTest()
        {
            // TODO unit test for the property 'Results'
        }
        /// <summary>
        /// Test the property 'TotalResults'
        /// </summary>
        [Fact]
        public void TotalResultsTest()
        {
            // TODO unit test for the property 'TotalResults'
        }
        /// <summary>
        /// Test the property 'Page'
        /// </summary>
        [Fact]
        public void PageTest()
        {
            // TODO unit test for the property 'Page'
        }
        /// <summary>
        /// Test the property 'PerPage'
        /// </summary>
        [Fact]
        public void PerPageTest()
        {
            // TODO unit test for the property 'PerPage'
        }
        /// <summary>
        /// Test the property 'TotalPages'
        /// </summary>
        [Fact]
        public void TotalPagesTest()
        {
            // TODO unit test for the property 'TotalPages'
        }

    }

}
