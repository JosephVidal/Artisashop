import styled from "styled-components";

export const CalendarWrapper = styled.div`
  margin: -20px auto 30px auto;
  display: flex;
  justify-content: space-between;
  align-items: center;
  width: 25%;

  & span {
    font-size: 40px;
  }
`;

export const Arrow = styled.span`
  cursor: pointer;
`;
