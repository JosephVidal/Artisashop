import React, { FC, useEffect, useState } from "react";
import {Account, Basket, CustomOrderApi, OrderList, State} from "api";
import { SetState } from "globals/state";
import useApi from "hooks/useApi";
import {AccordionTab} from "primereact/accordion";
import Select from "components/Select";
import Option from "components/Select/Option";
import {priceFormatter} from "components/ProductCard";
import {
  Wrapper,
  CustomAccordion,
  HeaderWrapper,
  ClientName,
  HeaderRight,
  ProductWrapper,
  ImageWrapper,
  ProductDetails,
  LeftWrapper,
  PriceWrapper,
} from "./styles";

const Orders: FC = () => {
  const [orderList, setOrderList] = useState<OrderList[]>([]);
  const [clientList, setClientList] = useState<Account[]>([]);
  const customOrderApi: CustomOrderApi = useApi(CustomOrderApi);

  useEffect(() => {
    customOrderApi.apiCustomOrderListGet().then((list) => {
      setOrderList(list);
      const temp: Account[] = [];
      list.forEach((order) => {
        if (!temp.includes(order.item!.account))
          temp.push(order.item!.account)
      });
      setClientList(temp);
    })
  }, []);

  const accordionHeader = (name: string, total: number, percentage: number) => (
    <HeaderWrapper>
      <ClientName>{name}</ClientName>
      <HeaderRight>Total: {priceFormatter.format(total)}</HeaderRight>
      <LeftWrapper>Complétion: {percentage} %</LeftWrapper>
    </HeaderWrapper>
  )

  const displayOrder = (basketItem: Basket) => (
    <ProductWrapper key={basketItem.id}>
      <ImageWrapper>
        {(basketItem.product.productImages && basketItem.product.productImages?.length !== 0) && <img src={basketItem.product.productImages[0].content!} alt=""/>}
      </ImageWrapper>
      <ProductDetails>
        <div>{basketItem.product.name}</div>
        <div>
          Quantité: {basketItem.quantity}
        </div>
        <PriceWrapper>
          {priceFormatter.format(basketItem.product.price * basketItem.quantity)}
        </PriceWrapper>
        <LeftWrapper>
          Livraison: {basketItem.deliveryOpt}
        </LeftWrapper>
        <div>
          <Select
            value={basketItem.currentState}
            onChange={(e) =>
              changeState(customOrderApi, setOrderList, basketItem.id!, e as State)}
          >
            <Option label="En cours" value="ONGOING" />
            <Option label="Livraison" value="DELIVERY" />
            <Option label="Refusé" value="REFUSED" />
            <Option label="Terminé" value="END" />
          </Select>
        </div>
      </ProductDetails>
    </ProductWrapper>
  );

  const displayClientOrders = (client: Account, orders: OrderList[]) => (
    <AccordionTab header={accordionHeader(client.userName!, calculateTotal(orders), calculateCompletion(orders))} key={client.id}>
      {orders.map((order) => displayOrder(order.item!))}
    </AccordionTab>
  )

  return (
    <Wrapper>
      <CustomAccordion>
        {clientList.map((client) => displayClientOrders(client, orderList.filter((order) => order.item!.accountId === client.id)))}
      </CustomAccordion>
    </Wrapper>
  )
};


const changeState = (customOrderApi: CustomOrderApi, setOrderList: SetState<OrderList[]>, id: number, state: State) => {
  setOrderList((prevState) =>
    prevState.map((orders) => {
        if (orders.item!.id === id) {
          customOrderApi.apiCustomOrderBasketIdChangeStatusPatch({
            basketId: id,
            state
          })
          return {
            ...orders,
            item: {
              ...orders.item,
              currentState: state
            }
          } as OrderList
        }
        return orders;
      }
    )
  );
}

const calculateTotal = (orders: OrderList[]) => {
  const priceList = orders.map((order) => order.item!.product.price * order.item!.quantity);
  return priceList.reduce((accumulator, current) => accumulator + current, 0);
}

const calculateCompletion = (orders: OrderList[]) =>
  Math.floor(orders.filter((order) => order.item!.currentState === "END").length * 100 / orders.length)

export default Orders;
