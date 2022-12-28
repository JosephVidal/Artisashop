import React, { useEffect, useMemo } from "react";
import { Field, Form, Formik } from "formik";
import _ from "lodash";
import { atom, PrimitiveAtom, useAtom } from "jotai";
import { splitAtom } from "jotai/utils";

import ProductCard from "components/ProductCard";
import CraftsmanresultCard from "components/CraftsmanresultCard";
import { useSearchParams } from "react-router-dom";
import useApi from "hooks/useApi";
import useFormattedDocumentTitle from "hooks/useFormattedDocumentTitle";
import useAsync from "hooks/useAsync";
import { ProductApi, ProductStyle, SearchApi } from "../../api";
import { Wrapper, SearchHeader, SearchFilters } from "./styles";

// --- INTERFACE ---

interface Props { }

interface CheckedFilterProps {
  checked: boolean;
}

interface StyleFilterProps extends ProductStyle, CheckedFilterProps { }

interface JobFilterProps extends CheckedFilterProps {
  job?: string | null;
}

// --- ATOMS ---

const styleFiltersAtom = atom<StyleFilterProps[]>([])
const jobFiltersAtom = atom<JobFilterProps[]>([])

const styleFiltersAtomAtom = splitAtom(styleFiltersAtom)
const jobFiltersAtomAtom = splitAtom(jobFiltersAtom)

// --- COMPONENTS ---

const StyleFilterCheckBox = ({
  filter,
}: {
  filter: PrimitiveAtom<StyleFilterProps>
}) => {
  const [styleFilter, setStyleFilter] = useAtom(filter)

  return (
    <div>
      <input type="checkbox" name="styleFilters"
        checked={styleFilter.checked}
        onChange={(e) => setStyleFilter({ ...styleFilter, checked: e.target.checked })}
      />
      {styleFilter.displayName}
    </div>
  )
}

const JobFilterCheckBox = ({
  filter,
}: {
  filter: PrimitiveAtom<JobFilterProps>
}) => {
  const [jobFilter, setJobFilter] = useAtom(filter)

  return (
    <div>
      <input type="checkbox" name="styleFilters"
        checked={jobFilter.checked}
        onChange={(e) => setJobFilter({ ...jobFilter, checked: e.target.checked })}
      />
      {jobFilter.job}
    </div>
  )
}

