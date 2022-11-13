import React from "react";
import { MenuItem as MenuItemModel } from "primereact/menuitem";

export interface MenuItemProps {
  label?: string;
  icon?: string;
  url?: string;
  disabled?: boolean;
  separator?: boolean;
  className?: string;
  active?: boolean;
  onClick?: () => void;
  children?:
    | React.ReactElement<MenuItemProps>
    | Array<React.ReactElement<MenuItemProps>>;
}

const MenuItem: React.FunctionComponent<MenuItemProps> = ({ children }) => (
  /* eslint-disable-next-line react/jsx-no-useless-fragment */
  <>{children}</>
);

export default MenuItem;

export const menuModelsFromChildren = (
  children:
    | React.ReactElement<MenuItemProps>
    | Array<React.ReactElement<MenuItemProps>>
): Array<MenuItemModel> =>
  menuItemsFromChildren(children).map(menuItemElementToMenuModel);

export const menuItemsFromChildren = (
  children:
    | React.ReactElement<MenuItemProps>
    | Array<React.ReactElement<MenuItemProps>>
): Array<any> => (Array.isArray(children) ? children : [children]);

export const menuItemElementToMenuModel = (node: {
  props: MenuItemProps;
}): MenuItemModel => ({
  label: node.props.label,
  icon: node.props.icon,
  command: node.props.onClick,
  disabled: node.props.disabled,
  url: node.props.url,
  className: menuItemClassnames(node.props),
  items:
    node.props.children &&
    menuItemsFromChildren(node.props.children).map(menuItemElementToMenuModel),
});

export const menuItemClassnames = (props: MenuItemProps): string =>
  (props.className || "") +
  (!props.children ? " no-children" : "") +
  (props.active ? " active" : "");
