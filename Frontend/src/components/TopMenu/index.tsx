import React from "react";
import { Link } from "react-router-dom";
import { useAtom } from "jotai";
import { Image } from "primereact/image";
import { useTranslation } from "react-i18next";
import { BsCart, BsChat, BsPerson } from "react-icons/bs";

import Logo from "assets/LogoOvale.png";
import userAtom from "states/atoms/user";
import { BaseText } from "globals/styles";
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
      <MenuItem>
        <Link to="/app/dashboard">
          {t("menu.dashboard")}
        </Link>
      </MenuItem>
      <MenuItem>
        <Link to="/app/about/craftsmans">
          Les artisans
        </Link>
      </MenuItem>
      <Link to="/"><Image src={Logo} width="50px" /></Link>
      <MenuItem>
        <Link to="/app/about/products">
          Les créations
        </Link>
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
