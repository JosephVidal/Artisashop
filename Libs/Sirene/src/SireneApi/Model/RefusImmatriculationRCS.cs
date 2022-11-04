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
    /// RefusImmatriculationRCS
    /// </summary>
    [DataContract(Name = "RefusImmatriculationRCS")]
    public partial class RefusImmatriculationRCS : IEquatable<RefusImmatriculationRCS>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RefusImmatriculationRCS" /> class.
        /// </summary>
        /// <param name="siren">Numéro Siren de l&#39;entreprise.</param>
        /// <param name="dateSuppressionUniteLegale">Date de traitement au répertoire Sirene du refus d&#39;immatriculation au RCS, au format AAAA-MM-JJTHH:MM:SS.</param>
        public RefusImmatriculationRCS(string siren = default(string), string dateSuppressionUniteLegale = default(string))
        {
            this.Siren = siren;
            this.DateSuppressionUniteLegale = dateSuppressionUniteLegale;
        }

        /// <summary>
        /// Numéro Siren de l&#39;entreprise
        /// </summary>
        /// <value>Numéro Siren de l&#39;entreprise</value>
        [DataMember(Name = "siren", EmitDefaultValue = false)]
        public string Siren { get; set; }

        /// <summary>
        /// Date de traitement au répertoire Sirene du refus d&#39;immatriculation au RCS, au format AAAA-MM-JJTHH:MM:SS
        /// </summary>
        /// <value>Date de traitement au répertoire Sirene du refus d&#39;immatriculation au RCS, au format AAAA-MM-JJTHH:MM:SS</value>
        [DataMember(Name = "dateSuppressionUniteLegale", EmitDefaultValue = false)]
        public string DateSuppressionUniteLegale { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class RefusImmatriculationRCS {\n");
            sb.Append("  Siren: ").Append(Siren).Append("\n");
            sb.Append("  DateSuppressionUniteLegale: ").Append(DateSuppressionUniteLegale).Append("\n");
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
            return this.Equals(input as RefusImmatriculationRCS);
        }

        /// <summary>
        /// Returns true if RefusImmatriculationRCS instances are equal
        /// </summary>
        /// <param name="input">Instance of RefusImmatriculationRCS to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(RefusImmatriculationRCS input)
        {
            if (input == null)
            {
                return false;
            }
            return 
                (
                    this.Siren == input.Siren ||
                    (this.Siren != null &&
                    this.Siren.Equals(input.Siren))
                ) && 
                (
                    this.DateSuppressionUniteLegale == input.DateSuppressionUniteLegale ||
                    (this.DateSuppressionUniteLegale != null &&
                    this.DateSuppressionUniteLegale.Equals(input.DateSuppressionUniteLegale))
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
                if (this.Siren != null)
                {
                    hashCode = (hashCode * 59) + this.Siren.GetHashCode();
                }
                if (this.DateSuppressionUniteLegale != null)
                {
                    hashCode = (hashCode * 59) + this.DateSuppressionUniteLegale.GetHashCode();
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
