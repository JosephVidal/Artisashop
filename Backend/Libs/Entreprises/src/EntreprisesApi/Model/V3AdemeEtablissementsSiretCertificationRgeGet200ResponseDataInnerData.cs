/*
 * API Entreprise
 *
 * Cette page contient la documentation technique pour accéder à API Entreprise. Les API étant accessible uniquement sous habilitation, l'interaction avec l'environnement de production n'est possible que si vous êtes **en possession d'une clé d'accès (jeton).  ### Comment tester l'API ?  Il est possible de tester les API via notre environnement de **staging** qui vous retournera systématiquement des données fictives.  Il est nécessaire d'utiliser le jeton de staging indiqué ci-dessous.  - --  *eyJhbGciOiJIUzI1NiJ9.eyJ1aWQiOiI1MmE1YmZjMi1jMzUwLTQ4ZjQtYjY5Ni05ZWE3NmRiM2VmMjkiLCJqdGkiOiIwMDAwMDAwMC0wMDAwLTAwMDAtMDAwMC0wMDAwMDAwMDAwMDAiLCJzY29wZXMiOlsiY2VydGlmaWNhdF9yZ2VfYWRlbWUiLCJtc2FfY290aXNhdGlvbnMiLCJlbnRyZXByaXNlcyIsImV4dHJhaXRzX3JjcyIsImNlcnRpZmljYXRfb3BxaWJpIiwiYXNzb2NpYXRpb25zIiwiZXRhYmxpc3NlbWVudHMiLCJmbnRwX2NhcnRlX3BybyIsInF1YWxpYmF0IiwiZW50cmVwcmlzZXNfYXJ0aXNhbmFsZXMiLCJjZXJ0aWZpY2F0X2NuZXRwIiwiZW9yaV9kb3VhbmVzIiwicHJvYnRwIiwiYWN0ZXNfaW5waSIsImV4dHJhaXRfY291cnRfaW5waSIsImF0dGVzdGF0aW9uc19zb2NpYWxlcyIsImxpYXNzZV9maXNjYWxlIiwiYXR0ZXN0YXRpb25zX2Zpc2NhbGVzIiwiZXhlcmNpY2VzIiwiY29udmVudGlvbnNfY29sbGVjdGl2ZXMiLCJiaWxhbnNfaW5waSIsImRvY3VtZW50c19hc3NvY2lhdGlvbiIsImNlcnRpZmljYXRfYWdlbmNlX2JpbyIsImJpbGFuc19lbnRyZXByaXNlX2JkZiIsImF0dGVzdGF0aW9uc19hZ2VmaXBoIiwibWVzcmlfaWRlbnRpZmlhbnQiLCJtZXNyaV9pZGVudGl0ZSIsIm1lc3JpX2luc2NyaXB0aW9uX2V0dWRpYW50IiwibWVzcmlfaW5zY3JpcHRpb25fYXV0cmUiLCJtZXNyaV9hZG1pc3Npb24iLCJtZXNyaV9ldGFibGlzc2VtZW50cyIsInBvbGVfZW1wbG9pX2lkZW50aXRlIiwicG9sZV9lbXBsb2lfYWRyZXNzZSIsInBvbGVfZW1wbG9pX2NvbnRhY3QiLCJwb2xlX2VtcGxvaV9pbnNjcmlwdGlvbiIsImNuYWZfcXVvdGllbnRfZmFtaWxpYWwiLCJjbmFmX2FsbG9jYXRhaXJlcyIsImNuYWZfZW5mYW50cyIsImNuYWZfYWRyZXNzZSIsImNub3VzX3N0YXR1dF9ib3Vyc2llciIsInVwdGltZSIsImNub3VzX2VjaGVsb25fYm91cnNlIiwiY25vdXNfZW1haWwiLCJjbm91c19wZXJpb2RlX3ZlcnNlbWVudCIsImNub3VzX3N0YXR1dF9ib3Vyc2UiLCJjbm91c192aWxsZV9ldHVkZXMiLCJjbm91c19pZGVudGl0ZSIsImRnZmlwX2RlY2xhcmFudDFfbm9tIiwiZGdmaXBfZGVjbGFyYW50MV9ub21fbmFpc3NhbmNlIiwiZGdmaXBfZGVjbGFyYW50MV9wcmVub21zIiwiZGdmaXBfZGVjbGFyYW50MV9kYXRlX25haXNzYW5jZSIsImRnZmlwX2RlY2xhcmFudDJfbm9tIiwiZGdmaXBfZGVjbGFyYW50Ml9ub21fbmFpc3NhbmNlIiwiZGdmaXBfZGVjbGFyYW50Ml9wcmVub21zIiwiZGdmaXBfZGVjbGFyYW50Ml9kYXRlX25haXNzYW5jZSIsImRnZmlwX2RhdGVfcmVjb3V2cmVtZW50IiwiZGdmaXBfZGF0ZV9ldGFibGlzc2VtZW50IiwiZGdmaXBfYWRyZXNzZV9maXNjYWxlX3RheGF0aW9uIiwiZGdmaXBfYWRyZXNzZV9maXNjYWxlX2FubmVlIiwiZGdmaXBfbm9tYnJlX3BhcnRzIiwiZGdmaXBfbm9tYnJlX3BlcnNvbm5lc19hX2NoYXJnZSIsImRnZmlwX3NpdHVhdGlvbl9mYW1pbGlhbGUiLCJkZ2ZpcF9yZXZlbnVfYnJ1dF9nbG9iYWwiLCJkZ2ZpcF9yZXZlbnVfaW1wb3NhYmxlIiwiZGdmaXBfaW1wb3RfcmV2ZW51X25ldF9hdmFudF9jb3JyZWN0aW9ucyIsImRnZmlwX21vbnRhbnRfaW1wb3QiLCJkZ2ZpcF9yZXZlbnVfZmlzY2FsX3JlZmVyZW5jZSIsImRnZmlwX2FubmVlX2ltcG90IiwiZGdmaXBfYW5uZWVfcmV2ZW51cyIsImRnZmlwX2VycmV1cl9jb3JyZWN0aWYiLCJkZ2ZpcF9zaXR1YXRpb25fcGFydGllbGxlIl0sInN1YiI6InN0YWdpbmcgZGV2ZWxvcG1lbnQiLCJpYXQiOjE2NjY4NjQwNzQsInZlcnNpb24iOiIxLjAiLCJleHAiOjE5ODI0ODMyNzR9.u2kMWzll3iCTczUOqMQbpS66VfrVzI2lLiyGEPcKAec*       
 *
 * The version of the OpenAPI document: 3.0.0
 * Contact: support@entreprise.api.gouv.fr
 * Generated by: https://github.com/openapitools/openapi-generator.git
 */


