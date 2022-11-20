import React from "react";
import { BreadCrumb as PRBreadCrumb } from "primereact/breadcrumb";
import { MenuItemProps } from "components/MenuItem";
import _ from "lodash/fp";
import { useLocation } from "react-router-dom";
import { TFunction } from "i18next";
import { useTranslation } from "react-i18next";
import { BreadcrumbWrapper } from "./styles";

interface Props {
  children?:
    | React.ReactElement<MenuItemProps>
    | Array<React.ReactElement<MenuItemProps>>;
  home: React.ReactElement<MenuItemProps>;
  noBorder?: boolean;
}

interface RouteModel {
  label: string;
  url: string;
  parents?: RouteModel[];
  icon?: string;
}

const home = (t: TFunction): RouteModel => ({
  label: t("menu.home"),
  icon: "pi pi-home",
  url: "/",
});

const games = (t: TFunction): RouteModel => ({
  label: t("menu.games"),
  url: "/games",
  parents: [],
});

const game = (t: TFunction): RouteModel => {
  const id = useLocation().pathname.split("/")[2];

  return {
    label: t("menu.game"),
    url: `/game/${id}`,
    parents: [games(t)],
  };
};

const parameters = (t: TFunction): RouteModel => ({
  label: t("menu.parameters"),
  url: "/parameters",
  parents: [],
});

const routes = (t: TFunction): RouteModel[] => [
  home(t),
  games(t),
  game(t),
  parameters(t),
];

const Breadcrumb: React.FunctionComponent<Props> = ({ noBorder }) => {
  const { t } = useTranslation();
  const location = useLocation();

  return (
    <BreadcrumbWrapper noBorder={noBorder || false}>
      <PRBreadCrumb
        model={breadcrumbModelFromCurrentPath(t, location.pathname)}
        home={home(t)}
      />
    </BreadcrumbWrapper>
  );
};

const breadcrumbModelFromCurrentPath = (
  t: TFunction,
  currentPath: string
): RouteModel[] => {
  const current = retrieveCurrentPathRouteModel(t, currentPath);

  return _.concat(retrieveCurrentModelParents(current))(current);
};

const retrieveCurrentPathRouteModel = (
  t: TFunction,
  currentPath: string
): RouteModel =>
  _.flow(
    _.find({ url: currentPath }),
    _.defaultTo([home(t)])
  )(routes(t)) as RouteModel;

const retrieveCurrentModelParents = (current: RouteModel): RouteModel[] =>
  _.flow(_.property("parents"), _.defaultTo([]))(current) as RouteModel[];

export default Breadcrumb;
