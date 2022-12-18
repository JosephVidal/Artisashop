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
    /// Breakdown
    /// </summary>
    [DataContract(Name = "Breakdown")]
    public partial class Breakdown : IEquatable<Breakdown>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Breakdown" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected Breakdown() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="Breakdown" /> class.
        /// </summary>
        /// <param name="itemTotal">itemTotal (required).</param>
        public Breakdown(UnitAmount itemTotal = default(UnitAmount))
        {
            // to ensure "itemTotal" is required (not null)
            if (itemTotal == null)
            {
                throw new ArgumentNullException("itemTotal is a required property for Breakdown and cannot be null");
            }
            this.ItemTotal = itemTotal;
        }

        /// <summary>
        /// Gets or Sets ItemTotal
        /// </summary>
        [DataMember(Name = "item_total", IsRequired = true, EmitDefaultValue = true)]
        public UnitAmount ItemTotal { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class Breakdown {\n");
            sb.Append("  ItemTotal: ").Append(ItemTotal).Append("\n");
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
            return this.Equals(input as Breakdown);
        }

        /// <summary>
        /// Returns true if Breakdown instances are equal
        /// </summary>
        /// <param name="input">Instance of Breakdown to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(Breakdown input)
        {
            if (input == null)
            {
                return false;
            }
            return 
                (
                    this.ItemTotal == input.ItemTotal ||
                    (this.ItemTotal != null &&
                    this.ItemTotal.Equals(input.ItemTotal))
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
                if (this.ItemTotal != null)
                {
                    hashCode = (hashCode * 59) + this.ItemTotal.GetHashCode();
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