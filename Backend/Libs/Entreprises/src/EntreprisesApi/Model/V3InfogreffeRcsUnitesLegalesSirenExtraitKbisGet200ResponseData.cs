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
    /// V3InfogreffeRcsUnitesLegalesSirenExtraitKbisGet200ResponseData
    /// </summary>
    [DataContract(Name = "_v3_infogreffe_rcs_unites_legales__siren__extrait_kbis_get_200_response_data")]
    public partial class V3InfogreffeRcsUnitesLegalesSirenExtraitKbisGet200ResponseData : IEquatable<V3InfogreffeRcsUnitesLegalesSirenExtraitKbisGet200ResponseData>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="V3InfogreffeRcsUnitesLegalesSirenExtraitKbisGet200ResponseData" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected V3InfogreffeRcsUnitesLegalesSirenExtraitKbisGet200ResponseData() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="V3InfogreffeRcsUnitesLegalesSirenExtraitKbisGet200ResponseData" /> class.
        /// </summary>
        /// <param name="dateExtrait">Il s&#39;agit de la date d&#39;émission de l&#39;extrait RCS. (required).</param>
        /// <param name="dateImmatriculation">Il s&#39;agit du jour d&#39;immatriculation de l&#39;entreprise au RCS. À compter de cette date, les sociétés jouissent de la personnalité morale. Cette date d&#39;immatriculation n&#39;est pas la même que celle délivrée par l&#39;Insee. Elle ne correspond pas non plus à la date du début d&#39;activité. (required).</param>
        /// <param name="mandatairesSociaux">Liste des mandataires sociaux d&#39;une société inscrite au RCS. Certaines informations telles que la date de naissance complète ne figurent pas dans cette API. Pour plus d&#39;exhaustivité, appeler l&#39;API Mandataires sociaux - Infogreffe. (required).</param>
        /// <param name="observations">Ce champ regroupe tous les messages laissés par le greffier et inscrits dans les observations. (required).</param>
        /// <param name="nomCommercial">nomCommercial (required).</param>
        /// <param name="etablissementPrincipal">etablissementPrincipal (required).</param>
        /// <param name="capital">capital (required).</param>
        /// <param name="greffe">greffe (required).</param>
        /// <param name="personnePhysique">personnePhysique (required).</param>
        /// <param name="personneMorale">personneMorale (required).</param>
        public V3InfogreffeRcsUnitesLegalesSirenExtraitKbisGet200ResponseData(string dateExtrait = default(string), string dateImmatriculation = default(string), List<MandatairesSociauxInner> mandatairesSociaux = default(List<MandatairesSociauxInner>), List<EnsembleDesObservationsDuGreffierInner> observations = default(List<EnsembleDesObservationsDuGreffierInner>), string nomCommercial = default(string), InformationsDeLTablissementPrincipal etablissementPrincipal = default(InformationsDeLTablissementPrincipal), CapitalDeLEntreprise capital = default(CapitalDeLEntreprise), Greffe greffe = default(Greffe), PersonnePhysique personnePhysique = default(PersonnePhysique), PersonneMorale personneMorale = default(PersonneMorale))
        {
            // to ensure "dateExtrait" is required (not null)
            if (dateExtrait == null)
            {
                throw new ArgumentNullException("dateExtrait is a required property for V3InfogreffeRcsUnitesLegalesSirenExtraitKbisGet200ResponseData and cannot be null");
            }
            this.DateExtrait = dateExtrait;
            // to ensure "dateImmatriculation" is required (not null)
            if (dateImmatriculation == null)
            {
                throw new ArgumentNullException("dateImmatriculation is a required property for V3InfogreffeRcsUnitesLegalesSirenExtraitKbisGet200ResponseData and cannot be null");
            }
            this.DateImmatriculation = dateImmatriculation;
            // to ensure "mandatairesSociaux" is required (not null)
            if (mandatairesSociaux == null)
            {
                throw new ArgumentNullException("mandatairesSociaux is a required property for V3InfogreffeRcsUnitesLegalesSirenExtraitKbisGet200ResponseData and cannot be null");
            }
            this.MandatairesSociaux = mandatairesSociaux;
            // to ensure "observations" is required (not null)
            if (observations == null)
            {
                throw new ArgumentNullException("observations is a required property for V3InfogreffeRcsUnitesLegalesSirenExtraitKbisGet200ResponseData and cannot be null");
            }
            this.Observations = observations;
            // to ensure "nomCommercial" is required (not null)
            if (nomCommercial == null)
            {
                throw new ArgumentNullException("nomCommercial is a required property for V3InfogreffeRcsUnitesLegalesSirenExtraitKbisGet200ResponseData and cannot be null");
            }
            this.NomCommercial = nomCommercial;
            // to ensure "etablissementPrincipal" is required (not null)
            if (etablissementPrincipal == null)
            {
                throw new ArgumentNullException("etablissementPrincipal is a required property for V3InfogreffeRcsUnitesLegalesSirenExtraitKbisGet200ResponseData and cannot be null");
            }
            this.EtablissementPrincipal = etablissementPrincipal;
            // to ensure "capital" is required (not null)
            if (capital == null)
            {
                throw new ArgumentNullException("capital is a required property for V3InfogreffeRcsUnitesLegalesSirenExtraitKbisGet200ResponseData and cannot be null");
            }
            this.Capital = capital;
            // to ensure "greffe" is required (not null)
            if (greffe == null)
            {
                throw new ArgumentNullException("greffe is a required property for V3InfogreffeRcsUnitesLegalesSirenExtraitKbisGet200ResponseData and cannot be null");
            }
            this.Greffe = greffe;
            // to ensure "personnePhysique" is required (not null)
            if (personnePhysique == null)
            {
                throw new ArgumentNullException("personnePhysique is a required property for V3InfogreffeRcsUnitesLegalesSirenExtraitKbisGet200ResponseData and cannot be null");
            }
            this.PersonnePhysique = personnePhysique;
            // to ensure "personneMorale" is required (not null)
            if (personneMorale == null)
            {
                throw new ArgumentNullException("personneMorale is a required property for V3InfogreffeRcsUnitesLegalesSirenExtraitKbisGet200ResponseData and cannot be null");
            }
            this.PersonneMorale = personneMorale;
        }

        /// <summary>
        /// Il s&#39;agit de la date d&#39;émission de l&#39;extrait RCS.
        /// </summary>
        /// <value>Il s&#39;agit de la date d&#39;émission de l&#39;extrait RCS.</value>
        [DataMember(Name = "date_extrait", IsRequired = true, EmitDefaultValue = true)]
        public string DateExtrait { get; set; }

        /// <summary>
        /// Il s&#39;agit du jour d&#39;immatriculation de l&#39;entreprise au RCS. À compter de cette date, les sociétés jouissent de la personnalité morale. Cette date d&#39;immatriculation n&#39;est pas la même que celle délivrée par l&#39;Insee. Elle ne correspond pas non plus à la date du début d&#39;activité.
        /// </summary>
        /// <value>Il s&#39;agit du jour d&#39;immatriculation de l&#39;entreprise au RCS. À compter de cette date, les sociétés jouissent de la personnalité morale. Cette date d&#39;immatriculation n&#39;est pas la même que celle délivrée par l&#39;Insee. Elle ne correspond pas non plus à la date du début d&#39;activité.</value>
        [DataMember(Name = "date_immatriculation", IsRequired = true, EmitDefaultValue = true)]
        public string DateImmatriculation { get; set; }

        /// <summary>
        /// Liste des mandataires sociaux d&#39;une société inscrite au RCS. Certaines informations telles que la date de naissance complète ne figurent pas dans cette API. Pour plus d&#39;exhaustivité, appeler l&#39;API Mandataires sociaux - Infogreffe.
        /// </summary>
        /// <value>Liste des mandataires sociaux d&#39;une société inscrite au RCS. Certaines informations telles que la date de naissance complète ne figurent pas dans cette API. Pour plus d&#39;exhaustivité, appeler l&#39;API Mandataires sociaux - Infogreffe.</value>
        [DataMember(Name = "mandataires_sociaux", IsRequired = true, EmitDefaultValue = true)]
        public List<MandatairesSociauxInner> MandatairesSociaux { get; set; }

        /// <summary>
        /// Ce champ regroupe tous les messages laissés par le greffier et inscrits dans les observations.
        /// </summary>
        /// <value>Ce champ regroupe tous les messages laissés par le greffier et inscrits dans les observations.</value>
        [DataMember(Name = "observations", IsRequired = true, EmitDefaultValue = true)]
        public List<EnsembleDesObservationsDuGreffierInner> Observations { get; set; }

        /// <summary>
        /// Gets or Sets NomCommercial
        /// </summary>
        [DataMember(Name = "nom_commercial", IsRequired = true, EmitDefaultValue = true)]
        public string NomCommercial { get; set; }

        /// <summary>
        /// Gets or Sets EtablissementPrincipal
        /// </summary>
        [DataMember(Name = "etablissement_principal", IsRequired = true, EmitDefaultValue = true)]
        public InformationsDeLTablissementPrincipal EtablissementPrincipal { get; set; }

        /// <summary>
        /// Gets or Sets Capital
        /// </summary>
        [DataMember(Name = "capital", IsRequired = true, EmitDefaultValue = true)]
        public CapitalDeLEntreprise Capital { get; set; }

        /// <summary>
        /// Gets or Sets Greffe
        /// </summary>
        [DataMember(Name = "greffe", IsRequired = true, EmitDefaultValue = true)]
        public Greffe Greffe { get; set; }

        /// <summary>
        /// Gets or Sets PersonnePhysique
        /// </summary>
        [DataMember(Name = "personne_physique", IsRequired = true, EmitDefaultValue = true)]
        public PersonnePhysique PersonnePhysique { get; set; }

        /// <summary>
        /// Gets or Sets PersonneMorale
        /// </summary>
        [DataMember(Name = "personne_morale", IsRequired = true, EmitDefaultValue = true)]
        public PersonneMorale PersonneMorale { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class V3InfogreffeRcsUnitesLegalesSirenExtraitKbisGet200ResponseData {\n");
            sb.Append("  DateExtrait: ").Append(DateExtrait).Append("\n");
            sb.Append("  DateImmatriculation: ").Append(DateImmatriculation).Append("\n");
            sb.Append("  MandatairesSociaux: ").Append(MandatairesSociaux).Append("\n");
            sb.Append("  Observations: ").Append(Observations).Append("\n");
            sb.Append("  NomCommercial: ").Append(NomCommercial).Append("\n");
            sb.Append("  EtablissementPrincipal: ").Append(EtablissementPrincipal).Append("\n");
            sb.Append("  Capital: ").Append(Capital).Append("\n");
            sb.Append("  Greffe: ").Append(Greffe).Append("\n");
            sb.Append("  PersonnePhysique: ").Append(PersonnePhysique).Append("\n");
            sb.Append("  PersonneMorale: ").Append(PersonneMorale).Append("\n");
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
            return this.Equals(input as V3InfogreffeRcsUnitesLegalesSirenExtraitKbisGet200ResponseData);
        }

        /// <summary>
        /// Returns true if V3InfogreffeRcsUnitesLegalesSirenExtraitKbisGet200ResponseData instances are equal
        /// </summary>
        /// <param name="input">Instance of V3InfogreffeRcsUnitesLegalesSirenExtraitKbisGet200ResponseData to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(V3InfogreffeRcsUnitesLegalesSirenExtraitKbisGet200ResponseData input)
        {
            if (input == null)
            {
                return false;
            }
            return 
                (
                    this.DateExtrait == input.DateExtrait ||
                    (this.DateExtrait != null &&
                    this.DateExtrait.Equals(input.DateExtrait))
                ) && 
                (
                    this.DateImmatriculation == input.DateImmatriculation ||
                    (this.DateImmatriculation != null &&
                    this.DateImmatriculation.Equals(input.DateImmatriculation))
                ) && 
                (
                    this.MandatairesSociaux == input.MandatairesSociaux ||
                    this.MandatairesSociaux != null &&
                    input.MandatairesSociaux != null &&
                    this.MandatairesSociaux.SequenceEqual(input.MandatairesSociaux)
                ) && 
                (
                    this.Observations == input.Observations ||
                    this.Observations != null &&
                    input.Observations != null &&
                    this.Observations.SequenceEqual(input.Observations)
                ) && 
                (
                    this.NomCommercial == input.NomCommercial ||
                    (this.NomCommercial != null &&
                    this.NomCommercial.Equals(input.NomCommercial))
                ) && 
                (
                    this.EtablissementPrincipal == input.EtablissementPrincipal ||
                    (this.EtablissementPrincipal != null &&
                    this.EtablissementPrincipal.Equals(input.EtablissementPrincipal))
                ) && 
                (
                    this.Capital == input.Capital ||
                    (this.Capital != null &&
                    this.Capital.Equals(input.Capital))
                ) && 
                (
                    this.Greffe == input.Greffe ||
                    (this.Greffe != null &&
                    this.Greffe.Equals(input.Greffe))
                ) && 
                (
                    this.PersonnePhysique == input.PersonnePhysique ||
                    (this.PersonnePhysique != null &&
                    this.PersonnePhysique.Equals(input.PersonnePhysique))
                ) && 
                (
                    this.PersonneMorale == input.PersonneMorale ||
                    (this.PersonneMorale != null &&
                    this.PersonneMorale.Equals(input.PersonneMorale))
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
                if (this.DateExtrait != null)
                {
                    hashCode = (hashCode * 59) + this.DateExtrait.GetHashCode();
                }
                if (this.DateImmatriculation != null)
                {
                    hashCode = (hashCode * 59) + this.DateImmatriculation.GetHashCode();
                }
                if (this.MandatairesSociaux != null)
                {
                    hashCode = (hashCode * 59) + this.MandatairesSociaux.GetHashCode();
                }
                if (this.Observations != null)
                {
                    hashCode = (hashCode * 59) + this.Observations.GetHashCode();
                }
                if (this.NomCommercial != null)
                {
                    hashCode = (hashCode * 59) + this.NomCommercial.GetHashCode();
                }
                if (this.EtablissementPrincipal != null)
                {
                    hashCode = (hashCode * 59) + this.EtablissementPrincipal.GetHashCode();
                }
                if (this.Capital != null)
                {
                    hashCode = (hashCode * 59) + this.Capital.GetHashCode();
                }
                if (this.Greffe != null)
                {
                    hashCode = (hashCode * 59) + this.Greffe.GetHashCode();
                }
                if (this.PersonnePhysique != null)
                {
                    hashCode = (hashCode * 59) + this.PersonnePhysique.GetHashCode();
                }
                if (this.PersonneMorale != null)
                {
                    hashCode = (hashCode * 59) + this.PersonneMorale.GetHashCode();
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
