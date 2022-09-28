import styled from "styled-components";
import { colors } from "globals/styles";

export const ScoreWrapper = styled.div`
  width: 100%;
  margin: 12px 0 30px;
  display: flex;
  flex-direction: row;
  align-items: center;
  justify-content: center;
`;

interface TextProps {
  color?: string;
}

export const Text = styled.div<TextProps>`
  font-size: 40px;
  ${(props) =>
    props.color &&
    `
    color: ${props.color};
  `}
`;

export const ScoreSeparator = styled.div<TextProps>`
  color: ${colors.textColor};
  font-size: 40px;
  padding-left: 5px;
  padding-right: 5px;
`;
