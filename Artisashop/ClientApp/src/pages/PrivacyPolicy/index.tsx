import React from "react";
import { Link } from "react-router-dom";
import { Container } from "./styles";

const PrivacyPolicy = () => (
  <Container>
    <h1 id="politique-de-confidentialit-">Politique de confidentialité</h1>
    <h2 id="objet-du-traitement-de-donn-es">Objet du traitement de données</h2>
    <p>Le traitement a pour objet <strong>la gestion des comptes clients</strong></p>
    <p>Il permet à la Artisashop :</p>
    <ul>
      <li>La gestion de compte</li>
      <li>L&#39;élaboration de statistiques liées au service.</li>
      <li>Vous contacter ou vous informer</li>
    </ul>
    <h2 id="base-l-gale">Base légale</h2>
    <p><strong><a href="https://www.cnil.fr/fr/reglement-europeen-protection-donnees/chapitre2#Article6">Article 6</a>
      (1)e du règlement général sur la protection des données - RGPD</strong></p>
    <p>Ce traitement de données relève de l&#39;exercice de l&#39;autorité publique dont
      est investie la CNIL en application du règlement général sur la
      protection des données et de la loi Informatique et Libertés
      modifiée.</p>
    <h2 id="donn-es-trait-es">Données traitées</h2>
    <p>Catégories de données traitées</p>
    <ul>
      <li>Nom</li>
      <li>Prénom</li>
      <li>Adresse de courrier électronique (e-mail)</li>
      <li>Adresse postale</li>
      <li>Téléphone</li>
      <li>Carte de crédit</li>
      <li>Localisation</li>
      <li>Date d&#39;inscription</li>
      <li>Date de dernière connexion</li>
      <li>Statistiques liées au service de newsletter</li>
      <li>Factures générées par les achats sur le site</li>
    </ul>
    <h3 id="source-des-donn-es">Source des données</h3>
    <p>Les données sont issues de l’enregistrement, par la personne souhaitant
      s’inscrire sur le site Artisashop, depuis le champ d’inscription en pied
      de page du site Artisashop <Link to="/app/register">https://www.artisashop.fr/create-account#pills-client</Link>.</p>
    <h3 id="caract-re-obligatoire-du-recueil-des-donn-es">Caractère obligatoire du recueil des données</h3>
    <p>Le recueil de l’adresse de courrier électronique est obligatoire pour
      l’envoi de la lettre d’information, l&#39;authentification et contacter la
      personne. Le nom et le prénom servent à l’identification de la personne
      sur le site. Le téléphone sert à contacter la personne. La carte de
      crédits et l&#39;adresse postale servent aux transactions financières. La
      localisation sert aux paramètres de recherche de produits.</p>
    <h3 id="prise-de-d-cision-automatis-e">Prise de décision automatisée</h3>
    <p>Le traitement prévoit une <a href="https://www.cnil.fr/fr/profilage-et-decision-entierement-automatisee">prise de décision automatisée</a>.</p>
    <h2 id="personnes-concern-es">Personnes concernées</h2>
    <p>Le traitement de données concerne uniquement les personnes qui souhaitent
      s’enregistrer en tant que client sur <Link to="/">artisashop.fr</Link>.</p>
    <h2 id="destinataires-des-donn-es">Destinataires des données</h2>
    <h3 id="cat-gories-de-destinataires">Catégories de destinataires</h3>
    <p>Sont destinataires des données :</p>
    <ul>
      <li>Le service de la communication (webmaster) de l&#39;Artisashop</li>
      <li>Le service informatique (gestionnaire de la base de données) d&#39;Artisashop</li>
      <li>Le service marketing d’Artisashop</li>
      <li>Les artisans partenaires d’Artisashop</li>
    </ul>
    <h3 id="transferts-des-donn-es-hors-ue">Transferts des données hors UE</h3>
    <p>Aucun transfert de données hors de l&#39;Union européenne n&#39;est réalisé.</p>
    <h2 id="dur-e-de-conservation-des-donn-es">Durée de conservation des données</h2>
    <p>Artisashop conserve le nom, le prénom, l’adresse e-mail, l&#39;adresse
      postale et le numéro de téléphone tant que la personne concernée ne se
      désinscrit pas (via le lien de désinscription intégré sur la page
      (insérer url)), la carte de crédit n&#39;est conservée que le temps
      d&#39;effectuer la transaction et la localisation n&#39;est conservé que pendant
      l&#39;utilisation de la recherche de produit ou artisan.</p>
    <h2 id="s-curit-">Sécurité</h2>
    <p>Les mesures de sécurité sont mises en œuvre conformément à la politique
      de sécurité des systèmes d’information (PSSI) de la CNIL, issue de la <a href="https://www.ssi.gouv.fr/entreprise/reglementation/protection-des-systemes-dinformations/la-politique-de-securite-des-systemes-dinformation-de-letat-pssie/">PSSI de l&#39;État</a>.</p>
    <h2 id="vos-droits-sur-les-donn-es-vous-concernant">Vos droits sur les données vous concernant</h2>
    <p>Vous pouvez accéder et obtenir copie des données vous concernant,
      vous opposer au traitement de ces données, les faire rectifier ou
      les faire effacer. Vous disposez également d&#39;un droit à la
      limitation du traitement de vos données.</p>
    <blockquote>
      <p><a href="https://www.cnil.fr/fr/les-droits-pour-maitriser-vos-donnees-personnelles">Comprendre vos droits</a></p>
    </blockquote>
    <h3 id="exercer-ses-droits">Exercer ses droits</h3>
    <p>Le délégué à la protection des données (DPO) de la CNIL est votre
      interlocuteur pour toute demande d&#39;exercice de vos droits sur ce
      traitement.</p>
    <ul>
      <li>Contacter le DPO par voie électronique</li>
      <li><Link to="/contact">Contacter le délégué à la protection des données (DPO) d&#39;Artisashop</Link></li>
      <li>Contacter le DPO par courrier postal</li>
    </ul>
    <p>Le délégué à la protection des données :<br />
      Artisashop <br />
      4 Rue du Dôme <br />
      67000 Strasbourg</p>
    <h3 id="r-clamation-plainte-aupr-s-de-la-cnil">Réclamation (plainte) auprès de la CNIL</h3>
    <p>Si vous estimez, après nous avoir contactés, que vos droits sur vos
      données ne sont pas respectés, vous pouvez
      <a href="https://connexion.services.cnil.fr/login/?nonce=_4079961FBD60839A9CC5D8077C06A16E&amp;next=/idp/saml2/continue%3Fnonce%3D_4079961FBD60839A9CC5D8077C06A16E&amp;service=default%20eservices">adresser une réclamation (plainte) à la CNIL</a>.</p>
  </Container>
);

export default PrivacyPolicy;
