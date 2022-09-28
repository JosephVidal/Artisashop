import React, { FC } from "react";
import { Player } from "models/players";
import ChooseTeam from "components/ChooseTeam";
import TextEditable from "components/TextEditable";
import Option from "components/Select/Option";
import Select from "components/Select";
import {
  DeletePlayer,
  PlayerComputer,
  PlayerDetailsWrapper,
  PlayerName,
  PlayerSkin,
} from "pages/CreateGame/components/PlayerDetails/styles";
import { useTranslation } from "react-i18next";
import { Maybe } from "monet";
import { FieldError } from "models/gameCreation";

interface Props {
  player: Player;
  playerMinAmount: string;
  currentPlayerAmount: number;
  onChangeTeam: (team: string) => void;
  onChangeName: (name: string) => void;
  onChangeSkin: (skin: string) => void;
  onDeletePlayer: (event: any) => any;
  fieldError: Maybe<FieldError>;
  errors: FieldError[];
}

const PlayerDetails: FC<Props> = (props: Props) => {
  const {
    player,
    playerMinAmount,
    currentPlayerAmount,
    onChangeTeam,
    onChangeName,
    onChangeSkin,
    onDeletePlayer,
  } = props;
  const { t } = useTranslation();

  return (
    <PlayerDetailsWrapper>
      <DeletePlayer
        visible={Number(playerMinAmount) !== currentPlayerAmount}
        onClick={onDeletePlayer}
      />

      <ChooseTeam value={player.team} onChangeTeam={onChangeTeam} />

      <PlayerName>
        <TextEditable
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
    </PlayerDetailsWrapper>
  );
};

export default PlayerDetails;
