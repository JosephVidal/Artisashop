import React, { useEffect, useMemo, useState } from "react";
import { Field, Form, Formik } from "formik";
import _ from "lodash";

import ProductCard from "components/ProductCard";
import CraftsmanresultCard from "components/CraftsmanresultCard";
import { useSearchParams } from "react-router-dom";
import useApi from "hooks/useApi";
import useFormattedDocumentTitle from "hooks/useFormattedDocumentTitle";
import { Account, Product, ProductStyle, SearchApi } from "../../api";
import { Wrapper, SearchHeader, SearchFilters } from "./styles";

interface Props { }

interface StyleFilter extends ProductStyle {
  checked: boolean;
}

interface JobFilter {
  job: string;
  checked: boolean;
}

const Search: React.FunctionComponent<Props> = () => {
  const [searchType, setType] = useState(false);
  const [searchParams, setSearchParams] = useSearchParams();

  const [productResult, setProductresult] = useState<Product[] | null>(null);
  const [accountResult, setAccountresult] = useState<Account[] | null>(null);

  const [stylesFilters, setStylesfilters] = useState<StyleFilter[] | null>(null);
  const [jobFilters, setjobfilters] = useState<JobFilter[] | null>(null);

  const api = useApi(SearchApi);

  const termSearchParam = useMemo(() => searchParams.get("q") || "", [searchParams]);
  const typeSearchParam = useMemo(() => searchParams.get("t") || "false", [searchParams]);

  const searchTypeLabel = useMemo(() => searchType ? "Par produit" : "Par métier", [searchType]);

  const titleText = useMemo(() =>
    termSearchParam
      ? `Résultats des ${typeSearchParam === "true" ? "produits" : "artisans"} pour "${termSearchParam}"`
      : `Explorer les ${typeSearchParam === "true" ? "produits" : "artisans"}`,
    [termSearchParam, typeSearchParam]);

  useFormattedDocumentTitle(titleText);

  const filteredProducts = useMemo(
    () => _.some(stylesFilters, f => f.checked)
    ? productResult?.filter((elem) => elem.productStyles?.some((style) => stylesFilters?.find((filter) => filter.normalizedName === style.normalizedName)?.checked))
    : productResult,
    [productResult, stylesFilters]
  );

  const filteredCraftsman = useMemo(
    () => _.some(jobFilters, f => f.checked)
      ? accountResult?.filter((elem) => jobFilters?.find((filter) => filter.job === elem.job)?.checked)
      : accountResult
    ,
    [productResult, jobFilters]
  );

  // const filteredCraftsman = useMemo(
  //   () => accountResult?.filter(value =>
  //     jobFilters?.filter(f => f.job === value?.job))

  //   , [accountResult, jobFilters]
  // );
  // const filteredCraftsman = useMemo(() => accountResult?.filter(value => jobFilters?.filter(f => value?.job === f)),
  //   [accountResult, jobFilters]);

  // Triggered when search changes
  useEffect(() => { }, [searchParams]);

  // Triggered when style filters change
  // useEffect(() => {
  //   if (_.some(stylesFilters, { checked: true })) {
  //     // setProductresult()
  //   } else {
  //   }
  // }, [stylesFilters]);

  // Triggered when job filters change
  useEffect(() => {

  }, [jobFilters]);

  useEffect(
    () => {
      const search = async () => {
        if (searchParams.get("t") === "true") {
          const result = await api.apiSearchProductGetRaw({ name: searchParams.get("q") ?? "" });
          const products = await result.value();

          setProductresult(products);
          setAccountresult(null);
          setType(true);
          setStylesfilters(
            _.uniqBy(products.map(p => p.productStyles).flat().filter(s => !!s?.normalizedName), a => a?.normalizedName)
              .map(s => ({ ...s, checked: false }))
          );
        } else {
          const result = await api.apiSearchCraftsmanGetRaw({ job: searchParams.get("q") ?? "" });
          const accounts = await result.value();

          setAccountresult(accounts);
          setProductresult(null);
          setType(false);
          setjobfilters(
            _.uniq(accounts.map(a => a.job).filter(j => !!j)).map(j => ({ job: j!, checked: false }))
          )
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
              searchStr: termSearchParam,
              searchType: typeSearchParam,
            }}
            onSubmit={async values => {
              setSearchParams({ "q": values.searchStr, "t": values.searchType.toString() });
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
                  <span className="round search-slider" />
                </label>
                <label className="wordCarousel" htmlFor="SearchType">
                  <p className="search-type-text">{searchTypeLabel}</p>
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
                  <li key={elem.normalizedName}>
                    <input type="checkbox" value={elem.checked.toString()} />
                    {elem.displayName}
                  </li>
                )
                }
                {jobFilters?.map(elem =>
                  <li key={elem.job}>
                    <input type="checkbox" value={elem.checked.toString()} />
                    {elem.job}
                  </li>
                )
                }
              </ul>
            </div>
          </SearchFilters>
          <section id="search-result-block">
            <h2>Résultats pour : {searchParams.get("q")}</h2>
            <div id="result-list">
              {filteredProducts?.map(elem => <ProductCard productStyles={elem?.productStyles} img={elem.productImages?.at(0)?.imagePath ?? "/img/product/default.png"} serie="Petite série" name={elem.name} price={elem.price} href={`/app/product/${elem?.id}`} />)}
              {filteredCraftsman?.map(elem => <CraftsmanresultCard img={elem.profilePicture ?? "/img/craftsman/default.svg"} name={elem.firstname} job={elem.job ?? ""} href={`/app/craftsman/${elem?.id ?? ""}`} />)}
            </div>
          </section>
        </div>
        <div id="suggestions">
          <h2>Pour vous :</h2>
          <div id="suggestions-wrapper">
            <ProductCard productStyles={[{ displayName: "Gallé", normalizedName: "Gallé" }]} img="/img/product/table à thé.jpg" serie="Petite série" name="table trop bien" price={1500} href="/app/product/test" />
            <ProductCard productStyles={[{ displayName: "Gallé", normalizedName: "Gallé" }]} img="/img/product/table à thé.jpg" serie="Petite série" name="table trop bien" price={1500} href="/app/product/test" />
          </div>
        </div>
      </div>
    </Wrapper>
  );
}

export default Search;
