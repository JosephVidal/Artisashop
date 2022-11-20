import { colors } from "globals/styles";
import styled from "styled-components";

interface LoaderWrapperProps {
  visible: boolean;
}

export const LoaderWrapper = styled.div<LoaderWrapperProps>`
  ${(props) =>
    props.visible &&
    `
    display: flex;
  `}

  ${(props) =>
    !props.visible &&
    `
    display: none;
  `}

  z-index: 1000;
  position: relative;

  @keyframes p-progress-spinner-color {
    100%,
    0% {
      stroke: ${colors.textColor};
    }
  }

  .p-progress-spinner {
    width: 40px;
    height: 40px;
  }
`;
