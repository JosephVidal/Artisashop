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
    /// L&#39;adresse transmise par Infogreffe est renvoyée sous différents formats, utilisant parfois le champ «nom postal», parfois les champs «ligne 1» et «ligne 2», ou encore au travers des champs «numéro de la voie» + «type de la voie» + «nom de la voie». Pour obtenir l&#39;adresse du siège ou l&#39;établissement principal, nous vous recommandons fortement de faire appel à l&#39;API Adresse établissement - Insee.
    /// </summary>
    [DataContract(Name = "Adresse")]
    public partial class Adresse : IEquatable<Adresse>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Adresse" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected Adresse() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="Adresse" /> class.
        /// </summary>
        /// <param name="nomPostal">nomPostal (required).</param>
        /// <param name="numero">numero (required).</param>
        /// <param name="type">type (required).</param>
        /// <param name="voie">voie (required).</param>
        /// <param name="ligne1">ligne1 (required).</param>
        /// <param name="ligne2">ligne2 (required).</param>
        /// <param name="localite">localite (required).</param>
        /// <param name="codePostal">codePostal (required).</param>
        /// <param name="bureauDistributeur">bureauDistributeur (required).</param>
        /// <param name="pays">pays (required).</param>
        public Adresse(string nomPostal = default(string), string numero = default(string), string type = default(string), string voie = default(string), string ligne1 = default(string), string ligne2 = default(string), string localite = default(string), string codePostal = default(string), string bureauDistributeur = default(string), string pays = default(string))
        {
            // to ensure "nomPostal" is required (not null)
            if (nomPostal == null)
            {
                throw new ArgumentNullException("nomPostal is a required property for Adresse and cannot be null");
            }
            this.NomPostal = nomPostal;
            // to ensure "numero" is required (not null)
            if (numero == null)
            {
                throw new ArgumentNullException("numero is a required property for Adresse and cannot be null");
            }
            this.Numero = numero;
            // to ensure "type" is required (not null)
            if (type == null)
            {
                throw new ArgumentNullException("type is a required property for Adresse and cannot be null");
            }
            this.Type = type;
            // to ensure "voie" is required (not null)
            if (voie == null)
            {
                throw new ArgumentNullException("voie is a required property for Adresse and cannot be null");
            }
            this.Voie = voie;
            // to ensure "ligne1" is required (not null)
            if (ligne1 == null)
            {
                throw new ArgumentNullException("ligne1 is a required property for Adresse and cannot be null");
            }
            this.Ligne1 = ligne1;
            // to ensure "ligne2" is required (not null)
            if (ligne2 == null)
            {
                throw new ArgumentNullException("ligne2 is a required property for Adresse and cannot be null");
            }
            this.Ligne2 = ligne2;
            // to ensure "localite" is required (not null)
            if (localite == null)
            {
                throw new ArgumentNullException("localite is a required property for Adresse and cannot be null");
            }
            this.Localite = localite;
            // to ensure "codePostal" is required (not null)
            if (codePostal == null)
            {
                throw new ArgumentNullException("codePostal is a required property for Adresse and cannot be null");
            }
            this.CodePostal = codePostal;
            // to ensure "bureauDistributeur" is required (not null)
            if (bureauDistributeur == null)
            {
                throw new ArgumentNullException("bureauDistributeur is a required property for Adresse and cannot be null");
            }
            this.BureauDistributeur = bureauDistributeur;
            // to ensure "pays" is required (not null)
            if (pays == null)
            {
                throw new ArgumentNullException("pays is a required property for Adresse and cannot be null");
            }
            this.Pays = pays;
        }

        /// <summary>
        /// Gets or Sets NomPostal
        /// </summary>
        [DataMember(Name = "nom_postal", IsRequired = true, EmitDefaultValue = true)]
        public string NomPostal { get; set; }

        /// <summary>
        /// Gets or Sets Numero
        /// </summary>
        [DataMember(Name = "numero", IsRequired = true, EmitDefaultValue = true)]
        public string Numero { get; set; }

        /// <summary>
        /// Gets or Sets Type
        /// </summary>
        [DataMember(Name = "type", IsRequired = true, EmitDefaultValue = true)]
        public string Type { get; set; }

        /// <summary>
        /// Gets or Sets Voie
        /// </summary>
        [DataMember(Name = "voie", IsRequired = true, EmitDefaultValue = true)]
        public string Voie { get; set; }

        /// <summary>
        /// Gets or Sets Ligne1
        /// </summary>
        [DataMember(Name = "ligne_1", IsRequired = true, EmitDefaultValue = true)]
        public string Ligne1 { get; set; }

        /// <summary>
        /// Gets or Sets Ligne2
        /// </summary>
        [DataMember(Name = "ligne_2", IsRequired = true, EmitDefaultValue = true)]
        public string Ligne2 { get; set; }

        /// <summary>
        /// Gets or Sets Localite
        /// </summary>
        [DataMember(Name = "localite", IsRequired = true, EmitDefaultValue = true)]
        public string Localite { get; set; }

        /// <summary>
        /// Gets or Sets CodePostal
        /// </summary>
        [DataMember(Name = "code_postal", IsRequired = true, EmitDefaultValue = true)]
        public string CodePostal { get; set; }

        /// <summary>
        /// Gets or Sets BureauDistributeur
        /// </summary>
        [DataMember(Name = "bureau_distributeur", IsRequired = true, EmitDefaultValue = true)]
        public string BureauDistributeur { get; set; }

        /// <summary>
        /// Gets or Sets Pays
        /// </summary>
        [DataMember(Name = "pays", IsRequired = true, EmitDefaultValue = true)]
        public string Pays { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class Adresse {\n");
            sb.Append("  NomPostal: ").Append(NomPostal).Append("\n");
            sb.Append("  Numero: ").Append(Numero).Append("\n");
            sb.Append("  Type: ").Append(Type).Append("\n");
            sb.Append("  Voie: ").Append(Voie).Append("\n");
            sb.Append("  Ligne1: ").Append(Ligne1).Append("\n");
            sb.Append("  Ligne2: ").Append(Ligne2).Append("\n");
            sb.Append("  Localite: ").Append(Localite).Append("\n");
            sb.Append("  CodePostal: ").Append(CodePostal).Append("\n");
            sb.Append("  BureauDistributeur: ").Append(BureauDistributeur).Append("\n");
            sb.Append("  Pays: ").Append(Pays).Append("\n");
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
            return this.Equals(input as Adresse);
        }

        /// <summary>
        /// Returns true if Adresse instances are equal
        /// </summary>
        /// <param name="input">Instance of Adresse to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(Adresse input)
        {
            if (input == null)
            {
                return false;
            }
            return 
                (
                    this.NomPostal == input.NomPostal ||
                    (this.NomPostal != null &&
                    this.NomPostal.Equals(input.NomPostal))
                ) && 
                (
                    this.Numero == input.Numero ||
                    (this.Numero != null &&
                    this.Numero.Equals(input.Numero))
                ) && 
                (
                    this.Type == input.Type ||
                    (this.Type != null &&
                    this.Type.Equals(input.Type))
                ) && 
                (
                    this.Voie == input.Voie ||
                    (this.Voie != null &&
                    this.Voie.Equals(input.Voie))
                ) && 
                (
                    this.Ligne1 == input.Ligne1 ||
                    (this.Ligne1 != null &&
                    this.Ligne1.Equals(input.Ligne1))
                ) && 
                (
                    this.Ligne2 == input.Ligne2 ||
                    (this.Ligne2 != null &&
                    this.Ligne2.Equals(input.Ligne2))
                ) && 
                (
                    this.Localite == input.Localite ||
                    (this.Localite != null &&
                    this.Localite.Equals(input.Localite))
                ) && 
                (
                    this.CodePostal == input.CodePostal ||
                    (this.CodePostal != null &&
                    this.CodePostal.Equals(input.CodePostal))
                ) && 
                (
                    this.BureauDistributeur == input.BureauDistributeur ||
                    (this.BureauDistributeur != null &&
                    this.BureauDistributeur.Equals(input.BureauDistributeur))
                ) && 
                (
                    this.Pays == input.Pays ||
                    (this.Pays != null &&
                    this.Pays.Equals(input.Pays))
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
                if (this.NomPostal != null)
                {
                    hashCode = (hashCode * 59) + this.NomPostal.GetHashCode();
                }
                if (this.Numero != null)
                {
                    hashCode = (hashCode * 59) + this.Numero.GetHashCode();
                }
                if (this.Type != null)
                {
                    hashCode = (hashCode * 59) + this.Type.GetHashCode();
                }
                if (this.Voie != null)
                {
                    hashCode = (hashCode * 59) + this.Voie.GetHashCode();
                }
                if (this.Ligne1 != null)
                {
                    hashCode = (hashCode * 59) + this.Ligne1.GetHashCode();
                }
                if (this.Ligne2 != null)
                {
                    hashCode = (hashCode * 59) + this.Ligne2.GetHashCode();
                }
                if (this.Localite != null)
                {
                    hashCode = (hashCode * 59) + this.Localite.GetHashCode();
                }
                if (this.CodePostal != null)
                {
                    hashCode = (hashCode * 59) + this.CodePostal.GetHashCode();
                }
                if (this.BureauDistributeur != null)
                {
                    hashCode = (hashCode * 59) + this.BureauDistributeur.GetHashCode();
                }
                if (this.Pays != null)
                {
                    hashCode = (hashCode * 59) + this.Pays.GetHashCode();
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
