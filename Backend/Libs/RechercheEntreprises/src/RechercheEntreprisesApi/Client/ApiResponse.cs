/*
 * API Recherche d’entreprises
 *
 * # Bienvenue sur la documentation interactive d'API Recherche d’entreprises ! L’API Recherche d’entreprises permet à tout le monde de rechercher et de trouver  une entreprise française par sa dénomination, ou son adresse. ## Données accessibles dans l'API L’API étant totalement ouverte d'accès, elle comporte des limitations. Ainsi ne sont pas accessibles dans l'API : - les prédécesseurs et successeurs d'un établissement - les entreprises non-diffusibles - les entreprises qui se sont vues refuser leurs immatriculation au RCS  **Attention :** cette API ne permet pas d'accèder aux données complètes de  la  base Sirene, mais uniquement de rechercher une entreprise, par sa dénomination ou son adresse. Pour savoir comment obtenir les données complètes, consultez [notre fiche explicative.](https://api.gouv.fr/guides/quelle-api-sirene)  ## Commencer à utiliser l'API L'API est accessible à partir de cette adresse : [https://recherche-entreprises.api.gouv.fr](https://recherche-entreprises.api.gouv.fr)  **Attention :** Vous devez rajouter votre requête sur l’adresse. ## Limite des requêtes    Le serveur accepte un maximum de 7 requêtes par seconde. Au delà, un code 429 est renvoyé indiquant que la volumétrie d'appels a été dépassée.     ## Monitoring de l'API Une supervision du service en temps réel est disponible à cette adresse : [https://stats.uptimerobot.com/kXzwzfk7BE](https://stats.uptimerobot.com/kXzwzfk7BE) 
 *
 * The version of the OpenAPI document: 1.0.0
 * Contact: recherche-entreprises@api.gouv.fr
 * Generated by: https://github.com/openapitools/openapi-generator.git
 */


using System;
using System.Collections.Generic;
using System.Net;

namespace RechercheEntreprisesApi.Client
{
    /// <summary>
    /// Provides a non-generic contract for the ApiResponse wrapper.
    /// </summary>
    public interface IApiResponse
    {
        /// <summary>
        /// The data type of <see cref="Content"/>
        /// </summary>
        Type ResponseType { get; }

        /// <summary>
        /// The content of this response
        /// </summary>
        Object Content { get; }

        /// <summary>
        /// Gets or sets the status code (HTTP status code)
        /// </summary>
        /// <value>The status code.</value>
        HttpStatusCode StatusCode { get; }

        /// <summary>
        /// Gets or sets the HTTP headers
        /// </summary>
        /// <value>HTTP headers</value>
        Multimap<string, string> Headers { get; }

        /// <summary>
        /// Gets or sets any error text defined by the calling client.
        /// </summary>
        string ErrorText { get; set; }

        /// <summary>
        /// Gets or sets any cookies passed along on the response.
        /// </summary>
        List<Cookie> Cookies { get; set; }

        /// <summary>
        /// The raw content of this response
        /// </summary>
        string RawContent { get; }
    }

    /// <summary>
    /// API Response
    /// </summary>
    public class ApiResponse<T> : IApiResponse
    {
        #region Properties

        /// <summary>
        /// Gets or sets the status code (HTTP status code)
        /// </summary>
        /// <value>The status code.</value>
        public HttpStatusCode StatusCode { get; }

        /// <summary>
        /// Gets or sets the HTTP headers
        /// </summary>
        /// <value>HTTP headers</value>
        public Multimap<string, string> Headers { get; }

        /// <summary>
        /// Gets or sets the data (parsed HTTP body)
        /// </summary>
        /// <value>The data.</value>
        public T Data { get; }

        /// <summary>
        /// Gets or sets any error text defined by the calling client.
        /// </summary>
        public string ErrorText { get; set; }

        /// <summary>
        /// Gets or sets any cookies passed along on the response.
        /// </summary>
        public List<Cookie> Cookies { get; set; }

        /// <summary>
        /// The content of this response
        /// </summary>
        public Type ResponseType
        {
            get { return typeof(T); }
        }

        /// <summary>
        /// The data type of <see cref="Content"/>
        /// </summary>
        public object Content
        {
            get { return Data; }
        }

        /// <summary>
        /// The raw content
        /// </summary>
        public string RawContent { get; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ApiResponse{T}" /> class.
        /// </summary>
        /// <param name="statusCode">HTTP status code.</param>
        /// <param name="headers">HTTP headers.</param>
        /// <param name="data">Data (parsed HTTP body)</param>
        /// <param name="rawContent">Raw content.</param>
        public ApiResponse(HttpStatusCode statusCode, Multimap<string, string> headers, T data, string rawContent)
        {
            StatusCode = statusCode;
            Headers = headers;
            Data = data;
            RawContent = rawContent;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ApiResponse{T}" /> class.
        /// </summary>
        /// <param name="statusCode">HTTP status code.</param>
        /// <param name="headers">HTTP headers.</param>
        /// <param name="data">Data (parsed HTTP body)</param>
        public ApiResponse(HttpStatusCode statusCode, Multimap<string, string> headers, T data) : this(statusCode, headers, data, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ApiResponse{T}" /> class.
        /// </summary>
        /// <param name="statusCode">HTTP status code.</param>
        /// <param name="data">Data (parsed HTTP body)</param>
        /// <param name="rawContent">Raw content.</param>
        public ApiResponse(HttpStatusCode statusCode, T data, string rawContent) : this(statusCode, null, data, rawContent)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ApiResponse{T}" /> class.
        /// </summary>
        /// <param name="statusCode">HTTP status code.</param>
        /// <param name="data">Data (parsed HTTP body)</param>
        public ApiResponse(HttpStatusCode statusCode, T data) : this(statusCode, data, null)
        {
        }

        #endregion Constructors
    }
}