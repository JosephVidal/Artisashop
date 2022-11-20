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
    ///  Class for testing PeriodeEtablissement
    /// </summary>
    /// <remarks>
    /// This file is automatically generated by OpenAPI Generator (https://openapi-generator.tech).
    /// Please update the test case below to test the model.
    /// </remarks>
    public class PeriodeEtablissementTests : IDisposable
    {
        // TODO uncomment below to declare an instance variable for PeriodeEtablissement
        //private PeriodeEtablissement instance;

        public PeriodeEtablissementTests()
        {
            // TODO uncomment below to create an instance of PeriodeEtablissement
            //instance = new PeriodeEtablissement();
        }

        public void Dispose()
        {
            // Cleanup when everything is done.
        }

        /// <summary>
        /// Test an instance of PeriodeEtablissement
        /// </summary>
        [Fact]
        public void PeriodeEtablissementInstanceTest()
        {
            // TODO uncomment below to test "IsType" PeriodeEtablissement
            //Assert.IsType<PeriodeEtablissement>(instance);
        }


        /// <summary>
        /// Test the property 'DateFin'
        /// </summary>
        [Fact]
        public void DateFinTest()
        {
            // TODO unit test for the property 'DateFin'
        }
        /// <summary>
        /// Test the property 'DateDebut'
        /// </summary>
        [Fact]
        public void DateDebutTest()
        {
            // TODO unit test for the property 'DateDebut'
        }
        /// <summary>
        /// Test the property 'EtatAdministratifEtablissement'
        /// </summary>
        [Fact]
        public void EtatAdministratifEtablissementTest()
        {
            // TODO unit test for the property 'EtatAdministratifEtablissement'
        }
        /// <summary>
        /// Test the property 'ChangementEtatAdministratifEtablissement'
        /// </summary>
        [Fact]
        public void ChangementEtatAdministratifEtablissementTest()
        {
            // TODO unit test for the property 'ChangementEtatAdministratifEtablissement'
        }
        /// <summary>
        /// Test the property 'Enseigne1Etablissement'
        /// </summary>
        [Fact]
        public void Enseigne1EtablissementTest()
        {
            // TODO unit test for the property 'Enseigne1Etablissement'
        }
        /// <summary>
        /// Test the property 'Enseigne2Etablissement'
        /// </summary>
        [Fact]
        public void Enseigne2EtablissementTest()
        {
            // TODO unit test for the property 'Enseigne2Etablissement'
        }
        /// <summary>
        /// Test the property 'Enseigne3Etablissement'
        /// </summary>
        [Fact]
        public void Enseigne3EtablissementTest()
        {
            // TODO unit test for the property 'Enseigne3Etablissement'
        }
        /// <summary>
        /// Test the property 'ChangementEnseigneEtablissement'
        /// </summary>
        [Fact]
        public void ChangementEnseigneEtablissementTest()
        {
            // TODO unit test for the property 'ChangementEnseigneEtablissement'
        }
        /// <summary>
        /// Test the property 'DenominationUsuelleEtablissement'
        /// </summary>
        [Fact]
        public void DenominationUsuelleEtablissementTest()
        {
            // TODO unit test for the property 'DenominationUsuelleEtablissement'
        }
        /// <summary>
        /// Test the property 'ChangementDenominationUsuelleEtablissement'
        /// </summary>
        [Fact]
        public void ChangementDenominationUsuelleEtablissementTest()
        {
            // TODO unit test for the property 'ChangementDenominationUsuelleEtablissement'
        }
        /// <summary>
        /// Test the property 'ActivitePrincipaleEtablissement'
        /// </summary>
        [Fact]
        public void ActivitePrincipaleEtablissementTest()
        {
            // TODO unit test for the property 'ActivitePrincipaleEtablissement'
        }
        /// <summary>
        /// Test the property 'NomenclatureActivitePrincipaleEtablissement'
        /// </summary>
        [Fact]
        public void NomenclatureActivitePrincipaleEtablissementTest()
        {
            // TODO unit test for the property 'NomenclatureActivitePrincipaleEtablissement'
        }
        /// <summary>
        /// Test the property 'ChangementActivitePrincipaleEtablissement'
        /// </summary>
        [Fact]
        public void ChangementActivitePrincipaleEtablissementTest()
        {
            // TODO unit test for the property 'ChangementActivitePrincipaleEtablissement'
        }
        /// <summary>
        /// Test the property 'CaractereEmployeurEtablissement'
        /// </summary>
        [Fact]
        public void CaractereEmployeurEtablissementTest()
        {
            // TODO unit test for the property 'CaractereEmployeurEtablissement'
        }
        /// <summary>
        /// Test the property 'ChangementCaractereEmployeurEtablissement'
        /// </summary>
        [Fact]
        public void ChangementCaractereEmployeurEtablissementTest()
        {
            // TODO unit test for the property 'ChangementCaractereEmployeurEtablissement'
        }

    }

}