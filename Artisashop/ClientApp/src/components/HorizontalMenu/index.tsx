import React, { ReactNode } from "react";
import { Menubar } from "primereact/menubar";
import { MenuItemProps, menuModelsFromChildren } from "components/MenuItem";
import { HorizontalMenuWrapper } from "./styles";

interface Props {
  children?:
    | React.ReactElement<MenuItemProps>
    | Array<React.ReactElement<MenuItemProps>>;
  noBorder?: boolean;
  start?: ReactNode;
  end?: ReactNode;
}

const HorizontalMenu: React.FunctionComponent<Props> = (props) => {
  const { noBorder, start, end, children } = props;

  const menuModels = children && menuModelsFromChildren(children);

  return (
    <HorizontalMenuWrapper noBorder={noBorder || false}>
      <Menubar model={menuModels} start={start as any} end={end as any} />
    </HorizontalMenuWrapper>
  );
};

export default HorizontalMenu;
