/*
 * API Répertoire National des Métiers
 *
 * Le service d'interrogation de la base du RNM  permet d'obtenir les informations suivantes : * Générer un extrait pdf pour une entreprise en fournissant le SIREN * Renvoyer un fichier json des données de l'entreprise en fournissant le SIREN * Renvoyer la fiche de l'entreprise en fournissant le SIREN (format html) 
 *
 * The version of the OpenAPI document: 2.0.2
 * Generated by: https://github.com/openapitools/openapi-generator.git
 */


using System;

namespace RepertoireNationalMetiersApi.Client
{
    /// <summary>
    /// Represents configuration aspects required to interact with the API endpoints.
    /// </summary>
    public interface IApiAccessor
    {
        /// <summary>
        /// Gets or sets the configuration object
        /// </summary>
        /// <value>An instance of the Configuration</value>
        IReadableConfiguration Configuration { get; set; }

        /// <summary>
        /// Gets the base path of the API client.
        /// </summary>
        /// <value>The base path</value>
        string GetBasePath();

        /// <summary>
        /// Provides a factory method hook for the creation of exceptions.
        /// </summary>
        ExceptionFactory ExceptionFactory { get; set; }
    }
}
