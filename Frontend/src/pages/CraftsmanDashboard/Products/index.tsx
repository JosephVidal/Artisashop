import React, { FC, useEffect, useState } from "react";
import { Product, ProductApi } from "api";
import useApi from "hooks/useApi";
import { priceFormatter } from "components/ProductCard";
import { useAtom } from "jotai";
import userAtom from "states/atoms/user";
import { useNavigate } from "react-router";
import { AiOutlinePlus } from "react-icons/ai";
import {
  Wrapper,
  NewProductButton,
  ProductWrapper,
  ImageWrapper,
  ProductDetails,
  ProductName,
  Quantity,
  PriceWrapper,
} from "./styles";

const Products: FC = () => {
  const [productList, setProductList] = useState<Product[]>([]);
  const [user] = useAtom(userAtom);
  const navigate = useNavigate();
  const productApi = useApi(ProductApi);

  useEffect(() => {
    productApi.apiProductGet({sellerId: user!.id!}).then((list) => setProductList(list))
  }, []);

  const displayProduct = (product: Product) => (
    <ProductWrapper key={product.id} onClick={() => navigate({
      pathname: "/update-product",
      search: `?product=${JSON.stringify(product)}`,
    })}>
      <ImageWrapper>
        {(product.productImages && product.productImages?.length !== 0) && <img src={product.productImages[0].content ?? `/img/product/${product.productImages?.at(0)?.imagePath || "default.png"}`} alt="" />}
      </ImageWrapper>
      <ProductDetails>
        <ProductName>
          {product.name}
        </ProductName>
        <Quantity>
          Quantité: {product.quantity}
        </Quantity>
        <PriceWrapper>
          {priceFormatter.format(product.price * product.quantity)}
        </PriceWrapper>
      </ProductDetails>
    </ProductWrapper>
  );

  return (
    <Wrapper>
      <NewProductButton onClick={() => navigate("/create-product")}><AiOutlinePlus />  Nouveau produit</NewProductButton>
      {productList.map((product) => displayProduct(product))}
    </Wrapper>
  )
};

export default Products;
