import React from "react";
import { Wrapper, Craftsman, Tag } from "./styles";

const Product = () => (
  <Wrapper>
    <div id="product-page">
      <div id="productCarousel" className="carousel slide" data-bs-ride="carousel">
        <div role="listbox">
          <img className="carrousel-img active" alt="600x600" src="img/product/table à thé.jpg" data-holder-rendered="true" />
        </div>
      </div>
      <div id="product-info">
        <h1>Table à thé</h1>
        <Craftsman>
          <img className="craftsman-img" src="img/craftsman/Joseph.jpg" alt="test" />
          <a href="/craftsman" id="craftsman-name">Joseph Vidal</a>
        </Craftsman>
        <div id="tags">
          <p id="price">200€</p>
          <Tag>tag</Tag>
        </div>
          <p id="description">Produit très cool</p>
          <p id="stock">Épuisé</p>
          <button className="red-button disabled" type="submit">Ajouter au panier</button>
      </div>
    </div>
  </Wrapper>
);

export default Product;
