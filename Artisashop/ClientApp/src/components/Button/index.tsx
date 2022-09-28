import React, { FC } from "react";
import { Button as PButton } from "primereact/button";
import { colors, teamsColors } from "globals/styles";
import { ButtonWrapper } from "./styles";

interface Props {
  label?: string;
  icon?: string;
  iconPos?: "left" | "right";
  badge?: string;
  type?:
    | "primary"
    | "secondary"
    | "success"
    | "info"
    | "warning"
    | "help"
    | "danger"
    | "plain"
    | "dark";
  size?: "large" | "medium" | "small";
  raised?: boolean;
  outlined?: boolean;
  rounded?: boolean;
  disabled?: boolean;
  expand?: boolean;
  loading?: boolean;
  onClick?: (event: any) => void;
}

const Button: FC<Props> = ({
  label,
  icon,
  iconPos,
  badge,
  type,
  size,
  raised,
  outlined,
  rounded,
  disabled,
  expand,
  loading,
  onClick,
}) => (
  <ButtonWrapper
    expand={expand || false}
    color={getColor(type)}
    hoverColor={getHoverColor(type)}
    size={size}
  >
    <PButton
      label={label}
      icon={icon}
      iconPos={iconPos}
      badge={badge}
      className={buildClassName(size, raised, outlined, rounded)}
      disabled={disabled}
      onClick={onClick}
      loading={loading}
    />
  </ButtonWrapper>
);

const buildClassName = (
  size: "large" | "medium" | "small" | undefined,
  raised: boolean | undefined,
  outlined: boolean | undefined,
  rounded: boolean | undefined
) => {
  const sizeClass =
    (size === "small" ? "p-button-sm" : "") +
    (size === "large" ? "p-button-lg" : "");
  const raisedClass = raised ? "p-button-raised" : "";
  const outlinedClass = outlined ? "p-button-outlined" : "";
  const roundedClass = rounded ? "p-button-rounded" : "";

  return `${sizeClass} ${raisedClass} ${outlinedClass} ${roundedClass}`;
};

const getColor = (
  type:
    | "primary"
    | "secondary"
    | "success"
    | "info"
    | "warning"
    | "help"
    | "danger"
    | "plain"
    | "dark"
    | undefined
) => {
  switch (type) {
    case "secondary":
      return colors.surfaceD;
    case "success":
      return colors.successColor;
    case "danger":
      return colors.red;
    case "warning":
      return teamsColors.orange;
    case "info":
      return teamsColors.yellow;
    case "help":
      return teamsColors.purple;
    case "dark":
      return colors.surfaceC;
    default:
      return colors.primaryColor;
  }
};

const getHoverColor = (
  type:
    | "primary"
    | "secondary"
    | "success"
    | "info"
    | "warning"
    | "help"
    | "danger"
    | "plain"
    | "dark"
    | undefined
) => {
  switch (type) {
    case "secondary":
      return "#223045";
    case "success":
      return "#50833a";
    case "danger":
      return "#942121";
    case "warning":
      return "#b26400";
    case "info":
      return "#b19600";
    case "help":
      return "#6d1b7b";
    case "dark":
      return "#182332";
    default:
      return "#00658a";
  }
};

export default Button;
