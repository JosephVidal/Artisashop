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
    /// ReponseEtablissement
    /// </summary>
    [DataContract(Name = "ReponseEtablissement")]
    public partial class ReponseEtablissement : IEquatable<ReponseEtablissement>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ReponseEtablissement" /> class.
        /// </summary>
        /// <param name="header">header.</param>
        /// <param name="etablissement">etablissement.</param>
        public ReponseEtablissement(Header header = default(Header), Etablissement etablissement = default(Etablissement))
        {
            this.Header = header;
            this.Etablissement = etablissement;
        }

        /// <summary>
        /// Gets or Sets Header
        /// </summary>
        [DataMember(Name = "header", EmitDefaultValue = false)]
        public Header Header { get; set; }

        /// <summary>
        /// Gets or Sets Etablissement
        /// </summary>
        [DataMember(Name = "etablissement", EmitDefaultValue = false)]
        public Etablissement Etablissement { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class ReponseEtablissement {\n");
            sb.Append("  Header: ").Append(Header).Append("\n");
            sb.Append("  Etablissement: ").Append(Etablissement).Append("\n");
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
            return this.Equals(input as ReponseEtablissement);
        }

        /// <summary>
        /// Returns true if ReponseEtablissement instances are equal
        /// </summary>
        /// <param name="input">Instance of ReponseEtablissement to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(ReponseEtablissement input)
        {
            if (input == null)
            {
                return false;
            }
            return 
                (
                    this.Header == input.Header ||
                    (this.Header != null &&
                    this.Header.Equals(input.Header))
                ) && 
                (
                    this.Etablissement == input.Etablissement ||
                    (this.Etablissement != null &&
                    this.Etablissement.Equals(input.Etablissement))
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
                if (this.Header != null)
                {
                    hashCode = (hashCode * 59) + this.Header.GetHashCode();
                }
                if (this.Etablissement != null)
                {
                    hashCode = (hashCode * 59) + this.Etablissement.GetHashCode();
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
