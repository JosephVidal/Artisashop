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
    /// ItemElem
    /// </summary>
    [DataContract(Name = "ItemElem")]
    public partial class ItemElem : IEquatable<ItemElem>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ItemElem" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected ItemElem() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="ItemElem" /> class.
        /// </summary>
        /// <param name="name">name (required).</param>
        /// <param name="description">description.</param>
        /// <param name="quantity">quantity (required).</param>
        /// <param name="unitAmount">unitAmount (required).</param>
        public ItemElem(string name = default(string), string description = default(string), int quantity = default(int), UnitAmount unitAmount = default(UnitAmount))
        {
            // to ensure "name" is required (not null)
            if (name == null)
            {
                throw new ArgumentNullException("name is a required property for ItemElem and cannot be null");
            }
            this.Name = name;
            this.Quantity = quantity;
            // to ensure "unitAmount" is required (not null)
            if (unitAmount == null)
            {
                throw new ArgumentNullException("unitAmount is a required property for ItemElem and cannot be null");
            }
            this.UnitAmount = unitAmount;
            this.Description = description;
        }

        /// <summary>
        /// Gets or Sets Name
        /// </summary>
        [DataMember(Name = "name", IsRequired = true, EmitDefaultValue = true)]
        public string Name { get; set; }

        /// <summary>
        /// Gets or Sets Description
        /// </summary>
        [DataMember(Name = "description", EmitDefaultValue = true)]
        public string Description { get; set; }

        /// <summary>
        /// Gets or Sets Quantity
        /// </summary>
        [DataMember(Name = "quantity", IsRequired = true, EmitDefaultValue = true)]
        public int Quantity { get; set; }

        /// <summary>
        /// Gets or Sets UnitAmount
        /// </summary>
        [DataMember(Name = "unit_amount", IsRequired = true, EmitDefaultValue = true)]
        public UnitAmount UnitAmount { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class ItemElem {\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  Description: ").Append(Description).Append("\n");
            sb.Append("  Quantity: ").Append(Quantity).Append("\n");
            sb.Append("  UnitAmount: ").Append(UnitAmount).Append("\n");
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
            return this.Equals(input as ItemElem);
        }

        /// <summary>
        /// Returns true if ItemElem instances are equal
        /// </summary>
        /// <param name="input">Instance of ItemElem to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(ItemElem input)
        {
            if (input == null)
            {
                return false;
            }
            return 
                (
                    this.Name == input.Name ||
                    (this.Name != null &&
                    this.Name.Equals(input.Name))
                ) && 
                (
                    this.Description == input.Description ||
                    (this.Description != null &&
                    this.Description.Equals(input.Description))
                ) && 
                (
                    this.Quantity == input.Quantity ||
                    this.Quantity.Equals(input.Quantity)
                ) && 
                (
                    this.UnitAmount == input.UnitAmount ||
                    (this.UnitAmount != null &&
                    this.UnitAmount.Equals(input.UnitAmount))
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
                if (this.Name != null)
                {
                    hashCode = (hashCode * 59) + this.Name.GetHashCode();
                }
                if (this.Description != null)
                {
                    hashCode = (hashCode * 59) + this.Description.GetHashCode();
                }
                hashCode = (hashCode * 59) + this.Quantity.GetHashCode();
                if (this.UnitAmount != null)
                {
                    hashCode = (hashCode * 59) + this.UnitAmount.GetHashCode();
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
            // Name (string) minLength
            if (this.Name != null && this.Name.Length < 1)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for Name, length must be greater than 1.", new [] { "Name" });
            }

            yield break;
        }
    }

}
