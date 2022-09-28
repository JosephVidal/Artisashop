import React, { FC } from "react";
import { useTranslation } from "react-i18next";
import Date from "pages/Game/GameOver/components/Date";
import Score from "pages/Game/components/Score";
import { colors, teamColorNameFromHex } from "globals/styles";
import { Game, Team } from "models/game";
import * as _ from "lodash/fp";
import { Maybe, None, Some } from "monet";
import {
  DateWrapper,
  GameOverWrapper,
  DisplayFinalScore,
} from "pages/Game/GameOver/styles";
import ScoreTable from "pages/Game/GameOver/components/ScoreTable";

interface Props {
  currentGame: Game;
}

const GameOver: FC<Props> = ({ currentGame }) => {
  const { teams } = currentGame;
  const winnerTeam = getVictoryTeam(teams);
  const { t } = useTranslation();

  return (
    <GameOverWrapper>
      <DateWrapper>
        <Date beginDate={currentGame.beginDate} endDate={currentGame.endDate} />
      </DateWrapper>

      <DisplayFinalScore teamColor={winnerTeam.getOrElse(colors.textColor)}>
        <Score teams={teams} />

        {winnerTeam.cata(
          () => t("game.finished.tie"),
          (teamColor) =>
            t("game.finished.victory", {
              team: t(`teams.${teamColorNameFromHex(teamColor)}`),
            })
        )}
      </DisplayFinalScore>

      <ScoreTable teams={_.sortBy<Team>("score")(teams)} />
    </GameOverWrapper>
  );
};

const getVictoryTeam = (teams: Team[]): Maybe<string> => {
  const maxScore = _.max<number>(_.map("score")(teams));

  const winningTeams = _.filter<Team>({ score: maxScore })(teams);

  if (winningTeams.length === 1) return Some(winningTeams[0].color);

  return None();
};

export default GameOver;
