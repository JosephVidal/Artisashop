import { colors } from "globals/styles";
import styled from "styled-components";

export const ChronometerWrapper = styled.div`
  height: 63px;
  display: flex;
  flex-direction: row;
  align-items: start;
  justify-content: left;
`;

export const Icon = styled.div`
  cursor: pointer;
  margin-left: 10px;
  margin-top: 5px;
  font-size: 35px;
  align-self: start;
`;

export const PlayIcon = styled.div`
  color: ${colors.green};
`;

interface TimeProps {
  paused: boolean;
}

export const Time = styled.div<TimeProps>`
  font-size: 40px;
  text-align: center;
  color: ${(timeProps) => (timeProps.paused ? colors.red : colors.textColor)};
  display: flex;
  flex-direction: column;

  & small {
    font-size: 15px;
    align-self: center;
    visibility: ${(timeProps) => (timeProps.paused ? "visible" : "hidden")};
  }
`;
