import React, {useEffect, useMemo, useState} from "react";
import ProductCard from "components/ProductCard";
import CraftsmanresultCard from "components/CraftsmanresultCard";
import { useSearchParams } from "react-router-dom";
import { Field, Form, Formik } from "formik";
import useApi from "hooks/useApi";
import { Account, Product, SearchApi } from "../../api";
import { Wrapper, SearchHeader, SearchFilters } from "./styles";

interface Props {}

interface FilterCheckboxProps {
  name: string,
  // id: number,
  checked: boolean,
}

const Search: React.FunctionComponent<Props> = () => {
  const [searchType, setType] = useState(false);
  const [searchParams, setSearchParams] = useSearchParams();
  const [productResult, setProductresult] = useState<Product[] | null>(null);
  const [accountResult, setAccountresult] = useState<Account[] | null>(null);
  const [stylesFilters, setStylesfilters] = useState<FilterCheckboxProps[] | null>(null);
  const [jobFilters, setjobfilters] = useState<FilterCheckboxProps[] | null>(null);
  const api = useApi(SearchApi);
  const type = searchType ? "Par produit" : "Par métier";
  const filteredProducts = useMemo(() => productResult
    ?.filter(value => stylesFilters?.filter(f => !!value?.styles
    ?.filter(s => s === f.name))),
    [productResult, stylesFilters]);
  const filteredCraftsman = useMemo(() => accountResult
    ?.filter(value => jobFilters?.filter(f => f.name === value?.job)),
    [accountResult, jobFilters]);
  // const filteredCraftsman = useMemo(() => accountResult?.filter(value => jobFilters?.filter(f => value?.job === f)),
  //   [accountResult, jobFilters]);

  useEffect(
    () => {
      const search = async () => {
        if (searchParams.get("t") === "true") {
          const result = await api.apiSearchProductGetRaw({name: searchParams.get("q") ?? ""});
          const products = await result.value();

          setProductresult(products);
          setAccountresult(null);
          setType(true);
          setStylesfilters(products.reduce<FilterCheckboxProps[]>((accumulator, current) => accumulator.concat(current.styles?.map<FilterCheckboxProps>(elem => ({name: elem, checked: false})) ?? []), []).filter(value => !!value?.name));
        } else {
          const result = await api.apiSearchCraftsmanGetRaw({job: searchParams.get("q") ?? ""});
          const accounts = await result.value();

          setAccountresult(accounts);
          setProductresult(null);
          setType(false);
          setjobfilters(accounts.reduce<FilterCheckboxProps[]>((accumulator, current) => accumulator.concat([{name: current.job ?? "", checked: false}]), []).filter(value => !!value.name));
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
                <span className="round search-slider" />
              </label>
              <label className="wordCarousel" htmlFor="SearchType">
                <p className="search-type-text">{type}</p>
              </label>
            </div>
          </Form>
        </Formik>
          <span className="category">
            <a href="#search" className="search-header-link">Mobilier 🪑</a>
            <a href="#search" className="search-header-link">Poterie 🏺</a>
          </span>
          <span className="category">
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
              <h2>Filtres</h2>
              <ul id="styles">
                {stylesFilters?.map(elem =>
                    <li key={elem.name}>
                      <input type="checkbox" value={elem.checked.toString()}/>
                      {elem.name}
                    </li>
                  )
                }
                {jobFilters?.map(elem =>
                    <li key={elem.name}>
                      <input type="checkbox" value={elem.checked.toString()}/>
                      {elem.name}
                    </li>
                  )
                }
              </ul>
            </div>
          </SearchFilters>
          <section id="search-result-block">
            <h2>Résultats pour : {searchParams.get("q")}</h2>
            <div id="result-list">
              {filteredProducts?.map(elem => <ProductCard styles={elem?.stylesList ?? ""} img={elem.images?.length ? elem.images[0] : "/img/product/default.png"} serie="Petite série" name={elem.name} price={elem.price} href={`/app/product/${elem?.id}`} />)}
              {filteredCraftsman?.map(elem => <CraftsmanresultCard img={elem.profilePicture ?? "/img/craftsman/default.svg"} name={elem.firstname} job={elem.job ?? ""} href={`/app/craftsman/${elem?.id ?? ""}`} />)}
            </div>
          </section>
        </div>
        <div id="suggestions">
          <h2>Pour vous :</h2>
          <div id="suggestions-wrapper">
            <ProductCard styles="Gallé" img="/img/product/table à thé.jpg" serie="Petite série" name="table trop bien" price={1500} href="/app/product/test"/>
            <ProductCard styles="Gallé" img="/img/product/table à thé.jpg" serie="Petite série" name="table trop bien" price={1500} href="/app/product/test"/>
          </div>
        </div>
      </div>
    </Wrapper>
  );
}

export default Search;
