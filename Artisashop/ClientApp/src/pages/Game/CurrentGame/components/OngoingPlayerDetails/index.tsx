import { GamePlayer } from "models/game";
import React, { FC } from "react";
import { Maybe } from "monet";
import { EquipmentState as EquipmentStateModel } from "models/equipment";
import { BatteriesInfos } from "models/battery";
import EquipmentState from "components/EquipmentState";
import { PlayerComputer } from "pages/CreateGame/components/PlayerDetails/styles";
import {
  OngoingPlayersDetailsWrapper,
  PlayerBattery,
  PlayerName,
  PlayerNameWrapper,
  TeamIcon,
} from "pages/Game/CurrentGame/components/OngoingPlayerDetails/styles";

interface Props {
  player: GamePlayer;
  teamColor: string;
  equipmentState?: EquipmentStateModel;
  equipmentBattery?: BatteriesInfos;
}

const OngoingPlayersDetails: FC<Props> = ({
  player,
  teamColor,
  equipmentState,
  equipmentBattery,
}) => (
  <OngoingPlayersDetailsWrapper>
    <TeamIcon teamcolor={teamColor} />

    <PlayerNameWrapper>
      <PlayerName>{player.name}</PlayerName>
    </PlayerNameWrapper>

    <PlayerBattery>
      <EquipmentState
        size="small"
        withPercentage
        equipmentBattery={Maybe.fromNull(equipmentBattery)}
        headsetConnected={equipmentState?.headsetConnected || false}
      />
    </PlayerBattery>

    <PlayerComputer>{player.equipmentLetter}</PlayerComputer>
  </OngoingPlayersDetailsWrapper>
);

export default OngoingPlayersDetails;
