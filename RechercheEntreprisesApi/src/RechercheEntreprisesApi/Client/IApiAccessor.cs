/*
 * API Recherche d’entreprises
 *
 * # Bienvenue sur la documentation interactive d'API Recherche d’entreprises ! L’API Recherche d’entreprises permet à tout le monde de rechercher et de trouver  une entreprise française par sa dénomination, ou son adresse. ## Données accessibles dans l'API L’API étant totalement ouverte d'accès, elle comporte des limitations. Ainsi ne sont pas accessibles dans l'API : - les prédécesseurs et successeurs d'un établissement - les entreprises non-diffusibles - les entreprises qui se sont vues refuser leurs immatriculation au RCS  **Attention :** cette API ne permet pas d'accèder aux données complètes de  la  base Sirene, mais uniquement de rechercher une entreprise, par sa dénomination ou son adresse. Pour savoir comment obtenir les données complètes, consultez [notre fiche explicative.](/guides/quelle-api-sirene)  ## Commencer à utiliser l'API L'API est accessible à partir de cette adresse : [https://recherche-entreprises.api.gouv.fr](https://recherche-entreprises.api.gouv.fr)  **Attention :** Vous devez rajouter votre requête sur l’adresse. ## Limite des requêtes    Le serveur accepte un maximum de 7 requêtes par seconde. Au delà, un code 429 est renvoyé indiquant que la volumétrie d'appels a été dépassée.     ## Monitoring de l'API Une supervision du service en temps réel est disponible à cette adresse : [https://stats.uptimerobot.com/kXzwzfk7BE](https://stats.uptimerobot.com/kXzwzfk7BE) 
 *
 * The version of the OpenAPI document: 1.0.0
 * Contact: recherche-entreprises@api.gouv.fr
 * Generated by: https://github.com/openapitools/openapi-generator.git
 */

namespace RechercheEntreprisesApi.Client
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