const Search: React.FunctionComponent<Props> = () => {
  const searchApi = useApi(SearchApi);
  const productApi = useApi(ProductApi); // used by "suggested for you"

  // --- STATE ---

  // TODO: Utiliser un routeur un peu plus typé que react-router ! https://tanstack.com/router/v1
  const [searchParams, setSearchParams] = useSearchParams();

  const [styleFilters, setStyleFilters] = useAtom(styleFiltersAtom);
  const [jobFilters, setJobFilters] = useAtom(jobFiltersAtom);

  const [styleFiltersAtoms] = useAtom(styleFiltersAtomAtom);
  const [jobFiltersAtoms] = useAtom(jobFiltersAtomAtom);

  const searchStr = useMemo(() => searchParams.get("q") || "", [searchParams]);
  const isProduct = useMemo(() => searchParams.get("t") ? searchParams.get("t") === "true" : true, [searchParams]);

  const searchProductsAsync = useAsync(() => searchApi.apiSearchProductGet({ name: searchStr ?? "" }), false);
  const searchCraftsmenAsync = useAsync(() => searchApi.apiSearchCraftsmanGet({ job: searchStr ?? "" }), false);

  // --- COMPUTED ---

  const filteredProducts = useMemo(
    () =>
      styleFilters.some(f => f.checked)
        ? searchProductsAsync.value?.filter(p => p.productStyles?.some(x => styleFilters.filter(y => y.checked).some(y => y.normalizedName === x.normalizedName)))
        : searchProductsAsync.value,
    [searchProductsAsync.value, styleFilters]);

  const filteredCraftsmen = useMemo(
    () =>
      jobFilters.some(x => x.checked)
        ? searchCraftsmenAsync.value?.filter(c => jobFilters.filter(y => y.checked).some(x => x.job === c.job))
        : searchCraftsmenAsync.value,
    [searchCraftsmenAsync.value, jobFilters]);

  // --- EFFECTS ---

  useEffect(() => {
    if (isProduct) {
      searchProductsAsync.execute();
    } else {
      searchCraftsmenAsync.execute();
    }
  }, [searchParams]);

  useEffect(() => {
    setStyleFilters(searchProductsAsync.value
      ? _.uniqBy(searchProductsAsync.value?.flatMap(p => p.productStyles ?? []), x => x.normalizedName).map(x => ({ ...x, checked: false }))
      : []
    )
  }, [searchProductsAsync.value]);

  useEffect(() => {
    setJobFilters(searchCraftsmenAsync.value
      ? _.uniq(searchCraftsmenAsync.value?.map(c => c.job)).map(x => ({ job: x, checked: false }))
      : []
    )
  }, [searchCraftsmenAsync.value]);

  // --- RENDER ---

  const resultsForText = useMemo(() => {
    const type = isProduct ? "produits" : "artisans";
    return searchStr
      ? `Résultats des ${type} pour "${searchStr}":`
      : `Explorez les ${type}:`;
  }, [searchStr, isProduct]);

  const suggestedProductsResults = useAsync(() => productApi.apiProductGet().then(res => _.take(res, 2)), false);

  useEffect(() => {
    suggestedProductsResults.execute();
  }, []);

  useFormattedDocumentTitle("Recherche");

  return (
    <Wrapper>
      <div id="search">
        <SearchHeader>
          <Formik
            initialValues={{ searchStr, isProduct }}
            onSubmit={async values => {
              setSearchParams({
                q: values.searchStr,
                t: values.isProduct.toString(),
              })

              // console.log(values)
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
                <div id="isProduct" style={{ display: "flex" }}>
                  <label className="switch">
                    <Field type="checkbox" name="isProduct" />
                    <span className="round search-slider" />
                  </label>
                  <label className="wordCarousel" htmlFor="isProduct">
                    <p className="search-type-text">{values.isProduct ? "Par Produit" : "Par Artisan"}</p>
                  </label>
                </div>
              </Form>
            )}
          </Formik>
          <div id="suggest">
            <span className="category">
              <a href="#search" className="search-header-link">Mobilier 🪑</a>
              <a href="#search" className="search-header-link">Poterie 🏺</a>
            </span>
            <span className="category">
              <a href="#search" className="search-header-link">Arts de la table 🍴</a>
              <a href="#search" className="search-header-link">Vêtements 👗</a>
            </span>
          </div>
        </SearchHeader>

        <div id="search-body">
          <SearchFilters>
            {/* <div className="filter">
                  <h2>Distance</h2>
                  <input type="range" min="0" className="slider" id="distance" />
              </div> */}
            <div className="filter">
              <h2>Filtres</h2>
              <div id="styles">
                {
                  isProduct
                    ? styleFiltersAtoms?.map(elem => <StyleFilterCheckBox filter={elem} />)
                    : jobFiltersAtoms?.map(elem => <JobFilterCheckBox filter={elem} />)
                }
              </div>
            </div>
          </SearchFilters>
          <section id="search-result-block">
            <h2>{resultsForText}</h2>
            <div id="result-list">
              {
                isProduct
                  ? filteredProducts?.map(elem => <ProductCard productStyles={elem?.productStyles} img={`/img/product/${elem.productImages?.at(0)?.imagePath ?? "default.png"}`} serie="Petite série" name={elem.name} price={elem.price} href={`/app/product/${elem?.id}`} />)
                  : filteredCraftsmen?.map(elem => <CraftsmanresultCard img={`/img/craftsman/${elem.profilePicture ?? "default.svg"}`} name={elem.firstname} job={elem.job ?? ""} href={`/app/craftsman/${elem?.id ?? ""}`} />)
              }
            </div>
          </section>
        </div>
        <div id="suggestions">
          <h2>Pour vous :</h2>
          <div>
            {suggestedProductsResults.status?.toString()}
          </div>
          <div id="suggestions-wrapper">
            {suggestedProductsResults.value?.map(elem =>
              <ProductCard key={elem.id}
                productStyles={elem.productStyles}
                img={`/img/product/${elem.productImages?.at(0)?.imagePath ?? "default.svg"}`}
                serie="Petite série"
                name={elem.name}
                price={elem.price}
                href={`/app/product/${elem.id}`}
              />
            )}
          </div>
        </div>
      </div>
    </Wrapper>
  );
}

export default Search;
