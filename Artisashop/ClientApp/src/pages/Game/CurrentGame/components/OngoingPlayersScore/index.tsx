import { GamePlayer } from "models/game";
import React, { FC } from "react";
import _ from "lodash/fp";
import { useTranslation } from "react-i18next";
import {
  OngoingPlayersScoreWrapper,
  ScoreLine,
  Left,
  Middle,
  Right,
  Text,
  Value,
} from "pages/Game/CurrentGame/components/OngoingPlayersScore/styles";

interface Props {
  player: GamePlayer;
}

const OngoingPlayersScore: FC<Props> = ({ player }) => {
  const accuracy = _.find(["key", "accuracy"], player.stats);
  const distance = _.find(["key", "distance"], player.stats);
  const { t } = useTranslation();

  return (
    <OngoingPlayersScoreWrapper>
      <ScoreLine>
        <Left>
          <Text>{t("game.current.score")}</Text>
          <Value>{player.score}</Value>
        </Left>

        <Middle />

        <Right>
          <Text>{t("game.current.accuracy")}</Text>
          <Value>
            {accuracy?.value}
            {accuracy?.unit}
          </Value>
        </Right>
      </ScoreLine>

      <ScoreLine>
        <Left>
          <Text>{t("game.current.deaths")}</Text>
          <Value>{player.deaths}</Value>
        </Left>

        <Middle />

        <Right>
          <Text>{t("game.current.distance")}</Text>
          <Value>
            {distance?.value}
            {distance?.unit}
          </Value>
        </Right>
      </ScoreLine>
    </OngoingPlayersScoreWrapper>
  );
};

export default OngoingPlayersScore;
