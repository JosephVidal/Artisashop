import React from "react";
import { Image } from "primereact/image";
import styled from "styled-components";
import { TopMenuWrapper, MenuItem } from "./styles";
import Logo from "../Logo/assets/LogoOvale.png";

interface Props {}

const MenuItemCornerRight = styled(MenuItem)`
  position: absolute;
  right: 0;
`;

const MenuItemCornerLeft = styled(MenuItem)`
  position: absolute;
  left: 50px;
`;

const TopMenu: React.FunctionComponent<Props> = () => (
  <TopMenuWrapper>
    <MenuItemCornerLeft onClick={() => console.log("Recherche")}>
      Recherche
    </MenuItemCornerLeft>
    <MenuItem onClick={() => console.log("Recherche")}>Recherche</MenuItem>
    <Image src={Logo} width="50px" />
    <MenuItem onClick={() => console.log("Contact")}>Contact</MenuItem>
    <MenuItemCornerRight onClick={() => console.log("Contact")}>
      Contact
    </MenuItemCornerRight>
  </TopMenuWrapper>
);

export default TopMenu;
