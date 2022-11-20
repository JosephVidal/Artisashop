/*
 * API Sirene
 *
 * <p><span style=\"color:red;\"> <b></b></p><br></span><span style=\"color:blue;\"> <b>Les tranches d’effectifs et les catégories d’entreprises du millésime 2020 sont désormais disponibles</b></span> <br><br><span style=\"color:blue;\"><i>La documentation des services est désormais au format html (Cf. Onglet Documentation)</i></span></p> <p><h4 class=\"add-margin-top-5x\"><b>Les données du répertoire Sirene depuis 1973</b></h4><p>API Sirene donne accès aux informations concernant les entreprises et les établissements enregistrés au répertoire interadministratif Sirene depuis sa création en 1973, y compris les unités fermées.</p> <p>La recherche peut être unitaire, multicritère, phonétique et porter sur les données courantes et historisées.</p> <p></p> <p>Les services actuellement disponibles interrogent :</p> <ul> <li> les unités légales (siren) </li> <li> les établissements (siret). </li> </ul> <p>Le service informations permet de connaître les dates de dernières mises à jour.</p> <p>Le service Liens de succession informe sur les prédécesseurs et les successeurs des établissements.</p> <p align=\"justify\" style=\"margin-top: 0.6cm\">Le service nonDiffusibles restitue les siren et siret des personnes physiques ayant demandé à être exclues de la diffusion publique conformément à l'article A123-96 du code de commerce. Les informations les concernant ne peuvent alors être rediffusées, ni utilisées à des fins de prospection. Les utilisateurs ayant un référentiel en interne peuvent ainsi le mettre à jour quotidiennement.</p> <p>La lettre <b>Sirene open data actualités</b> est destinée aux utilisateurs des données Sirene. Pour vous abonner, <a href=\"https://insee.fr/fr/information/1405555\">suivez ce lien</a>. Pour consulter les précédents numéros, <a href=\"https://insee.fr/fr/information/3711739\">cliquez ici</a>.</p>
 *
 * The version of the OpenAPI document: 3.9
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
using OpenAPIDateConverter = SireneApi.Client.OpenAPIDateConverter;

namespace SireneApi.Model
{
    /// <summary>
    /// Informations générales sur le résultat de la requête
    /// </summary>
    [DataContract(Name = "Header")]
    public partial class Header : IEquatable<Header>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Header" /> class.
        /// </summary>
        /// <param name="statut">Égal au status de la réponse HTTP.</param>
        /// <param name="message">En cas d&#39;erreur, message indiquant la cause de l&#39;erreur. OK sinon.</param>
        /// <param name="total">Nombre total des éléments répondant à la requête.</param>
        /// <param name="debut">Numéro du premier élément fourni, défaut à 0, commence à 0.</param>
        /// <param name="nombre">Nombre d&#39;éléments fournis, défaut à 20.</param>
        /// <param name="curseur">Curseur passé en argument dans la requête de l&#39;utilisateur, utilisé pour la pagination profonde.</param>
        /// <param name="curseurSuivant">Curseur suivant pour accéder à la suite des résultat lorsqu&#39;on utilise la pagination profonde.</param>
        public Header(int statut = default(int), string message = default(string), int total = default(int), int debut = default(int), int nombre = default(int), string curseur = default(string), string curseurSuivant = default(string))
        {
            this.Statut = statut;
            this.Message = message;
            this.Total = total;
            this.Debut = debut;
            this.Nombre = nombre;
            this.Curseur = curseur;
            this.CurseurSuivant = curseurSuivant;
        }

        /// <summary>
        /// Égal au status de la réponse HTTP
        /// </summary>
        /// <value>Égal au status de la réponse HTTP</value>
        [DataMember(Name = "statut", EmitDefaultValue = false)]
        public int Statut { get; set; }

        /// <summary>
        /// En cas d&#39;erreur, message indiquant la cause de l&#39;erreur. OK sinon
        /// </summary>
        /// <value>En cas d&#39;erreur, message indiquant la cause de l&#39;erreur. OK sinon</value>
        [DataMember(Name = "message", EmitDefaultValue = false)]
        public string Message { get; set; }

        /// <summary>
        /// Nombre total des éléments répondant à la requête
        /// </summary>
        /// <value>Nombre total des éléments répondant à la requête</value>
        [DataMember(Name = "total", EmitDefaultValue = false)]
        public int Total { get; set; }

        /// <summary>
        /// Numéro du premier élément fourni, défaut à 0, commence à 0
        /// </summary>
        /// <value>Numéro du premier élément fourni, défaut à 0, commence à 0</value>
        [DataMember(Name = "debut", EmitDefaultValue = false)]
        public int Debut { get; set; }

        /// <summary>
        /// Nombre d&#39;éléments fournis, défaut à 20
        /// </summary>
        /// <value>Nombre d&#39;éléments fournis, défaut à 20</value>
        [DataMember(Name = "nombre", EmitDefaultValue = false)]
        public int Nombre { get; set; }

        /// <summary>
        /// Curseur passé en argument dans la requête de l&#39;utilisateur, utilisé pour la pagination profonde
        /// </summary>
        /// <value>Curseur passé en argument dans la requête de l&#39;utilisateur, utilisé pour la pagination profonde</value>
        [DataMember(Name = "curseur", EmitDefaultValue = false)]
        public string Curseur { get; set; }

        /// <summary>
        /// Curseur suivant pour accéder à la suite des résultat lorsqu&#39;on utilise la pagination profonde
        /// </summary>
        /// <value>Curseur suivant pour accéder à la suite des résultat lorsqu&#39;on utilise la pagination profonde</value>
        [DataMember(Name = "curseurSuivant", EmitDefaultValue = false)]
        public string CurseurSuivant { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class Header {\n");
            sb.Append("  Statut: ").Append(Statut).Append("\n");
            sb.Append("  Message: ").Append(Message).Append("\n");
            sb.Append("  Total: ").Append(Total).Append("\n");
            sb.Append("  Debut: ").Append(Debut).Append("\n");
            sb.Append("  Nombre: ").Append(Nombre).Append("\n");
            sb.Append("  Curseur: ").Append(Curseur).Append("\n");
            sb.Append("  CurseurSuivant: ").Append(CurseurSuivant).Append("\n");
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
            return this.Equals(input as Header);
        }

        /// <summary>
        /// Returns true if Header instances are equal
        /// </summary>
        /// <param name="input">Instance of Header to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(Header input)
        {
            if (input == null)
            {
                return false;
            }
            return 
                (
                    this.Statut == input.Statut ||
                    this.Statut.Equals(input.Statut)
                ) && 
                (
                    this.Message == input.Message ||
                    (this.Message != null &&
                    this.Message.Equals(input.Message))
                ) && 
                (
                    this.Total == input.Total ||
                    this.Total.Equals(input.Total)
                ) && 
                (
                    this.Debut == input.Debut ||
                    this.Debut.Equals(input.Debut)
                ) && 
                (
                    this.Nombre == input.Nombre ||
                    this.Nombre.Equals(input.Nombre)
                ) && 
                (
                    this.Curseur == input.Curseur ||
                    (this.Curseur != null &&
                    this.Curseur.Equals(input.Curseur))
                ) && 
                (
                    this.CurseurSuivant == input.CurseurSuivant ||
                    (this.CurseurSuivant != null &&
                    this.CurseurSuivant.Equals(input.CurseurSuivant))
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
                hashCode = (hashCode * 59) + this.Statut.GetHashCode();
                if (this.Message != null)
                {
                    hashCode = (hashCode * 59) + this.Message.GetHashCode();
                }
                hashCode = (hashCode * 59) + this.Total.GetHashCode();
                hashCode = (hashCode * 59) + this.Debut.GetHashCode();
                hashCode = (hashCode * 59) + this.Nombre.GetHashCode();
                if (this.Curseur != null)
                {
                    hashCode = (hashCode * 59) + this.Curseur.GetHashCode();
                }
                if (this.CurseurSuivant != null)
                {
                    hashCode = (hashCode * 59) + this.CurseurSuivant.GetHashCode();
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