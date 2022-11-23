import React, { FC, useEffect, useState } from "react";
import {Account, Basket, CustomOrderApi, OrderList, Product, State} from "api";
import { SetState } from "globals/state";
import useApi from "hooks/useApi";
import {AccordionTab} from "primereact/accordion";
import Select from "components/Select";
import Option from "components/Select/Option";
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

const Jojo: Account = {
  id: "1",
  userName: "Jojo",
  email: "jojo@jojo.jojo",
  lastname: "Vidol",
  firstname: "Jojo",
  suspended: false,
  validation: true
}

const Juju: Account = {
  id: "2",
  userName: "Juju",
  email: "juju@juju.juju",
  lastname: "Vidul",
  firstname: "Juju",
  suspended: false,
  validation: true
}

const Jaja: Account = {
  id: "3",
  userName: "Jaja",
  email: "jaja@jaja.jaja",
  lastname: "Vidal",
  firstname: "Jaja",
  suspended: false,
  validation: true
}

const Chaise: Product = {
  id: 1,
  name: "Chaise",
  description: "Jolie",
  price: 100,
  quantity: 10,
  craftsmanId: "1",
  craftsman: Jojo,
  productImages: [
    {
      id: 1,
      content: "https://d2ans0z9s1x1c.cloudfront.net/produits/chaise-design-bois-de-teck-606e3eaa401bf.jpg",
      name: 'Cat',
      productId: 1
    }
  ]
}

const list: OrderList[] = [
  {
    item: {
      id: 1,
      accountId: "2",
      account: Juju,
      productId: 1,
      product: Chaise,
      quantity: 1,
      deliveryOpt: "TAKEOUT",
      currentState: "ONGOING"
    }
  },
  {
    item: {
      id: 2,
      accountId: "2",
      account: Juju,
      productId: 1,
      product: Chaise,
      quantity: 1,
      deliveryOpt: "TAKEOUT",
      currentState: "ONGOING"
    }
  },
  {
    item: {
      id: 3,
      accountId: "3",
      account: Jaja,
      productId: 1,
      product: Chaise,
      quantity: 2,
      deliveryOpt: "DELIVERY",
      currentState: "ONGOING"
    }
  }
]

const CraftsmanDashboard: FC = () => {
  const [orderList, setOrderList] = useState<OrderList[]>(list);
  const [clientList, setClientList] = useState<Account[]>([]);
  const customOrderApi: CustomOrderApi = useApi(CustomOrderApi);

  useEffect(() => {
    // customOrderApi.apiCustomOrderListGet().then(setOrderList)
    const temp: Account[] = [];
    orderList.forEach((order) => {
      if (!temp.includes(order.item!.account))
        temp.push(order.item!.account)
    });
    setClientList(temp)
  }, []);

  const accordionHeader = (name: string, total: number, percentage: number) => (
    <HeaderWrapper>
      <ClientName>{name}</ClientName>
      <HeaderRight>Total: {total} €</HeaderRight>
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
          {`${basketItem.product.price * basketItem.quantity} €`}
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
    // eslint-disable-next-line react/jsx-no-undef
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
            "item.currentState": state
          }
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
  orders.filter((order) => order.item!.currentState === "END").length

export default CraftsmanDashboard;
