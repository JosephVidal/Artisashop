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
    /// V3InpiUnitesLegalesSirenActesGet200ResponseDataInnerData
    /// </summary>
    [DataContract(Name = "_v3_inpi_unites_legales__siren__actes_get_200_response_data_inner_data")]
    public partial class V3InpiUnitesLegalesSirenActesGet200ResponseDataInnerData : IEquatable<V3InpiUnitesLegalesSirenActesGet200ResponseDataInnerData>, IValidatableObject
    {
        /// <summary>
        /// Defines Type
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum TypeEnum
        {
            /// <summary>
            /// Enum Acte for value: acte
            /// </summary>
            [EnumMember(Value = "acte")]
            Acte = 1

        }


        /// <summary>
        /// Gets or Sets Type
        /// </summary>
        [DataMember(Name = "type", IsRequired = true, EmitDefaultValue = true)]
        public TypeEnum Type { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="V3InpiUnitesLegalesSirenActesGet200ResponseDataInnerData" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected V3InpiUnitesLegalesSirenActesGet200ResponseDataInnerData() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="V3InpiUnitesLegalesSirenActesGet200ResponseDataInnerData" /> class.
        /// </summary>
        /// <param name="type">type (required).</param>
        /// <param name="siren">Numéro SIREN de l&#39;entreprise concernée par l&#39;acte (required).</param>
        /// <param name="codeGreffe">Code identifiant du greffe ayant traité l&#39;acte (required).</param>
        /// <param name="dateDepot">Date à laquelle a été déposé l&#39;acte (required).</param>
        /// <param name="natureArchive">Chaîne de caractères contenant une ou plusieurs lettres séparées par un tiret, explicitant de quelle(s) catégories d&#39;archives l&#39;acte provient: A (actes de sociétés) R (ordonnances) et P (actes de personnes physiques) (required).</param>
        public V3InpiUnitesLegalesSirenActesGet200ResponseDataInnerData(TypeEnum type = default(TypeEnum), string siren = default(string), decimal codeGreffe = default(decimal), string dateDepot = default(string), string natureArchive = default(string))
        {
            this.Type = type;
            // to ensure "siren" is required (not null)
            if (siren == null)
            {
                throw new ArgumentNullException("siren is a required property for V3InpiUnitesLegalesSirenActesGet200ResponseDataInnerData and cannot be null");
            }
            this.Siren = siren;
            this.CodeGreffe = codeGreffe;
            // to ensure "dateDepot" is required (not null)
            if (dateDepot == null)
            {
                throw new ArgumentNullException("dateDepot is a required property for V3InpiUnitesLegalesSirenActesGet200ResponseDataInnerData and cannot be null");
            }
            this.DateDepot = dateDepot;
            // to ensure "natureArchive" is required (not null)
            if (natureArchive == null)
            {
                throw new ArgumentNullException("natureArchive is a required property for V3InpiUnitesLegalesSirenActesGet200ResponseDataInnerData and cannot be null");
            }
            this.NatureArchive = natureArchive;
        }

        /// <summary>
        /// Numéro SIREN de l&#39;entreprise concernée par l&#39;acte
        /// </summary>
        /// <value>Numéro SIREN de l&#39;entreprise concernée par l&#39;acte</value>
        [DataMember(Name = "siren", IsRequired = true, EmitDefaultValue = true)]
        public string Siren { get; set; }

        /// <summary>
        /// Code identifiant du greffe ayant traité l&#39;acte
        /// </summary>
        /// <value>Code identifiant du greffe ayant traité l&#39;acte</value>
        [DataMember(Name = "code_greffe", IsRequired = true, EmitDefaultValue = true)]
        public decimal CodeGreffe { get; set; }

        /// <summary>
        /// Date à laquelle a été déposé l&#39;acte
        /// </summary>
        /// <value>Date à laquelle a été déposé l&#39;acte</value>
        [DataMember(Name = "date_depot", IsRequired = true, EmitDefaultValue = true)]
        public string DateDepot { get; set; }

        /// <summary>
        /// Chaîne de caractères contenant une ou plusieurs lettres séparées par un tiret, explicitant de quelle(s) catégories d&#39;archives l&#39;acte provient: A (actes de sociétés) R (ordonnances) et P (actes de personnes physiques)
        /// </summary>
        /// <value>Chaîne de caractères contenant une ou plusieurs lettres séparées par un tiret, explicitant de quelle(s) catégories d&#39;archives l&#39;acte provient: A (actes de sociétés) R (ordonnances) et P (actes de personnes physiques)</value>
        [DataMember(Name = "nature_archive", IsRequired = true, EmitDefaultValue = true)]
        public string NatureArchive { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class V3InpiUnitesLegalesSirenActesGet200ResponseDataInnerData {\n");
            sb.Append("  Type: ").Append(Type).Append("\n");
            sb.Append("  Siren: ").Append(Siren).Append("\n");
            sb.Append("  CodeGreffe: ").Append(CodeGreffe).Append("\n");
            sb.Append("  DateDepot: ").Append(DateDepot).Append("\n");
            sb.Append("  NatureArchive: ").Append(NatureArchive).Append("\n");
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
            return this.Equals(input as V3InpiUnitesLegalesSirenActesGet200ResponseDataInnerData);
        }

        /// <summary>
        /// Returns true if V3InpiUnitesLegalesSirenActesGet200ResponseDataInnerData instances are equal
        /// </summary>
        /// <param name="input">Instance of V3InpiUnitesLegalesSirenActesGet200ResponseDataInnerData to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(V3InpiUnitesLegalesSirenActesGet200ResponseDataInnerData input)
        {
            if (input == null)
            {
                return false;
            }
            return 
                (
                    this.Type == input.Type ||
                    this.Type.Equals(input.Type)
                ) && 
                (
                    this.Siren == input.Siren ||
                    (this.Siren != null &&
                    this.Siren.Equals(input.Siren))
                ) && 
                (
                    this.CodeGreffe == input.CodeGreffe ||
                    this.CodeGreffe.Equals(input.CodeGreffe)
                ) && 
                (
                    this.DateDepot == input.DateDepot ||
                    (this.DateDepot != null &&
                    this.DateDepot.Equals(input.DateDepot))
                ) && 
                (
                    this.NatureArchive == input.NatureArchive ||
                    (this.NatureArchive != null &&
                    this.NatureArchive.Equals(input.NatureArchive))
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
                hashCode = (hashCode * 59) + this.Type.GetHashCode();
                if (this.Siren != null)
                {
                    hashCode = (hashCode * 59) + this.Siren.GetHashCode();
                }
                hashCode = (hashCode * 59) + this.CodeGreffe.GetHashCode();
                if (this.DateDepot != null)
                {
                    hashCode = (hashCode * 59) + this.DateDepot.GetHashCode();
                }
                if (this.NatureArchive != null)
                {
                    hashCode = (hashCode * 59) + this.NatureArchive.GetHashCode();
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
