import styled from "styled-components";

interface TeamColorProps {
  teamColor: string;
}

export const GameOverWrapper = styled.div`
  width: 100%;
`;

export const DateWrapper = styled.div`
  position: absolute;
  top: 10px;
  right: 64px;
`;

export const DisplayFinalScore = styled.div<TeamColorProps>`
  color: ${(props) => props.teamColor};
  text-align: center;
  font-size: 50px;
  margin-top: -4.5%;
  margin-bottom: 50px;

  div {
    font-size: 100px;
    height: 55%;
  }

  & > div > div:nth-child(2) {
    margin-left: 5px;
    margin-right: 4px;
  }
`;
