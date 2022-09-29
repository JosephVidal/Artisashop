import React, { FC, useEffect, useState } from "react";
import _ from "lodash/fp";
import { ToastHandler } from "components/Toaster";
import { FieldError, PlayerCreation, TeamCreation } from "models/gameCreation";
import { Player } from "models/players";
import { SetState } from "globals/state";
import Separator from "components/Separator";
import Button from "components/Button";
import Duration from "pages/CreateGame/components/Duration";
import PlayerNumber from "pages/CreateGame/components/PlayerNumber";
import PlayerDetails from "pages/CreateGame/components/PlayerDetails";
import { SubmitButtonWrapper } from "pages/Game/styles";
import { sendCreatedGame } from "pages/Game/api";
import { useTranslation } from "react-i18next";
import { retrieveConfigParameter } from "configurations";
import { useNavigate, useParams } from "react-router-dom";
import { Equipment } from "models/equipment";
import { Maybe, None } from "monet";
import { handleErrors } from "globals/error";
import Content from "components/Content";
import { colors } from "globals/styles";
import { TFunction } from "i18next";
import { NavigateFunction } from "react-router";
import { retrieveEquipments } from "equipments";

interface Props {
  toastHandler: ToastHandler;
}

const CreateGame: FC<Props> = ({ toastHandler }) => {
  const [players, setPlayers] = useState<Player[]>([]);
  const [playerNumber, setPlayerNumber] = useState<number>(2);
  const [loading, setLoading] = useState<boolean>(true);
  const [equipments, setEquipments] = useState<Equipment[]>([]);
  const [fieldsErrors, setFieldErrors] = useState<FieldError[]>([]);

  const [duration, setDuration] = useState<string>("10");

  const navigate: NavigateFunction = useNavigate();
  const { t } = useTranslation();

  const { beginDate } = useParams();

  // @ts-ignore: React router useParams() typing possibly return undefined
  const paramsBeginDate = beginDate.split("-").map((str) => Number(str));

  const startDate = new Date(
    paramsBeginDate[0],
    paramsBeginDate[1] - 1,
    paramsBeginDate[2],
    paramsBeginDate[3],
    paramsBeginDate[4]
  );

  useEffect(() => {
    retrieveEquipments(toastHandler, equipments, setEquipments)
      .then(makePlayersArray(setPlayers, playerNumber, players))
      .then(setLoading);
  }, [playerNumber]);

  useEffect(() => {
    retrieveConfigParameter(
      toastHandler,
      "default-duration",
      duration,
      setDuration
    );
  }, []);

  return (
    <Content title={t("game.create.title")} loading={loading}>
      <Duration
        value={Number(duration)}
        onChange={(d) => d && setDuration(String(d))}
        fieldError={Maybe.fromNull(
          _.find<FieldError>({ field: "duration" }, fieldsErrors)
        )}
      />

      <Separator />

      <PlayerNumber
        value={playerNumber}
        maxPlayers={_.compact(equipments.map((eL) => eL.activated)).length}
        onChange={(amount: number) => amount && setPlayerNumber(amount)}
      />

      {players &&
        players.map((player) => (
          <PlayerDetails
            key={player.id}
            player={player}
            playerMinAmount="2"
            currentPlayerAmount={playerNumber}
            onChangeTeam={onChangeTeam(setPlayers, player)}
            onChangeName={onChangeName(setPlayers, player)}
            onChangeSkin={onChangeSkin(setPlayers, player)}
            onDeletePlayer={onDeletePlayer(setPlayers, setPlayerNumber, player)}
            fieldError={
              !player.name || player.name === ""
                ? Maybe.fromNull(
                    _.find<FieldError>(
                      (err) => _.contains(".name", err.field),
                      fieldsErrors
                    )
                  )
                : None()
            }
            errors={fieldsErrors}
          />
        ))}

      <SubmitButtonWrapper>
        <Button
          label={t("game.create.submit-label")}
          type="primary"
          size="large"
          onClick={onCreateGame(
            players,
            startDate.getTime() / 1000,
            Number(duration),
            toastHandler,
            navigate,
            t,
            setFieldErrors
          )}
          expand
        />
      </SubmitButtonWrapper>
    </Content>
  );
};

