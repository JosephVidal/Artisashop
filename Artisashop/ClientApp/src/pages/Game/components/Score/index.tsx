import React, { FC } from "react";
import { Team } from "models/game";
import * as _ from "lodash/fp";
import { ScoreWrapper, Text, ScoreSeparator } from "./styles";

interface Props {
  teams: Team[];
}

const Score: FC<Props> = ({ teams }) => (
  <ScoreWrapper>
    {_.sortBy<Team>("scores")(teams).map((team, index) => (
      <React.Fragment key={index.toString()}>
        <Text color={team.color}>{team.score}</Text>
        {teams[index + 1] !== undefined && <ScoreSeparator>-</ScoreSeparator>}
      </React.Fragment>
    ))}
  </ScoreWrapper>
);

export default Score;
