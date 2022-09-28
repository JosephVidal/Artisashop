import styled from "styled-components";
import { colors } from "globals/styles";

export const OngoingPlayersDetailsWrapper = styled.div`
  width: 100%;
  margin: 12px 0;
  display: flex;
  cursor: pointer;
  align-items: center;
`;

interface TeamIconProps {
  teamcolor: string;
}

export const TeamIcon = styled.div<TeamIconProps>`
  width: 15px;
  height: 15px;
  border-radius: 50%;
  border: none;
  box-shadow: 0 0 8px 0 ${(props) => props.teamcolor};
  background-color: ${(props) => props.teamcolor};
  outline: none;
  padding: 0;
`;

export const PlayerNameWrapper = styled.div`
  flex: 0.6;
`;

export const PlayerName = styled.div`
  text-align: left;
  margin: 0 20px;
`;

export const PlayerBattery = styled.div`
  flex: 0.8;
  display: flex;
  flex-direction: row;
  align-content: center;
  justify-content: center;
`;

interface TextProps {
  color: string;
}

export const Text = styled.div<TextProps>`
  font-size: 15px;
  align-self: center;
  text-align: right;
  color: ${(textProps) => textProps.color};
`;

export const TextLeft = styled.div`
  width: 120px;
  text-align: left;
  color: ${colors.textColorSecondary};
`;

export const TextRight = styled.div`
  font-size: 25px;
  text-align: right;
`;
