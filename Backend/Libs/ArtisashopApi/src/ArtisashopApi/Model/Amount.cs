/*
 * API Artisashop
 *
 * No description provided (generated by Openapi Generator https://github.com/openapitools/openapi-generator)
 *
 * The version of the OpenAPI document: v1
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
using OpenAPIDateConverter = ArtisashopApi.Client.OpenAPIDateConverter;

namespace ArtisashopApi.Model
{
    /// <summary>
    /// Amount
    /// </summary>
    [DataContract(Name = "Amount")]
    public partial class Amount : IEquatable<Amount>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Amount" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected Amount() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="Amount" /> class.
        /// </summary>
        /// <param name="currencyCode">currencyCode (required).</param>
        /// <param name="value">value (required).</param>
        /// <param name="breakdown">breakdown (required).</param>
        public Amount(string currencyCode = default(string), double value = default(double), Breakdown breakdown = default(Breakdown))
        {
            // to ensure "currencyCode" is required (not null)
            if (currencyCode == null)
            {
                throw new ArgumentNullException("currencyCode is a required property for Amount and cannot be null");
            }
            this.CurrencyCode = currencyCode;
            this.Value = value;
            // to ensure "breakdown" is required (not null)
            if (breakdown == null)
            {
                throw new ArgumentNullException("breakdown is a required property for Amount and cannot be null");
            }
            this.Breakdown = breakdown;
        }

        /// <summary>
        /// Gets or Sets CurrencyCode
        /// </summary>
        [DataMember(Name = "currency_code", IsRequired = true, EmitDefaultValue = true)]
        public string CurrencyCode { get; set; }

        /// <summary>
        /// Gets or Sets Value
        /// </summary>
        [DataMember(Name = "value", IsRequired = true, EmitDefaultValue = true)]
        public double Value { get; set; }

        /// <summary>
        /// Gets or Sets Breakdown
        /// </summary>
        [DataMember(Name = "breakdown", IsRequired = true, EmitDefaultValue = true)]
        public Breakdown Breakdown { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class Amount {\n");
            sb.Append("  CurrencyCode: ").Append(CurrencyCode).Append("\n");
            sb.Append("  Value: ").Append(Value).Append("\n");
            sb.Append("  Breakdown: ").Append(Breakdown).Append("\n");
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
            return this.Equals(input as Amount);
        }

        /// <summary>
        /// Returns true if Amount instances are equal
        /// </summary>
        /// <param name="input">Instance of Amount to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(Amount input)
        {
            if (input == null)
            {
                return false;
            }
            return 
                (
                    this.CurrencyCode == input.CurrencyCode ||
                    (this.CurrencyCode != null &&
                    this.CurrencyCode.Equals(input.CurrencyCode))
                ) && 
                (
                    this.Value == input.Value ||
                    this.Value.Equals(input.Value)
                ) && 
                (
                    this.Breakdown == input.Breakdown ||
                    (this.Breakdown != null &&
                    this.Breakdown.Equals(input.Breakdown))
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
                if (this.CurrencyCode != null)
                {
                    hashCode = (hashCode * 59) + this.CurrencyCode.GetHashCode();
                }
                hashCode = (hashCode * 59) + this.Value.GetHashCode();
                if (this.Breakdown != null)
                {
                    hashCode = (hashCode * 59) + this.Breakdown.GetHashCode();
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
            // CurrencyCode (string) minLength
            if (this.CurrencyCode != null && this.CurrencyCode.Length < 1)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for CurrencyCode, length must be greater than 1.", new [] { "CurrencyCode" });
            }

            yield break;
        }
    }

}
