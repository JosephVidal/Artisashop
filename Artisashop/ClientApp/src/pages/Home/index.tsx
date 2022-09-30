import React from "react";
import Input from "components/Input";
import { Wrapper } from "./styles";

interface Props {}

const Home: React.FunctionComponent<Props> = () => (
  <Wrapper>
    <div className="me-sm-2">
      <input className="search-input" placeholder="Rechercher..." />
      <label htmlFor="SearchStr">
        <button type="submit" id="sendButton" className="search_icon">
          <i className="fas fa-search" />
        </button>
      </label>
    </div>
    <div id="searchType">
      <input type="checkbox" className="form-check-input" />
      <label className="wordCarousel" htmlFor="SearchType">
        <ul className="text-start flip3 fs-5">
          <li>By product</li>
          <li>By craftsman</li>
        </ul>
      </label>
    </div>

    <Input id="TestInput" type="text" label="Test input" />

    <br />
    <br />

    <Input type="number" label="Age" />
  </Wrapper>
);

export default Home;
