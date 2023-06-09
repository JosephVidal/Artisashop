/*
 * API Entreprise
 *
 * Cette page contient la documentation technique pour accéder à API Entreprise. Les API étant accessible uniquement sous habilitation, l'interaction avec l'environnement de production n'est possible que si vous êtes **en possession d'une clé d'accès (jeton).  ### Comment tester l'API ?  Il est possible de tester les API via notre environnement de **staging** qui vous retournera systématiquement des données fictives.  Il est nécessaire d'utiliser le jeton de staging indiqué ci-dessous.  - --  *eyJhbGciOiJIUzI1NiJ9.eyJ1aWQiOiI1MmE1YmZjMi1jMzUwLTQ4ZjQtYjY5Ni05ZWE3NmRiM2VmMjkiLCJqdGkiOiIwMDAwMDAwMC0wMDAwLTAwMDAtMDAwMC0wMDAwMDAwMDAwMDAiLCJzY29wZXMiOlsiY2VydGlmaWNhdF9yZ2VfYWRlbWUiLCJtc2FfY290aXNhdGlvbnMiLCJlbnRyZXByaXNlcyIsImV4dHJhaXRzX3JjcyIsImNlcnRpZmljYXRfb3BxaWJpIiwiYXNzb2NpYXRpb25zIiwiZXRhYmxpc3NlbWVudHMiLCJmbnRwX2NhcnRlX3BybyIsInF1YWxpYmF0IiwiZW50cmVwcmlzZXNfYXJ0aXNhbmFsZXMiLCJjZXJ0aWZpY2F0X2NuZXRwIiwiZW9yaV9kb3VhbmVzIiwicHJvYnRwIiwiYWN0ZXNfaW5waSIsImV4dHJhaXRfY291cnRfaW5waSIsImF0dGVzdGF0aW9uc19zb2NpYWxlcyIsImxpYXNzZV9maXNjYWxlIiwiYXR0ZXN0YXRpb25zX2Zpc2NhbGVzIiwiZXhlcmNpY2VzIiwiY29udmVudGlvbnNfY29sbGVjdGl2ZXMiLCJiaWxhbnNfaW5waSIsImRvY3VtZW50c19hc3NvY2lhdGlvbiIsImNlcnRpZmljYXRfYWdlbmNlX2JpbyIsImJpbGFuc19lbnRyZXByaXNlX2JkZiIsImF0dGVzdGF0aW9uc19hZ2VmaXBoIiwibWVzcmlfaWRlbnRpZmlhbnQiLCJtZXNyaV9pZGVudGl0ZSIsIm1lc3JpX2luc2NyaXB0aW9uX2V0dWRpYW50IiwibWVzcmlfaW5zY3JpcHRpb25fYXV0cmUiLCJtZXNyaV9hZG1pc3Npb24iLCJtZXNyaV9ldGFibGlzc2VtZW50cyIsInBvbGVfZW1wbG9pX2lkZW50aXRlIiwicG9sZV9lbXBsb2lfYWRyZXNzZSIsInBvbGVfZW1wbG9pX2NvbnRhY3QiLCJwb2xlX2VtcGxvaV9pbnNjcmlwdGlvbiIsImNuYWZfcXVvdGllbnRfZmFtaWxpYWwiLCJjbmFmX2FsbG9jYXRhaXJlcyIsImNuYWZfZW5mYW50cyIsImNuYWZfYWRyZXNzZSIsImNub3VzX3N0YXR1dF9ib3Vyc2llciIsInVwdGltZSIsImNub3VzX2VjaGVsb25fYm91cnNlIiwiY25vdXNfZW1haWwiLCJjbm91c19wZXJpb2RlX3ZlcnNlbWVudCIsImNub3VzX3N0YXR1dF9ib3Vyc2UiLCJjbm91c192aWxsZV9ldHVkZXMiLCJjbm91c19pZGVudGl0ZSIsImRnZmlwX2RlY2xhcmFudDFfbm9tIiwiZGdmaXBfZGVjbGFyYW50MV9ub21fbmFpc3NhbmNlIiwiZGdmaXBfZGVjbGFyYW50MV9wcmVub21zIiwiZGdmaXBfZGVjbGFyYW50MV9kYXRlX25haXNzYW5jZSIsImRnZmlwX2RlY2xhcmFudDJfbm9tIiwiZGdmaXBfZGVjbGFyYW50Ml9ub21fbmFpc3NhbmNlIiwiZGdmaXBfZGVjbGFyYW50Ml9wcmVub21zIiwiZGdmaXBfZGVjbGFyYW50Ml9kYXRlX25haXNzYW5jZSIsImRnZmlwX2RhdGVfcmVjb3V2cmVtZW50IiwiZGdmaXBfZGF0ZV9ldGFibGlzc2VtZW50IiwiZGdmaXBfYWRyZXNzZV9maXNjYWxlX3RheGF0aW9uIiwiZGdmaXBfYWRyZXNzZV9maXNjYWxlX2FubmVlIiwiZGdmaXBfbm9tYnJlX3BhcnRzIiwiZGdmaXBfbm9tYnJlX3BlcnNvbm5lc19hX2NoYXJnZSIsImRnZmlwX3NpdHVhdGlvbl9mYW1pbGlhbGUiLCJkZ2ZpcF9yZXZlbnVfYnJ1dF9nbG9iYWwiLCJkZ2ZpcF9yZXZlbnVfaW1wb3NhYmxlIiwiZGdmaXBfaW1wb3RfcmV2ZW51X25ldF9hdmFudF9jb3JyZWN0aW9ucyIsImRnZmlwX21vbnRhbnRfaW1wb3QiLCJkZ2ZpcF9yZXZlbnVfZmlzY2FsX3JlZmVyZW5jZSIsImRnZmlwX2FubmVlX2ltcG90IiwiZGdmaXBfYW5uZWVfcmV2ZW51cyIsImRnZmlwX2VycmV1cl9jb3JyZWN0aWYiLCJkZ2ZpcF9zaXR1YXRpb25fcGFydGllbGxlIl0sInN1YiI6InN0YWdpbmcgZGV2ZWxvcG1lbnQiLCJpYXQiOjE2NjY4NjQwNzQsInZlcnNpb24iOiIxLjAiLCJleHAiOjE5ODI0ODMyNzR9.u2kMWzll3iCTczUOqMQbpS66VfrVzI2lLiyGEPcKAec*       
 *
 * The version of the OpenAPI document: 3.0.0
 * Contact: support@entreprise.api.gouv.fr
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
using OpenAPIDateConverter = EntreprisesApi.Client.OpenAPIDateConverter;

namespace EntreprisesApi.Model
{
    /// <summary>
    /// V3InfogreffeRcsUnitesLegalesSirenMandatairesSociauxGet200ResponseDataInnerData
    /// </summary>
    [DataContract(Name = "_v3_infogreffe_rcs_unites_legales__siren__mandataires_sociaux_get_200_response_data_inner_data")]
    public partial class V3InfogreffeRcsUnitesLegalesSirenMandatairesSociauxGet200ResponseDataInnerData : IEquatable<V3InfogreffeRcsUnitesLegalesSirenMandatairesSociauxGet200ResponseDataInnerData>, IValidatableObject
    {
        /// <summary>
        /// Ce champ permet de faire la distinction entre les personnes physiques et morales.
        /// </summary>
        /// <value>Ce champ permet de faire la distinction entre les personnes physiques et morales.</value>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum TypeEnum
        {
            /// <summary>
            /// Enum Morale for value: personne_morale
            /// </summary>
            [EnumMember(Value = "personne_morale")]
            Morale = 1,

            /// <summary>
            /// Enum Physique for value: personne_physique
            /// </summary>
            [EnumMember(Value = "personne_physique")]
            Physique = 2

        }


        /// <summary>
        /// Ce champ permet de faire la distinction entre les personnes physiques et morales.
        /// </summary>
        /// <value>Ce champ permet de faire la distinction entre les personnes physiques et morales.</value>
        [DataMember(Name = "type", EmitDefaultValue = false)]
        public TypeEnum? Type { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="V3InfogreffeRcsUnitesLegalesSirenMandatairesSociauxGet200ResponseDataInnerData" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected V3InfogreffeRcsUnitesLegalesSirenMandatairesSociauxGet200ResponseDataInnerData() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="V3InfogreffeRcsUnitesLegalesSirenMandatairesSociauxGet200ResponseDataInnerData" /> class.
        /// </summary>
        /// <param name="numeroIdentification">Ce champ est uniquement disponible pour une personne morale..</param>
        /// <param name="type">Ce champ permet de faire la distinction entre les personnes physiques et morales..</param>
        /// <param name="fonction">Ce champ décrit la fonction du mandataire social au sein de l&#39;entreprise. Cette information est disponible pour les personnes morales et physiques. (required).</param>
        /// <param name="nom">Nom du mandataire social. Ce champ est disponible uniquement pour une personne physique..</param>
        /// <param name="prenom">Prénom du mandataire social. Ce champ est disponible uniquement pour une personne physique..</param>
        /// <param name="dateNaissance">Date de naissance du mandataire social. Ce champ est disponible uniquement pour une personne physique..</param>
        /// <param name="dateNaissanceTimestamp">Date de naissance délivrée au format timestamp. Ce champ est disponible uniquement pour une personne physique..</param>
        /// <param name="lieuNaissance">Lieu de naissance du mandataire social. Ce champ est disponible uniquement pour une personne physique..</param>
        /// <param name="paysNaissance">Pays de naissance du mandataire social. Ce champ est disponible uniquement pour une personne physique..</param>
        /// <param name="codePaysNaissance">Code à deux lettres indiquant le pays de naissance du mandataire social, suivant la norme ISO 3166 Alpha 2. Ce champ est disponible uniquement pour une personne physique..</param>
        /// <param name="nationalite">Nationalité du mandataire social. Ce champ est disponible uniquement pour une personne physique..</param>
        /// <param name="codeNationalite">Code à deux lettres indiquant le pays de nationalité du mandataire social, suivant la norme ISO 3166 Alpha 2. Ce champ est disponible uniquement pour une personne physique..</param>
        /// <param name="raisonSociale">Raison sociale de la personne morale mandataire social. Ce champ est disponible uniquement pour une personne morale..</param>
        /// <param name="codeGreffe">Code du greffe auquel la personne morale mandataire social est rattachée. Ce champ est disponible uniquement pour une personne morale. Tous les codes greffe sont disponibles ici : https://opendata.datainfogreffe.fr/explore/dataset/liste-des-greffes/table/.</param>
        /// <param name="libelleGreffe">Nom du greffe auquel la personne morale mandataire social est rattachée. Ce champ est disponible uniquement pour une personne morale. Tous les libellés sont disponibles ici : https://opendata.datainfogreffe.fr/explore/dataset/liste-des-greffes/table/.</param>
        public V3InfogreffeRcsUnitesLegalesSirenMandatairesSociauxGet200ResponseDataInnerData(string numeroIdentification = default(string), TypeEnum? type = default(TypeEnum?), string fonction = default(string), string nom = default(string), string prenom = default(string), string dateNaissance = default(string), int? dateNaissanceTimestamp = default(int?), string lieuNaissance = default(string), string paysNaissance = default(string), string codePaysNaissance = default(string), string nationalite = default(string), string codeNationalite = default(string), string raisonSociale = default(string), string codeGreffe = default(string), string libelleGreffe = default(string))
        {
            // to ensure "fonction" is required (not null)
            if (fonction == null)
            {
                throw new ArgumentNullException("fonction is a required property for V3InfogreffeRcsUnitesLegalesSirenMandatairesSociauxGet200ResponseDataInnerData and cannot be null");
            }
            this.Fonction = fonction;
            this.NumeroIdentification = numeroIdentification;
            this.Type = type;
            this.Nom = nom;
            this.Prenom = prenom;
            this.DateNaissance = dateNaissance;
            this.DateNaissanceTimestamp = dateNaissanceTimestamp;
            this.LieuNaissance = lieuNaissance;
            this.PaysNaissance = paysNaissance;
            this.CodePaysNaissance = codePaysNaissance;
            this.Nationalite = nationalite;
            this.CodeNationalite = codeNationalite;
            this.RaisonSociale = raisonSociale;
            this.CodeGreffe = codeGreffe;
            this.LibelleGreffe = libelleGreffe;
        }

        /// <summary>
        /// Ce champ est uniquement disponible pour une personne morale.
        /// </summary>
        /// <value>Ce champ est uniquement disponible pour une personne morale.</value>
        [DataMember(Name = "numero_identification", EmitDefaultValue = false)]
        public string NumeroIdentification { get; set; }

        /// <summary>
        /// Ce champ décrit la fonction du mandataire social au sein de l&#39;entreprise. Cette information est disponible pour les personnes morales et physiques.
        /// </summary>
        /// <value>Ce champ décrit la fonction du mandataire social au sein de l&#39;entreprise. Cette information est disponible pour les personnes morales et physiques.</value>
        [DataMember(Name = "fonction", IsRequired = true, EmitDefaultValue = true)]
        public string Fonction { get; set; }

        /// <summary>
        /// Nom du mandataire social. Ce champ est disponible uniquement pour une personne physique.
        /// </summary>
        /// <value>Nom du mandataire social. Ce champ est disponible uniquement pour une personne physique.</value>
        [DataMember(Name = "nom", EmitDefaultValue = true)]
        public string Nom { get; set; }

        /// <summary>
        /// Prénom du mandataire social. Ce champ est disponible uniquement pour une personne physique.
        /// </summary>
        /// <value>Prénom du mandataire social. Ce champ est disponible uniquement pour une personne physique.</value>
        [DataMember(Name = "prenom", EmitDefaultValue = true)]
        public string Prenom { get; set; }

        /// <summary>
        /// Date de naissance du mandataire social. Ce champ est disponible uniquement pour une personne physique.
        /// </summary>
        /// <value>Date de naissance du mandataire social. Ce champ est disponible uniquement pour une personne physique.</value>
        [DataMember(Name = "date_naissance", EmitDefaultValue = true)]
        public string DateNaissance { get; set; }

        /// <summary>
        /// Date de naissance délivrée au format timestamp. Ce champ est disponible uniquement pour une personne physique.
        /// </summary>
        /// <value>Date de naissance délivrée au format timestamp. Ce champ est disponible uniquement pour une personne physique.</value>
        [DataMember(Name = "date_naissance_timestamp", EmitDefaultValue = true)]
        public int? DateNaissanceTimestamp { get; set; }

        /// <summary>
        /// Lieu de naissance du mandataire social. Ce champ est disponible uniquement pour une personne physique.
        /// </summary>
        /// <value>Lieu de naissance du mandataire social. Ce champ est disponible uniquement pour une personne physique.</value>
        [DataMember(Name = "lieu_naissance", EmitDefaultValue = true)]
        public string LieuNaissance { get; set; }

        /// <summary>
        /// Pays de naissance du mandataire social. Ce champ est disponible uniquement pour une personne physique.
        /// </summary>
        /// <value>Pays de naissance du mandataire social. Ce champ est disponible uniquement pour une personne physique.</value>
        [DataMember(Name = "pays_naissance", EmitDefaultValue = true)]
        public string PaysNaissance { get; set; }

        /// <summary>
        /// Code à deux lettres indiquant le pays de naissance du mandataire social, suivant la norme ISO 3166 Alpha 2. Ce champ est disponible uniquement pour une personne physique.
        /// </summary>
        /// <value>Code à deux lettres indiquant le pays de naissance du mandataire social, suivant la norme ISO 3166 Alpha 2. Ce champ est disponible uniquement pour une personne physique.</value>
        [DataMember(Name = "code_pays_naissance", EmitDefaultValue = true)]
        public string CodePaysNaissance { get; set; }

        /// <summary>
        /// Nationalité du mandataire social. Ce champ est disponible uniquement pour une personne physique.
        /// </summary>
        /// <value>Nationalité du mandataire social. Ce champ est disponible uniquement pour une personne physique.</value>
        [DataMember(Name = "nationalite", EmitDefaultValue = true)]
        public string Nationalite { get; set; }

        /// <summary>
        /// Code à deux lettres indiquant le pays de nationalité du mandataire social, suivant la norme ISO 3166 Alpha 2. Ce champ est disponible uniquement pour une personne physique.
        /// </summary>
        /// <value>Code à deux lettres indiquant le pays de nationalité du mandataire social, suivant la norme ISO 3166 Alpha 2. Ce champ est disponible uniquement pour une personne physique.</value>
        [DataMember(Name = "code_nationalite", EmitDefaultValue = true)]
        public string CodeNationalite { get; set; }

        /// <summary>
        /// Raison sociale de la personne morale mandataire social. Ce champ est disponible uniquement pour une personne morale.
        /// </summary>
        /// <value>Raison sociale de la personne morale mandataire social. Ce champ est disponible uniquement pour une personne morale.</value>
        [DataMember(Name = "raison_sociale", EmitDefaultValue = true)]
        public string RaisonSociale { get; set; }

        /// <summary>
        /// Code du greffe auquel la personne morale mandataire social est rattachée. Ce champ est disponible uniquement pour une personne morale. Tous les codes greffe sont disponibles ici : https://opendata.datainfogreffe.fr/explore/dataset/liste-des-greffes/table/
        /// </summary>
        /// <value>Code du greffe auquel la personne morale mandataire social est rattachée. Ce champ est disponible uniquement pour une personne morale. Tous les codes greffe sont disponibles ici : https://opendata.datainfogreffe.fr/explore/dataset/liste-des-greffes/table/</value>
        [DataMember(Name = "code_greffe", EmitDefaultValue = true)]
        public string CodeGreffe { get; set; }

        /// <summary>
        /// Nom du greffe auquel la personne morale mandataire social est rattachée. Ce champ est disponible uniquement pour une personne morale. Tous les libellés sont disponibles ici : https://opendata.datainfogreffe.fr/explore/dataset/liste-des-greffes/table/
        /// </summary>
        /// <value>Nom du greffe auquel la personne morale mandataire social est rattachée. Ce champ est disponible uniquement pour une personne morale. Tous les libellés sont disponibles ici : https://opendata.datainfogreffe.fr/explore/dataset/liste-des-greffes/table/</value>
        [DataMember(Name = "libelle_greffe", EmitDefaultValue = true)]
        public string LibelleGreffe { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class V3InfogreffeRcsUnitesLegalesSirenMandatairesSociauxGet200ResponseDataInnerData {\n");
            sb.Append("  NumeroIdentification: ").Append(NumeroIdentification).Append("\n");
            sb.Append("  Type: ").Append(Type).Append("\n");
            sb.Append("  Fonction: ").Append(Fonction).Append("\n");
            sb.Append("  Nom: ").Append(Nom).Append("\n");
            sb.Append("  Prenom: ").Append(Prenom).Append("\n");
            sb.Append("  DateNaissance: ").Append(DateNaissance).Append("\n");
            sb.Append("  DateNaissanceTimestamp: ").Append(DateNaissanceTimestamp).Append("\n");
            sb.Append("  LieuNaissance: ").Append(LieuNaissance).Append("\n");
            sb.Append("  PaysNaissance: ").Append(PaysNaissance).Append("\n");
            sb.Append("  CodePaysNaissance: ").Append(CodePaysNaissance).Append("\n");
            sb.Append("  Nationalite: ").Append(Nationalite).Append("\n");
            sb.Append("  CodeNationalite: ").Append(CodeNationalite).Append("\n");
            sb.Append("  RaisonSociale: ").Append(RaisonSociale).Append("\n");
            sb.Append("  CodeGreffe: ").Append(CodeGreffe).Append("\n");
            sb.Append("  LibelleGreffe: ").Append(LibelleGreffe).Append("\n");
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
            return this.Equals(input as V3InfogreffeRcsUnitesLegalesSirenMandatairesSociauxGet200ResponseDataInnerData);
        }

        /// <summary>
        /// Returns true if V3InfogreffeRcsUnitesLegalesSirenMandatairesSociauxGet200ResponseDataInnerData instances are equal
        /// </summary>
        /// <param name="input">Instance of V3InfogreffeRcsUnitesLegalesSirenMandatairesSociauxGet200ResponseDataInnerData to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(V3InfogreffeRcsUnitesLegalesSirenMandatairesSociauxGet200ResponseDataInnerData input)
        {
            if (input == null)
            {
                return false;
            }
            return 
                (
                    this.NumeroIdentification == input.NumeroIdentification ||
                    (this.NumeroIdentification != null &&
                    this.NumeroIdentification.Equals(input.NumeroIdentification))
                ) && 
                (
                    this.Type == input.Type ||
                    this.Type.Equals(input.Type)
                ) && 
                (
                    this.Fonction == input.Fonction ||
                    (this.Fonction != null &&
                    this.Fonction.Equals(input.Fonction))
                ) && 
                (
                    this.Nom == input.Nom ||
                    (this.Nom != null &&
                    this.Nom.Equals(input.Nom))
                ) && 
                (
                    this.Prenom == input.Prenom ||
                    (this.Prenom != null &&
                    this.Prenom.Equals(input.Prenom))
                ) && 
                (
                    this.DateNaissance == input.DateNaissance ||
                    (this.DateNaissance != null &&
                    this.DateNaissance.Equals(input.DateNaissance))
                ) && 
                (
                    this.DateNaissanceTimestamp == input.DateNaissanceTimestamp ||
                    (this.DateNaissanceTimestamp != null &&
                    this.DateNaissanceTimestamp.Equals(input.DateNaissanceTimestamp))
                ) && 
                (
                    this.LieuNaissance == input.LieuNaissance ||
                    (this.LieuNaissance != null &&
                    this.LieuNaissance.Equals(input.LieuNaissance))
                ) && 
                (
                    this.PaysNaissance == input.PaysNaissance ||
                    (this.PaysNaissance != null &&
                    this.PaysNaissance.Equals(input.PaysNaissance))
                ) && 
                (
                    this.CodePaysNaissance == input.CodePaysNaissance ||
                    (this.CodePaysNaissance != null &&
                    this.CodePaysNaissance.Equals(input.CodePaysNaissance))
                ) && 
                (
                    this.Nationalite == input.Nationalite ||
                    (this.Nationalite != null &&
                    this.Nationalite.Equals(input.Nationalite))
                ) && 
                (
                    this.CodeNationalite == input.CodeNationalite ||
                    (this.CodeNationalite != null &&
                    this.CodeNationalite.Equals(input.CodeNationalite))
                ) && 
                (
                    this.RaisonSociale == input.RaisonSociale ||
                    (this.RaisonSociale != null &&
                    this.RaisonSociale.Equals(input.RaisonSociale))
                ) && 
                (
                    this.CodeGreffe == input.CodeGreffe ||
                    (this.CodeGreffe != null &&
                    this.CodeGreffe.Equals(input.CodeGreffe))
                ) && 
                (
                    this.LibelleGreffe == input.LibelleGreffe ||
                    (this.LibelleGreffe != null &&
                    this.LibelleGreffe.Equals(input.LibelleGreffe))
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
                if (this.NumeroIdentification != null)
                {
                    hashCode = (hashCode * 59) + this.NumeroIdentification.GetHashCode();
                }
                hashCode = (hashCode * 59) + this.Type.GetHashCode();
                if (this.Fonction != null)
                {
                    hashCode = (hashCode * 59) + this.Fonction.GetHashCode();
                }
                if (this.Nom != null)
                {
                    hashCode = (hashCode * 59) + this.Nom.GetHashCode();
                }
                if (this.Prenom != null)
                {
                    hashCode = (hashCode * 59) + this.Prenom.GetHashCode();
                }
                if (this.DateNaissance != null)
                {
                    hashCode = (hashCode * 59) + this.DateNaissance.GetHashCode();
                }
                if (this.DateNaissanceTimestamp != null)
                {
                    hashCode = (hashCode * 59) + this.DateNaissanceTimestamp.GetHashCode();
                }
                if (this.LieuNaissance != null)
                {
                    hashCode = (hashCode * 59) + this.LieuNaissance.GetHashCode();
                }
                if (this.PaysNaissance != null)
                {
                    hashCode = (hashCode * 59) + this.PaysNaissance.GetHashCode();
                }
                if (this.CodePaysNaissance != null)
                {
                    hashCode = (hashCode * 59) + this.CodePaysNaissance.GetHashCode();
                }
                if (this.Nationalite != null)
                {
                    hashCode = (hashCode * 59) + this.Nationalite.GetHashCode();
                }
                if (this.CodeNationalite != null)
                {
                    hashCode = (hashCode * 59) + this.CodeNationalite.GetHashCode();
                }
                if (this.RaisonSociale != null)
                {
                    hashCode = (hashCode * 59) + this.RaisonSociale.GetHashCode();
                }
                if (this.CodeGreffe != null)
                {
                    hashCode = (hashCode * 59) + this.CodeGreffe.GetHashCode();
                }
                if (this.LibelleGreffe != null)
                {
                    hashCode = (hashCode * 59) + this.LibelleGreffe.GetHashCode();
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