using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.IO;
using System.Runtime.Serialization;
using System.Text;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using System.ComponentModel.DataAnnotations;
using OpenAPIDateConverter = EntreprisesApi.Client.OpenAPIDateConverter;

namespace EntreprisesApi.Model
{
    /// <summary>
    /// V3AdemeEtablissementsSiretCertificationRgeGet200ResponseDataInnerData
    /// </summary>
    [DataContract(Name = "_v3_ademe_etablissements__siret__certification_rge_get_200_response_data_inner_data")]
    public partial class V3AdemeEtablissementsSiretCertificationRgeGet200ResponseDataInnerData : IEquatable<V3AdemeEtablissementsSiretCertificationRgeGet200ResponseDataInnerData>, IValidatableObject
    {
        /// <summary>
        /// Domaine des travaux sur lesquelles porte la qualification du certificat
        /// </summary>
        /// <value>Domaine des travaux sur lesquelles porte la qualification du certificat</value>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum DomaineEnum
        {
            /// <summary>
            /// Enum FentresVoletsPortesExtrieures2020 for value: Fenêtres, volets, portes extérieures 2020
            /// </summary>
            [EnumMember(Value = "Fenêtres, volets, portes extérieures 2020")]
            FentresVoletsPortesExtrieures2020 = 1,

            /// <summary>
            /// Enum IsolationDuToit2020 for value: Isolation du toit 2020
            /// </summary>
            [EnumMember(Value = "Isolation du toit 2020")]
            IsolationDuToit2020 = 2,

            /// <summary>
            /// Enum IsolationDesMursEtPlanchersBas2020 for value: Isolation des murs et planchers bas 2020
            /// </summary>
            [EnumMember(Value = "Isolation des murs et planchers bas 2020")]
            IsolationDesMursEtPlanchersBas2020 = 3,

            /// <summary>
            /// Enum ChaudireCondensationOuMicroCognrationGazOuFioul2020 for value: Chaudière condensation ou micro-cogénération gaz ou fioul 2020
            /// </summary>
            [EnumMember(Value = "Chaudière condensation ou micro-cogénération gaz ou fioul 2020")]
            ChaudireCondensationOuMicroCognrationGazOuFioul2020 = 4,

            /// <summary>
            /// Enum EquipementslectriquesHorsENRChauffageEauChaudeclairage2020 for value: Equipements électriques hors ENR : chauffage, eau chaude, éclairage 2020
            /// </summary>
            [EnumMember(Value = "Equipements électriques hors ENR : chauffage, eau chaude, éclairage 2020")]
            EquipementslectriquesHorsENRChauffageEauChaudeclairage2020 = 5,

            /// <summary>
            /// Enum IsolationParLintrieurDesMursOuRampantsDeToituresOuPlafonds for value: Isolation par l&#39;intérieur des murs ou rampants de toitures  ou plafonds
            /// </summary>
            [EnumMember(Value = "Isolation par l'intérieur des murs ou rampants de toitures  ou plafonds")]
            IsolationParLintrieurDesMursOuRampantsDeToituresOuPlafonds = 6,

            /// <summary>
            /// Enum IsolationDesComblesPerdus for value: Isolation des combles perdus
            /// </summary>
            [EnumMember(Value = "Isolation des combles perdus")]
            IsolationDesComblesPerdus = 7,

            /// <summary>
            /// Enum PompeChaleurChauffage for value: Pompe à chaleur : chauffage
            /// </summary>
            [EnumMember(Value = "Pompe à chaleur : chauffage")]
            PompeChaleurChauffage = 8,

            /// <summary>
            /// Enum FentresVoletsPortesDonnantSurLextrieur for value: Fenêtres, volets, portes donnant sur l&#39;extérieur
            /// </summary>
            [EnumMember(Value = "Fenêtres, volets, portes donnant sur l'extérieur")]
            FentresVoletsPortesDonnantSurLextrieur = 9,

            /// <summary>
            /// Enum IsolationDesPlanchersBas for value: Isolation des planchers bas
            /// </summary>
            [EnumMember(Value = "Isolation des planchers bas")]
            IsolationDesPlanchersBas = 10,

            /// <summary>
            /// Enum ChaudireCondensationOuMicroCognrationGazOuFioul for value: Chaudière condensation ou micro-cogénération gaz ou fioul
            /// </summary>
            [EnumMember(Value = "Chaudière condensation ou micro-cogénération gaz ou fioul")]
            ChaudireCondensationOuMicroCognrationGazOuFioul = 11,

            /// <summary>
            /// Enum Ventilation2020 for value: Ventilation 2020
            /// </summary>
            [EnumMember(Value = "Ventilation 2020")]
            Ventilation2020 = 12,

            /// <summary>
            /// Enum PoleOuInsertBois for value: Poêle ou insert bois
            /// </summary>
            [EnumMember(Value = "Poêle ou insert bois")]
            PoleOuInsertBois = 13,

            /// <summary>
            /// Enum IsolationDesMursParLextrieur for value: Isolation des murs par l&#39;extérieur
            /// </summary>
            [EnumMember(Value = "Isolation des murs par l'extérieur")]
            IsolationDesMursParLextrieur = 14,

            /// <summary>
            /// Enum RadiateurslectriquesDontRgulation for value: Radiateurs électriques, dont régulation.
            /// </summary>
            [EnumMember(Value = "Radiateurs électriques, dont régulation.")]
            RadiateurslectriquesDontRgulation = 15,

            /// <summary>
            /// Enum ChauffeEauThermodynamique for value: Chauffe-Eau Thermodynamique
            /// </summary>
            [EnumMember(Value = "Chauffe-Eau Thermodynamique")]
            ChauffeEauThermodynamique = 16,

            /// <summary>
            /// Enum IsolationDesToituresTerrassesOuDesToituresParLextrieur for value: Isolation des toitures terrasses ou des toitures par l&#39;extérieur
            /// </summary>
            [EnumMember(Value = "Isolation des toitures terrasses ou des toitures par l'extérieur")]
            IsolationDesToituresTerrassesOuDesToituresParLextrieur = 17,

            /// <summary>
            /// Enum FentresDeToit for value: Fenêtres de toit
            /// </summary>
            [EnumMember(Value = "Fenêtres de toit")]
            FentresDeToit = 18,

            /// <summary>
            /// Enum ChaudireBois for value: Chaudière bois
            /// </summary>
            [EnumMember(Value = "Chaudière bois")]
            ChaudireBois = 19,

            /// <summary>
            /// Enum PompeChaleurEtOuChauffeEauThermodynamique2020 for value: Pompe à chaleur et/ou Chauffe-eau thermodynamique 2020
            /// </summary>
            [EnumMember(Value = "Pompe à chaleur et/ou Chauffe-eau thermodynamique 2020")]
            PompeChaleurEtOuChauffeEauThermodynamique2020 = 20,

            /// <summary>
            /// Enum Architecte for value: Architecte
            /// </summary>
            [EnumMember(Value = "Architecte")]
            Architecte = 21,

            /// <summary>
            /// Enum ChauffageEtOuEauChaudeSolaire for value: Chauffage et/ou eau chaude solaire
            /// </summary>
            [EnumMember(Value = "Chauffage et/ou eau chaude solaire")]
            ChauffageEtOuEauChaudeSolaire = 22,

            /// <summary>
            /// Enum PanneauxSolairesPhotovoltaques for value: Panneaux solaires photovoltaïques
            /// </summary>
            [EnumMember(Value = "Panneaux solaires photovoltaïques")]
            PanneauxSolairesPhotovoltaques = 23,

            /// <summary>
            /// Enum VentilationMcanique for value: Ventilation mécanique
            /// </summary>
            [EnumMember(Value = "Ventilation mécanique")]
            VentilationMcanique = 24,

            /// <summary>
            /// Enum ChauffageEtOuEauChaudeAuBois2020 for value: Chauffage et/ou eau chaude au bois 2020
            /// </summary>
            [EnumMember(Value = "Chauffage et/ou eau chaude au bois 2020")]
            ChauffageEtOuEauChaudeAuBois2020 = 25,

            /// <summary>
            /// Enum Auditnergtique for value: Audit énergétique
            /// </summary>
            [EnumMember(Value = "Audit énergétique")]
            Auditnergtique = 26,

            /// <summary>
            /// Enum PanneauxPhotovoltaques2020 for value: Panneaux photovoltaïques 2020
            /// </summary>
            [EnumMember(Value = "Panneaux photovoltaïques 2020")]
            PanneauxPhotovoltaques2020 = 27,

            /// <summary>
            /// Enum EtudeThermiqueReglementaire for value: Etude thermique reglementaire
            /// </summary>
            [EnumMember(Value = "Etude thermique reglementaire")]
            EtudeThermiqueReglementaire = 28,

            /// <summary>
            /// Enum ChauffageEtOuEauChaudeSolaire2020 for value: Chauffage et/ou eau chaude solaire 2020
            /// </summary>
            [EnumMember(Value = "Chauffage et/ou eau chaude solaire 2020")]
            ChauffageEtOuEauChaudeSolaire2020 = 29,

            /// <summary>
            /// Enum ProjetCompletDeRnovation for value: Projet complet de rénovation
            /// </summary>
            [EnumMember(Value = "Projet complet de rénovation")]
            ProjetCompletDeRnovation = 30,

            /// <summary>
            /// Enum EtudeSolairePhotovoltaque for value: Etude solaire photovoltaïque
            /// </summary>
            [EnumMember(Value = "Etude solaire photovoltaïque")]
            EtudeSolairePhotovoltaque = 31,

            /// <summary>
            /// Enum EtudeBoisnergie for value: Etude bois énergie
            /// </summary>
            [EnumMember(Value = "Etude bois énergie")]
            EtudeBoisnergie = 32,

            /// <summary>
            /// Enum EtudeForageGothermique for value: Etude forage géothermique
            /// </summary>
            [EnumMember(Value = "Etude forage géothermique")]
            EtudeForageGothermique = 33,

            /// <summary>
            /// Enum EtudeSolaireThermique for value: Etude solaire thermique
            /// </summary>
            [EnumMember(Value = "Etude solaire thermique")]
            EtudeSolaireThermique = 34,

            /// <summary>
            /// Enum EtudeSystmeTechniqueBtiment for value: Etude système technique bâtiment
            /// </summary>
            [EnumMember(Value = "Etude système technique bâtiment")]
            EtudeSystmeTechniqueBtiment = 35,

            /// <summary>
            /// Enum EtudeEclairage for value: Etude eclairage
            /// </summary>
            [EnumMember(Value = "Etude eclairage")]
            EtudeEclairage = 36,

            /// <summary>
            /// Enum ForageGothermique for value: Forage géothermique
            /// </summary>
            [EnumMember(Value = "Forage géothermique")]
            ForageGothermique = 37,

            /// <summary>
            /// Enum EtudeACV for value: Etude ACV
            /// </summary>
            [EnumMember(Value = "Etude ACV")]
            EtudeACV = 38,

            /// <summary>
            /// Enum Inconnu for value: Inconnu
            /// </summary>
            [EnumMember(Value = "Inconnu")]
            Inconnu = 39,

            /// <summary>
            /// Enum NonRenseign for value: Non renseigné
            /// </summary>
            [EnumMember(Value = "Non renseigné")]
            NonRenseign = 40,

            /// <summary>
            /// Enum EtudeEnveloppeDuBtiment for value: Etude enveloppe du bâtiment
            /// </summary>
            [EnumMember(Value = "Etude enveloppe du bâtiment")]
            EtudeEnveloppeDuBtiment = 41,

            /// <summary>
            /// Enum Commisionnement for value: Commisionnement
            /// </summary>
            [EnumMember(Value = "Commisionnement")]
            Commisionnement = 42

        }


