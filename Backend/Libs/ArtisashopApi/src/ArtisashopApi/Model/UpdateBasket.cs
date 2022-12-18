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
    /// UpdateBasket
    /// </summary>
    [DataContract(Name = "UpdateBasket")]
    public partial class UpdateBasket : IEquatable<UpdateBasket>, IValidatableObject
    {

        /// <summary>
        /// Gets or Sets DeliveryOpt
        /// </summary>
        [DataMember(Name = "deliveryOpt", IsRequired = true, EmitDefaultValue = true)]
        public DeliveryOption DeliveryOpt { get; set; }

        /// <summary>
        /// Gets or Sets CurrentState
        /// </summary>
        [DataMember(Name = "currentState", IsRequired = true, EmitDefaultValue = true)]
        public State CurrentState { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateBasket" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected UpdateBasket() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateBasket" /> class.
        /// </summary>
        /// <param name="id">id.</param>
        /// <param name="quantity">quantity (required).</param>
        /// <param name="deliveryOpt">deliveryOpt (required).</param>
        /// <param name="currentState">currentState (required).</param>
        public UpdateBasket(int id = default(int), int quantity = default(int), DeliveryOption deliveryOpt = default(DeliveryOption), State currentState = default(State))
        {
            this.Quantity = quantity;
            this.DeliveryOpt = deliveryOpt;
            this.CurrentState = currentState;
            this.Id = id;
        }

        /// <summary>
        /// Gets or Sets Id
        /// </summary>
        [DataMember(Name = "id", EmitDefaultValue = false)]
        public int Id { get; set; }

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
            sb.Append("class UpdateBasket {\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  Quantity: ").Append(Quantity).Append("\n");
            sb.Append("  DeliveryOpt: ").Append(DeliveryOpt).Append("\n");
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
            return this.Equals(input as UpdateBasket);
        }

        /// <summary>
        /// Returns true if UpdateBasket instances are equal
        /// </summary>
        /// <param name="input">Instance of UpdateBasket to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(UpdateBasket input)
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
                    this.Quantity == input.Quantity ||
                    this.Quantity.Equals(input.Quantity)
                ) && 
                (
                    this.DeliveryOpt == input.DeliveryOpt ||
                    this.DeliveryOpt.Equals(input.DeliveryOpt)
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
                hashCode = (hashCode * 59) + this.Quantity.GetHashCode();
                hashCode = (hashCode * 59) + this.DeliveryOpt.GetHashCode();
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