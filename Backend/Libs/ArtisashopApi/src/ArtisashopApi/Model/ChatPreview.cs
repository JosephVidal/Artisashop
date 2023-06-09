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
    /// ChatPreview
    /// </summary>
    [DataContract(Name = "ChatPreview")]
    public partial class ChatPreview : IEquatable<ChatPreview>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ChatPreview" /> class.
        /// </summary>
        /// <param name="lastMsg">lastMsg.</param>
        /// <param name="receive">receive.</param>
        public ChatPreview(ChatMessage lastMsg = default(ChatMessage), bool receive = default(bool))
        {
            this.LastMsg = lastMsg;
            this.Receive = receive;
        }

        /// <summary>
        /// Gets or Sets LastMsg
        /// </summary>
        [DataMember(Name = "lastMsg", EmitDefaultValue = false)]
        public ChatMessage LastMsg { get; set; }

        /// <summary>
        /// Gets or Sets Receive
        /// </summary>
        [DataMember(Name = "receive", EmitDefaultValue = true)]
        public bool Receive { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class ChatPreview {\n");
            sb.Append("  LastMsg: ").Append(LastMsg).Append("\n");
            sb.Append("  Receive: ").Append(Receive).Append("\n");
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
            return this.Equals(input as ChatPreview);
        }

        /// <summary>
        /// Returns true if ChatPreview instances are equal
        /// </summary>
        /// <param name="input">Instance of ChatPreview to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(ChatPreview input)
        {
            if (input == null)
            {
                return false;
            }
            return 
                (
                    this.LastMsg == input.LastMsg ||
                    (this.LastMsg != null &&
                    this.LastMsg.Equals(input.LastMsg))
                ) && 
                (
                    this.Receive == input.Receive ||
                    this.Receive.Equals(input.Receive)
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
                if (this.LastMsg != null)
                {
                    hashCode = (hashCode * 59) + this.LastMsg.GetHashCode();
                }
                hashCode = (hashCode * 59) + this.Receive.GetHashCode();
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
