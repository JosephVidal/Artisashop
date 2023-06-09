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
    /// Register
    /// </summary>
    [DataContract(Name = "Register")]
    public partial class Register : IEquatable<Register>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Register" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected Register() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="Register" /> class.
        /// </summary>
        /// <param name="email">email (required).</param>
        /// <param name="password">password (required).</param>
        /// <param name="lastname">lastname (required).</param>
        /// <param name="firstname">firstname (required).</param>
        /// <param name="role">role (required).</param>
        /// <param name="job">job.</param>
        /// <param name="address">address.</param>
        public Register(string email = default(string), string password = default(string), string lastname = default(string), string firstname = default(string), string role = default(string), string job = default(string), string address = default(string))
        {
            // to ensure "email" is required (not null)
            if (email == null)
            {
                throw new ArgumentNullException("email is a required property for Register and cannot be null");
            }
            this.Email = email;
            // to ensure "password" is required (not null)
            if (password == null)
            {
                throw new ArgumentNullException("password is a required property for Register and cannot be null");
            }
            this.Password = password;
            // to ensure "lastname" is required (not null)
            if (lastname == null)
            {
                throw new ArgumentNullException("lastname is a required property for Register and cannot be null");
            }
            this.Lastname = lastname;
            // to ensure "firstname" is required (not null)
            if (firstname == null)
            {
                throw new ArgumentNullException("firstname is a required property for Register and cannot be null");
            }
            this.Firstname = firstname;
            // to ensure "role" is required (not null)
            if (role == null)
            {
                throw new ArgumentNullException("role is a required property for Register and cannot be null");
            }
            this.Role = role;
            this.Job = job;
            this.Address = address;
        }

        /// <summary>
        /// Gets or Sets Email
        /// </summary>
        [DataMember(Name = "email", IsRequired = true, EmitDefaultValue = true)]
        public string Email { get; set; }

        /// <summary>
        /// Gets or Sets Password
        /// </summary>
        [DataMember(Name = "password", IsRequired = true, EmitDefaultValue = true)]
        public string Password { get; set; }

        /// <summary>
        /// Gets or Sets Lastname
        /// </summary>
        [DataMember(Name = "lastname", IsRequired = true, EmitDefaultValue = true)]
        public string Lastname { get; set; }

        /// <summary>
        /// Gets or Sets Firstname
        /// </summary>
        [DataMember(Name = "firstname", IsRequired = true, EmitDefaultValue = true)]
        public string Firstname { get; set; }

        /// <summary>
        /// Gets or Sets Role
        /// </summary>
        [DataMember(Name = "role", IsRequired = true, EmitDefaultValue = true)]
        public string Role { get; set; }

        /// <summary>
        /// Gets or Sets Job
        /// </summary>
        [DataMember(Name = "job", EmitDefaultValue = true)]
        public string Job { get; set; }

        /// <summary>
        /// Gets or Sets Address
        /// </summary>
        [DataMember(Name = "address", EmitDefaultValue = true)]
        public string Address { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class Register {\n");
            sb.Append("  Email: ").Append(Email).Append("\n");
            sb.Append("  Password: ").Append(Password).Append("\n");
            sb.Append("  Lastname: ").Append(Lastname).Append("\n");
            sb.Append("  Firstname: ").Append(Firstname).Append("\n");
            sb.Append("  Role: ").Append(Role).Append("\n");
            sb.Append("  Job: ").Append(Job).Append("\n");
            sb.Append("  Address: ").Append(Address).Append("\n");
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
            return this.Equals(input as Register);
        }

        /// <summary>
        /// Returns true if Register instances are equal
        /// </summary>
        /// <param name="input">Instance of Register to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(Register input)
        {
            if (input == null)
            {
                return false;
            }
            return 
                (
                    this.Email == input.Email ||
                    (this.Email != null &&
                    this.Email.Equals(input.Email))
                ) && 
                (
                    this.Password == input.Password ||
                    (this.Password != null &&
                    this.Password.Equals(input.Password))
                ) && 
                (
                    this.Lastname == input.Lastname ||
                    (this.Lastname != null &&
                    this.Lastname.Equals(input.Lastname))
                ) && 
                (
                    this.Firstname == input.Firstname ||
                    (this.Firstname != null &&
                    this.Firstname.Equals(input.Firstname))
                ) && 
                (
                    this.Role == input.Role ||
                    (this.Role != null &&
                    this.Role.Equals(input.Role))
                ) && 
                (
                    this.Job == input.Job ||
                    (this.Job != null &&
                    this.Job.Equals(input.Job))
                ) && 
                (
                    this.Address == input.Address ||
                    (this.Address != null &&
                    this.Address.Equals(input.Address))
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
                if (this.Email != null)
                {
                    hashCode = (hashCode * 59) + this.Email.GetHashCode();
                }
                if (this.Password != null)
                {
                    hashCode = (hashCode * 59) + this.Password.GetHashCode();
                }
                if (this.Lastname != null)
                {
                    hashCode = (hashCode * 59) + this.Lastname.GetHashCode();
                }
                if (this.Firstname != null)
                {
                    hashCode = (hashCode * 59) + this.Firstname.GetHashCode();
                }
                if (this.Role != null)
                {
                    hashCode = (hashCode * 59) + this.Role.GetHashCode();
                }
                if (this.Job != null)
                {
                    hashCode = (hashCode * 59) + this.Job.GetHashCode();
                }
                if (this.Address != null)
                {
                    hashCode = (hashCode * 59) + this.Address.GetHashCode();
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
            // Email (string) minLength
            if (this.Email != null && this.Email.Length < 1)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for Email, length must be greater than 1.", new [] { "Email" });
            }

            // Password (string) minLength
            if (this.Password != null && this.Password.Length < 1)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for Password, length must be greater than 1.", new [] { "Password" });
            }

            // Lastname (string) minLength
            if (this.Lastname != null && this.Lastname.Length < 1)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for Lastname, length must be greater than 1.", new [] { "Lastname" });
            }

            // Firstname (string) minLength
            if (this.Firstname != null && this.Firstname.Length < 1)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for Firstname, length must be greater than 1.", new [] { "Firstname" });
            }

            // Role (string) minLength
            if (this.Role != null && this.Role.Length < 1)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for Role, length must be greater than 1.", new [] { "Role" });
            }

            yield break;
        }
    }

}
