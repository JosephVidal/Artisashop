import styled from "styled-components";

export const DayOffFormWrapper = styled.div`
  display: flex;
  height: 100%;
  width: 100%;
  flex-direction: column;
  margin-top: 20px;
`;

export const TitleWrapper = styled.span`
  font-size: 18px;
  flex: 1;
`;

export const CheckBoxWrapper = styled.span`
  display: flex;
  flex-direction: row;
  align-content: space-between;
  align-items: end;
  margin-bottom: 10px;

  .p-checkbox-box {
    height: 16px;
    width: 16px;
    border: none;
  }
`;

export const AllDayText = styled.span`
  font-size: 16px;
  margin-left: 10px;
`;

export const ButtonsWrapper = styled.span`
  align-self: end;
  margin-top: 30px;
  display: flex;
  flex-direction: row;

  & > div:last-child {
    margin-left: 15px;
  }
`;
