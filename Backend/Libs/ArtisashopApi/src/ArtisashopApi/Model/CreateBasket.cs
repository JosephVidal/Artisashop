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
    /// CreateBasket
    /// </summary>
    [DataContract(Name = "CreateBasket")]
    public partial class CreateBasket : IEquatable<CreateBasket>, IValidatableObject
    {

        /// <summary>
        /// Gets or Sets CurrentState
        /// </summary>
        [DataMember(Name = "currentState", IsRequired = true, EmitDefaultValue = true)]
        public State CurrentState { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateBasket" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected CreateBasket() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateBasket" /> class.
        /// </summary>
        /// <param name="id">id.</param>
        /// <param name="productId">productId.</param>
        /// <param name="quantity">quantity (required).</param>
        /// <param name="currentState">currentState (required).</param>
        public CreateBasket(int id = default(int), int productId = default(int), int quantity = default(int), State currentState = default(State))
        {
            this.Quantity = quantity;
            this.CurrentState = currentState;
            this.Id = id;
            this.ProductId = productId;
        }

        /// <summary>
        /// Gets or Sets Id
        /// </summary>
        [DataMember(Name = "id", EmitDefaultValue = false)]
        public int Id { get; set; }

        /// <summary>
        /// Gets or Sets ProductId
        /// </summary>
        [DataMember(Name = "productId", EmitDefaultValue = false)]
        public int ProductId { get; set; }

        /// <summary>
        /// Gets or Sets Quantity
        /// </summary>
        [DataMember(Name = "quantity", IsRequired = true, EmitDefaultValue = true)]
        public int Quantity { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class CreateBasket {\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  ProductId: ").Append(ProductId).Append("\n");
            sb.Append("  Quantity: ").Append(Quantity).Append("\n");
            sb.Append("  CurrentState: ").Append(CurrentState).Append("\n");
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
            return this.Equals(input as CreateBasket);
        }

        /// <summary>
        /// Returns true if CreateBasket instances are equal
        /// </summary>
        /// <param name="input">Instance of CreateBasket to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(CreateBasket input)
        {
            if (input == null)
            {
                return false;
            }
            return 
                (
                    this.Id == input.Id ||
                    this.Id.Equals(input.Id)
                ) && 
                (
                    this.ProductId == input.ProductId ||
                    this.ProductId.Equals(input.ProductId)
                ) && 
                (
                    this.Quantity == input.Quantity ||
                    this.Quantity.Equals(input.Quantity)
                ) && 
                (
                    this.CurrentState == input.CurrentState ||
                    this.CurrentState.Equals(input.CurrentState)
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
                hashCode = (hashCode * 59) + this.Id.GetHashCode();
                hashCode = (hashCode * 59) + this.ProductId.GetHashCode();
                hashCode = (hashCode * 59) + this.Quantity.GetHashCode();
                hashCode = (hashCode * 59) + this.CurrentState.GetHashCode();
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
