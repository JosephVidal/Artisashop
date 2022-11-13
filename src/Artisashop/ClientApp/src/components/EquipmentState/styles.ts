import styled from "styled-components";

export const EquipmentStateIcons = styled.div<StateIconProps>`
  display: inline-flex;
  flex-direction: row;
  justify-content: center;
  align-items: center;
  margin: 0 20px;
`;

interface EquipmentCapacityProps {
  color: string;
}

export const EquipmentCapacity = styled.span<EquipmentCapacityProps>`
  height: 1em;
  line-height: 1em;
  color: ${(props) => props.color};
`;

interface StateIconProps {
  size: "small" | "large";
}

export const StateIcon = styled.div<StateIconProps>`
  display: flex;
  flex-direction: ${(props) => (props.size === "small" ? "row" : "column")};
  align-items: center;
  justify-content: center;

  & > svg {
    font-size: ${(props) => (props.size === "small" ? "37px" : "85px")};
  }

  & > ${EquipmentCapacity} {
    width: ${(props) => (props.size === "small" ? "30px" : "auto")};
    font-size: ${(props) => (props.size === "small" ? "14px" : "16px")};
    margin-left: ${(props) => (props.size === "small" ? "6px" : "0")};
  }

  &:first-child {
    margin-right: ${(props) => (props.size === "small" ? "6px" : "13px")};
    flex-direction: ${(props) =>
      props.size === "small" ? "row-reverse" : "column"};

    & > ${EquipmentCapacity} {
      text-align: right;
      margin-left: 0;
      margin-right: ${(props) => (props.size === "small" ? "6px" : "0")};
    }
  }
`;
