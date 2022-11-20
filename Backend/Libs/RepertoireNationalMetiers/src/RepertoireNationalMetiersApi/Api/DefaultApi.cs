/*
 * API Répertoire National des Métiers
 *
 * Le service d'interrogation de la base du RNM  permet d'obtenir les informations suivantes : * Générer un extrait pdf pour une entreprise en fournissant le SIREN * Renvoyer un fichier json des données de l'entreprise en fournissant le SIREN * Renvoyer la fiche de l'entreprise en fournissant le SIREN (format html) 
 *
 * The version of the OpenAPI document: 2.0.2
 * Generated by: https://github.com/openapitools/openapi-generator.git
 */


using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Net.Mime;
using RepertoireNationalMetiersApi.Client;
using RepertoireNationalMetiersApi.Model;

namespace RepertoireNationalMetiersApi.Api
{

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface IDefaultApiSync : IApiAccessor
    {
        #region Synchronous Operations
        /// <summary>
        /// Renvoi un fichier JSON des données de l&#39;entreprise en fournissant le SIREN
        /// </summary>
        /// <remarks>
        /// Get document whith selected format JSON/HTML/PDF (default is JSON)
        /// </remarks>
        /// <exception cref="RepertoireNationalMetiersApi.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="siren">The enterprise siren</param>
        /// <param name="format">The document format (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>Entreprise</returns>
        Entreprise V2EntreprisesSirenGet(string siren, string? format = default(string?), int operationIndex = 0);

        /// <summary>
        /// Renvoi un fichier JSON des données de l&#39;entreprise en fournissant le SIREN
        /// </summary>
        /// <remarks>
        /// Get document whith selected format JSON/HTML/PDF (default is JSON)
        /// </remarks>
        /// <exception cref="RepertoireNationalMetiersApi.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="siren">The enterprise siren</param>
        /// <param name="format">The document format (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of Entreprise</returns>
        ApiResponse<Entreprise> V2EntreprisesSirenGetWithHttpInfo(string siren, string? format = default(string?), int operationIndex = 0);
        #endregion Synchronous Operations
    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface IDefaultApiAsync : IApiAccessor
    {
        #region Asynchronous Operations
        /// <summary>
        /// Renvoi un fichier JSON des données de l&#39;entreprise en fournissant le SIREN
        /// </summary>
        /// <remarks>
        /// Get document whith selected format JSON/HTML/PDF (default is JSON)
        /// </remarks>
        /// <exception cref="RepertoireNationalMetiersApi.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="siren">The enterprise siren</param>
        /// <param name="format">The document format (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of Entreprise</returns>
        System.Threading.Tasks.Task<Entreprise> V2EntreprisesSirenGetAsync(string siren, string? format = default(string?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// Renvoi un fichier JSON des données de l&#39;entreprise en fournissant le SIREN
        /// </summary>
        /// <remarks>
        /// Get document whith selected format JSON/HTML/PDF (default is JSON)
        /// </remarks>
        /// <exception cref="RepertoireNationalMetiersApi.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="siren">The enterprise siren</param>
        /// <param name="format">The document format (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (Entreprise)</returns>
        System.Threading.Tasks.Task<ApiResponse<Entreprise>> V2EntreprisesSirenGetWithHttpInfoAsync(string siren, string? format = default(string?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        #endregion Asynchronous Operations
    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface IDefaultApi : IDefaultApiSync, IDefaultApiAsync
    {

    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public partial class DefaultApi : IDefaultApi
    {
        private RepertoireNationalMetiersApi.Client.ExceptionFactory _exceptionFactory = (name, response) => null;

        /// <summary>
        /// Initializes a new instance of the <see cref="DefaultApi"/> class.
        /// </summary>
        /// <returns></returns>
        public DefaultApi() : this((string)null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DefaultApi"/> class.
        /// </summary>
        /// <returns></returns>
        public DefaultApi(string basePath)
        {
            this.Configuration = RepertoireNationalMetiersApi.Client.Configuration.MergeConfigurations(
                RepertoireNationalMetiersApi.Client.GlobalConfiguration.Instance,
                new RepertoireNationalMetiersApi.Client.Configuration { BasePath = basePath }
            );
            this.Client = new RepertoireNationalMetiersApi.Client.ApiClient(this.Configuration.BasePath);
            this.AsynchronousClient = new RepertoireNationalMetiersApi.Client.ApiClient(this.Configuration.BasePath);
            this.ExceptionFactory = RepertoireNationalMetiersApi.Client.Configuration.DefaultExceptionFactory;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DefaultApi"/> class
        /// using Configuration object
        /// </summary>
        /// <param name="configuration">An instance of Configuration</param>
        /// <returns></returns>
        public DefaultApi(RepertoireNationalMetiersApi.Client.Configuration configuration)
        {
            if (configuration == null) throw new ArgumentNullException("configuration");

            this.Configuration = RepertoireNationalMetiersApi.Client.Configuration.MergeConfigurations(
                RepertoireNationalMetiersApi.Client.GlobalConfiguration.Instance,
                configuration
            );
            this.Client = new RepertoireNationalMetiersApi.Client.ApiClient(this.Configuration.BasePath);
            this.AsynchronousClient = new RepertoireNationalMetiersApi.Client.ApiClient(this.Configuration.BasePath);
            ExceptionFactory = RepertoireNationalMetiersApi.Client.Configuration.DefaultExceptionFactory;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DefaultApi"/> class
        /// using a Configuration object and client instance.
        /// </summary>
        /// <param name="client">The client interface for synchronous API access.</param>
        /// <param name="asyncClient">The client interface for asynchronous API access.</param>
        /// <param name="configuration">The configuration object.</param>
        public DefaultApi(RepertoireNationalMetiersApi.Client.ISynchronousClient client, RepertoireNationalMetiersApi.Client.IAsynchronousClient asyncClient, RepertoireNationalMetiersApi.Client.IReadableConfiguration configuration)
        {
            if (client == null) throw new ArgumentNullException("client");
            if (asyncClient == null) throw new ArgumentNullException("asyncClient");
            if (configuration == null) throw new ArgumentNullException("configuration");

            this.Client = client;
            this.AsynchronousClient = asyncClient;
            this.Configuration = configuration;
            this.ExceptionFactory = RepertoireNationalMetiersApi.Client.Configuration.DefaultExceptionFactory;
        }

        /// <summary>
        /// The client for accessing this underlying API asynchronously.
        /// </summary>
        public RepertoireNationalMetiersApi.Client.IAsynchronousClient AsynchronousClient { get; set; }

        /// <summary>
        /// The client for accessing this underlying API synchronously.
        /// </summary>
        public RepertoireNationalMetiersApi.Client.ISynchronousClient Client { get; set; }

        /// <summary>
        /// Gets the base path of the API client.
        /// </summary>
        /// <value>The base path</value>
        public string GetBasePath()
        {
            return this.Configuration.BasePath;
        }

        /// <summary>
        /// Gets or sets the configuration object
        /// </summary>
        /// <value>An instance of the Configuration</value>
        public RepertoireNationalMetiersApi.Client.IReadableConfiguration Configuration { get; set; }

        /// <summary>
        /// Provides a factory method hook for the creation of exceptions.
        /// </summary>
        public RepertoireNationalMetiersApi.Client.ExceptionFactory ExceptionFactory
        {
            get
            {
                if (_exceptionFactory != null && _exceptionFactory.GetInvocationList().Length > 1)
                {
                    throw new InvalidOperationException("Multicast delegate for ExceptionFactory is unsupported.");
                }
                return _exceptionFactory;
            }
            set { _exceptionFactory = value; }
        }

        /// <summary>
        /// Renvoi un fichier JSON des données de l&#39;entreprise en fournissant le SIREN Get document whith selected format JSON/HTML/PDF (default is JSON)
        /// </summary>
        /// <exception cref="RepertoireNationalMetiersApi.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="siren">The enterprise siren</param>
        /// <param name="format">The document format (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>Entreprise</returns>
        public Entreprise V2EntreprisesSirenGet(string siren, string? format = default(string?), int operationIndex = 0)
        {
            RepertoireNationalMetiersApi.Client.ApiResponse<Entreprise> localVarResponse = V2EntreprisesSirenGetWithHttpInfo(siren, format);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Renvoi un fichier JSON des données de l&#39;entreprise en fournissant le SIREN Get document whith selected format JSON/HTML/PDF (default is JSON)
        /// </summary>
        /// <exception cref="RepertoireNationalMetiersApi.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="siren">The enterprise siren</param>
        /// <param name="format">The document format (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of Entreprise</returns>
        public RepertoireNationalMetiersApi.Client.ApiResponse<Entreprise> V2EntreprisesSirenGetWithHttpInfo(string siren, string? format = default(string?), int operationIndex = 0)
        {
            // verify the required parameter 'siren' is set
            if (siren == null)
            {
                throw new RepertoireNationalMetiersApi.Client.ApiException(400, "Missing required parameter 'siren' when calling DefaultApi->V2EntreprisesSirenGet");
            }

            RepertoireNationalMetiersApi.Client.RequestOptions localVarRequestOptions = new RepertoireNationalMetiersApi.Client.RequestOptions();

            string[] _contentTypes = new string[] {
            };

            // to determine the Accept header
            string[] _accepts = new string[] {
                "application/json; charset=utf-8"
            };

            var localVarContentType = RepertoireNationalMetiersApi.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);
            }

            var localVarAccept = RepertoireNationalMetiersApi.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);
            }

            localVarRequestOptions.PathParameters.Add("siren", RepertoireNationalMetiersApi.Client.ClientUtils.ParameterToString(siren)); // path parameter
            if (format != null)
            {
                localVarRequestOptions.QueryParameters.Add(RepertoireNationalMetiersApi.Client.ClientUtils.ParameterToMultiMap("", "format", format));
            }

            localVarRequestOptions.Operation = "DefaultApi.V2EntreprisesSirenGet";
            localVarRequestOptions.OperationIndex = operationIndex;


            // make the HTTP request
            var localVarResponse = this.Client.Get<Entreprise>("/v2/entreprises/{siren}", localVarRequestOptions, this.Configuration);
            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("V2EntreprisesSirenGet", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Renvoi un fichier JSON des données de l&#39;entreprise en fournissant le SIREN Get document whith selected format JSON/HTML/PDF (default is JSON)
        /// </summary>
        /// <exception cref="RepertoireNationalMetiersApi.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="siren">The enterprise siren</param>
        /// <param name="format">The document format (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of Entreprise</returns>
        public async System.Threading.Tasks.Task<Entreprise> V2EntreprisesSirenGetAsync(string siren, string? format = default(string?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            RepertoireNationalMetiersApi.Client.ApiResponse<Entreprise> localVarResponse = await V2EntreprisesSirenGetWithHttpInfoAsync(siren, format, operationIndex, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Renvoi un fichier JSON des données de l&#39;entreprise en fournissant le SIREN Get document whith selected format JSON/HTML/PDF (default is JSON)
        /// </summary>
        /// <exception cref="RepertoireNationalMetiersApi.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="siren">The enterprise siren</param>
        /// <param name="format">The document format (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (Entreprise)</returns>
        public async System.Threading.Tasks.Task<RepertoireNationalMetiersApi.Client.ApiResponse<Entreprise>> V2EntreprisesSirenGetWithHttpInfoAsync(string siren, string? format = default(string?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // verify the required parameter 'siren' is set
            if (siren == null)
            {
                throw new RepertoireNationalMetiersApi.Client.ApiException(400, "Missing required parameter 'siren' when calling DefaultApi->V2EntreprisesSirenGet");
            }


            RepertoireNationalMetiersApi.Client.RequestOptions localVarRequestOptions = new RepertoireNationalMetiersApi.Client.RequestOptions();

            string[] _contentTypes = new string[] {
            };

            // to determine the Accept header
            string[] _accepts = new string[] {
                "application/json; charset=utf-8"
            };

            var localVarContentType = RepertoireNationalMetiersApi.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);
            }

            var localVarAccept = RepertoireNationalMetiersApi.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);
            }

            localVarRequestOptions.PathParameters.Add("siren", RepertoireNationalMetiersApi.Client.ClientUtils.ParameterToString(siren)); // path parameter
            if (format != null)
            {
                localVarRequestOptions.QueryParameters.Add(RepertoireNationalMetiersApi.Client.ClientUtils.ParameterToMultiMap("", "format", format));
            }

            localVarRequestOptions.Operation = "DefaultApi.V2EntreprisesSirenGet";
            localVarRequestOptions.OperationIndex = operationIndex;


            // make the HTTP request
            var localVarResponse = await this.AsynchronousClient.GetAsync<Entreprise>("/v2/entreprises/{siren}", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("V2EntreprisesSirenGet", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

    }
}