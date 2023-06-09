/*
 * API Sirene
 *
 * <p><span style=\"color:red;\"> <b></b></p><br></span><span style=\"color:blue;\"> <b>Les tranches d’effectifs et les catégories d’entreprises du millésime 2020 sont désormais disponibles</b></span> <br><br><span style=\"color:blue;\"><i>La documentation des services est désormais au format html (Cf. Onglet Documentation)</i></span></p> <p><h4 class=\"add-margin-top-5x\"><b>Les données du répertoire Sirene depuis 1973</b></h4><p>API Sirene donne accès aux informations concernant les entreprises et les établissements enregistrés au répertoire interadministratif Sirene depuis sa création en 1973, y compris les unités fermées.</p> <p>La recherche peut être unitaire, multicritère, phonétique et porter sur les données courantes et historisées.</p> <p></p> <p>Les services actuellement disponibles interrogent :</p> <ul> <li> les unités légales (siren) </li> <li> les établissements (siret). </li> </ul> <p>Le service informations permet de connaître les dates de dernières mises à jour.</p> <p>Le service Liens de succession informe sur les prédécesseurs et les successeurs des établissements.</p> <p align=\"justify\" style=\"margin-top: 0.6cm\">Le service nonDiffusibles restitue les siren et siret des personnes physiques ayant demandé à être exclues de la diffusion publique conformément à l'article A123-96 du code de commerce. Les informations les concernant ne peuvent alors être rediffusées, ni utilisées à des fins de prospection. Les utilisateurs ayant un référentiel en interne peuvent ainsi le mettre à jour quotidiennement.</p> <p>La lettre <b>Sirene open data actualités</b> est destinée aux utilisateurs des données Sirene. Pour vous abonner, <a href=\"https://insee.fr/fr/information/1405555\">suivez ce lien</a>. Pour consulter les précédents numéros, <a href=\"https://insee.fr/fr/information/3711739\">cliquez ici</a>.</p>
 *
 * The version of the OpenAPI document: 3.9
 * Generated by: https://github.com/openapitools/openapi-generator.git
 */


using Xunit;

using System;
using System.Linq;
using System.IO;
using System.Collections.Generic;
using SireneApi.Api;
using SireneApi.Model;
using SireneApi.Client;
using System.Reflection;
using Newtonsoft.Json;

namespace SireneApi.Test.Model
{
    /// <summary>
    ///  Class for testing ReponseEtablissementsAllOf
    /// </summary>
    /// <remarks>
    /// This file is automatically generated by OpenAPI Generator (https://openapi-generator.tech).
    /// Please update the test case below to test the model.
    /// </remarks>
    public class ReponseEtablissementsAllOfTests : IDisposable
    {
        // TODO uncomment below to declare an instance variable for ReponseEtablissementsAllOf
        //private ReponseEtablissementsAllOf instance;

        public ReponseEtablissementsAllOfTests()
        {
            // TODO uncomment below to create an instance of ReponseEtablissementsAllOf
            //instance = new ReponseEtablissementsAllOf();
        }

        public void Dispose()
        {
            // Cleanup when everything is done.
        }

        /// <summary>
        /// Test an instance of ReponseEtablissementsAllOf
        /// </summary>
        [Fact]
        public void ReponseEtablissementsAllOfInstanceTest()
        {
            // TODO uncomment below to test "IsType" ReponseEtablissementsAllOf
            //Assert.IsType<ReponseEtablissementsAllOf>(instance);
        }


        /// <summary>
        /// Test the property 'Etablissements'
        /// </summary>
        [Fact]
        public void EtablissementsTest()
        {
            // TODO unit test for the property 'Etablissements'
        }
        /// <summary>
        /// Test the property 'Facettes'
        /// </summary>
        [Fact]
        public void FacettesTest()
        {
            // TODO unit test for the property 'Facettes'
        }

    }

}
