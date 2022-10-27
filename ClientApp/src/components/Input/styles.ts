import styled from "styled-components";
import { colors } from "globals/styles";

interface InputWrapperProps {
  error?: string | undefined;
}

export const InputWrapper = styled.div<InputWrapperProps>`
  display: flex;
  flex-direction: column;

  & input {
    color: ${(props) => (props.error ? colors.errorColor : colors.textColor)};
    border-color: ${(props) =>
      props.error ? colors.errorColor : colors.beige};
  }

  & .p-inputtext:enabled:focus {
    border-color: ${(props) =>
      props.error ? colors.errorColor : colors.beige};
    box-shadow: ${(props) =>
      props.error ? `0 0 0 1px${colors.errorColor}` : "0 0 0 1px #93cbf9"};
  }

  & small {
    margin-top: 3px;
    color: ${colors.errorColor};
  }
`;
