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
    /// V3DgfipUnitesLegalesSirenLiassesFiscalesYearGet200ResponseData
    /// </summary>
    [DataContract(Name = "_v3_dgfip_unites_legales__siren__liasses_fiscales__year__get_200_response_data")]
    public partial class V3DgfipUnitesLegalesSirenLiassesFiscalesYearGet200ResponseData : IEquatable<V3DgfipUnitesLegalesSirenLiassesFiscalesYearGet200ResponseData>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="V3DgfipUnitesLegalesSirenLiassesFiscalesYearGet200ResponseData" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected V3DgfipUnitesLegalesSirenLiassesFiscalesYearGet200ResponseData() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="V3DgfipUnitesLegalesSirenLiassesFiscalesYearGet200ResponseData" /> class.
        /// </summary>
        /// <param name="obligationsFiscales">Une entité légale peut posséder plusieurs règles d&#39;impositions, notamment si celle-ci fait partie d&#39;un groupe. (required).</param>
        /// <param name="declarations">declarations (required).</param>
        public V3DgfipUnitesLegalesSirenLiassesFiscalesYearGet200ResponseData(List<RGlesDImpositionApplicablesAuRSultatDeLUnitLGaleNommObfEnInterneInner> obligationsFiscales = default(List<RGlesDImpositionApplicablesAuRSultatDeLUnitLGaleNommObfEnInterneInner>), List<V3DgfipUnitesLegalesSirenLiassesFiscalesYearGet200ResponseDataDeclarationsInner> declarations = default(List<V3DgfipUnitesLegalesSirenLiassesFiscalesYearGet200ResponseDataDeclarationsInner>))
        {
            // to ensure "obligationsFiscales" is required (not null)
            if (obligationsFiscales == null)
            {
                throw new ArgumentNullException("obligationsFiscales is a required property for V3DgfipUnitesLegalesSirenLiassesFiscalesYearGet200ResponseData and cannot be null");
            }
            this.ObligationsFiscales = obligationsFiscales;
            // to ensure "declarations" is required (not null)
            if (declarations == null)
            {
                throw new ArgumentNullException("declarations is a required property for V3DgfipUnitesLegalesSirenLiassesFiscalesYearGet200ResponseData and cannot be null");
            }
            this.Declarations = declarations;
        }

        /// <summary>
        /// Une entité légale peut posséder plusieurs règles d&#39;impositions, notamment si celle-ci fait partie d&#39;un groupe.
        /// </summary>
        /// <value>Une entité légale peut posséder plusieurs règles d&#39;impositions, notamment si celle-ci fait partie d&#39;un groupe.</value>
        [DataMember(Name = "obligations_fiscales", IsRequired = true, EmitDefaultValue = true)]
        public List<RGlesDImpositionApplicablesAuRSultatDeLUnitLGaleNommObfEnInterneInner> ObligationsFiscales { get; set; }

        /// <summary>
        /// Gets or Sets Declarations
        /// </summary>
        [DataMember(Name = "declarations", IsRequired = true, EmitDefaultValue = true)]
        public List<V3DgfipUnitesLegalesSirenLiassesFiscalesYearGet200ResponseDataDeclarationsInner> Declarations { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class V3DgfipUnitesLegalesSirenLiassesFiscalesYearGet200ResponseData {\n");
            sb.Append("  ObligationsFiscales: ").Append(ObligationsFiscales).Append("\n");
            sb.Append("  Declarations: ").Append(Declarations).Append("\n");
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
            return this.Equals(input as V3DgfipUnitesLegalesSirenLiassesFiscalesYearGet200ResponseData);
        }

        /// <summary>
        /// Returns true if V3DgfipUnitesLegalesSirenLiassesFiscalesYearGet200ResponseData instances are equal
        /// </summary>
        /// <param name="input">Instance of V3DgfipUnitesLegalesSirenLiassesFiscalesYearGet200ResponseData to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(V3DgfipUnitesLegalesSirenLiassesFiscalesYearGet200ResponseData input)
        {
            if (input == null)
            {
                return false;
            }
            return 
                (
                    this.ObligationsFiscales == input.ObligationsFiscales ||
                    this.ObligationsFiscales != null &&
                    input.ObligationsFiscales != null &&
                    this.ObligationsFiscales.SequenceEqual(input.ObligationsFiscales)
                ) && 
                (
                    this.Declarations == input.Declarations ||
                    this.Declarations != null &&
                    input.Declarations != null &&
                    this.Declarations.SequenceEqual(input.Declarations)
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
                if (this.ObligationsFiscales != null)
                {
                    hashCode = (hashCode * 59) + this.ObligationsFiscales.GetHashCode();
                }
                if (this.Declarations != null)
                {
                    hashCode = (hashCode * 59) + this.Declarations.GetHashCode();
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