import React, {useState} from "react";
import { InputSwitch } from 'primereact/inputswitch';
import CraftsmanCard from "components/CraftsmanCard";
import ProductCard from "components/ProductCard";
import { Link } from "react-router-dom";
import { Field, Form, Formik } from "formik";
import { useNavigate } from "react-router";
import { Wrapper } from "./styles";

interface Props {}

const Home: React.FunctionComponent<Props> = () => {
  const [searchType, setType] = useState(false);
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
          {({ isSubmitting }) => (
            <Form id="search-block">
              <Field type="text" className="search-input" name="searchStr" placeholder="Rechercher..."/>
              <label htmlFor="SearchStr">
                <button type="submit" id="sendButton" className="search-button">
                  <i className="fas fa-search"/>
                </button>
              </label>
              <div id="searchType">
                <label className="switch">
                  <Field type="checkbox" name="searchType"/>
                  <span className="slider round" />
                </label>
                {/* <Field type="checkbox" name="searchType" className="form-switch"/> */}
                {/* <InputSwitch checked={searchType} onChange={(e) => setType(e.value)} /> */}
                <label className="wordCarousel" htmlFor="SearchType">
                  <span className="search-type-text">{type}</span>
                </label>
              </div>
            </Form>
          )}
        </Formik>
      </section>
      <section id="product-section">
        <h2>Produits de la semaine</h2>
        <div className="section-body">
          <ProductCard img="img/product/table à thé.jpg" serie="Petite série" name="table trop bien" price={1500} href="/app/product/test"/>
          <ProductCard img="img/product/table à thé.jpg" serie="Pièce unique" name="table chouette et pas cher" price={30} href="/app/product/test"/>
          <ProductCard img="img/product/table à thé.jpg" serie="Petite série" name="tabouret" price={200} href="/app/product/test"/>
        </div>
        <p id="product-text">Trouvez votre bonheur, vendez vos créations dans un espace unique et dédié à l&apos;art, où excellence rime avec savoir faire et élégance. Nos artisans sont impatients de vous présenter leurs ouvrages réalisés avec passion et expertise.</p>
      </section>
      <section id="craftsman-section">
        <h2>Artisans de la semaine</h2>
        <div className="section-body">
          <CraftsmanCard name="Jean Epp" job="Facteur de colliers de pâtes" img="img/craftsman/Joseph.jpg" description="Lorem ipsum dolor sit amet consectetur adipisicing elit. Nostrum autem ullam ab aliquid optio. Delectus consectetur sunt repellendus vero! Doloribus fugiat rerum consequuntur beatae natus architecto nostrum amet odit ducimus!"/>
          <CraftsmanCard name="Joseph Vidal" job="Sculpteur" img="img/craftsman/Joseph.jpg" description="Lorem ipsum dolor sit amet consectetur adipisicing elit. Nostrum autem ullam ab aliquid optio. Delectus consectetur sunt repellendus vero! Doloribus fugiat rerum consequuntur beatae natus architecto nostrum amet odit ducimus!"/>
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
          <Link className="red-button" to="/register">Créer un compte client</Link>
        </div>
      </section>
    </Wrapper>
  );
}

export default Home;
