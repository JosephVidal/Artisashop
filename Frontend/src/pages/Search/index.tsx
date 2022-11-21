import React, {useEffect, useState} from "react";
import ProductCard from "components/ProductCard";
import CraftsmanresultCard from "components/CraftsmanresultCard";
import { useSearchParams } from "react-router-dom";
import { Field, Form, Formik } from "formik";
import useApi from "hooks/useApi";
import { Account, Product, SearchApi } from "../../api";
import { Wrapper, SearchHeader, SearchFilters } from "./styles";

interface Props {}

const Search: React.FunctionComponent<Props> = () => {
  const [searchType, setType] = useState(false);
  const [searchParams, setSearchParams] = useSearchParams();
  const [productResult, setProductresult] = useState<Product[] | null>(null);
  const [accountResult, setAccountresult] = useState<Account[] | null>(null);
  const api = useApi(SearchApi);
  const type = searchType ? "Par produit" : "Par métier";

  useEffect(
    () => {
      const search = async () => {
        if (searchParams.get("t") === "true") {
          const result = await api.apiSearchProductGetRaw({name: searchParams.get("q") ?? ""});
          setProductresult(await result.value());
          setAccountresult(null);
          setType(true);
        } else {
          const result = await api.apiSearchCraftsmanGetRaw({job: searchParams.get("q") ?? ""});
          setAccountresult(await result.value());
          setProductresult(null);
          setType(false);
        }
      };
      search();
    }, [searchParams]
  )

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
            setSearchParams({"q": values.searchStr, "t": values.searchType.toString()});
          }}
        >
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
              <label className="wordCarousel" htmlFor="SearchType">
                <span className="search-type-text">{type}</span>
              </label>
            </div>
          </Form>
        </Formik>
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
          <SearchFilters>
              {/* <div className="filter">
                  <h2>Distance</h2>
                  <input type="range" min="0" className="slider" id="distance" />
              </div> */}
            <div className="filter">
                <h2>Styles</h2>
                <ul id="styles">
                  <li>
                    <input type="checkbox" />
                    <span>test</span>
                  </li>
                </ul>
            </div>
          </SearchFilters>
          <section id="search-result-block">
            <h2>Résultats pour : {searchParams.get("q")}</h2>
            <div id="result-list">
              {productResult?.map(elem => <ProductCard styles={elem?.stylesList ?? ""} img={elem.images?.length ? elem.images[0] : "/img/product/default.png"} serie="Petite série" name={elem.name} price={elem.price} href={`/app/product/${elem?.id}`} />)}
              {accountResult?.map(elem => <CraftsmanresultCard img={elem.profilePicture ?? "/img/craftsman/default.png"} name={elem.firstname} job={elem.job ?? ""} href={`/app/craftsman/${elem?.id ?? ""}`} />)}
            </div>
          </section>
        </div>
        <div id="suggestions">
          <h2>Pour vous :</h2>
          <div id="suggestions-wrapper">
            <ProductCard styles="LouisXV" img="img/product/table à thé.jpg" serie="Petite série" name="table trop bien" price={1500} href="/app/product/test"/>
            <ProductCard styles="LouisXV" img="img/product/table à thé.jpg" serie="Petite série" name="table trop bien" price={1500} href="/app/product/test"/>
          </div>
        </div>
      </div>
    </Wrapper>
  );
}

export default Search;
