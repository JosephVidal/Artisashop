import styled from "styled-components";

export const OngoingPlayersScoreWrapper = styled.div`
  width: 100%;
  margin: 5px 0;
  display: flex;
  flex-direction: column;
  align-items: center;
  justify-content: space-between;
`;

export const ScoreLine = styled.div`
  width: 100%;
  margin: 5px 0;
  display: flex;
  align-items: center;
  flex-direction: row;
`;

export const Left = styled.div`
  display: flex;
  align-items: center;
  text-align: left;
  flex: 0.5;
`;

export const Middle = styled.div`
  flex: 1;
`;

export const Right = styled.div`
  display: flex;
  align-items: center;
  text-align: right;
  flex: 1;
`;

export const Text = styled.div`
  text-align: left;
  flex: 2;
`;

export const Value = styled.div`
  text-align: right;
`;