        /// <summary>
        /// Domaine des travaux sur lesquelles porte la qualification du certificat
        /// </summary>
        /// <value>Domaine des travaux sur lesquelles porte la qualification du certificat</value>
        [DataMember(Name = "domaine", IsRequired = true, EmitDefaultValue = true)]
        public DomaineEnum Domaine { get; set; }
        /// <summary>
        /// Le Méta domaine explicite le contexte de la qualification du certificat
        /// </summary>
        /// <value>Le Méta domaine explicite le contexte de la qualification du certificat</value>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum MetaDomaineEnum
        {
            /// <summary>
            /// Enum AnciensDomainesAvant2021 for value: anciens domaines avant 2021
            /// </summary>
            [EnumMember(Value = "anciens domaines avant 2021")]
            AnciensDomainesAvant2021 = 1,

            /// <summary>
            /// Enum TravauxDefficacitnergtique for value: Travaux d&#39;efficacité énergétique
            /// </summary>
            [EnumMember(Value = "Travaux d'efficacité énergétique")]
            TravauxDefficacitnergtique = 2,

            /// <summary>
            /// Enum InstallationsDnergiesRenouvelables for value: Installations d&#39;énergies renouvelables
            /// </summary>
            [EnumMember(Value = "Installations d'énergies renouvelables")]
            InstallationsDnergiesRenouvelables = 3,

            /// <summary>
            /// Enum RnovationGlobale for value: Rénovation globale
            /// </summary>
            [EnumMember(Value = "Rénovation globale")]
            RnovationGlobale = 4,

            /// <summary>
            /// Enum Etudesnergtiques for value: Etudes énergétiques
            /// </summary>
            [EnumMember(Value = "Etudes énergétiques")]
            Etudesnergtiques = 5,

            /// <summary>
            /// Enum Inconnu for value: Inconnu
            /// </summary>
            [EnumMember(Value = "Inconnu")]
            Inconnu = 6,

            /// <summary>
            /// Enum NonRenseign for value: Non renseigné
            /// </summary>
            [EnumMember(Value = "Non renseigné")]
            NonRenseign = 7

        }


