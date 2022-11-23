import React, { FC, useEffect, useState } from "react";
import { Basket, BasketApi, DeliveryOption } from "api";
import { SetState } from "globals/state";
import Select from "components/Select";
import Option from "components/Select/Option";
import {
  PayPalScriptProvider
} from "@paypal/react-paypal-js";
import { Divider } from "primereact/divider";
import CheckoutButtons from "components/CheckoutButtons";
import useApi from "hooks/useApi";
import useFormattedDocumentTitle from "hooks/useFormattedDocumentTitle";
import { REACT_APP_PAYPAL_CLIENT } from "conf";
import QuantityInput from "components/QuantityInuput";
import {
  Wrapper,
  BasketDeliveryWrapper,
  Card,
  CardTitle,
  CardBody,
  ProductWrapper,
  ImageWrapper,
  ProductDetails,
  LeftWrapper,
  PriceWrapper,
  AddressInput,
  TextRight,
  ProductBill,
  BillElement
} from "./styles";

const BasketView: FC = () => {
  const [basket, setBasket] = useState<Basket[]>([]);
  const [address, setAddress] = useState<string>("");
  const [hasDelivery, setHasDelivery] = useState<boolean>(false);
  const [deliveryCost, setDeliveryCost] = useState<number>(0);
  const basketAPI: BasketApi = useApi(BasketApi);

  useFormattedDocumentTitle("Panier");

  useEffect(() => {
    basketAPI.apiBasketGet().then((list) => setBasket(list.filter((item) => item.currentState === "WAITINGCONSUMER")))
  }, []);

  useEffect(() => {
    setHasDelivery(basket.find((product) => product.deliveryOpt === DeliveryOption.Delivery) !== undefined);
    setDeliveryCost(basket.filter((product) => product.deliveryOpt === "DELIVERY").length * 50)
  }, [basket]);

  const displayProduct = (basketItem: Basket) => (
    <ProductWrapper key={basketItem.id}>
      <ImageWrapper>
        {basketItem.product.productImages?.map((image) => (
          // TODO: Use image.content instead of image.imagePath
          <img src={image.imagePath ?? '/img/product/default.svg'} alt={image.name ?? "Image du produit"} />
        ))}
      </ImageWrapper>
      <ProductDetails>
        <div>{basketItem.product.name}</div>
        <div>
          <div>Quantité:</div>
          <QuantityInput quantity={basketItem.quantity} onChange={changeQuantity(basketAPI, setBasket, basketItem.id!)} />
        </div>
      </ProductDetails>
      <LeftWrapper>
        <PriceWrapper>
          {`${basketItem.product.price * basketItem.quantity} €`}
        </PriceWrapper>
        <Select
          value={basketItem.deliveryOpt}
          onChange={(e) =>
            changeDelivery(basketAPI, setBasket, basketItem.id!, e as DeliveryOption)}
        >
          <Option label="Livraison" value="DELIVERY" />
          <Option label="Chercher sur place" value="TAKEOUT" />
        </Select>
      </LeftWrapper>
    </ProductWrapper>
  )


  const displayProductBill = (basketItem: Basket) => (
    <ProductBill>
      <div>{basketItem.quantity} x {basketItem.product.name}</div>
      <div>{basketItem.quantity * basketItem.product.price} €</div>
    </ProductBill>
  )

  return (
    <Wrapper>
      <BasketDeliveryWrapper>
        <Card>
          <CardTitle>Panier ({basket.length})</CardTitle>
          <CardBody>{basket.map(displayProduct)}</CardBody>
        </Card>
        {hasDelivery && (
          <Card isDelivery>
            <CardTitle>Livraison</CardTitle>
            <CardBody>
              Adresse de livraison (numéro, rue, code postal, ville, pays):
              <AddressInput onChange={(e) => setAddress(e.target.value)} />
            </CardBody>
          </Card>
        )}
      </BasketDeliveryWrapper>
      <Card isBill>
        <CardTitle>Facture</CardTitle>
        <Divider />
        <CardBody isBill>
          {hasDelivery && (
            <BillElement>
              <div>Adresse de livraison:</div>
              <TextRight>{address}</TextRight>
            </BillElement>
          )}
          <BillElement>
            <div>Produits:</div>
            {basket.map(displayProductBill)}
          </BillElement>
          {hasDelivery && (
            <BillElement>
              <div>Frais de livraison:</div>
              <ProductBill>
                <div>{basket.filter((product) => product.deliveryOpt === "DELIVERY").length} x 50</div>
                <div>{deliveryCost} €</div>
              </ProductBill>
            </BillElement>
          )}
          <BillElement>
            <div>Total:</div>
            <TextRight>{deliveryCost + basket.reduce(
              (previousValue, currentValue) => previousValue + currentValue.quantity * currentValue.product.price, 0)} €</TextRight>
          </BillElement>

          <PayPalScriptProvider
            options={{
              "client-id": REACT_APP_PAYPAL_CLIENT,
              components: "buttons",
              currency: "EUR"
            }}
          >
            <CheckoutButtons basketAPI={basketAPI} setBasket={setBasket} basket={basket} total={deliveryCost + basket.reduce(
              (previousValue, currentValue) => previousValue + currentValue.quantity * currentValue.product.price, 0)}
            />
          </PayPalScriptProvider>
        </CardBody>
      </Card>
    </Wrapper>
  )
};

const changeDelivery = (basketApi: BasketApi, setProducts: SetState<Basket[]>, id: number, delivery: DeliveryOption) => {
  setProducts((prevState) =>
    prevState.map((product) => {
      if (product.id === id) {
        basketApi.apiBasketPatch({
          updateBasket: {
            id: product.id,
            quantity: product.quantity,
            deliveryOpt: delivery,
            currentState: product.currentState
          }
        })
        return {
          ...product,
          deliveryOpt: delivery
        }
      }
      return product;
    }
    )
  );
}

const changeQuantity = (basketApi: BasketApi, setProducts: SetState<Basket[]>, id: number) => (quantity: number | null) => {
  if (quantity === null || quantity === 0) {
    basketApi.apiBasketBasketIdDelete({ basketId: id })
      .then(() => setProducts((prevState) => prevState.filter((product) => product.id !== id)))

  }
  else
    setProducts((prevState) =>
      prevState.map((product) => {
        if (product.id === id) {
          basketApi.apiBasketPatch({
            updateBasket: {
              id: product.id,
              quantity,
              deliveryOpt: product.deliveryOpt,
              currentState: product.currentState
            }
          })
          return {
            ...product,
            quantity
          }
        }
        return product;
      }
      )
    );
}

export default BasketView;
