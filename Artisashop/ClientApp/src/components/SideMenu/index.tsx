import Logo from "components/Logo";
import React from "react";
import { useLocation, useNavigate } from "react-router-dom";
import VerticalMenu from "components/VerticalMenu";
import MenuItem from "components/MenuItem";
import { useTranslation } from "react-i18next";
import { SideMenuWrapper } from "./styles";

interface Props {}

const SideMenu: React.FunctionComponent<Props> = () => {
  const location = useLocation();
  const navigate = useNavigate();
  const { t } = useTranslation();

  return (
    <SideMenuWrapper>
      <Logo type="light" withText />

      <VerticalMenu noBorder>
        <MenuItem
          label={t("menu.home")}
          icon="pi pi-home"
          onClick={() => navigate("/")}
          active={location.pathname === "/"}
        />
        <MenuItem
          label={t("menu.games")}
          icon="fa fas fa-gamepad"
          onClick={() => navigate("/games")}
          active={location.pathname === "/games"}
        />
        <MenuItem label={t("menu.parameters.title")} icon="fa fas fa-cog">
          <MenuItem
            label={t("menu.parameters.configuration")}
            icon="fa fas fa-cog"
            onClick={() => navigate("/parameters/configuration")}
            active={location.pathname === "/parameters/configuration"}
          />

          <MenuItem
            label={t("menu.parameters.equipments")}
            icon="fa fas fa-desktop"
            onClick={() => navigate("/parameters/equipments")}
            active={location.pathname === "/parameters/equipments"}
          />

          <MenuItem
            label={t("menu.parameters.opening-hours")}
            icon="fa fas fa-clock"
            onClick={() => navigate("/parameters/openingHours")}
            active={location.pathname === "/parameters/openingHours"}
          />

          <MenuItem
            label={t("menu.parameters.days-off")}
            icon="far fa-calendar-times"
            onClick={() => navigate("/parameters/daysOff")}
            active={location.pathname === "/parameters/daysOff"}
          />
        </MenuItem>
      </VerticalMenu>
    </SideMenuWrapper>
  );
};

export default SideMenu;