        /// <summary>
        /// Le Méta domaine explicite le contexte de la qualification du certificat
        /// </summary>
        /// <value>Le Méta domaine explicite le contexte de la qualification du certificat</value>
        [DataMember(Name = "meta_domaine", IsRequired = true, EmitDefaultValue = true)]
        public MetaDomaineEnum MetaDomaine { get; set; }
        /// <summary>
        /// Organisme ayant délivré le certificat
        /// </summary>
        /// <value>Organisme ayant délivré le certificat</value>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum OrganismeEnum
        {
            /// <summary>
            /// Enum NonRenseign for value: Non renseigné
            /// </summary>
            [EnumMember(Value = "Non renseigné")]
            NonRenseign = 1,

            /// <summary>
            /// Enum Qualibat for value: qualibat
            /// </summary>
            [EnumMember(Value = "qualibat")]
            Qualibat = 2,

            /// <summary>
            /// Enum Qualitenr for value: qualitenr
            /// </summary>
            [EnumMember(Value = "qualitenr")]
            Qualitenr = 3,

            /// <summary>
            /// Enum Cnoa for value: cnoa
            /// </summary>
            [EnumMember(Value = "cnoa")]
            Cnoa = 4,

            /// <summary>
            /// Enum Opqibi for value: opqibi
            /// </summary>
            [EnumMember(Value = "opqibi")]
            Opqibi = 5,

            /// <summary>
            /// Enum Qualifelec for value: qualifelec
            /// </summary>
            [EnumMember(Value = "qualifelec")]
            Qualifelec = 6,

            /// <summary>
            /// Enum Cequami for value: cequami
            /// </summary>
            [EnumMember(Value = "cequami")]
            Cequami = 7,

            /// <summary>
            /// Enum Certibat for value: certibat
            /// </summary>
            [EnumMember(Value = "certibat")]
            Certibat = 8,

            /// <summary>
            /// Enum Afnor for value: afnor
            /// </summary>
            [EnumMember(Value = "afnor")]
            Afnor = 9,

            /// <summary>
            /// Enum Inconnu for value: Inconnu
            /// </summary>
            [EnumMember(Value = "Inconnu")]
            Inconnu = 10

        }


