/*
 * API Répertoire National des Métiers
 *
 * Le service d'interrogation de la base du RNM  permet d'obtenir les informations suivantes : * Générer un extrait pdf pour une entreprise en fournissant le SIREN * Renvoyer un fichier json des données de l'entreprise en fournissant le SIREN * Renvoyer la fiche de l'entreprise en fournissant le SIREN (format html) 
 *
 * The version of the OpenAPI document: 2.0.2
 * Generated by: https://github.com/openapitools/openapi-generator.git
 */


using Polly;
using RestSharp;

namespace CmaApi.Client
{
    /// <summary>
    /// Configuration class to set the polly retry policies to be applied to the requests.
    /// </summary>
    public static class RetryConfiguration
    {
        /// <summary>
        /// Retry policy
        /// </summary>
        public static Policy<IRestResponse> RetryPolicy { get; set; }

        /// <summary>
        /// Async retry policy
        /// </summary>
        public static AsyncPolicy<IRestResponse> AsyncRetryPolicy { get; set; }
    }
}