const makePlayersArray =
  (setPlayers: SetState<Player[]>, playerAmount: number, players: Player[]) =>
  (equipments: Equipment[]): boolean => {
    if (equipments.length <= 0) return true;

    setPlayers(
      _.flow([
        _.take(playerAmount),
        appendNewPlayers(playerAmount, equipments),
      ])(players) as Player[]
    );

    return false;
  };

const appendNewPlayers =
  (playerAmount: number, equipments: Equipment[]) =>
  (currentPlayers: Player[]) => {
    if (playerAmount <= currentPlayers.length) return currentPlayers;

    const lettersUsed = currentPlayers.map((p) => p.equipment);
    const activatedEquipments = _.filter((eL: Equipment) => eL.activated)(
      equipments
    );
    const availableLetters = _.difference(
      activatedEquipments.map((eL) => eL.letter)
    )(lettersUsed);

    return _.concat(currentPlayers)(
      _.range(0, playerAmount - currentPlayers.length).map((index) =>
        makeNewPlayer(
          activatedEquipments
            .map((eL) => eL.letter)
            .indexOf(availableLetters[index])
            .toString(),
          availableLetters[index]
        )
      )
    );
  };

const makeNewPlayer = (id: string, equipment: string): Player => ({
  id,
  name: `Player ${parseInt(id, 10) + 1}`,
  team: `${parseInt(id, 10) % 2 === 0 ? colors.blue : colors.red}`,
  skin: "Jack",
  equipment,
});

const onChangeTeam =
  (setPlayers: SetState<Player[]>, player: Player) => (team: string) =>
    updatePlayer(setPlayers, {
      ...player,
      team,
    });

const onChangeName =
  (setPlayers: SetState<Player[]>, player: Player) => (name: string) =>
    updatePlayer(setPlayers, {
      ...player,
      name,
    });

const onChangeSkin =
  (setPlayers: SetState<Player[]>, player: Player) => (skin: string) =>
    updatePlayer(setPlayers, {
      ...player,
      skin,
    });

const onDeletePlayer =
  (
    setPlayers: SetState<Player[]>,
    setPlayerAmount: SetState<number>,
    player: Player
  ) =>
  () => {
    setPlayers((prevState) =>
      _.remove<Player>((p) => p.id === player.id)(prevState)
    );

    setPlayerAmount((prevState) => prevState - 1);
  };

const onCreateGame =
  (
    players: Player[],
    beginDate: number,
    duration: number,
    toaster: ToastHandler,
    navigate: NavigateFunction,
    t: TFunction,
    setFieldErrors: SetState<FieldError[]>
  ) =>
  () => {
    const teams: TeamCreation[] = _.flow([
      _.groupBy("team"),
      _.toPairs,
      _.map(makeTeamCreation),
    ])(players);

    sendCreatedGame(beginDate, duration, teams).then((maybeGameOrError) =>
      maybeGameOrError.cata(
        (errors) => handleErrors(toaster, setFieldErrors, t, errors),
        () => {
          /* eslint-disable-next-line @typescript-eslint/no-unsafe-call */ /* react.router typing for NavigateOptions.state is bad */
          navigate("/games", { state: { createdGameDate: beginDate } });
          toaster.showSuccess(t("success.game.create"));
        }
      )
    );
  };

const playerToPlayerCreation = (player: Player): PlayerCreation => ({
  name: player.name,
  skin: player.skin,
  equipmentLetter: player.equipment,
});

const makeTeamCreation = (
  team: [color: string, players: Player[]]
): TeamCreation => ({
  color: team[0],
  players: team[1].map(playerToPlayerCreation),
});

const updatePlayer = (setPlayers: SetState<Player[]>, player: Player) =>
  Promise.resolve(
    setPlayers((prevState) =>
      prevState.map((p: Player) => {
        if (p.id === player.id) return player;

        return p;
      })
    )
  );

export default CreateGame;
