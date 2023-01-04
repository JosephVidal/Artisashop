import React, { useState, useEffect } from "react";
import { Home } from "api/models/Home";
import { BackofficeApi } from "api";
import useAsync from "hooks/useAsync";
import useApi from "hooks/useApi";
import CraftsmanCard from "components/CraftsmanCard";
import ProductCard from "components/ProductCard";
import { Link } from "react-router-dom";
import { Field, Form, Formik } from "formik";
import { useNavigate } from "react-router";
import _ from "lodash";
import { Wrapper } from "./styles";
import { ProductApi, HomeApi } from "../../api";

interface Props { }

const HomeView: React.FunctionComponent<Props> = () => {
  const productApi = useApi(ProductApi);
  const homeApi = useApi(HomeApi);

  const suggestedProductsResults = useAsync(() => productApi.apiProductGet().then(res => _.take(res, 3)), false);
  const suggestedCraftsmansResults = useAsync(() => homeApi.apiHomeGet().then(res => _.take(res.craftsmanSample, 2)), false);

  const navigate = useNavigate();

  const backOfficeApi = useApi(BackofficeApi);
  const [home, setHome] = useState<Home | null> (null);

  const fetchData = async () => {
    setHome(await backOfficeApi.apiBackofficeStatsGet());
  };

  useEffect(() => {
    suggestedProductsResults.execute();
    suggestedCraftsmansResults.execute();
    fetchData()
  }, []);

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
              <div>
                <Field type="text" className="search-input" name="searchStr" placeholder="Rechercher..." />
                <label htmlFor="SearchStr">
                  <button type="submit" id="sendButton" className="search-button">
                    <i className="fas fa-search" />
                  </button>
                </label>
              </div>
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
          {suggestedProductsResults.value?.map(product =>
            <ProductCard key={product.id}
              productStyles={product.productStyles}
              img={product.productImages?.at(0)?.content ?? `/img/product/${product.productImages?.at(0)?.imagePath || "default.png"}`}
              serie="Petite série"
              name={product.name}
              price={product.price}
              href={`/app/product/${product.id}`}
            />
          )}
        </div>
        <p id="product-text">Trouvez votre bonheur, vendez vos créations dans un espace unique et dédié à l&apos;art, où excellence rime avec savoir faire et élégance. Nos artisans sont impatients de vous présenter leurs ouvrages réalisés avec passion et expertise.</p>
      </section>
      <section id="craftsman-section">
        <h2>Artisans de la semaine</h2>
        <div className="section-body">
          {suggestedCraftsmansResults.value?.map(elem =>
            <CraftsmanCard key={elem.id}
              img={`/img/craftsman/${elem.profilePicture ?? "default.svg"}`}
              name={elem.firstname}
              job={elem.job ?? ""}
              description={elem?.biography ?? ""}
              href={`/app/craftsman/${elem?.id ?? ""}`}
            />
          )}
        </div>
      </section>
      <section id="register-section">
        <div id="register-dark">
          <h2>Artisan</h2>
          <p>Créez un compte et venez proposer vos produits</p>
          <Link className="red-button" to="/app/register">Créer un compte</Link>
        </div>
        <div id="register-light">
          <h2>Client</h2>
          <p>Inscrivez-vous et découvrez les produits de nos artisans</p>
          <Link className="red-button" to="/app/register">Créer un compte</Link>
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
