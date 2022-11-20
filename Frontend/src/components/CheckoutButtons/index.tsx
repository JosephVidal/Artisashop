import React, {useEffect} from "react";
import {PayPalButtons, usePayPalScriptReducer} from "@paypal/react-paypal-js";
import {Basket, BasketApi} from "api";
import {SetState} from "globals/state";

interface Props {
  basketAPI: BasketApi,
  setBasket: SetState<Basket[]>,
  basket: Basket[],
  total: number
}

const currency = "EUR";
const style = {"layout":"vertical"};

const CheckoutButtons: React.FC<Props> = ({ basketAPI, setBasket, basket, total }) => {
  const [{ options }, dispatch] = usePayPalScriptReducer();

  useEffect(() => {
    dispatch({
      type: "resetOptions",
      value: {
        ...options,
        currency,
      },
    });
  }, [currency]);

  return (
    <PayPalButtons
    disabled={false}
    forceReRender={[total, currency, style]}
    fundingSource={undefined}
    createOrder={(data, actions) => actions.order
      .create({
        purchase_units: [
          {
            amount: {
              currency_code: currency,
              value: total.toString(),
            },
          },
        ],
      })
      .then((orderId) => orderId)}
    onApprove={(data, actions) => actions.order!.capture().then((response) => {
      if (response.status === "COMPLETED") {
        basket.forEach((item) => basketAPI.apiBasketPatch({
          updateBasket: {
            ...item,
            currentState: "WAITINGCRAFTSMAN"
          }
        }));
        setBasket([]);
      }
      // Your code here after capture the order
    })}
  />
  )
};

export default CheckoutButtons;
