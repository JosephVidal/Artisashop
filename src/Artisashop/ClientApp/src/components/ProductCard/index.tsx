import React from "react";
import { ProductCardWrapper } from "./styles";

interface Props {
    name: string;
    img: string;
    serie: string;
    price: number;
}

const ProductCard: React.FunctionComponent<Props> = ({
    name,
    img,
    serie,
    price,
}) => (
  <ProductCardWrapper>
    <a id="product-card" href="/product/test">
        <img src={img} alt="" />
        <div>
            <p id="product-name">{name}</p>
            <p id="product-serie">{serie}</p>
            <p id="product-price">{price}€</p>
        </div>
    </a>
  </ProductCardWrapper>
);

export default ProductCard;
