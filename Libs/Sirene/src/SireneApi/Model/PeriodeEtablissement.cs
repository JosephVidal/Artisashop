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
    /// Ensemble des variables historisées de l&#39;établissement entre dateDebut et dateFin
    /// </summary>
    [DataContract(Name = "PeriodeEtablissement")]
    public partial class PeriodeEtablissement : IEquatable<PeriodeEtablissement>, IValidatableObject
    {
        /// <summary>
        /// Nomenclature de l&#39;activité, permet de savoir à partir de quelle nomenclature est codifiée ActivitePrincipaleEtablissement
        /// </summary>
        /// <value>Nomenclature de l&#39;activité, permet de savoir à partir de quelle nomenclature est codifiée ActivitePrincipaleEtablissement</value>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum NomenclatureActivitePrincipaleEtablissementEnum
        {
            /// <summary>
            /// Enum NAP for value: NAP
            /// </summary>
            [EnumMember(Value = "NAP")]
            NAP = 1,

            /// <summary>
            /// Enum NAFRev1 for value: NAFRev1
            /// </summary>
            [EnumMember(Value = "NAFRev1")]
            NAFRev1 = 2,

            /// <summary>
            /// Enum NAFRev2 for value: NAFRev2
            /// </summary>
            [EnumMember(Value = "NAFRev2")]
            NAFRev2 = 3,

            /// <summary>
            /// Enum NAF1993 for value: NAF1993
            /// </summary>
            [EnumMember(Value = "NAF1993")]
            NAF1993 = 4

        }


        /// <summary>
        /// Nomenclature de l&#39;activité, permet de savoir à partir de quelle nomenclature est codifiée ActivitePrincipaleEtablissement
        /// </summary>
        /// <value>Nomenclature de l&#39;activité, permet de savoir à partir de quelle nomenclature est codifiée ActivitePrincipaleEtablissement</value>
        [DataMember(Name = "nomenclatureActivitePrincipaleEtablissement", EmitDefaultValue = false)]
        public NomenclatureActivitePrincipaleEtablissementEnum? NomenclatureActivitePrincipaleEtablissement { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="PeriodeEtablissement" /> class.
        /// </summary>
        /// <param name="dateFin">Date de fin de la période, null pour la dernière période, format AAAA-MM-DD.</param>
        /// <param name="dateDebut">Date de début de la période, format AAAA-MM-DD.</param>
        /// <param name="etatAdministratifEtablissement">État administratif de l&#39;établissement pendant la période (A&#x3D; établissement actif ; F&#x3D; établissement fermé).</param>
        /// <param name="changementEtatAdministratifEtablissement">Indicatrice de changement de l&#39;état administratif de l&#39;établissement par rapport à la période précédente.</param>
        /// <param name="enseigne1Etablissement">Première ligne d&#39;enseigne.</param>
        /// <param name="enseigne2Etablissement">Deuxième ligne d&#39;enseigne.</param>
        /// <param name="enseigne3Etablissement">Troisième ligne d&#39;enseigne.</param>
        /// <param name="changementEnseigneEtablissement">Indicatrice de changement de l&#39;enseigne de l&#39;établissement par rapport à la période précédente (un seul indicateur pour les trois variables Enseigne1, Enseigne2 et Enseigne3).</param>
        /// <param name="denominationUsuelleEtablissement">Nom sous lequel l’activité de l’établissement est connu du public .</param>
        /// <param name="changementDenominationUsuelleEtablissement">Indicatrice de changement de la dénomination usuelle de l’établissement par rapport à la période précédente.</param>
        /// <param name="activitePrincipaleEtablissement">Activité principale de l&#39;établissement pendant la période (l&#39;APE est codifiée selon la &lt;a href&#x3D;&#39;https://www.insee.fr/fr/information/2406147&#39;&gt;nomenclature d&#39;Activités Française (NAF)&lt;/a&gt;.</param>
        /// <param name="nomenclatureActivitePrincipaleEtablissement">Nomenclature de l&#39;activité, permet de savoir à partir de quelle nomenclature est codifiée ActivitePrincipaleEtablissement.</param>
        /// <param name="changementActivitePrincipaleEtablissement">Indicatrice de changement de l&#39;activité principale de l&#39;établissement par rapport à la période précédente.</param>
        /// <param name="caractereEmployeurEtablissement">Caractère employeur de l&#39;établissement (O&#x3D;oui ; N&#x3D;non ; null&#x3D;sans objet).</param>
        /// <param name="changementCaractereEmployeurEtablissement">Indicatrice de changement du caractère employeur de l&#39;établissement par rapport à la période précédente.</param>
        public PeriodeEtablissement(DateTime dateFin = default(DateTime), DateTime dateDebut = default(DateTime), string etatAdministratifEtablissement = default(string), bool changementEtatAdministratifEtablissement = default(bool), string enseigne1Etablissement = default(string), string enseigne2Etablissement = default(string), string enseigne3Etablissement = default(string), bool changementEnseigneEtablissement = default(bool), string denominationUsuelleEtablissement = default(string), bool changementDenominationUsuelleEtablissement = default(bool), string activitePrincipaleEtablissement = default(string), NomenclatureActivitePrincipaleEtablissementEnum? nomenclatureActivitePrincipaleEtablissement = default(NomenclatureActivitePrincipaleEtablissementEnum?), bool changementActivitePrincipaleEtablissement = default(bool), string caractereEmployeurEtablissement = default(string), bool changementCaractereEmployeurEtablissement = default(bool))
        {
            this.DateFin = dateFin;
            this.DateDebut = dateDebut;
            this.EtatAdministratifEtablissement = etatAdministratifEtablissement;
            this.ChangementEtatAdministratifEtablissement = changementEtatAdministratifEtablissement;
            this.Enseigne1Etablissement = enseigne1Etablissement;
            this.Enseigne2Etablissement = enseigne2Etablissement;
            this.Enseigne3Etablissement = enseigne3Etablissement;
            this.ChangementEnseigneEtablissement = changementEnseigneEtablissement;
            this.DenominationUsuelleEtablissement = denominationUsuelleEtablissement;
            this.ChangementDenominationUsuelleEtablissement = changementDenominationUsuelleEtablissement;
            this.ActivitePrincipaleEtablissement = activitePrincipaleEtablissement;
            this.NomenclatureActivitePrincipaleEtablissement = nomenclatureActivitePrincipaleEtablissement;
            this.ChangementActivitePrincipaleEtablissement = changementActivitePrincipaleEtablissement;
            this.CaractereEmployeurEtablissement = caractereEmployeurEtablissement;
            this.ChangementCaractereEmployeurEtablissement = changementCaractereEmployeurEtablissement;
        }

        /// <summary>
        /// Date de fin de la période, null pour la dernière période, format AAAA-MM-DD
        /// </summary>
        /// <value>Date de fin de la période, null pour la dernière période, format AAAA-MM-DD</value>
        [DataMember(Name = "dateFin", EmitDefaultValue = false)]
        [JsonConverter(typeof(OpenAPIDateConverter))]
        public DateTime DateFin { get; set; }

        /// <summary>
        /// Date de début de la période, format AAAA-MM-DD
        /// </summary>
        /// <value>Date de début de la période, format AAAA-MM-DD</value>
        [DataMember(Name = "dateDebut", EmitDefaultValue = false)]
        [JsonConverter(typeof(OpenAPIDateConverter))]
        public DateTime DateDebut { get; set; }

        /// <summary>
        /// État administratif de l&#39;établissement pendant la période (A&#x3D; établissement actif ; F&#x3D; établissement fermé)
        /// </summary>
        /// <value>État administratif de l&#39;établissement pendant la période (A&#x3D; établissement actif ; F&#x3D; établissement fermé)</value>
        [DataMember(Name = "etatAdministratifEtablissement", EmitDefaultValue = false)]
        public string EtatAdministratifEtablissement { get; set; }

        /// <summary>
        /// Indicatrice de changement de l&#39;état administratif de l&#39;établissement par rapport à la période précédente
        /// </summary>
        /// <value>Indicatrice de changement de l&#39;état administratif de l&#39;établissement par rapport à la période précédente</value>
        [DataMember(Name = "changementEtatAdministratifEtablissement", EmitDefaultValue = true)]
        public bool ChangementEtatAdministratifEtablissement { get; set; }

        /// <summary>
        /// Première ligne d&#39;enseigne
        /// </summary>
        /// <value>Première ligne d&#39;enseigne</value>
        [DataMember(Name = "enseigne1Etablissement", EmitDefaultValue = false)]
        public string Enseigne1Etablissement { get; set; }

        /// <summary>
        /// Deuxième ligne d&#39;enseigne
        /// </summary>
        /// <value>Deuxième ligne d&#39;enseigne</value>
        [DataMember(Name = "enseigne2Etablissement", EmitDefaultValue = false)]
        public string Enseigne2Etablissement { get; set; }

        /// <summary>
        /// Troisième ligne d&#39;enseigne
        /// </summary>
        /// <value>Troisième ligne d&#39;enseigne</value>
        [DataMember(Name = "enseigne3Etablissement", EmitDefaultValue = false)]
        public string Enseigne3Etablissement { get; set; }

        /// <summary>
        /// Indicatrice de changement de l&#39;enseigne de l&#39;établissement par rapport à la période précédente (un seul indicateur pour les trois variables Enseigne1, Enseigne2 et Enseigne3)
        /// </summary>
        /// <value>Indicatrice de changement de l&#39;enseigne de l&#39;établissement par rapport à la période précédente (un seul indicateur pour les trois variables Enseigne1, Enseigne2 et Enseigne3)</value>
        [DataMember(Name = "changementEnseigneEtablissement", EmitDefaultValue = true)]
        public bool ChangementEnseigneEtablissement { get; set; }

        /// <summary>
        /// Nom sous lequel l’activité de l’établissement est connu du public 
        /// </summary>
        /// <value>Nom sous lequel l’activité de l’établissement est connu du public </value>
        [DataMember(Name = "denominationUsuelleEtablissement", EmitDefaultValue = false)]
        public string DenominationUsuelleEtablissement { get; set; }

        /// <summary>
        /// Indicatrice de changement de la dénomination usuelle de l’établissement par rapport à la période précédente
        /// </summary>
        /// <value>Indicatrice de changement de la dénomination usuelle de l’établissement par rapport à la période précédente</value>
        [DataMember(Name = "changementDenominationUsuelleEtablissement", EmitDefaultValue = true)]
        public bool ChangementDenominationUsuelleEtablissement { get; set; }

        /// <summary>
        /// Activité principale de l&#39;établissement pendant la période (l&#39;APE est codifiée selon la &lt;a href&#x3D;&#39;https://www.insee.fr/fr/information/2406147&#39;&gt;nomenclature d&#39;Activités Française (NAF)&lt;/a&gt;
        /// </summary>
        /// <value>Activité principale de l&#39;établissement pendant la période (l&#39;APE est codifiée selon la &lt;a href&#x3D;&#39;https://www.insee.fr/fr/information/2406147&#39;&gt;nomenclature d&#39;Activités Française (NAF)&lt;/a&gt;</value>
        [DataMember(Name = "activitePrincipaleEtablissement", EmitDefaultValue = false)]
        public string ActivitePrincipaleEtablissement { get; set; }

        /// <summary>
        /// Indicatrice de changement de l&#39;activité principale de l&#39;établissement par rapport à la période précédente
        /// </summary>
        /// <value>Indicatrice de changement de l&#39;activité principale de l&#39;établissement par rapport à la période précédente</value>
        [DataMember(Name = "changementActivitePrincipaleEtablissement", EmitDefaultValue = true)]
        public bool ChangementActivitePrincipaleEtablissement { get; set; }

        /// <summary>
        /// Caractère employeur de l&#39;établissement (O&#x3D;oui ; N&#x3D;non ; null&#x3D;sans objet)
        /// </summary>
        /// <value>Caractère employeur de l&#39;établissement (O&#x3D;oui ; N&#x3D;non ; null&#x3D;sans objet)</value>
        [DataMember(Name = "caractereEmployeurEtablissement", EmitDefaultValue = false)]
        public string CaractereEmployeurEtablissement { get; set; }

        /// <summary>
        /// Indicatrice de changement du caractère employeur de l&#39;établissement par rapport à la période précédente
        /// </summary>
        /// <value>Indicatrice de changement du caractère employeur de l&#39;établissement par rapport à la période précédente</value>
        [DataMember(Name = "changementCaractereEmployeurEtablissement", EmitDefaultValue = true)]
        public bool ChangementCaractereEmployeurEtablissement { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class PeriodeEtablissement {\n");
            sb.Append("  DateFin: ").Append(DateFin).Append("\n");
            sb.Append("  DateDebut: ").Append(DateDebut).Append("\n");
            sb.Append("  EtatAdministratifEtablissement: ").Append(EtatAdministratifEtablissement).Append("\n");
            sb.Append("  ChangementEtatAdministratifEtablissement: ").Append(ChangementEtatAdministratifEtablissement).Append("\n");
            sb.Append("  Enseigne1Etablissement: ").Append(Enseigne1Etablissement).Append("\n");
            sb.Append("  Enseigne2Etablissement: ").Append(Enseigne2Etablissement).Append("\n");
            sb.Append("  Enseigne3Etablissement: ").Append(Enseigne3Etablissement).Append("\n");
            sb.Append("  ChangementEnseigneEtablissement: ").Append(ChangementEnseigneEtablissement).Append("\n");
            sb.Append("  DenominationUsuelleEtablissement: ").Append(DenominationUsuelleEtablissement).Append("\n");
            sb.Append("  ChangementDenominationUsuelleEtablissement: ").Append(ChangementDenominationUsuelleEtablissement).Append("\n");
            sb.Append("  ActivitePrincipaleEtablissement: ").Append(ActivitePrincipaleEtablissement).Append("\n");
            sb.Append("  NomenclatureActivitePrincipaleEtablissement: ").Append(NomenclatureActivitePrincipaleEtablissement).Append("\n");
            sb.Append("  ChangementActivitePrincipaleEtablissement: ").Append(ChangementActivitePrincipaleEtablissement).Append("\n");
            sb.Append("  CaractereEmployeurEtablissement: ").Append(CaractereEmployeurEtablissement).Append("\n");
            sb.Append("  ChangementCaractereEmployeurEtablissement: ").Append(ChangementCaractereEmployeurEtablissement).Append("\n");
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
            return this.Equals(input as PeriodeEtablissement);
        }

        /// <summary>
        /// Returns true if PeriodeEtablissement instances are equal
        /// </summary>
        /// <param name="input">Instance of PeriodeEtablissement to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(PeriodeEtablissement input)
        {
            if (input == null)
            {
                return false;
            }
            return 
                (
                    this.DateFin == input.DateFin ||
                    (this.DateFin != null &&
                    this.DateFin.Equals(input.DateFin))
                ) && 
                (
                    this.DateDebut == input.DateDebut ||
                    (this.DateDebut != null &&
                    this.DateDebut.Equals(input.DateDebut))
                ) && 
                (
                    this.EtatAdministratifEtablissement == input.EtatAdministratifEtablissement ||
                    (this.EtatAdministratifEtablissement != null &&
                    this.EtatAdministratifEtablissement.Equals(input.EtatAdministratifEtablissement))
                ) && 
                (
                    this.ChangementEtatAdministratifEtablissement == input.ChangementEtatAdministratifEtablissement ||
                    this.ChangementEtatAdministratifEtablissement.Equals(input.ChangementEtatAdministratifEtablissement)
                ) && 
                (
                    this.Enseigne1Etablissement == input.Enseigne1Etablissement ||
                    (this.Enseigne1Etablissement != null &&
                    this.Enseigne1Etablissement.Equals(input.Enseigne1Etablissement))
                ) && 
                (
                    this.Enseigne2Etablissement == input.Enseigne2Etablissement ||
                    (this.Enseigne2Etablissement != null &&
                    this.Enseigne2Etablissement.Equals(input.Enseigne2Etablissement))
                ) && 
                (
                    this.Enseigne3Etablissement == input.Enseigne3Etablissement ||
                    (this.Enseigne3Etablissement != null &&
                    this.Enseigne3Etablissement.Equals(input.Enseigne3Etablissement))
                ) && 
                (
                    this.ChangementEnseigneEtablissement == input.ChangementEnseigneEtablissement ||
                    this.ChangementEnseigneEtablissement.Equals(input.ChangementEnseigneEtablissement)
                ) && 
                (
                    this.DenominationUsuelleEtablissement == input.DenominationUsuelleEtablissement ||
                    (this.DenominationUsuelleEtablissement != null &&
                    this.DenominationUsuelleEtablissement.Equals(input.DenominationUsuelleEtablissement))
                ) && 
                (
                    this.ChangementDenominationUsuelleEtablissement == input.ChangementDenominationUsuelleEtablissement ||
                    this.ChangementDenominationUsuelleEtablissement.Equals(input.ChangementDenominationUsuelleEtablissement)
                ) && 
                (
                    this.ActivitePrincipaleEtablissement == input.ActivitePrincipaleEtablissement ||
                    (this.ActivitePrincipaleEtablissement != null &&
                    this.ActivitePrincipaleEtablissement.Equals(input.ActivitePrincipaleEtablissement))
                ) && 
                (
                    this.NomenclatureActivitePrincipaleEtablissement == input.NomenclatureActivitePrincipaleEtablissement ||
                    this.NomenclatureActivitePrincipaleEtablissement.Equals(input.NomenclatureActivitePrincipaleEtablissement)
                ) && 
                (
                    this.ChangementActivitePrincipaleEtablissement == input.ChangementActivitePrincipaleEtablissement ||
                    this.ChangementActivitePrincipaleEtablissement.Equals(input.ChangementActivitePrincipaleEtablissement)
                ) && 
                (
                    this.CaractereEmployeurEtablissement == input.CaractereEmployeurEtablissement ||
                    (this.CaractereEmployeurEtablissement != null &&
                    this.CaractereEmployeurEtablissement.Equals(input.CaractereEmployeurEtablissement))
                ) && 
                (
                    this.ChangementCaractereEmployeurEtablissement == input.ChangementCaractereEmployeurEtablissement ||
                    this.ChangementCaractereEmployeurEtablissement.Equals(input.ChangementCaractereEmployeurEtablissement)
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
                if (this.DateFin != null)
                {
                    hashCode = (hashCode * 59) + this.DateFin.GetHashCode();
                }
                if (this.DateDebut != null)
                {
                    hashCode = (hashCode * 59) + this.DateDebut.GetHashCode();
                }
                if (this.EtatAdministratifEtablissement != null)
                {
                    hashCode = (hashCode * 59) + this.EtatAdministratifEtablissement.GetHashCode();
                }
                hashCode = (hashCode * 59) + this.ChangementEtatAdministratifEtablissement.GetHashCode();
                if (this.Enseigne1Etablissement != null)
                {
                    hashCode = (hashCode * 59) + this.Enseigne1Etablissement.GetHashCode();
                }
                if (this.Enseigne2Etablissement != null)
                {
                    hashCode = (hashCode * 59) + this.Enseigne2Etablissement.GetHashCode();
                }
                if (this.Enseigne3Etablissement != null)
                {
                    hashCode = (hashCode * 59) + this.Enseigne3Etablissement.GetHashCode();
                }
                hashCode = (hashCode * 59) + this.ChangementEnseigneEtablissement.GetHashCode();
                if (this.DenominationUsuelleEtablissement != null)
                {
                    hashCode = (hashCode * 59) + this.DenominationUsuelleEtablissement.GetHashCode();
                }
                hashCode = (hashCode * 59) + this.ChangementDenominationUsuelleEtablissement.GetHashCode();
                if (this.ActivitePrincipaleEtablissement != null)
                {
                    hashCode = (hashCode * 59) + this.ActivitePrincipaleEtablissement.GetHashCode();
                }
                hashCode = (hashCode * 59) + this.NomenclatureActivitePrincipaleEtablissement.GetHashCode();
                hashCode = (hashCode * 59) + this.ChangementActivitePrincipaleEtablissement.GetHashCode();
                if (this.CaractereEmployeurEtablissement != null)
                {
                    hashCode = (hashCode * 59) + this.CaractereEmployeurEtablissement.GetHashCode();
                }
                hashCode = (hashCode * 59) + this.ChangementCaractereEmployeurEtablissement.GetHashCode();
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