        /// <summary>
        /// Organisme ayant délivré le certificat
        /// </summary>
        /// <value>Organisme ayant délivré le certificat</value>
        [DataMember(Name = "organisme", IsRequired = true, EmitDefaultValue = true)]
        public OrganismeEnum Organisme { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="V3AdemeEtablissementsSiretCertificationRgeGet200ResponseDataInnerData" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected V3AdemeEtablissementsSiretCertificationRgeGet200ResponseDataInnerData() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="V3AdemeEtablissementsSiretCertificationRgeGet200ResponseDataInnerData" /> class.
        /// </summary>
        /// <param name="url">URL de téléchargement du certificat (required).</param>
        /// <param name="nomCertificat">libéllé du certificat (required).</param>
        /// <param name="domaine">Domaine des travaux sur lesquelles porte la qualification du certificat (required).</param>
        /// <param name="metaDomaine">Le Méta domaine explicite le contexte de la qualification du certificat (required).</param>
        /// <param name="qualification">qualification (required).</param>
        /// <param name="organisme">Organisme ayant délivré le certificat (required).</param>
        /// <param name="dateAttribution">Date à laquelle a été attribué le certificat (required).</param>
        /// <param name="dateExpiration">Date à laquelle le présent certificat expire (required).</param>
        /// <param name="meta">meta (required).</param>
        public V3AdemeEtablissementsSiretCertificationRgeGet200ResponseDataInnerData(string url = default(string), string nomCertificat = default(string), DomaineEnum domaine = default(DomaineEnum), MetaDomaineEnum metaDomaine = default(MetaDomaineEnum), Qualification qualification = default(Qualification), OrganismeEnum organisme = default(OrganismeEnum), string dateAttribution = default(string), string dateExpiration = default(string), InformationsADEME meta = default(InformationsADEME))
        {
            // to ensure "url" is required (not null)
            if (url == null)
            {
                throw new ArgumentNullException("url is a required property for V3AdemeEtablissementsSiretCertificationRgeGet200ResponseDataInnerData and cannot be null");
            }
            this.Url = url;
            // to ensure "nomCertificat" is required (not null)
            if (nomCertificat == null)
            {
                throw new ArgumentNullException("nomCertificat is a required property for V3AdemeEtablissementsSiretCertificationRgeGet200ResponseDataInnerData and cannot be null");
            }
            this.NomCertificat = nomCertificat;
            this.Domaine = domaine;
            this.MetaDomaine = metaDomaine;
            // to ensure "qualification" is required (not null)
            if (qualification == null)
            {
                throw new ArgumentNullException("qualification is a required property for V3AdemeEtablissementsSiretCertificationRgeGet200ResponseDataInnerData and cannot be null");
            }
            this.Qualification = qualification;
            this.Organisme = organisme;
            // to ensure "dateAttribution" is required (not null)
            if (dateAttribution == null)
            {
                throw new ArgumentNullException("dateAttribution is a required property for V3AdemeEtablissementsSiretCertificationRgeGet200ResponseDataInnerData and cannot be null");
            }
            this.DateAttribution = dateAttribution;
            // to ensure "dateExpiration" is required (not null)
            if (dateExpiration == null)
            {
                throw new ArgumentNullException("dateExpiration is a required property for V3AdemeEtablissementsSiretCertificationRgeGet200ResponseDataInnerData and cannot be null");
            }
            this.DateExpiration = dateExpiration;
            // to ensure "meta" is required (not null)
            if (meta == null)
            {
                throw new ArgumentNullException("meta is a required property for V3AdemeEtablissementsSiretCertificationRgeGet200ResponseDataInnerData and cannot be null");
            }
            this.Meta = meta;
        }

        /// <summary>
        /// URL de téléchargement du certificat
        /// </summary>
        /// <value>URL de téléchargement du certificat</value>
        [DataMember(Name = "url", IsRequired = true, EmitDefaultValue = true)]
        public string Url { get; set; }

        /// <summary>
        /// libéllé du certificat
        /// </summary>
        /// <value>libéllé du certificat</value>
        [DataMember(Name = "nom_certificat", IsRequired = true, EmitDefaultValue = true)]
        public string NomCertificat { get; set; }

        /// <summary>
        /// Gets or Sets Qualification
        /// </summary>
        [DataMember(Name = "qualification", IsRequired = true, EmitDefaultValue = true)]
        public Qualification Qualification { get; set; }

        /// <summary>
        /// Date à laquelle a été attribué le certificat
        /// </summary>
        /// <value>Date à laquelle a été attribué le certificat</value>
        [DataMember(Name = "date_attribution", IsRequired = true, EmitDefaultValue = true)]
        public string DateAttribution { get; set; }

        /// <summary>
        /// Date à laquelle le présent certificat expire
        /// </summary>
        /// <value>Date à laquelle le présent certificat expire</value>
        [DataMember(Name = "date_expiration", IsRequired = true, EmitDefaultValue = true)]
        public string DateExpiration { get; set; }

        /// <summary>
        /// Gets or Sets Meta
        /// </summary>
        [DataMember(Name = "meta", IsRequired = true, EmitDefaultValue = true)]
        public InformationsADEME Meta { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class V3AdemeEtablissementsSiretCertificationRgeGet200ResponseDataInnerData {\n");
            sb.Append("  Url: ").Append(Url).Append("\n");
            sb.Append("  NomCertificat: ").Append(NomCertificat).Append("\n");
            sb.Append("  Domaine: ").Append(Domaine).Append("\n");
            sb.Append("  MetaDomaine: ").Append(MetaDomaine).Append("\n");
            sb.Append("  Qualification: ").Append(Qualification).Append("\n");
            sb.Append("  Organisme: ").Append(Organisme).Append("\n");
            sb.Append("  DateAttribution: ").Append(DateAttribution).Append("\n");
            sb.Append("  DateExpiration: ").Append(DateExpiration).Append("\n");
            sb.Append("  Meta: ").Append(Meta).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }

        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public virtual string ToJson()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this, Newtonsoft.Json.Formatting.Indented);
        }

        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            return this.Equals(input as V3AdemeEtablissementsSiretCertificationRgeGet200ResponseDataInnerData);
        }

