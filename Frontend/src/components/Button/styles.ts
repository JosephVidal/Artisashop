import styled from "styled-components";
import { colors } from "globals/styles";

interface ButtonWrapperProps {
  expand: boolean;
  color: string;
  hoverColor: string;
  size?: "large" | "medium" | "small";
}

export const ButtonWrapper = styled.div<ButtonWrapperProps>`
  ${(props) =>
    props.expand &&
    `
    width: 100%;
  `};

  display: inline-block;

  .p-button {
    width: 100%;
    background-color: ${(props) => props.color};
    color: ${colors.textColor};
    border-color: ${(props) => props.color};
    padding-left: ${(props) => (props.size === "large" ? "25px" : "20px")};
    padding-right: ${(props) => (props.size === "large" ? "25px" : "20px")};
  }

  .p-button:hover {
    background-color: ${(props) => props.hoverColor};
    color: ${colors.textColor};
    border-color: ${(props) => props.hoverColor};
  }

  .p-button-icon {
    position: absolute;
    left: 45%;
    font-size: 40px;
  }
`;
