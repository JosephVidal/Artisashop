import React, {useState} from "react";
import { InputSwitch } from 'primereact/inputswitch';
import CraftsmanCard from "components/CraftsmanCard";
import ProductCard from "components/ProductCard";
import { Link } from "react-router-dom";
import { Wrapper } from "./styles";

interface Props {}

const Home: React.FunctionComponent<Props> = () => {
  const [searchType, setType] = useState(false);

  return (
    <Wrapper>
      <section id="search-section">
        <h1>Artisashop</h1>
        <div id="search-block">
          <input className="search-input" placeholder="Rechercher..."/>
          <label htmlFor="SearchStr">
            <button type="submit" id="sendButton" className="search-button">
              <i className="fas fa-search"/>
            </button>
          </label>
          <div id="searchType">
            <InputSwitch checked={searchType} onChange={(e) => setType(e.value)} />
            <label className="wordCarousel" htmlFor="SearchType">
              <ul className={`text-start ${searchType ? "flip2": "flip3"} fs-5`}>
                <li>By product</li>
                <li>By craftsman</li>
              </ul>
            </label>
          </div>
        </div>
      </section>
      <section id="product-section">
        <h2>Produits de la semaine</h2>
        <div className="section-body">
          <ProductCard img="img/product/table à thé.jpg" serie="Petite série" name="table trop bien" price={1500}/>
          <ProductCard img="img/product/table à thé.jpg" serie="Pièce unique" name="table chouette et pas cher" price={30}/>
          <ProductCard img="img/product/table à thé.jpg" serie="Petite série" name="tabouret" price={200}/>
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
