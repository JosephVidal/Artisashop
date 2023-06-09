/*
 * API Artisashop
 *
 * No description provided (generated by Openapi Generator https://github.com/openapitools/openapi-generator)
 *
 * The version of the OpenAPI document: v1
 * Generated by: https://github.com/openapitools/openapi-generator.git
 */


using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Net.Mime;
using ArtisashopApi.Client;

namespace ArtisashopApi.Api
{

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface IOidcConfigurationApiSync : IApiAccessor
    {
        #region Synchronous Operations
        /// <summary>
        /// 
        /// </summary>
        /// <exception cref="ArtisashopApi.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="clientId"></param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns></returns>
        void ConfigurationClientIdGet(string clientId, int operationIndex = 0);

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="ArtisashopApi.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="clientId"></param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of Object(void)</returns>
        ApiResponse<Object> ConfigurationClientIdGetWithHttpInfo(string clientId, int operationIndex = 0);
        #endregion Synchronous Operations
    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface IOidcConfigurationApiAsync : IApiAccessor
    {
        #region Asynchronous Operations
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="ArtisashopApi.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="clientId"></param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of void</returns>
        System.Threading.Tasks.Task ConfigurationClientIdGetAsync(string clientId, int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="ArtisashopApi.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="clientId"></param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse</returns>
        System.Threading.Tasks.Task<ApiResponse<Object>> ConfigurationClientIdGetWithHttpInfoAsync(string clientId, int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        #endregion Asynchronous Operations
    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface IOidcConfigurationApi : IOidcConfigurationApiSync, IOidcConfigurationApiAsync
    {

    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public partial class OidcConfigurationApi : IOidcConfigurationApi
    {
        private ArtisashopApi.Client.ExceptionFactory _exceptionFactory = (name, response) => null;

        /// <summary>
        /// Initializes a new instance of the <see cref="OidcConfigurationApi"/> class.
        /// </summary>
        /// <returns></returns>
        public OidcConfigurationApi() : this((string)null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="OidcConfigurationApi"/> class.
        /// </summary>
        /// <returns></returns>
        public OidcConfigurationApi(string basePath)
        {
            this.Configuration = ArtisashopApi.Client.Configuration.MergeConfigurations(
                ArtisashopApi.Client.GlobalConfiguration.Instance,
                new ArtisashopApi.Client.Configuration { BasePath = basePath }
            );
            this.Client = new ArtisashopApi.Client.ApiClient(this.Configuration.BasePath);
            this.AsynchronousClient = new ArtisashopApi.Client.ApiClient(this.Configuration.BasePath);
            this.ExceptionFactory = ArtisashopApi.Client.Configuration.DefaultExceptionFactory;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="OidcConfigurationApi"/> class
        /// using Configuration object
        /// </summary>
        /// <param name="configuration">An instance of Configuration</param>
        /// <returns></returns>
        public OidcConfigurationApi(ArtisashopApi.Client.Configuration configuration)
        {
            if (configuration == null) throw new ArgumentNullException("configuration");

            this.Configuration = ArtisashopApi.Client.Configuration.MergeConfigurations(
                ArtisashopApi.Client.GlobalConfiguration.Instance,
                configuration
            );
            this.Client = new ArtisashopApi.Client.ApiClient(this.Configuration.BasePath);
            this.AsynchronousClient = new ArtisashopApi.Client.ApiClient(this.Configuration.BasePath);
            ExceptionFactory = ArtisashopApi.Client.Configuration.DefaultExceptionFactory;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="OidcConfigurationApi"/> class
        /// using a Configuration object and client instance.
        /// </summary>
        /// <param name="client">The client interface for synchronous API access.</param>
        /// <param name="asyncClient">The client interface for asynchronous API access.</param>
        /// <param name="configuration">The configuration object.</param>
        public OidcConfigurationApi(ArtisashopApi.Client.ISynchronousClient client, ArtisashopApi.Client.IAsynchronousClient asyncClient, ArtisashopApi.Client.IReadableConfiguration configuration)
        {
            if (client == null) throw new ArgumentNullException("client");
            if (asyncClient == null) throw new ArgumentNullException("asyncClient");
            if (configuration == null) throw new ArgumentNullException("configuration");

            this.Client = client;
            this.AsynchronousClient = asyncClient;
            this.Configuration = configuration;
            this.ExceptionFactory = ArtisashopApi.Client.Configuration.DefaultExceptionFactory;
        }

        /// <summary>
        /// The client for accessing this underlying API asynchronously.
        /// </summary>
        public ArtisashopApi.Client.IAsynchronousClient AsynchronousClient { get; set; }

        /// <summary>
        /// The client for accessing this underlying API synchronously.
        /// </summary>
        public ArtisashopApi.Client.ISynchronousClient Client { get; set; }

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
        public ArtisashopApi.Client.IReadableConfiguration Configuration { get; set; }

        /// <summary>
        /// Provides a factory method hook for the creation of exceptions.
        /// </summary>
        public ArtisashopApi.Client.ExceptionFactory ExceptionFactory
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
        ///  
        /// </summary>
        /// <exception cref="ArtisashopApi.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="clientId"></param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns></returns>
        public void ConfigurationClientIdGet(string clientId, int operationIndex = 0)
        {
            ConfigurationClientIdGetWithHttpInfo(clientId);
        }

        /// <summary>
        ///  
        /// </summary>
        /// <exception cref="ArtisashopApi.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="clientId"></param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of Object(void)</returns>
        public ArtisashopApi.Client.ApiResponse<Object> ConfigurationClientIdGetWithHttpInfo(string clientId, int operationIndex = 0)
        {
            // verify the required parameter 'clientId' is set
            if (clientId == null)
            {
                throw new ArtisashopApi.Client.ApiException(400, "Missing required parameter 'clientId' when calling OidcConfigurationApi->ConfigurationClientIdGet");
            }

            ArtisashopApi.Client.RequestOptions localVarRequestOptions = new ArtisashopApi.Client.RequestOptions();

            string[] _contentTypes = new string[] {
            };

            // to determine the Accept header
            string[] _accepts = new string[] {
            };

            var localVarContentType = ArtisashopApi.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);
            }

            var localVarAccept = ArtisashopApi.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);
            }

            localVarRequestOptions.PathParameters.Add("clientId", ArtisashopApi.Client.ClientUtils.ParameterToString(clientId)); // path parameter

            localVarRequestOptions.Operation = "OidcConfigurationApi.ConfigurationClientIdGet";
            localVarRequestOptions.OperationIndex = operationIndex;

            // authentication (Bearer) required
            if (!string.IsNullOrEmpty(this.Configuration.GetApiKeyWithPrefix("Authorization")))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", this.Configuration.GetApiKeyWithPrefix("Authorization"));
            }

            // make the HTTP request
            var localVarResponse = this.Client.Get<Object>("/_configuration/{clientId}", localVarRequestOptions, this.Configuration);
            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ConfigurationClientIdGet", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        ///  
        /// </summary>
        /// <exception cref="ArtisashopApi.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="clientId"></param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of void</returns>
        public async System.Threading.Tasks.Task ConfigurationClientIdGetAsync(string clientId, int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            await ConfigurationClientIdGetWithHttpInfoAsync(clientId, operationIndex, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        ///  
        /// </summary>
        /// <exception cref="ArtisashopApi.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="clientId"></param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse</returns>
        public async System.Threading.Tasks.Task<ArtisashopApi.Client.ApiResponse<Object>> ConfigurationClientIdGetWithHttpInfoAsync(string clientId, int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // verify the required parameter 'clientId' is set
            if (clientId == null)
            {
                throw new ArtisashopApi.Client.ApiException(400, "Missing required parameter 'clientId' when calling OidcConfigurationApi->ConfigurationClientIdGet");
            }


            ArtisashopApi.Client.RequestOptions localVarRequestOptions = new ArtisashopApi.Client.RequestOptions();

            string[] _contentTypes = new string[] {
            };

            // to determine the Accept header
            string[] _accepts = new string[] {
            };

            var localVarContentType = ArtisashopApi.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);
            }

            var localVarAccept = ArtisashopApi.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);
            }

            localVarRequestOptions.PathParameters.Add("clientId", ArtisashopApi.Client.ClientUtils.ParameterToString(clientId)); // path parameter

            localVarRequestOptions.Operation = "OidcConfigurationApi.ConfigurationClientIdGet";
            localVarRequestOptions.OperationIndex = operationIndex;

            // authentication (Bearer) required
            if (!string.IsNullOrEmpty(this.Configuration.GetApiKeyWithPrefix("Authorization")))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", this.Configuration.GetApiKeyWithPrefix("Authorization"));
            }

            // make the HTTP request
            var localVarResponse = await this.AsynchronousClient.GetAsync<Object>("/_configuration/{clientId}", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ConfigurationClientIdGet", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

    }
}
