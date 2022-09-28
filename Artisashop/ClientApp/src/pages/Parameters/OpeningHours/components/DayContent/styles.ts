import styled from "styled-components";

export const DayContentWrapper = styled.div`
  display: flex;
  align-items: baseline;
  min-height: 80px;
  width: 800px;
`;

export const DayTextWrapper = styled.span`
  font-size: 20px;
  flex: 1;
`;

export const DayInputsWrapper = styled.div`
  flex: 3;
`;

export const HoursWrapper = styled.div`
  display: flex;
  align-items: center;
  justify-content: space-between;
  margin-top: 10px;

  &:last-child {
    margin-bottom: 40px;
  }
`;

export const TimeWrapper = styled.div`
  display: flex;
  justify-content: space-evenly;
  align-items: center;
  width: 40%;
`;

export const HourText = styled.span``;

export const TimePickerWrapper = styled.div`
  width: 60%;
  min-height: 50px;
  padding-top: 6px;
`;

export const AddOrRemoveWrapper = styled.span`
  width: 15%;
  display: flex;
  font-size: 30px;
  cursor: pointer;
`;

export const CheckboxWrapper = styled.div`
  display: flex;
  width: 20%;
  padding-left: 20px;
  justify-content: space-between;
  font-size: 20px;

  .p-checkbox {
    margin-bottom: 2px;
  }
`;