        /// <summary>
        /// Returns true if V3AdemeEtablissementsSiretCertificationRgeGet200ResponseDataInnerData instances are equal
        /// </summary>
        /// <param name="input">Instance of V3AdemeEtablissementsSiretCertificationRgeGet200ResponseDataInnerData to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(V3AdemeEtablissementsSiretCertificationRgeGet200ResponseDataInnerData input)
        {
            if (input == null)
            {
                return false;
            }
            return 
                (
                    this.Url == input.Url ||
                    (this.Url != null &&
                    this.Url.Equals(input.Url))
                ) && 
                (
                    this.NomCertificat == input.NomCertificat ||
                    (this.NomCertificat != null &&
                    this.NomCertificat.Equals(input.NomCertificat))
                ) && 
                (
                    this.Domaine == input.Domaine ||
                    this.Domaine.Equals(input.Domaine)
                ) && 
                (
                    this.MetaDomaine == input.MetaDomaine ||
                    this.MetaDomaine.Equals(input.MetaDomaine)
                ) && 
                (
                    this.Qualification == input.Qualification ||
                    (this.Qualification != null &&
                    this.Qualification.Equals(input.Qualification))
                ) && 
                (
                    this.Organisme == input.Organisme ||
                    this.Organisme.Equals(input.Organisme)
                ) && 
                (
                    this.DateAttribution == input.DateAttribution ||
                    (this.DateAttribution != null &&
                    this.DateAttribution.Equals(input.DateAttribution))
                ) && 
                (
                    this.DateExpiration == input.DateExpiration ||
                    (this.DateExpiration != null &&
                    this.DateExpiration.Equals(input.DateExpiration))
                ) && 
                (
                    this.Meta == input.Meta ||
                    (this.Meta != null &&
                    this.Meta.Equals(input.Meta))
                );
        }

