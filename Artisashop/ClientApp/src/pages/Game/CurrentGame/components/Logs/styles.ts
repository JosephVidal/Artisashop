import styled from "styled-components";
import { colors } from "globals/styles";

export const LogCard = styled.div`
  & .p-card {
    height: 500px;
    width: 755px;
    background: ${colors.darkBlue};
  }

  & .p-card .p-card-body {
    height: 500px;
    padding: 2rem;
  }

  & .p-card .p-card-content {
    height: 438px;
    padding: 0;
  }

  & .p-scrollpanel {
    height: inherit;
  }
`;

interface OrderArrowsProps {
  lastTop: boolean;
}

export const OrderArrows = styled.div<OrderArrowsProps>`
  height: 30px;
  display: flex;
  flex-direction: row-reverse;
  align-content: space-between;

  & .arrowDown {
    font-size: ${(props) => (props.lastTop ? "20px" : "30px")};
  }

  & .arrowUp {
    font-size: ${(props) => (props.lastTop ? "30px" : "20px")};
  }
`;

export const Icon = styled.div`
  font-size: 20px;
  align-self: center;
`;

export const LogText = styled.div`
  align-self: center;
`;
