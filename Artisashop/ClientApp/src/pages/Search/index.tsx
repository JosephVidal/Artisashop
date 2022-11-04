import React, {useState} from "react";
import { InputSwitch } from 'primereact/inputswitch';
import ProductCard from "components/ProductCard";
import { Wrapper, SearchHeader, SearchFilter, SearchBar } from "./styles";

interface Props {}

const Search: React.FunctionComponent<Props> = () => {
  const [searchType, setType] = useState(false);

  return (
    <Wrapper>
      <div id="search">
        <SearchHeader>
          <SearchBar>
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
          </SearchBar>
          <span>
            <a href="#search" className="search-header-link">Mobilier 🪑</a>
            <a href="#search" className="search-header-link">Poterie 🏺</a>
          </span>
          <span>
            <a href="#search" className="search-header-link">Arts de la table 🍴</a>
            <a href="#search" className="search-header-link">Vêtements 👗</a>
          </span>
        </SearchHeader>

        <div id="search-body">
          <SearchFilter id="search-filters">
              <div className="filter">
                  <h2>Distance</h2>
                  <input type="range" min="0" className="slider" id="distance" />
              </div>
              <div className="filter">
                  <h2 id="filters-title">test</h2>
                  <ul id="styles">
                    bonjour
                  </ul>
              </div>
          </SearchFilter>
          <section id="search-block">
              <h2>Résultats pour : <span id="result-str">test</span></h2>
              <div id="result-list">porte</div>
          </section>
        </div>
        <div id="suggestions">
          <h2>Pour vous :</h2>
          <div id="suggestions-wrapper">
            <ProductCard img="../../assets/Logox150.png" serie="Petite série" name="table trop bien" price={1500}/>
            <ProductCard img="../../assets/Logox150.png" serie="Petite série" name="table trop bien" price={1500}/>
          </div>
        </div>
      </div>
    </Wrapper>
  );
}

export default Search;
