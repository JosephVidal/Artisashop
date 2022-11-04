/*
 * API Répertoire National des Métiers
 *
 * Le service d'interrogation de la base du RNM  permet d'obtenir les informations suivantes : * Générer un extrait pdf pour une entreprise en fournissant le SIREN * Renvoyer un fichier json des données de l'entreprise en fournissant le SIREN * Renvoyer la fiche de l'entreprise en fournissant le SIREN (format html) 
 *
 * The version of the OpenAPI document: 2.0.2
 * Generated by: https://github.com/openapitools/openapi-generator.git
 */


using System.Collections.Generic;

namespace RepertoireNationalMetiersApi.Client
{
    /// <summary>
    /// <see cref="GlobalConfiguration"/> provides a compile-time extension point for globally configuring
    /// API Clients.
    /// </summary>
    /// <remarks>
    /// A customized implementation via partial class may reside in another file and may
    /// be excluded from automatic generation via a .openapi-generator-ignore file.
    /// </remarks>
    public partial class GlobalConfiguration : Configuration
    {
        #region Private Members

        private static readonly object GlobalConfigSync = new { };
        private static IReadableConfiguration _globalConfiguration;

        #endregion Private Members

        #region Constructors

        /// <inheritdoc />
        private GlobalConfiguration()
        {
        }

        /// <inheritdoc />
        public GlobalConfiguration(IDictionary<string, string> defaultHeader, IDictionary<string, string> apiKey, IDictionary<string, string> apiKeyPrefix, string basePath = "http://localhost:3000/api") : base(defaultHeader, apiKey, apiKeyPrefix, basePath)
        {
        }

        static GlobalConfiguration()
        {
            Instance = new GlobalConfiguration();
        }

        #endregion Constructors

        /// <summary>
        /// Gets or sets the default Configuration.
        /// </summary>
        /// <value>Configuration.</value>
        public static IReadableConfiguration Instance
        {
            get { return _globalConfiguration; }
            set
            {
                lock (GlobalConfigSync)
                {
                    _globalConfiguration = value;
                }
            }
        }
    }
}
