import React from "react";
import { useLocation } from "react-router-dom";
import MenuItem from "components/MenuItem";
import HorizontalMenu from "components/HorizontalMenu";
import Breadcrumb from "components/Breadcrumb";
import { useTranslation } from "react-i18next";
import { TopMenuWrapper } from "./styles";

interface Props {}

const TopMenu: React.FunctionComponent<Props> = () => {
  const location = useLocation();
  const { t } = useTranslation();

  return (
    <TopMenuWrapper>
      <HorizontalMenu
        noBorder
        start={
          <Breadcrumb noBorder home={<MenuItem icon="pi pi-home" url="/" />}>
            {location.pathname !== "/" ? (
              <MenuItem
                label={t(`menu.${location.pathname}`)}
                url={location.pathname}
              />
            ) : undefined}
          </Breadcrumb>
        }
      />
    </TopMenuWrapper>
  );
};

export default TopMenu;
