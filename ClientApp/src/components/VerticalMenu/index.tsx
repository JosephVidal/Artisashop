import React from "react";
import { PanelMenu } from "primereact/panelmenu";
import { MenuItemProps, menuModelsFromChildren } from "components/MenuItem";
import { VerticalMenuWrapper } from "./styles";

interface Props {
  children:
    | React.ReactElement<MenuItemProps>
    | Array<React.ReactElement<MenuItemProps>>;
  noBorder?: boolean;
}

const VerticalMenu: React.FunctionComponent<Props> = (props) => {
  const { noBorder, children } = props;
  const menuModels = menuModelsFromChildren(children);

  return (
    <VerticalMenuWrapper noBorder={noBorder || false}>
      <PanelMenu model={menuModels} />
    </VerticalMenuWrapper>
  );
};

export default VerticalMenu;
