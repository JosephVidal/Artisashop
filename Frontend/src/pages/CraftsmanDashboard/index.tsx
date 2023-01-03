import React, { FC, useState } from "react";
import Orders from "pages/CraftsmanDashboard/Orders";
import Products from "pages/CraftsmanDashboard/Products";
import {
  Wrapper,
  TabWrapper,
  TabButton,
} from "./styles";

const CraftsmanDashboard: FC = () => {
  const [selected, setSelected] = useState<"products" | "orders">("products");

  return (
    <Wrapper>
      <TabWrapper>
        <TabButton
          selected={selected === "products"}
          onClick={() => setSelected("products")}>
          Produits
        </TabButton>
        <TabButton
          selected={selected === "orders"}
          onClick={() => setSelected("orders")}>
          Commandes
        </TabButton>
      </TabWrapper>
      {
        selected === "products" ?
          <Products /> :
          <Orders />
      }
    </Wrapper>
  )
};

export default CraftsmanDashboard;
