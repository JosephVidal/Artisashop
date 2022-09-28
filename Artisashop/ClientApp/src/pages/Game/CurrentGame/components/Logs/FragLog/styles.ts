import styled from "styled-components";
import { Icon } from "pages/Game/CurrentGame/components/Logs/styles";

export const FragLogWrapper = styled.div`
  display: flex;
  align-content: space-between;

  & ${Icon} {
    margin-right: 10px;
  }
`;
