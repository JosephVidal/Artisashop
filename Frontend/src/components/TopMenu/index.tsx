import React from "react";
import { Link } from "react-router-dom";
import { useAtom } from "jotai";
import { Image } from "primereact/image";
import { useTranslation } from "react-i18next";
import { BsCart, BsChat, BsPerson } from "react-icons/bs";

import Logo from "assets/LogoOvale.png";
import { BaseText } from "globals/styles";
import userAtom from "states/atoms/user";
import { Quarter, TopMenuWrapper, MenuItem, RightIcons } from "./styles";

interface Props { }
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

const TopMenu: React.FunctionComponent<Props> = () => {
  const { t } = useTranslation();
  const [user] = useAtom(userAtom);

  return (
    <TopMenuWrapper>
      <Quarter />
      <MenuItem>
        <BaseText onClick={() => console.log("Recherche")}>
          {t("menu.search")}
        </BaseText>
      </MenuItem>
      <Link to="/"><Image src={Logo} width="50px" /></Link>
      <MenuItem>
        <BaseText onClick={() => console.log("Contact")}>
          {t("menu.contact")}
        </BaseText>
      </MenuItem>
      <RightIcons>
        {user
          ? (<>
            <Link to="/app/mon-panier"><BsCart size="100%" /></Link>
            <Link to="/app/chat"><BsChat size="100%" /></Link>
            <Link to="/app/profile"><BsPerson size="100%" /></Link>
          </>)
          : (<Link to="/app/login"><BsPerson size="100%" /></Link>
          )
        }
      </RightIcons>
    </TopMenuWrapper>
  );
};

export default TopMenu;
