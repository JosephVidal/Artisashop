import React from "react";
import { Link } from "react-router-dom";
import { Field, Form, Formik } from "formik";
import { useNavigate } from "react-router";
import useFormattedDocumentTitle from "hooks/useFormattedDocumentTitle";
import CraftsmanCard from "components/CraftsmanCard";
import ProductCard from "components/ProductCard";
import { Wrapper } from "./styles";

interface Props { }

const Home: React.FunctionComponent<Props> = () => {

  const navigate = useNavigate();
  const type = "Par produit";

  return (
    <Wrapper>
      <section id="search-section">
        <h1>Artisashop</h1>
        <Formik
          initialValues={{
            searchStr: "",
            searchType: false,
          }}
          onSubmit={async values => {
            navigate({
              pathname: '/app/search',
              search: `?q=${values.searchStr}&t=${values.searchType.toString()}`,
            })
          }}
        >
          <Form id="search-block">
            <Field type="text" className="search-input" name="searchStr" placeholder="Rechercher..." />
            <label htmlFor="SearchStr">
              <button type="submit" id="sendButton" className="search-button">
                <i className="fas fa-search" />
              </button>
            </label>
            <div id="searchType">
              <label className="switch">
                <Field type="checkbox" name="searchType" />
                <span className="slider round" />
              </label>
              <label className="wordCarousel" htmlFor="SearchType">
                <p className="search-type-text">{type}</p>
              </label>
            </div>
          </Form>
        </Formik>
      </section>
      <section id="product-section">
        <h2>Produits de la semaine</h2>
        <div className="section-body">
          <ProductCard img="img/product/Applique papier.jpg" name="Applique en papier" price={297.92} href="/app/product/2" productStyles={[{ displayName: "Papier", normalizedName: "Papier" }]} />
          <ProductCard img="img/product/Oeuf de paques.jpg" name="Oeuf d'extérieur" price={473.81} href="/app/product/20" productStyles={[{ displayName: "Carton", normalizedName: "Carton" }]} />
          <ProductCard img="img/product/buste-romain.JPG" name="Buste Romain" price={58.90} href="/app/product/9" productStyles={[{ displayName: "Romain", normalizedName: "Romain" }]} />
        </div>
        <p id="product-text">Trouvez votre bonheur, vendez vos créations dans un espace unique et dédié à l&apos;art, où excellence rime avec savoir faire et élégance. Nos artisans sont impatients de vous présenter leurs ouvrages réalisés avec passion et expertise.</p>
      </section>
      <section id="craftsman-section">
        <h2>Artisans de la semaine</h2>
        <div className="section-body">
          <CraftsmanCard href="/app/craftsman/test" name="Jean du Pont" job="Joalier" img="img/craftsman/Jean.jpeg" description="Joalier à Saint-Sulpice-la-Pointe, je suis spécialisé dans la gravure héraldique." />
          <CraftsmanCard href="/app/craftsman/test" name="Joseph Vidal" job="Sculpteur" img="img/craftsman/Joseph.jpg" description="Après des études d'ébénisterie à Revel, je me suis reconverti dans l'informatique en entrant à epitech Toulouse. Aujourd'hui je fabrique des meubles et des objets d'influence Japonaise." />
        </div>
      </section>
      <section id="register-section">
        <div id="register-dark">
          <h2>Artisan</h2>
          <p>Créez un compte et venez proposer vos produits</p>
          <Link className="red-button" to="/app/register">Créer un compte artisan</Link>
        </div>
        <div id="register-light">
          <h2>Client</h2>
          <p>Inscrivez-vous et découvrez les produits de nos artisans</p>
          <Link className="red-button" to="/app/register">Créer un compte client</Link>
        </div>
      </section>
    </Wrapper>
  );
}

export default Home;
