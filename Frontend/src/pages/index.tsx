import React, { useState, useEffect } from "react";
import { Home } from "api/models/Home";
import { BackofficeApi } from "api";
import useApi from "hooks/useApi";
import { InputSwitch } from 'primereact/inputswitch';
import CraftsmanCard from "components/CraftsmanCard";
import ProductCard from "components/ProductCard";
import { Link } from "react-router-dom";
import { Field, Form, Formik } from "formik";
import { useNavigate } from "react-router";
import useFormattedDocumentTitle from "hooks/useFormattedDocumentTitle";
import { Wrapper } from "./styles";

interface Props { }

const HomeView: React.FunctionComponent<Props> = () => {

  const navigate = useNavigate();

  const backOfficeApi = useApi(BackofficeApi);
  const [home, setHome] = useState<Home | null> (null);

  const fetchData = async () => {
    setHome(await backOfficeApi.backofficeStats());
  };

  useEffect(() => { fetchData() }, []);

  return (
    <Wrapper>
      <section id="search-section">
        <h1>Artisashop</h1>
        <Formik
          initialValues={{
            searchStr: "",
            searchType: true,
          }}
          onSubmit={async values => {
            navigate({
              pathname: '/app/search',
              search: `?q=${values.searchStr}&t=${values.searchType.toString()}`,
            })
          }}
        >
          {({ values }) => (
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
                  <p className="search-type-text">{values.searchType ? "Par produit" : "Par artisan"}</p>
                </label>
              </div>
            </Form>
          )}
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
      <section id="craftsman-section">
        <h2>Statistiques du site</h2>
        <div className="section-body">
          <div className="surface-ground px-4 py-5 md:px-6 lg:px-8">
            <div className="grid">
              <div className="col-12 md:col-6 lg:col-3">
                <div className="surface-card shadow-2 p-3 border-round">
                  <div className="flex justify-content-between mb-3">
                    <div>
                      <span className="block text-500 font-medium mb-3">Artisans</span>
                      <div className="text-900 font-medium text-xl">{home?.craftsmanNumber}</div>
                    </div>
                    <div className="flex align-items-center justify-content-center bg-orange-100 border-round" style={{ width: '2.5rem', height: '2.5rem' }} />
                  </div>
                  <span className="text-green-500 font-medium">{home?.craftsmanNumber}</span>
                  <span className="text-500"> récemment</span>
                </div>
              </div>
              <div className="col-12 md:col-6 lg:col-3">
                <div className="surface-card shadow-2 p-3 border-round">
                  <div className="flex justify-content-between mb-3">
                    <div>
                      <span className="block text-500 font-medium mb-3">Inscrits</span>
                      <div className="text-900 font-medium text-xl">{home?.inscrit}</div>
                    </div>
                    <div className="flex align-items-center justify-content-center bg-cyan-100 border-round" style={{ width: '2.5rem', height: '2.5rem' }} />
                  </div>
                  <span className="text-green-500 font-medium">{home?.inscrit}</span>
                  <span className="text-500"> ce mois-ci</span>
                </div>
              </div>
              <div className="col-12 md:col-6 lg:col-3">
                <div className="surface-card shadow-2 p-3 border-round">
                  <div className="flex justify-content-between mb-3">
                    <div>
                      <span className="block text-500 font-medium mb-3">Ventes</span>
                      <div className="text-900 font-medium text-xl">{home?.productNumber}</div>
                    </div>
                    <div className="flex align-items-center justify-content-center bg-purple-100 border-round" style={{ width: '2.5rem', height: '2.5rem' }} />
                  </div>
                  <span className="text-green-500 font-medium">{home?.productNumber}</span>
                  <span className="text-500"> ce mois-ci</span>
                </div>
              </div>
            </div>
          </div>
        </div>
      </section>
    </Wrapper>
  );
}

export default HomeView;
