/*
 * API Recherche d’entreprises
 *
 * # Bienvenue sur la documentation interactive d'API Recherche d’entreprises ! L’API Recherche d’entreprises permet à tout le monde de rechercher et de trouver  une entreprise française par sa dénomination, ou son adresse. ## Données accessibles dans l'API L’API étant totalement ouverte d'accès, elle comporte des limitations. Ainsi ne sont pas accessibles dans l'API : - les prédécesseurs et successeurs d'un établissement - les entreprises non-diffusibles - les entreprises qui se sont vues refuser leurs immatriculation au RCS  **Attention :** cette API ne permet pas d'accèder aux données complètes de  la  base Sirene, mais uniquement de rechercher une entreprise, par sa dénomination ou son adresse. Pour savoir comment obtenir les données complètes, consultez [notre fiche explicative.](/guides/quelle-api-sirene)  ## Commencer à utiliser l'API L'API est accessible à partir de cette adresse : [https://recherche-entreprises.api.gouv.fr](https://recherche-entreprises.api.gouv.fr)  **Attention :** Vous devez rajouter votre requête sur l’adresse. ## Limite des requêtes    Le serveur accepte un maximum de 7 requêtes par seconde. Au delà, un code 429 est renvoyé indiquant que la volumétrie d'appels a été dépassée.     ## Monitoring de l'API Une supervision du service en temps réel est disponible à cette adresse : [https://stats.uptimerobot.com/kXzwzfk7BE](https://stats.uptimerobot.com/kXzwzfk7BE) 
 *
 * The version of the OpenAPI document: 1.0.0
 * Contact: recherche-entreprises@api.gouv.fr
 * Generated by: https://github.com/openapitools/openapi-generator.git
 */


using System;
using System.Collections.Generic;
using System.IO;
using System.Net;

namespace RechercheEntreprisesApi.Client
{
    /// <summary>
    /// A container for generalized request inputs. This type allows consumers to extend the request functionality
    /// by abstracting away from the default (built-in) request framework (e.g. RestSharp).
    /// </summary>
    public class RequestOptions
    {
        /// <summary>
        /// Parameters to be bound to path parts of the Request's URL
        /// </summary>
        public Dictionary<string, string> PathParameters { get; set; }

        /// <summary>
        /// Query parameters to be applied to the request.
        /// Keys may have 1 or more values associated.
        /// </summary>
        public Multimap<string, string> QueryParameters { get; set; }

        /// <summary>
        /// Header parameters to be applied to to the request.
        /// Keys may have 1 or more values associated.
        /// </summary>
        public Multimap<string, string> HeaderParameters { get; set; }

        /// <summary>
        /// Form parameters to be sent along with the request.
        /// </summary>
        public Dictionary<string, string> FormParameters { get; set; }

        /// <summary>
        /// File parameters to be sent along with the request.
        /// </summary>
        public Multimap<string, Stream> FileParameters { get; set; }

        /// <summary>
        /// Cookies to be sent along with the request.
        /// </summary>
        public List<Cookie> Cookies { get; set; }

        /// <summary>
        /// Operation associated with the request path.
        /// </summary>
        public string Operation { get; set; }

        /// <summary>
        /// Index associated with the operation.
        /// </summary>
        public int OperationIndex { get; set; }

        /// <summary>
        /// Any data associated with a request body.
        /// </summary>
        public Object Data { get; set; }

        /// <summary>
        /// Constructs a new instance of <see cref="RequestOptions"/>
        /// </summary>
        public RequestOptions()
        {
            PathParameters = new Dictionary<string, string>();
            QueryParameters = new Multimap<string, string>();
            HeaderParameters = new Multimap<string, string>();
            FormParameters = new Dictionary<string, string>();
            FileParameters = new Multimap<string, Stream>();
            Cookies = new List<Cookie>();
        }
    }
}