        /// <summary>
        /// Gets the hash code
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode()
        {
            unchecked // Overflow is fine, just wrap
            {
                int hashCode = 41;
                if (this.Url != null)
                {
                    hashCode = (hashCode * 59) + this.Url.GetHashCode();
                }
                if (this.NomCertificat != null)
                {
                    hashCode = (hashCode * 59) + this.NomCertificat.GetHashCode();
                }
                hashCode = (hashCode * 59) + this.Domaine.GetHashCode();
                hashCode = (hashCode * 59) + this.MetaDomaine.GetHashCode();
                if (this.Qualification != null)
                {
                    hashCode = (hashCode * 59) + this.Qualification.GetHashCode();
                }
                hashCode = (hashCode * 59) + this.Organisme.GetHashCode();
                if (this.DateAttribution != null)
                {
                    hashCode = (hashCode * 59) + this.DateAttribution.GetHashCode();
                }
                if (this.DateExpiration != null)
                {
                    hashCode = (hashCode * 59) + this.DateExpiration.GetHashCode();
                }
                if (this.Meta != null)
                {
                    hashCode = (hashCode * 59) + this.Meta.GetHashCode();
                }
                return hashCode;
            }
        }

        /// <summary>
        /// To validate all properties of the instance
        /// </summary>
        /// <param name="validationContext">Validation context</param>
        /// <returns>Validation Result</returns>
        public IEnumerable<System.ComponentModel.DataAnnotations.ValidationResult> Validate(ValidationContext validationContext)
        {
            yield break;
        }
    }

}