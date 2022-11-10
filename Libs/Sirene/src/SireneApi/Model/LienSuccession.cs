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
    /// LienSuccession
    /// </summary>
    [DataContract(Name = "LienSuccession")]
    public partial class LienSuccession : IEquatable<LienSuccession>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LienSuccession" /> class.
        /// </summary>
        /// <param name="siretEtablissementPredecesseur">Numéro Siret de l&#39;établissement prédécesseur.</param>
        /// <param name="siretEtablissementSuccesseur">Numéro Siret de l&#39;établissement successeur.</param>
        /// <param name="dateLienSuccession">Date d&#39;effet du lien de succession, au format AAAA-MM-JJ.</param>
        /// <param name="transfertSiege">Indicatrice de transfert de siège.</param>
        /// <param name="continuiteEconomique">Indicatrice de continuité économique entre les deux établissements.</param>
        public LienSuccession(string siretEtablissementPredecesseur = default(string), string siretEtablissementSuccesseur = default(string), string dateLienSuccession = default(string), bool transfertSiege = default(bool), bool continuiteEconomique = default(bool))
        {
            this.SiretEtablissementPredecesseur = siretEtablissementPredecesseur;
            this.SiretEtablissementSuccesseur = siretEtablissementSuccesseur;
            this.DateLienSuccession = dateLienSuccession;
            this.TransfertSiege = transfertSiege;
            this.ContinuiteEconomique = continuiteEconomique;
        }

        /// <summary>
        /// Numéro Siret de l&#39;établissement prédécesseur
        /// </summary>
        /// <value>Numéro Siret de l&#39;établissement prédécesseur</value>
        [DataMember(Name = "siretEtablissementPredecesseur", EmitDefaultValue = false)]
        public string SiretEtablissementPredecesseur { get; set; }

        /// <summary>
        /// Numéro Siret de l&#39;établissement successeur
        /// </summary>
        /// <value>Numéro Siret de l&#39;établissement successeur</value>
        [DataMember(Name = "siretEtablissementSuccesseur", EmitDefaultValue = false)]
        public string SiretEtablissementSuccesseur { get; set; }

        /// <summary>
        /// Date d&#39;effet du lien de succession, au format AAAA-MM-JJ
        /// </summary>
        /// <value>Date d&#39;effet du lien de succession, au format AAAA-MM-JJ</value>
        [DataMember(Name = "dateLienSuccession", EmitDefaultValue = false)]
        public string DateLienSuccession { get; set; }

        /// <summary>
        /// Indicatrice de transfert de siège
        /// </summary>
        /// <value>Indicatrice de transfert de siège</value>
        [DataMember(Name = "transfertSiege", EmitDefaultValue = true)]
        public bool TransfertSiege { get; set; }

        /// <summary>
        /// Indicatrice de continuité économique entre les deux établissements
        /// </summary>
        /// <value>Indicatrice de continuité économique entre les deux établissements</value>
        [DataMember(Name = "continuiteEconomique", EmitDefaultValue = true)]
        public bool ContinuiteEconomique { get; set; }

        /// <summary>
        /// Date de traitement du lien de succession, au format AAAA-MM-JJTHH:MM:SS
        /// </summary>
        /// <value>Date de traitement du lien de succession, au format AAAA-MM-JJTHH:MM:SS</value>
        [DataMember(Name = "dateDernierTraitementLienSuccession", EmitDefaultValue = false)]
        public string DateDernierTraitementLienSuccession { get; private set; }

        /// <summary>
        /// Returns false as DateDernierTraitementLienSuccession should not be serialized given that it's read-only.
        /// </summary>
        /// <returns>false (boolean)</returns>
        public bool ShouldSerializeDateDernierTraitementLienSuccession()
        {
            return false;
        }
        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class LienSuccession {\n");
            sb.Append("  SiretEtablissementPredecesseur: ").Append(SiretEtablissementPredecesseur).Append("\n");
            sb.Append("  SiretEtablissementSuccesseur: ").Append(SiretEtablissementSuccesseur).Append("\n");
            sb.Append("  DateLienSuccession: ").Append(DateLienSuccession).Append("\n");
            sb.Append("  TransfertSiege: ").Append(TransfertSiege).Append("\n");
            sb.Append("  ContinuiteEconomique: ").Append(ContinuiteEconomique).Append("\n");
            sb.Append("  DateDernierTraitementLienSuccession: ").Append(DateDernierTraitementLienSuccession).Append("\n");
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
            return this.Equals(input as LienSuccession);
        }

        /// <summary>
        /// Returns true if LienSuccession instances are equal
        /// </summary>
        /// <param name="input">Instance of LienSuccession to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(LienSuccession input)
        {
            if (input == null)
            {
                return false;
            }
            return 
                (
                    this.SiretEtablissementPredecesseur == input.SiretEtablissementPredecesseur ||
                    (this.SiretEtablissementPredecesseur != null &&
                    this.SiretEtablissementPredecesseur.Equals(input.SiretEtablissementPredecesseur))
                ) && 
                (
                    this.SiretEtablissementSuccesseur == input.SiretEtablissementSuccesseur ||
                    (this.SiretEtablissementSuccesseur != null &&
                    this.SiretEtablissementSuccesseur.Equals(input.SiretEtablissementSuccesseur))
                ) && 
                (
                    this.DateLienSuccession == input.DateLienSuccession ||
                    (this.DateLienSuccession != null &&
                    this.DateLienSuccession.Equals(input.DateLienSuccession))
                ) && 
                (
                    this.TransfertSiege == input.TransfertSiege ||
                    this.TransfertSiege.Equals(input.TransfertSiege)
                ) && 
                (
                    this.ContinuiteEconomique == input.ContinuiteEconomique ||
                    this.ContinuiteEconomique.Equals(input.ContinuiteEconomique)
                ) && 
                (
                    this.DateDernierTraitementLienSuccession == input.DateDernierTraitementLienSuccession ||
                    (this.DateDernierTraitementLienSuccession != null &&
                    this.DateDernierTraitementLienSuccession.Equals(input.DateDernierTraitementLienSuccession))
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
                if (this.SiretEtablissementPredecesseur != null)
                {
                    hashCode = (hashCode * 59) + this.SiretEtablissementPredecesseur.GetHashCode();
                }
                if (this.SiretEtablissementSuccesseur != null)
                {
                    hashCode = (hashCode * 59) + this.SiretEtablissementSuccesseur.GetHashCode();
                }
                if (this.DateLienSuccession != null)
                {
                    hashCode = (hashCode * 59) + this.DateLienSuccession.GetHashCode();
                }
                hashCode = (hashCode * 59) + this.TransfertSiege.GetHashCode();
                hashCode = (hashCode * 59) + this.ContinuiteEconomique.GetHashCode();
                if (this.DateDernierTraitementLienSuccession != null)
                {
                    hashCode = (hashCode * 59) + this.DateDernierTraitementLienSuccession.GetHashCode();
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
