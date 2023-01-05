import React from "react";
import { Link } from "react-router-dom";
import { useAtom } from "jotai";
import { Image } from "primereact/image";
import { useTranslation } from "react-i18next";
import { BsCart, BsChat, BsPerson } from "react-icons/bs";
import Logo from "assets/LogoOvale.png";
import userAtom from "states/atoms/user";
import { TopMenuWrapper, MenuItem, RightIcons } from "./styles";

interface Props { }

const TopMenu: React.FunctionComponent<Props> = () => {
  const { t } = useTranslation();
  const [user] = useAtom(userAtom);

  return (
    <TopMenuWrapper>
      <MenuItem>
        {
          (user && user?.roles?.includes("SELLER")) &&
          <Link to="/dashboard">
            {t("menu.dashboard")}
          </Link>
        }
      </MenuItem>
      <MenuItem>
        <Link to="/about/craftsmans">
          Les artisans
        </Link>
      </MenuItem>
      <Link to="/"><Image src={Logo} width="50px" /></Link>
      <MenuItem>
        <Link to="/about/products">
          Les créations
        </Link>
      </MenuItem>
      <RightIcons>
        {user
          ? (<>
            <Link to="/mon-panier"><BsCart size="100%" /></Link>
            <Link to="/chat"><BsChat size="100%" /></Link>
            <Link to="/profile"><BsPerson size="100%" /></Link>
          </>)
          : (<Link to="/login"><BsPerson size="100%" /></Link>
          )
        }
      </RightIcons>
    </TopMenuWrapper>
  );
};

export default TopMenu;
