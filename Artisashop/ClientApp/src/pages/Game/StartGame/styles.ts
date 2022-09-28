import styled from "styled-components";
import { colors } from "globals/styles";

export const StartGameWrapper = styled.div`
  width: 100%;
  z-index: 1;
  display: flex;
  flex-direction: column;
  justify-content: start;
  align-items: center;

  & .bzKUuO {
    background: ${colors.surfaceD};
    color: ${colors.textColor};
  }

  & .p-disabled,
  .p-component:disabled {
    background: ${colors.surfaceA};
    border-color: ${colors.surfaceA};
  }
`;

export const ConnectedPlayersScrollWrapper = styled.div`
  width: 60%;
  height: 450px;

  & .p-scrollpanel-wrapper {
    height: 450px;
  }

  & .p-scrollpanel-content {
    padding-top: 18px;
  }
`;
