import { ProductStyle } from "api";
import React from "react";
import { Link } from "react-router-dom";
import { ProductCardWrapper } from "./styles";

interface Props {
  name: string
  img: string
  serie?: string
  price: number
  href: string
  productStyles?: ProductStyle[] | null
}

// TODO: Handle internationalization here
export const priceFormatter = new Intl.NumberFormat('fr-FR', { style: 'currency',currency: 'EUR',});

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
        <div id="line">
          <p id="product-name">{name}</p>
          {/* {
              productStyles?.map((style) => (
                <span key={style.normalizedName} className="tag">{style.displayName}</span>
              ))
          } */}
          <span className="tag">{productStyles?.at(0)?.displayName}</span>
        </div>
        {serie &&
          <p id="product-serie">{serie}</p>
        }
        <p id="product-price">{priceFormatter.format(price)}</p>
      </div>
    </Link>
  </ProductCardWrapper>
);

export default ProductCard;
