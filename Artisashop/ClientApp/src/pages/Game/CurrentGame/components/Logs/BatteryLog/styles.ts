import { colors } from "globals/styles";
import styled from "styled-components";
import { Icon } from "pages/Game/CurrentGame/components/Logs/styles";

export const BatteryLogWrapper = styled.div`
  display: flex;
  align-content: space-between;
  color: ${colors.errorColor};

  & ${Icon} {
    margin-right: 10px;
  }
`;
