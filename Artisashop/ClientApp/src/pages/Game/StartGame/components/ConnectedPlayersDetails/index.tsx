import React, { FC } from "react";
import { Maybe } from "monet";
import EquipmentState from "components/EquipmentState";
import {
  ConnectedPlayersDetailsWrapper,
  DeletePlayer,
  PlayerComputer,
  PlayerName,
  PlayerSkin,
} from "pages/Game/StartGame/components/ConnectedPlayersDetails/styles";
import ChooseTeam from "components/ChooseTeam";
import TextEditable from "components/TextEditable";
import { EquipmentState as EquipmentStateModel } from "models/equipment";
import { BatteriesInfos } from "models/battery";
import Select from "components/Select";
import Option from "components/Select/Option";
import { FieldError } from "models/gameCreation";
import { useTranslation } from "react-i18next";
import { Player } from "models/players";

interface Props {
  player: Player;
  playerMinAmount: string;
  maxPlayer?: number;
  currentPlayerAmount: number;
  onChangeTeam: (team: string) => void;
  onChangeName: (name: string) => void;
  onChangeSkin: (skin: string) => void;
  onDeletePlayer: (event: any) => any;
  equipmentState?: EquipmentStateModel;
  equipmentBattery?: BatteriesInfos;
  fieldError: Maybe<FieldError>;
  errors: FieldError[];
}

const ConnectedPlayersDetails: FC<Props> = (props: Props) => {
  const {
    player,
    playerMinAmount,
    currentPlayerAmount,
    onChangeTeam,
    onChangeName,
    onChangeSkin,
    onDeletePlayer,
    equipmentState,
    equipmentBattery,
  } = props;

  const { t } = useTranslation();

  return (
    <ConnectedPlayersDetailsWrapper>
      <DeletePlayer
        visible={Number(playerMinAmount) !== currentPlayerAmount}
        onClick={onDeletePlayer}
      />

      <EquipmentState
        size="small"
        equipmentBattery={Maybe.fromNull(equipmentBattery)}
        headsetConnected={equipmentState?.headsetConnected || false}
      />

      <ChooseTeam value={player.team} onChangeTeam={onChangeTeam} />

      <PlayerName>
        <TextEditable
          key={player.name}
          value={player.name}
          onValidateValue={onChangeName}
          fieldError={props.fieldError.cata(
            () => undefined,
            (e) => e.message
          )}
        />
      </PlayerName>

      <PlayerSkin>
        <Select
          placeholder={t("game.create.select-skin")}
          value={player.skin}
          onChange={onChangeSkin}
        >
          <Option label="Sam" value="Sam" />
          <Option label="Jack" value="Jack" />
        </Select>
      </PlayerSkin>

      <PlayerComputer>{player.equipment}</PlayerComputer>
    </ConnectedPlayersDetailsWrapper>
  );
};

export default ConnectedPlayersDetails;
