import styled from "styled-components";
import { colors } from "globals/styles";
import { ButtonWrapper } from "components/Button/styles";

export const LogoWrapper = styled.div`
  position: fixed;
  top: 20px;
  left: 20px;
  width: 90px;
  height: 90px;
`;

export const StepsWrapper = styled.div`
  width: 60%;
  margin-bottom: 50px;

  .p-steps-number {
    border: 1px solid ${colors.surfaceD} !important;
    border-radius: 50% !important;
    background: ${colors.surfaceB} !important;
  }

  .p-steps-current {
    .p-steps-number {
      background: ${colors.surfaceD} !important;
    }
  }
`;

export const ButtonsWrapper = styled.div`
  display: flex;
  flex-direction: row;
  align-self: center;

  ${ButtonWrapper} {
    margin: 20px 10px 0 10px;
  }
`;
