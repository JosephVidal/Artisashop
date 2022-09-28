import styled from "styled-components";
import { colors } from "globals/styles";

interface TextEditableWrapperProps {
  active: boolean;
}

export const TextEditableWrapper = styled.div<TextEditableWrapperProps>`
  width: 100%;
  display: inline-block;

  & .p-inplace-display {
    width: 100%;
    display: inline-block;
    border: 1px solid transparent;

    & small {
      visibility: ${(props) => (props.active ? "hidden" : "visible")};
      color: ${colors.errorColor};
    }
  }
`;
