import React, {useState} from "react";
import { InputSwitch } from 'primereact/inputswitch';
import ProductCard from "components/ProductCard";
import { useSearchParams } from "react-router-dom";
import { Field, Form, Formik } from "formik";
import useApi from "hooks/useApi";
import { Product, SearchApi } from "../../api";
import { Wrapper, SearchHeader, SearchFilter, SearchBar } from "./styles";

const defaultResults: Product[] = [
  {
    id: 1,
    name: "Product 1",
    description: "Description 1",
    price: 10,
    images: ["img/product/table à thé.jpg"],
    craftsmanId: "fakeID",
    quantity: 10,
    craftsman: {
      id: "fakeID",
      firstname: "John",
      lastname: "Doe",
      job: "Fake job",
      biography: "Fake description",
      address: "Fake address",
    }
  },
  {
    id: 2,
    name: "Product 2",
    description: "Description 2",
    price: 10,
    images: ["img/product/table à thé.jpg"],
    craftsmanId: "fakeID",
    quantity: 10,
    craftsman: {
      id: "fakeID",
      firstname: "John",
      lastname: "Doe",
      job: "Fake job",
      biography: "Fake description",
      address: "Fake address",
    }
  },
  {
    id: 3,
    name: "Product 3",
    description: "Description 3",
    price: 10,
    images: ["img/product/table à thé.jpg"],
    craftsmanId: "fakeID",
    quantity: 10,
    craftsman: {
      id: "fakeID",
      firstname: "John",
      lastname: "Doe",
      job: "Fake job",
      biography: "Fake description",
      address: "Fake address",
    }
  },
  {
    id: 4,
    name: "Product 4",
    description: "Description 4",
    price: 10,
    images: ["img/product/table à thé.jpg"],
    craftsmanId: "fakeID",
    quantity: 10,
    craftsman: {
      id: "fakeID",
      firstname: "John",
      lastname: "Doe",
      job: "Fake job",
      biography: "Fake description",
      address: "Fake address",
    }
  },
];

interface Props {}

const Search: React.FunctionComponent<Props> = () => {
  const [searchType, setType] = useState(false);
  const [searchParams, setSearchParams] = useSearchParams();
  const [searchResult, setResult] = useState(defaultResults);
  const api = useApi(SearchApi);
  const search = "Table";

  return (
    <Wrapper>
      <div id="search">
        <SearchHeader>
        <Formik
          initialValues={{
            searchStr: "",
            searchType: false,
          }}
          onSubmit={async values => {
            const result = await api.apiSearchProductGetRaw({name: values.searchStr});
            setResult(await result.value());
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
                <Field type="checkbox" name="searchType"/>
                <InputSwitch checked={searchType} onChange={(e) => setType(e.value)} />
                <label className="wordCarousel" htmlFor="SearchType">
                  <ul className={`text-start ${searchType ? "flip2": "flip3"} fs-5`}>
                    <li>By product</li>
                    <li>By craftsman</li>
                  </ul>
                </label>
              </div>
            </Form>
          )}
        </Formik>
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
                    <li>
                      <input type="checkbox" />
                      <span>test</span>
                    </li>
                  </ul>
              </div>
          </SearchFilter>
          <section id="search-block">
              <h2>Résultats pour : <span id="result-str">{search}</span></h2>
              <div id="result-list">
                {searchResult.map(elem => <ProductCard img={elem.images?.length ? elem.images[0] : "img/product/default.png"} serie="Petite série" name={elem.name} price={elem.price} />)}
              </div>
          </section>
        </div>
        <div id="suggestions">
          <h2>Pour vous :</h2>
          <div id="suggestions-wrapper">
            <ProductCard img="img/product/table à thé.jpg" serie="Petite série" name="table trop bien" price={1500}/>
            <ProductCard img="img/product/table à thé.jpg" serie="Petite série" name="table trop bien" price={1500}/>
          </div>
        </div>
      </div>
    </Wrapper>
  );
}

export default Search;
