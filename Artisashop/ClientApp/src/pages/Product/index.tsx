import React, { useEffect, useMemo, useState } from "react";
import { useParams } from "react-router-dom";
import { Product } from "api/models/Product";
import { Wrapper, Craftsman, Tag } from "./styles";

const ProductView = () => {
  const { id } = useParams();
  const [product, setProduct] = useState<Product | null>(null);
  const productLink = useMemo(() => product?.craftsmanId ? `/craftsman/${product?.craftsmanId}` : "#", [product]);
  const productImg = useMemo(() => product?.images ? `/img/product/${product?.images[0]}` : "/img/product/default.png", [product]);
  const productStock = useMemo(() => product?.quantity === 0 ? "Épuisé" : "En stock", [product]);
  const buttonClass = useMemo(() => product?.quantity === 0 ? "red-button disabled" : "red-button", [product]);

  useEffect(() => {
    if (id) {
      fetch(`/api/product/info/${id}`)
      .then(response => response.json())
      .then(data => setProduct(data as Product));
    }
  }, [id]);

  return (
    <Wrapper>
      <div id="product-page">
        <div id="productCarousel" className="carousel slide" data-bs-ride="carousel">
          <div role="listbox">
            <img className="carrousel-img active" alt="600x600" src={productImg} data-holder-rendered="true" />
          </div>
        </div>
        <div id="product-info">
          <h1>{product?.name}</h1>
          <Craftsman>
            <img className="craftsman-img" src="img/craftsman/Joseph.jpg" alt="test" />
            <a href={productLink} id="craftsman-name">{product?.craftsman.firstname} {product?.craftsman.lastname}</a>
          </Craftsman>
          <div id="tags">
            <p id="price">{product?.price}€</p>
            {product?.styles?.map(elem => <Tag>{elem}</Tag>)}
          </div>
          <p id="description">{product?.description}</p>
          <p id="stock">{productStock}</p>
          <button className={buttonClass} type="submit">Ajouter au panier</button>
        </div>
      </div>
    </Wrapper>
  )
};

export default ProductView;