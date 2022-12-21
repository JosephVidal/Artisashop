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
    /// Account
    /// </summary>
    [DataContract(Name = "Account")]
    public partial class Account : IEquatable<Account>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Account" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected Account() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="Account" /> class.
        /// </summary>
        /// <param name="id">id.</param>
        /// <param name="userName">userName.</param>
        /// <param name="normalizedUserName">normalizedUserName.</param>
        /// <param name="email">email.</param>
        /// <param name="normalizedEmail">normalizedEmail.</param>
        /// <param name="emailConfirmed">emailConfirmed.</param>
        /// <param name="passwordHash">passwordHash.</param>
        /// <param name="securityStamp">securityStamp.</param>
        /// <param name="concurrencyStamp">concurrencyStamp.</param>
        /// <param name="phoneNumber">phoneNumber.</param>
        /// <param name="phoneNumberConfirmed">phoneNumberConfirmed.</param>
        /// <param name="twoFactorEnabled">twoFactorEnabled.</param>
        /// <param name="lockoutEnd">lockoutEnd.</param>
        /// <param name="lockoutEnabled">lockoutEnabled.</param>
        /// <param name="accessFailedCount">accessFailedCount.</param>
        /// <param name="lastname">lastname (required).</param>
        /// <param name="firstname">firstname (required).</param>
        /// <param name="profilePicture">profilePicture.</param>
        /// <param name="job">job.</param>
        /// <param name="biography">biography.</param>
        /// <param name="address">address.</param>
        /// <param name="addressGPS">addressGPS.</param>
        /// <param name="createdAt">createdAt.</param>
        /// <param name="updatedAt">updatedAt.</param>
        /// <param name="baskets">baskets.</param>
        /// <param name="bills">bills.</param>
        /// <param name="suspended">suspended (required).</param>
        /// <param name="products">products.</param>
        /// <param name="validation">validation (required).</param>
        public Account(string id = default(string), string userName = default(string), string normalizedUserName = default(string), string email = default(string), string normalizedEmail = default(string), bool emailConfirmed = default(bool), string passwordHash = default(string), string securityStamp = default(string), string concurrencyStamp = default(string), string phoneNumber = default(string), bool phoneNumberConfirmed = default(bool), bool twoFactorEnabled = default(bool), DateTime? lockoutEnd = default(DateTime?), bool lockoutEnabled = default(bool), int accessFailedCount = default(int), string lastname = default(string), string firstname = default(string), string profilePicture = default(string), string job = default(string), string biography = default(string), string address = default(string), GPSCoord addressGPS = default(GPSCoord), DateTime? createdAt = default(DateTime?), DateTime? updatedAt = default(DateTime?), List<Basket> baskets = default(List<Basket>), List<Bill> bills = default(List<Bill>), bool suspended = default(bool), List<Product> products = default(List<Product>), bool validation = default(bool))
        {
            // to ensure "lastname" is required (not null)
            if (lastname == null)
            {
                throw new ArgumentNullException("lastname is a required property for Account and cannot be null");
            }
            this.Lastname = lastname;
            // to ensure "firstname" is required (not null)
            if (firstname == null)
            {
                throw new ArgumentNullException("firstname is a required property for Account and cannot be null");
            }
            this.Firstname = firstname;
            this.Suspended = suspended;
            this.Validation = validation;
            this.Id = id;
            this.UserName = userName;
            this.NormalizedUserName = normalizedUserName;
            this.Email = email;
            this.NormalizedEmail = normalizedEmail;
            this.EmailConfirmed = emailConfirmed;
            this.PasswordHash = passwordHash;
            this.SecurityStamp = securityStamp;
            this.ConcurrencyStamp = concurrencyStamp;
            this.PhoneNumber = phoneNumber;
            this.PhoneNumberConfirmed = phoneNumberConfirmed;
            this.TwoFactorEnabled = twoFactorEnabled;
            this.LockoutEnd = lockoutEnd;
            this.LockoutEnabled = lockoutEnabled;
            this.AccessFailedCount = accessFailedCount;
            this.ProfilePicture = profilePicture;
            this.Job = job;
            this.Biography = biography;
            this.Address = address;
            this.AddressGPS = addressGPS;
            this.CreatedAt = createdAt;
            this.UpdatedAt = updatedAt;
            this.Baskets = baskets;
            this.Bills = bills;
            this.Products = products;
        }

        /// <summary>
        /// Gets or Sets Id
        /// </summary>
        [DataMember(Name = "id", EmitDefaultValue = true)]
        public string Id { get; set; }

        /// <summary>
        /// Gets or Sets UserName
        /// </summary>
        [DataMember(Name = "userName", EmitDefaultValue = true)]
        public string UserName { get; set; }

        /// <summary>
        /// Gets or Sets NormalizedUserName
        /// </summary>
        [DataMember(Name = "normalizedUserName", EmitDefaultValue = true)]
        public string NormalizedUserName { get; set; }

        /// <summary>
        /// Gets or Sets Email
        /// </summary>
        [DataMember(Name = "email", EmitDefaultValue = true)]
        public string Email { get; set; }

        /// <summary>
        /// Gets or Sets NormalizedEmail
        /// </summary>
        [DataMember(Name = "normalizedEmail", EmitDefaultValue = true)]
        public string NormalizedEmail { get; set; }

        /// <summary>
        /// Gets or Sets EmailConfirmed
        /// </summary>
        [DataMember(Name = "emailConfirmed", EmitDefaultValue = true)]
        public bool EmailConfirmed { get; set; }

        /// <summary>
        /// Gets or Sets PasswordHash
        /// </summary>
        [DataMember(Name = "passwordHash", EmitDefaultValue = true)]
        public string PasswordHash { get; set; }

        /// <summary>
        /// Gets or Sets SecurityStamp
        /// </summary>
        [DataMember(Name = "securityStamp", EmitDefaultValue = true)]
        public string SecurityStamp { get; set; }

        /// <summary>
        /// Gets or Sets ConcurrencyStamp
        /// </summary>
        [DataMember(Name = "concurrencyStamp", EmitDefaultValue = true)]
        public string ConcurrencyStamp { get; set; }

        /// <summary>
        /// Gets or Sets PhoneNumber
        /// </summary>
        [DataMember(Name = "phoneNumber", EmitDefaultValue = true)]
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Gets or Sets PhoneNumberConfirmed
        /// </summary>
        [DataMember(Name = "phoneNumberConfirmed", EmitDefaultValue = true)]
        public bool PhoneNumberConfirmed { get; set; }

        /// <summary>
        /// Gets or Sets TwoFactorEnabled
        /// </summary>
        [DataMember(Name = "twoFactorEnabled", EmitDefaultValue = true)]
        public bool TwoFactorEnabled { get; set; }

        /// <summary>
        /// Gets or Sets LockoutEnd
        /// </summary>
        [DataMember(Name = "lockoutEnd", EmitDefaultValue = true)]
        public DateTime? LockoutEnd { get; set; }

        /// <summary>
        /// Gets or Sets LockoutEnabled
        /// </summary>
        [DataMember(Name = "lockoutEnabled", EmitDefaultValue = true)]
        public bool LockoutEnabled { get; set; }

        /// <summary>
        /// Gets or Sets AccessFailedCount
        /// </summary>
        [DataMember(Name = "accessFailedCount", EmitDefaultValue = false)]
        public int AccessFailedCount { get; set; }

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
        /// Gets or Sets ProfilePicture
        /// </summary>
        [DataMember(Name = "profilePicture", EmitDefaultValue = true)]
        public string ProfilePicture { get; set; }

        /// <summary>
        /// Gets or Sets Job
        /// </summary>
        [DataMember(Name = "job", EmitDefaultValue = true)]
        public string Job { get; set; }

        /// <summary>
        /// Gets or Sets Biography
        /// </summary>
        [DataMember(Name = "biography", EmitDefaultValue = true)]
        public string Biography { get; set; }

        /// <summary>
        /// Gets or Sets Address
        /// </summary>
        [DataMember(Name = "address", EmitDefaultValue = true)]
        public string Address { get; set; }

        /// <summary>
        /// Gets or Sets AddressGPS
        /// </summary>
        [DataMember(Name = "addressGPS", EmitDefaultValue = false)]
        public GPSCoord AddressGPS { get; set; }

        /// <summary>
        /// Gets or Sets CreatedAt
        /// </summary>
        [DataMember(Name = "createdAt", EmitDefaultValue = true)]
        public DateTime? CreatedAt { get; set; }

        /// <summary>
        /// Gets or Sets UpdatedAt
        /// </summary>
        [DataMember(Name = "updatedAt", EmitDefaultValue = true)]
        public DateTime? UpdatedAt { get; set; }

        /// <summary>
        /// Gets or Sets Baskets
        /// </summary>
        [DataMember(Name = "baskets", EmitDefaultValue = true)]
        public List<Basket> Baskets { get; set; }

        /// <summary>
        /// Gets or Sets Bills
        /// </summary>
        [DataMember(Name = "bills", EmitDefaultValue = true)]
        public List<Bill> Bills { get; set; }

        /// <summary>
        /// Gets or Sets Suspended
        /// </summary>
        [DataMember(Name = "suspended", IsRequired = true, EmitDefaultValue = true)]
        public bool Suspended { get; set; }

        /// <summary>
        /// Gets or Sets Products
        /// </summary>
        [DataMember(Name = "products", EmitDefaultValue = true)]
        public List<Product> Products { get; set; }

        /// <summary>
        /// Gets or Sets Validation
        /// </summary>
        [DataMember(Name = "validation", IsRequired = true, EmitDefaultValue = true)]
        public bool Validation { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class Account {\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  UserName: ").Append(UserName).Append("\n");
            sb.Append("  NormalizedUserName: ").Append(NormalizedUserName).Append("\n");
            sb.Append("  Email: ").Append(Email).Append("\n");
            sb.Append("  NormalizedEmail: ").Append(NormalizedEmail).Append("\n");
            sb.Append("  EmailConfirmed: ").Append(EmailConfirmed).Append("\n");
            sb.Append("  PasswordHash: ").Append(PasswordHash).Append("\n");
            sb.Append("  SecurityStamp: ").Append(SecurityStamp).Append("\n");
            sb.Append("  ConcurrencyStamp: ").Append(ConcurrencyStamp).Append("\n");
            sb.Append("  PhoneNumber: ").Append(PhoneNumber).Append("\n");
            sb.Append("  PhoneNumberConfirmed: ").Append(PhoneNumberConfirmed).Append("\n");
            sb.Append("  TwoFactorEnabled: ").Append(TwoFactorEnabled).Append("\n");
            sb.Append("  LockoutEnd: ").Append(LockoutEnd).Append("\n");
            sb.Append("  LockoutEnabled: ").Append(LockoutEnabled).Append("\n");
            sb.Append("  AccessFailedCount: ").Append(AccessFailedCount).Append("\n");
            sb.Append("  Lastname: ").Append(Lastname).Append("\n");
            sb.Append("  Firstname: ").Append(Firstname).Append("\n");
            sb.Append("  ProfilePicture: ").Append(ProfilePicture).Append("\n");
            sb.Append("  Job: ").Append(Job).Append("\n");
            sb.Append("  Biography: ").Append(Biography).Append("\n");
            sb.Append("  Address: ").Append(Address).Append("\n");
            sb.Append("  AddressGPS: ").Append(AddressGPS).Append("\n");
            sb.Append("  CreatedAt: ").Append(CreatedAt).Append("\n");
            sb.Append("  UpdatedAt: ").Append(UpdatedAt).Append("\n");
            sb.Append("  Baskets: ").Append(Baskets).Append("\n");
            sb.Append("  Bills: ").Append(Bills).Append("\n");
            sb.Append("  Suspended: ").Append(Suspended).Append("\n");
            sb.Append("  Products: ").Append(Products).Append("\n");
            sb.Append("  Validation: ").Append(Validation).Append("\n");
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
            return this.Equals(input as Account);
        }

        /// <summary>
        /// Returns true if Account instances are equal
        /// </summary>
        /// <param name="input">Instance of Account to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(Account input)
        {
            if (input == null)
            {
                return false;
            }
            return 
                (
                    this.Id == input.Id ||
                    (this.Id != null &&
                    this.Id.Equals(input.Id))
                ) && 
                (
                    this.UserName == input.UserName ||
                    (this.UserName != null &&
                    this.UserName.Equals(input.UserName))
                ) && 
                (
                    this.NormalizedUserName == input.NormalizedUserName ||
                    (this.NormalizedUserName != null &&
                    this.NormalizedUserName.Equals(input.NormalizedUserName))
                ) && 
                (
                    this.Email == input.Email ||
                    (this.Email != null &&
                    this.Email.Equals(input.Email))
                ) && 
                (
                    this.NormalizedEmail == input.NormalizedEmail ||
                    (this.NormalizedEmail != null &&
                    this.NormalizedEmail.Equals(input.NormalizedEmail))
                ) && 
                (
                    this.EmailConfirmed == input.EmailConfirmed ||
                    this.EmailConfirmed.Equals(input.EmailConfirmed)
                ) && 
                (
                    this.PasswordHash == input.PasswordHash ||
                    (this.PasswordHash != null &&
                    this.PasswordHash.Equals(input.PasswordHash))
                ) && 
                (
                    this.SecurityStamp == input.SecurityStamp ||
                    (this.SecurityStamp != null &&
                    this.SecurityStamp.Equals(input.SecurityStamp))
                ) && 
                (
                    this.ConcurrencyStamp == input.ConcurrencyStamp ||
                    (this.ConcurrencyStamp != null &&
                    this.ConcurrencyStamp.Equals(input.ConcurrencyStamp))
                ) && 
                (
                    this.PhoneNumber == input.PhoneNumber ||
                    (this.PhoneNumber != null &&
                    this.PhoneNumber.Equals(input.PhoneNumber))
                ) && 
                (
                    this.PhoneNumberConfirmed == input.PhoneNumberConfirmed ||
                    this.PhoneNumberConfirmed.Equals(input.PhoneNumberConfirmed)
                ) && 
                (
                    this.TwoFactorEnabled == input.TwoFactorEnabled ||
                    this.TwoFactorEnabled.Equals(input.TwoFactorEnabled)
                ) && 
                (
                    this.LockoutEnd == input.LockoutEnd ||
                    (this.LockoutEnd != null &&
                    this.LockoutEnd.Equals(input.LockoutEnd))
                ) && 
                (
                    this.LockoutEnabled == input.LockoutEnabled ||
                    this.LockoutEnabled.Equals(input.LockoutEnabled)
                ) && 
                (
                    this.AccessFailedCount == input.AccessFailedCount ||
                    this.AccessFailedCount.Equals(input.AccessFailedCount)
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
                    this.ProfilePicture == input.ProfilePicture ||
                    (this.ProfilePicture != null &&
                    this.ProfilePicture.Equals(input.ProfilePicture))
                ) && 
                (
                    this.Job == input.Job ||
                    (this.Job != null &&
                    this.Job.Equals(input.Job))
                ) && 
                (
                    this.Biography == input.Biography ||
                    (this.Biography != null &&
                    this.Biography.Equals(input.Biography))
                ) && 
                (
                    this.Address == input.Address ||
                    (this.Address != null &&
                    this.Address.Equals(input.Address))
                ) && 
                (
                    this.AddressGPS == input.AddressGPS ||
                    (this.AddressGPS != null &&
                    this.AddressGPS.Equals(input.AddressGPS))
                ) && 
                (
                    this.CreatedAt == input.CreatedAt ||
                    (this.CreatedAt != null &&
                    this.CreatedAt.Equals(input.CreatedAt))
                ) && 
                (
                    this.UpdatedAt == input.UpdatedAt ||
                    (this.UpdatedAt != null &&
                    this.UpdatedAt.Equals(input.UpdatedAt))
                ) && 
                (
                    this.Baskets == input.Baskets ||
                    this.Baskets != null &&
                    input.Baskets != null &&
                    this.Baskets.SequenceEqual(input.Baskets)
                ) && 
                (
                    this.Bills == input.Bills ||
                    this.Bills != null &&
                    input.Bills != null &&
                    this.Bills.SequenceEqual(input.Bills)
                ) && 
                (
                    this.Suspended == input.Suspended ||
                    this.Suspended.Equals(input.Suspended)
                ) && 
                (
                    this.Products == input.Products ||
                    this.Products != null &&
                    input.Products != null &&
                    this.Products.SequenceEqual(input.Products)
                ) && 
                (
                    this.Validation == input.Validation ||
                    this.Validation.Equals(input.Validation)
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
                if (this.Id != null)
                {
                    hashCode = (hashCode * 59) + this.Id.GetHashCode();
                }
                if (this.UserName != null)
                {
                    hashCode = (hashCode * 59) + this.UserName.GetHashCode();
                }
                if (this.NormalizedUserName != null)
                {
                    hashCode = (hashCode * 59) + this.NormalizedUserName.GetHashCode();
                }
                if (this.Email != null)
                {
                    hashCode = (hashCode * 59) + this.Email.GetHashCode();
                }
                if (this.NormalizedEmail != null)
                {
                    hashCode = (hashCode * 59) + this.NormalizedEmail.GetHashCode();
                }
                hashCode = (hashCode * 59) + this.EmailConfirmed.GetHashCode();
                if (this.PasswordHash != null)
                {
                    hashCode = (hashCode * 59) + this.PasswordHash.GetHashCode();
                }
                if (this.SecurityStamp != null)
                {
                    hashCode = (hashCode * 59) + this.SecurityStamp.GetHashCode();
                }
                if (this.ConcurrencyStamp != null)
                {
                    hashCode = (hashCode * 59) + this.ConcurrencyStamp.GetHashCode();
                }
                if (this.PhoneNumber != null)
                {
                    hashCode = (hashCode * 59) + this.PhoneNumber.GetHashCode();
                }
                hashCode = (hashCode * 59) + this.PhoneNumberConfirmed.GetHashCode();
                hashCode = (hashCode * 59) + this.TwoFactorEnabled.GetHashCode();
                if (this.LockoutEnd != null)
                {
                    hashCode = (hashCode * 59) + this.LockoutEnd.GetHashCode();
                }
                hashCode = (hashCode * 59) + this.LockoutEnabled.GetHashCode();
                hashCode = (hashCode * 59) + this.AccessFailedCount.GetHashCode();
                if (this.Lastname != null)
                {
                    hashCode = (hashCode * 59) + this.Lastname.GetHashCode();
                }
                if (this.Firstname != null)
                {
                    hashCode = (hashCode * 59) + this.Firstname.GetHashCode();
                }
                if (this.ProfilePicture != null)
                {
                    hashCode = (hashCode * 59) + this.ProfilePicture.GetHashCode();
                }
                if (this.Job != null)
                {
                    hashCode = (hashCode * 59) + this.Job.GetHashCode();
                }
                if (this.Biography != null)
                {
                    hashCode = (hashCode * 59) + this.Biography.GetHashCode();
                }
                if (this.Address != null)
                {
                    hashCode = (hashCode * 59) + this.Address.GetHashCode();
                }
                if (this.AddressGPS != null)
                {
                    hashCode = (hashCode * 59) + this.AddressGPS.GetHashCode();
                }
                if (this.CreatedAt != null)
                {
                    hashCode = (hashCode * 59) + this.CreatedAt.GetHashCode();
                }
                if (this.UpdatedAt != null)
                {
                    hashCode = (hashCode * 59) + this.UpdatedAt.GetHashCode();
                }
                if (this.Baskets != null)
                {
                    hashCode = (hashCode * 59) + this.Baskets.GetHashCode();
                }
                if (this.Bills != null)
                {
                    hashCode = (hashCode * 59) + this.Bills.GetHashCode();
                }
                hashCode = (hashCode * 59) + this.Suspended.GetHashCode();
                if (this.Products != null)
                {
                    hashCode = (hashCode * 59) + this.Products.GetHashCode();
                }
                hashCode = (hashCode * 59) + this.Validation.GetHashCode();
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

            yield break;
        }
    }

}
