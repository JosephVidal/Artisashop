import styled from "styled-components";
import { colors } from "globals/styles";

export const SeparatorWrapper = styled.div`
  width: 60%;
  height: 1px;
  margin: 10px auto;
  opacity: 0.4;

  .p-divider {
    color: ${colors.surfaceD};

    &::before {
      border-width: 1px;
    }
  }
`;
