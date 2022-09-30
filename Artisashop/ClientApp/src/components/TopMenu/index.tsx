import React from "react";
import { BaseText } from "globals/styles";
import { Image } from "primereact/image";
import { BsCart, BsChat, BsPersonFill } from "react-icons/bs";
import { Quarter, TopMenuWrapper, MenuItem, RightIcons } from "./styles";
import Logo from "../Logo/assets/LogoOvale.png";

interface Props {}
//
// const MenuItemCornerRight = styled(MenuItem)`
//   position: absolute;
//   right: 0;
// `;
//
// const MenuItemCornerLeft = styled(MenuItem)`
//   position: absolute;
//   left: 50px;
// `;

const TopMenu: React.FunctionComponent<Props> = () => (
  <TopMenuWrapper>
    <Quarter />
    <MenuItem>
      <BaseText onClick={() => console.log("Recherche")}>Recherche</BaseText>
    </MenuItem>
    <Image src={Logo} width="50px" />
    <MenuItem>
      <BaseText onClick={() => console.log("Contact")}>Contact</BaseText>
    </MenuItem>
    <RightIcons>
      <BsCart size="100%" onClick={() => console.log("Cart")} />
      <BsChat size="100%" onClick={() => console.log("Chat")} />
      <BsPersonFill size="100%" onClick={() => console.log("Account")} />
    </RightIcons>
  </TopMenuWrapper>
);

export default TopMenu;
