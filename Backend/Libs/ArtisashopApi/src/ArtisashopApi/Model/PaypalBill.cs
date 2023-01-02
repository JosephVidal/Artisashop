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
    /// PaypalBill
    /// </summary>
    [DataContract(Name = "PaypalBill")]
    public partial class PaypalBill : IEquatable<PaypalBill>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PaypalBill" /> class.
        /// </summary>
        /// <param name="purchaseUnits">purchaseUnits.</param>
        public PaypalBill(List<PurchaseUnitElem> purchaseUnits = default(List<PurchaseUnitElem>))
        {
            this.PurchaseUnits = purchaseUnits;
        }

        /// <summary>
        /// Gets or Sets PurchaseUnits
        /// </summary>
        [DataMember(Name = "purchase_units", EmitDefaultValue = true)]
        public List<PurchaseUnitElem> PurchaseUnits { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class PaypalBill {\n");
            sb.Append("  PurchaseUnits: ").Append(PurchaseUnits).Append("\n");
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
            return this.Equals(input as PaypalBill);
        }

        /// <summary>
        /// Returns true if PaypalBill instances are equal
        /// </summary>
        /// <param name="input">Instance of PaypalBill to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(PaypalBill input)
        {
            if (input == null)
            {
                return false;
            }
            return 
                (
                    this.PurchaseUnits == input.PurchaseUnits ||
                    this.PurchaseUnits != null &&
                    input.PurchaseUnits != null &&
                    this.PurchaseUnits.SequenceEqual(input.PurchaseUnits)
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
                if (this.PurchaseUnits != null)
                {
                    hashCode = (hashCode * 59) + this.PurchaseUnits.GetHashCode();
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
