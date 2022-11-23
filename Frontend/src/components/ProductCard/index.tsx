import { ProductStyle } from "api";
import React from "react";
import { Link } from "react-router-dom";
import { ProductCardWrapper } from "./styles";

interface Props {
  name: string
  img: string
  serie: string
  price: number
  href: string
  productStyles?: ProductStyle[] | null
}

const ProductCard: React.FunctionComponent<Props> = ({
  name,
  img,
  serie,
  price,
  href,
  productStyles,
}) => (
  <ProductCardWrapper>
    <Link id="product-card" to={href}>
      <img src={img} alt="" />
      <div>
        <p id="product-name">{name}</p>
        <p id="product-serie">{serie}</p>
        <p id="product-price">{price}€</p>

        {productStyles &&
          <ul>
            {productStyles.map((style) => (
              <li key={style.normalizedName}>{style.displayName}</li>
            ))}
          </ul>
        }
      </div>
    </Link>
  </ProductCardWrapper>
);

export default ProductCard;
