import styled from "styled-components";

export const CalendarWrapper = styled.div`
  display: flex;
  align-items: center;

  .p-inputtext {
    visibility: hidden;
    position: absolute;
    top: -12px;
    left: -127px;
    width: 450px;
  }
`;

export const DateText = styled.div`
  margin-right: 10px;
`;

export const DateAndIconWrapper = styled.div`
  display: flex;
  align-items: center;
  cursor: pointer;
  font-size: 30px;
  padding-bottom: 5px;
`;
