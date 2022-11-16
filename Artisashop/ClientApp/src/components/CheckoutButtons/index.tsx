import React, {useEffect} from "react";
import {PayPalButtons, usePayPalScriptReducer} from "@paypal/react-paypal-js";
import {Basket} from "api";

interface Props {
  basket: Basket[],
  total: number
}

const currency = "EUR";
const style = {"layout":"vertical"};

const CheckoutButtons: React.FC<Props> = ({ basket, total }) => {
  const [{ options, isPending }, dispatch] = usePayPalScriptReducer();

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
      .then((orderId) => {
        console.log("orderId");
        console.log(orderId);
        return orderId;
      })}
    onApprove={(data, actions) => actions.order!.capture().then((response) => {
      console.log("orderRespo,se");
      console.log(response);
      // Your code here after capture the order
    })}
  />
  )
};

export default CheckoutButtons;
