import React, { useEffect, useMemo, useState } from "react";
import { useParams } from "react-router-dom";
import { Product } from "api/models/Product";
import { SetState } from "globals/state";
import QuantityInput from "components/QuantityInuput";
import { BasketApi } from "api/apis";
import useApi from "hooks/useApi";
import useFormattedDocumentTitle from "hooks/useFormattedDocumentTitle";
import { ProductApi } from "../../api";
import { Wrapper, Craftsman, Tag } from "./styles";

const ProductView = () => {
  const { id } = useParams();
  const [quantity, setQuantity] = useState<number>(1);
  const basketApi = useApi(BasketApi);
  const productApi = useApi(ProductApi);
  const [product, setProduct] = useState<Product | null>(null);
  const craftsmanLink = useMemo(() => product?.craftsmanId ? `/craftsman/${product?.craftsmanId}` : "#", [product]);
  const productImg = useMemo(() => product?.productImages?.at(0)?.content ?? `/img/product/${product?.productImages?.at(0)?.imagePath || "default.png"}`, [product]);
  const productStock = useMemo(() => product?.quantity === 0 ? "Épuisé" : "En stock", [product]);
  const buttonClass = useMemo(() => product?.quantity === 0 ? "red-button disabled" : "red-button", [product]);

  useFormattedDocumentTitle(product?.name ?? "Produit");

  useEffect(() => {
    const getProduct = async () => {
      if (id) {
        const result = await productApi.apiProductInfoProductIdGet({ productId: +id });
        setProduct(result ?? null);
      }
    }
    getProduct();
  }, [id]);

  return (
    <Wrapper>
      <div id="product-page">
        <div id="productCarousel" className="carousel slide" data-bs-ride="carousel">
          <div role="listbox">
            <img className="carrousel-img" alt="600x600" src={productImg} />
          </div>
        </div>
        <div id="product-info">
          <h1>{product?.name}</h1>
          <Craftsman>
            <img className="craftsman-img" src={`/img/craftsman/${product?.craftsman.profilePicture ?? "default.svg"}`} alt="test" />
            <a href={craftsmanLink}>{product?.craftsman.firstname} {product?.craftsman.lastname}</a>
          </Craftsman>
          <div id="tags">
            <p id="price">{product?.price.toFixed(2)}€</p>
            {product?.productStyles?.map(elem => <Tag>{elem.displayName || elem.normalizedName}</Tag>)}
          </div>
          <p id="description">{product?.description}</p>
          <p id="stock">{productStock}</p>
          <QuantityInput quantity={quantity} onChange={changeQuantity(setQuantity, product?.quantity ?? 0)} />
          <button id="addToCart" className={buttonClass} onClick={() => addToBasket(basketApi, product?.id ?? 0, quantity)} type="submit">Ajouter au panier</button>
        </div>
      </div>
    </Wrapper>
  )
};

const changeQuantity = (setQuantity: SetState<number>, max: number) => (value: number | null) => {
  if (value && value > 0 && value <= max)
    setQuantity(value);
}

const addToBasket = (basketApi: BasketApi, id: number, quantity: number) =>
  basketApi.apiBasketPost({
    createBasket: {
      productId: id,
      quantity,
      currentState: "WAITINGCONSUMER"
    }
  }).then((e) => {
    alert("Et hop, c'est dans la boîte !");
    document.getElementById("addToCart")?.classList.add("active");
  }, (e) => {
    alert("Oups on dirait qu'il y a un problème, veuillez réessayer plus tard !");
    document.getElementById("addToCart")?.classList.add("error");
  });

export default ProductView;
