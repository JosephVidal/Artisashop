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
    /// Product
    /// </summary>
    [DataContract(Name = "Product")]
    public partial class Product : IEquatable<Product>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Product" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected Product() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="Product" /> class.
        /// </summary>
        /// <param name="id">id (required).</param>
        /// <param name="name">name (required).</param>
        /// <param name="price">price (required).</param>
        /// <param name="description">description.</param>
        /// <param name="quantity">quantity (required).</param>
        /// <param name="craftsmanId">craftsmanId (required).</param>
        /// <param name="craftsman">craftsman (required).</param>
        /// <param name="productImages">productImages.</param>
        /// <param name="productStyles">productStyles.</param>
        public Product(int id = default(int), string name = default(string), double price = default(double), string description = default(string), int quantity = default(int), string craftsmanId = default(string), Account craftsman = default(Account), List<ProductImage> productImages = default(List<ProductImage>), List<ProductStyle> productStyles = default(List<ProductStyle>))
        {
            this.Id = id;
            // to ensure "name" is required (not null)
            if (name == null)
            {
                throw new ArgumentNullException("name is a required property for Product and cannot be null");
            }
            this.Name = name;
            this.Price = price;
            this.Quantity = quantity;
            // to ensure "craftsmanId" is required (not null)
            if (craftsmanId == null)
            {
                throw new ArgumentNullException("craftsmanId is a required property for Product and cannot be null");
            }
            this.CraftsmanId = craftsmanId;
            // to ensure "craftsman" is required (not null)
            if (craftsman == null)
            {
                throw new ArgumentNullException("craftsman is a required property for Product and cannot be null");
            }
            this.Craftsman = craftsman;
            this.Description = description;
            this.ProductImages = productImages;
            this.ProductStyles = productStyles;
        }

        /// <summary>
        /// Gets or Sets Id
        /// </summary>
        [DataMember(Name = "id", IsRequired = true, EmitDefaultValue = true)]
        public int Id { get; set; }

        /// <summary>
        /// Gets or Sets Name
        /// </summary>
        [DataMember(Name = "name", IsRequired = true, EmitDefaultValue = true)]
        public string Name { get; set; }

        /// <summary>
        /// Gets or Sets Price
        /// </summary>
        [DataMember(Name = "price", IsRequired = true, EmitDefaultValue = true)]
        public double Price { get; set; }

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
        /// Gets or Sets CraftsmanId
        /// </summary>
        [DataMember(Name = "craftsmanId", IsRequired = true, EmitDefaultValue = true)]
        public string CraftsmanId { get; set; }

        /// <summary>
        /// Gets or Sets Craftsman
        /// </summary>
        [DataMember(Name = "craftsman", IsRequired = true, EmitDefaultValue = true)]
        public Account Craftsman { get; set; }

        /// <summary>
        /// Gets or Sets ProductImages
        /// </summary>
        [DataMember(Name = "productImages", EmitDefaultValue = true)]
        public List<ProductImage> ProductImages { get; set; }

        /// <summary>
        /// Gets or Sets ProductStyles
        /// </summary>
        [DataMember(Name = "productStyles", EmitDefaultValue = true)]
        public List<ProductStyle> ProductStyles { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class Product {\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  Price: ").Append(Price).Append("\n");
            sb.Append("  Description: ").Append(Description).Append("\n");
            sb.Append("  Quantity: ").Append(Quantity).Append("\n");
            sb.Append("  CraftsmanId: ").Append(CraftsmanId).Append("\n");
            sb.Append("  Craftsman: ").Append(Craftsman).Append("\n");
            sb.Append("  ProductImages: ").Append(ProductImages).Append("\n");
            sb.Append("  ProductStyles: ").Append(ProductStyles).Append("\n");
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
            return this.Equals(input as Product);
        }

        /// <summary>
        /// Returns true if Product instances are equal
        /// </summary>
        /// <param name="input">Instance of Product to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(Product input)
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
                    this.Name == input.Name ||
                    (this.Name != null &&
                    this.Name.Equals(input.Name))
                ) && 
                (
                    this.Price == input.Price ||
                    this.Price.Equals(input.Price)
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
                    this.CraftsmanId == input.CraftsmanId ||
                    (this.CraftsmanId != null &&
                    this.CraftsmanId.Equals(input.CraftsmanId))
                ) && 
                (
                    this.Craftsman == input.Craftsman ||
                    (this.Craftsman != null &&
                    this.Craftsman.Equals(input.Craftsman))
                ) && 
                (
                    this.ProductImages == input.ProductImages ||
                    this.ProductImages != null &&
                    input.ProductImages != null &&
                    this.ProductImages.SequenceEqual(input.ProductImages)
                ) && 
                (
                    this.ProductStyles == input.ProductStyles ||
                    this.ProductStyles != null &&
                    input.ProductStyles != null &&
                    this.ProductStyles.SequenceEqual(input.ProductStyles)
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
                if (this.Name != null)
                {
                    hashCode = (hashCode * 59) + this.Name.GetHashCode();
                }
                hashCode = (hashCode * 59) + this.Price.GetHashCode();
                if (this.Description != null)
                {
                    hashCode = (hashCode * 59) + this.Description.GetHashCode();
                }
                hashCode = (hashCode * 59) + this.Quantity.GetHashCode();
                if (this.CraftsmanId != null)
                {
                    hashCode = (hashCode * 59) + this.CraftsmanId.GetHashCode();
                }
                if (this.Craftsman != null)
                {
                    hashCode = (hashCode * 59) + this.Craftsman.GetHashCode();
                }
                if (this.ProductImages != null)
                {
                    hashCode = (hashCode * 59) + this.ProductImages.GetHashCode();
                }
                if (this.ProductStyles != null)
                {
                    hashCode = (hashCode * 59) + this.ProductStyles.GetHashCode();
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

            // CraftsmanId (string) minLength
            if (this.CraftsmanId != null && this.CraftsmanId.Length < 1)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for CraftsmanId, length must be greater than 1.", new [] { "CraftsmanId" });
            }

            yield break;
        }
    }

}