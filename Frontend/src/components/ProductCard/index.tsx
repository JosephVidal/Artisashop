import React from "react";
import { Link } from "react-router-dom";
import { ProductCardWrapper } from "./styles";

interface Props {
    name: string;
    img: string;
    serie: string;
    price: number;
    href: string,
}

const ProductCard: React.FunctionComponent<Props> = ({
    name,
    img,
    serie,
    price,
    href,
}) => (
  <ProductCardWrapper>
    <Link id="product-card" to={href}>
      <img src={img} alt="" />
      <div>
        <p id="product-name">{name}</p>
        <p id="product-serie">{serie}</p>
        <p id="product-price">{price}€</p>
      </div>
    </Link>
  </ProductCardWrapper>
);

export default ProductCard;
