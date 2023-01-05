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
      <Products />
    </Wrapper>
  )
};

export default CraftsmanDashboard;
