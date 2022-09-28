import React, { FC } from "react";
import { useTranslation } from "react-i18next";
import {
  ScoreTableWrapper,
  TeamsSeparator,
} from "pages/Game/GameOver/components/ScoreTable/styles";
import { GamePlayer, PlayerStat, Team } from "models/game";
import _ from "lodash/fp";
import Table from "components/Table";
import { Maybe } from "monet";
import Column from "components/Table/Column";

interface Props {
  teams: Team[];
}

const ScoreTable: FC<Props> = ({ teams }) => {
  const { t } = useTranslation();

  return (
    <ScoreTableWrapper>
      <Table
        data={getPlayersToDisplay(teams, getPlayersPositions(teams))}
        groupBy="team.color"
        sortBy="team.score"
        /* eslint-disable-next-line react/no-unstable-nested-components */
        groupHeaderDisplay={(data) => (
          <TeamsSeparator color={data.team.color} />
        )}
      >
        <Column
          field="position"
          header={t("game.finished.table.position")}
          align="center"
        />
        <Column
          field="name"
          header={t("game.finished.table.name")}
          align="center"
        />
        <Column
          field="score"
          header={t("game.finished.table.scores")}
          align="center"
        />
        <Column
          field="deaths"
          header={t("game.finished.table.deaths")}
          align="center"
        />
        <Column
          field="accuracy"
          header={t("game.finished.table.accuracy")}
          align="center"
        />
      </Table>
    </ScoreTableWrapper>
  );
};

interface PlayerToDisplay {
  id: string;
  team: Team;
  position?: number;
  name: string;
  score: number;
  deaths: number;
  accuracy?: string;
}

const getPlayersToDisplay = (
  teams: Team[],
  positions: PlayersPositions
): PlayerToDisplay[] =>
  teams
    .flatMap((team) =>
      team.players.map((player) => ({
        id: player.id,
        team,
        position: positions[player.id],
        name: player.name,
        score: player.score,
        deaths: player.deaths,
        accuracy: getPlayerAccuracy(player),
      }))
    )
    .sort((p1, p2) => p1.position - p2.position);

const getPlayerAccuracy = (player: GamePlayer): string =>
  Maybe.fromNull(_.find<PlayerStat>(["key", "accuracy"])(player.stats))
    .map((stat: PlayerStat) => stat.value.toString() + stat.unit)
    .getOrElse("0");

type PlayersPositions = { [key: string]: number };

const getPlayersPositions = (teams: Team[]): PlayersPositions =>
  _.flow([
    _.flatMap((team: Team) => team.players),
    _.concat([]),
    _.orderBy(["score", "deaths"], ["desc", "asc"]),
    (players: GamePlayer[]) =>
      players.map((player, position) => [player.id, position + 1]),
    _.fromPairs,
  ])(teams) as PlayersPositions;

export default ScoreTable;
