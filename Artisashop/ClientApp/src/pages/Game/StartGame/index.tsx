import React, { Dispatch, FC, useContext, useEffect, useState } from "react";
import { ToastHandler } from "components/Toaster";
import {
  Game as GameModel,
  GamePlayer,
  gamePlayersToPlayers,
  TeamPlayersNumber,
} from "models/game";
import Button from "components/Button";
import { loadGame, startGame } from "pages/Game/api";
import Separator from "components/Separator";
import { SubmitButtonWrapper } from "pages/Game/styles";
import { ScrollPanel } from "primereact/scrollpanel";
import { SetState } from "globals/state";
import { useTranslation } from "react-i18next";
import * as _ from "lodash/fp";
import { Equipment, EquipmentState } from "models/equipment";
import { BatteriesInfos } from "models/battery";
import { StoreContext } from "reducers/utils";
import {
  CurrentGameActions,
  setCurrentGame,
  updateCurrentGame,
} from "reducers/currentGameReducer";
import { Either, Maybe, None } from "monet";
import {
  ConnectedPlayersScrollWrapper,
  StartGameWrapper,
} from "pages/Game/StartGame/styles";
import ConnectedPlayersNumber from "pages/Game/StartGame/components/ConnectedPlayersNumber";
import { fromUnixTime, isSameDay } from "date-fns/fp";
import { Error, handleErrors } from "globals/error";
import { TFunction } from "i18next";
import { Player } from "models/players";
import { FieldError, PlayerCreation, TeamCreation } from "models/gameCreation";
import { retrieveEquipments } from "equipments";
import ConnectedPlayersDetails from "pages/Game/StartGame/components/ConnectedPlayersDetails";

interface Props {
  toastHandler: ToastHandler;
  currentGame: Maybe<GameModel>;
  equipmentsState: EquipmentState[];
  equipmentBattery: BatteriesInfos[];
  onUpdateGame: (
    id: string,
    beginDate: number,
    duration: number,
    teams: TeamCreation[]
  ) => Promise<Either<Error[], GameModel>>;
  game: GameModel;
}

const StartGame: FC<Props> = ({
  toastHandler,
  currentGame,
  equipmentsState,
  equipmentBattery,
  onUpdateGame,
  game,
}) => {
  const [, dispatch] = useContext(StoreContext);
  const [updatedPlayers, setUpdatedPlayers] = useState<Player[]>(
    game.teams.flatMap((team) => gamePlayersToPlayers(team))
  );
  const [playerNumber, setPlayerNumber] = useState<number>(
    updatedPlayers.length
  );
  const [equipments, setEquipments] = useState<Equipment[]>([]);
  const [gameUpdated, setGameUpdated] = useState<boolean>(false);
  const [gameLoaded, setGameLoaded] = useState<boolean>(false);
  const [disabled, setDisabled] = useState<boolean>(false);
  const [fieldsErrors, setFieldErrors] = useState<FieldError[]>([]);
  const { t } = useTranslation();

  useEffect(
    () =>
      currentGame.cata(
        () => setGameLoaded(false),
        (g) => setGameLoaded(g.id === game.id)
      ),
    []
  );

  useEffect(() => {
    retrieveEquipments(toastHandler, equipments, setEquipments).then(
      makePlayersArray(setUpdatedPlayers, playerNumber, updatedPlayers)
    );
  }, [playerNumber]);

  useEffect(() => {
    const gamePlayers = game.teams.flatMap((team) =>
      gamePlayersToPlayers(team)
    );

    const isUpdated: boolean = _.flow([
      _.some((gP: GamePlayer) => !_.some(gP)(updatedPlayers)),
      (playerModified: boolean) =>
        playerModified || gamePlayers.length !== updatedPlayers.length,
    ])(gamePlayers);

    setGameUpdated(isUpdated);
  }, [updatedPlayers]);

  return (
    <StartGameWrapper>
      <ConnectedPlayersNumber
        value={playerNumber}
        connectedPlayers={
          equipmentsState.filter((state) => state.headsetConnected).length
        }
        maxPlayers={_.compact(equipments.map((eL) => eL.activated)).length}
        onChange={(amount: number) => amount && setPlayerNumber(amount)}
      />

      <Separator />

      <ConnectedPlayersScrollWrapper>
        <ScrollPanel>
          {updatedPlayers.map((player) => (
            <ConnectedPlayersDetails
              player={player}
              playerMinAmount="2"
              currentPlayerAmount={updatedPlayers.length}
              onChangeTeam={onChangeTeam(setUpdatedPlayers, player)}
              onChangeName={onChangeName(setUpdatedPlayers, player)}
              onChangeSkin={onChangeSkin(setUpdatedPlayers, player)}
              onDeletePlayer={onDeletePlayer(
                setUpdatedPlayers,
                setPlayerNumber,
                player
              )}
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
              equipmentState={equipmentsState.find(
                (equipment) => equipment.letter === player.equipment
              )}
              equipmentBattery={equipmentBattery?.find(
                (equipment) => equipment.letter === player.equipment
              )}
            />
          ))}
        </ScrollPanel>
      </ConnectedPlayersScrollWrapper>

      <SubmitButtonWrapper>
        {gameUpdated && (
          <Button
            label={disabled ? "" : t("game.start.save.submit-label")}
            type="primary"
            size="large"
            disabled={disabled}
            loading={disabled}
            onClick={() =>
              updateGame(
                onUpdateGame,
                game,
                updatedPlayers,
                gameLoaded,
                setGameUpdated,
                setGameLoaded,
                setDisabled,
                setFieldErrors,
                toastHandler,
                dispatch,
                t
              )
            }
            expand
          />
        )}

        {isSameDay(fromUnixTime(game.beginDate))(new Date()) &&
          !gameUpdated &&
          (!gameLoaded ? (
            <Button
              label={disabled ? "" : t("game.start.load.submit-label")}
              type="primary"
              size="large"
              disabled={disabled}
              loading={disabled}
              onClick={() =>
                onLoadGame(
                  game,
                  gameLoaded,
                  setGameLoaded,
                  setDisabled,
                  toastHandler,
                  dispatch,
                  t
                )
              }
              expand
            />
          ) : (
            <Button
              label={t("game.start.submit-label")}
              type="primary"
              size="large"
              disabled={canStartGame(equipmentsState, equipmentBattery)}
              onClick={onStartGame(game, toastHandler, dispatch)}
              expand
            />
          ))}
      </SubmitButtonWrapper>
    </StartGameWrapper>
  );
};

const makePlayersArray =
  (
    setUpdatedPlayers: SetState<Player[]>,
    playerAmount: number,
    players: Player[]
  ) =>
  (equipments: Equipment[]): boolean => {
    if (equipments.length <= 0) return true;

    setUpdatedPlayers(
      _.flow([
        _.take(playerAmount),
        appendNewPlayers(playerAmount, equipments),
      ])(players) as Player[]
    );

    return false;
  };

const canStartGame = (
  connectedPlayers: EquipmentState[],
  batteriesInfos: BatteriesInfos[] | undefined
) =>
  connectedPlayers.length === 0 ||
  !_.every(
    {
      headsetConnected: true,
    },
    connectedPlayers
  ) ||
  batteriesInfos === undefined ||
  batteriesInfos.length === 0 ||
  batteriesInfos.some((batteries) =>
    connectedPlayers.some(
      (player) =>
        player.letter === batteries.letter &&
        batteriesShouldPreventStartGame(batteries)
    )
  );

const batteriesShouldPreventStartGame = (batteries: BatteriesInfos): boolean =>
  batteries.mustStop || batteries.headsetCapacity <= 30;

const appendNewPlayers =
  (playerAmount: number, equipments: Equipment[]) =>
  (updatedPlayers: Player[]) => {
    if (playerAmount <= updatedPlayers.length) return updatedPlayers;

    const lettersUsed = updatedPlayers.map((p) => p.equipment);
    const activatedEquipments = _.filter((eL: Equipment) => eL.activated)(
      equipments
    );
    const availableLetters = _.difference(
      activatedEquipments.map((eL) => eL.letter)
    )(lettersUsed);

    const countTeamsPlayers = (players: Player[]): TeamPlayersNumber[] =>
      _.flow([
        _.groupBy("team"),
        _.toPairs,
        _.map((pair: [color: string, players: Player[]]) => ({
          color: pair[0],
          playersNb: pair[1].length,
        })),
        _.sortBy((numbers: TeamPlayersNumber) => numbers.playersNb),
      ])(players) as TeamPlayersNumber[];

    const appendNewPlayer = (
      players: Player[],
      teamsPlayersNumber: TeamPlayersNumber[],
      nbPlayersToAdd: number,
      totalNbPlayersToAdd: number
    ): Player[] => {
      if (nbPlayersToAdd === 0) return players;

      const newPlayers = _.concat(players)(
        makeNewPlayer(
          activatedEquipments
            .map((eL) => eL.letter)
            .indexOf(availableLetters[totalNbPlayersToAdd - nbPlayersToAdd])
            .toString(),
          availableLetters[totalNbPlayersToAdd - nbPlayersToAdd],
          teamsPlayersNumber[0].color
        )
      );

      return appendNewPlayer(
        newPlayers,
        countTeamsPlayers(newPlayers),
        nbPlayersToAdd - 1,
        totalNbPlayersToAdd
      );
    };

    return appendNewPlayer(
      updatedPlayers,
      countTeamsPlayers(updatedPlayers),
      playerAmount - updatedPlayers.length,
      playerAmount - updatedPlayers.length
    );
  };

const makeNewPlayer = (
  id: string,
  equipment: string,
  teamColor: string
): Player => ({
  id,
  name: `Player ${parseInt(id, 10) + 1}`,
  team: teamColor,
  skin: "Jack",
  equipment,
});

const onChangeTeam =
  (setUpdatedPlayers: SetState<Player[]>, player: Player) => (team: string) =>
    updatePlayer(setUpdatedPlayers, {
      ...player,
      team,
    });

const onChangeName =
  (setUpdatedPlayers: SetState<Player[]>, player: Player) => (name: string) =>
    updatePlayer(setUpdatedPlayers, {
      ...player,
      name,
    });

const onChangeSkin =
  (setUpdatedPlayers: SetState<Player[]>, player: Player) => (skin: string) =>
    updatePlayer(setUpdatedPlayers, {
      ...player,
      skin,
    });

const onDeletePlayer =
  (
    setUpdatedPlayers: SetState<Player[]>,
    setPlayerAmount: SetState<number>,
    player: Player
  ) =>
  () => {
    setUpdatedPlayers((prevState) =>
      _.remove<Player>((p) => p.id === player.id)(prevState)
    );

    return setPlayerAmount((prevState) => prevState - 1);
  };

const makeTeamCreation = (
  team: [color: string, players: Player[]]
): TeamCreation => ({
  color: team[0],
  players: team[1].map(playerToPlayerCreation),
});

const playerToPlayerCreation = (player: Player): PlayerCreation => ({
  name: player.name,
  skin: player.skin,
  equipmentLetter: player.equipment,
});

const updatePlayer = (setUpdatedPlayers: SetState<Player[]>, player: Player) =>
  Promise.resolve(
    setUpdatedPlayers((prevState) =>
      prevState.map((p: Player) => {
        if (p.id === player.id) return player;

        return p;
      })
    )
  );

const updateGame = (
  onUpdateGame: (
    id: string,
    beginDate: number,
    duration: number,
    teams: TeamCreation[]
  ) => Promise<Either<Error[], GameModel>>,
  game: GameModel,
  updatedPlayers: Player[],
  gameLoaded: boolean,
  setIsGameUpdated: SetState<boolean>,
  setGameLoaded: SetState<boolean>,
  setDisabled: SetState<boolean>,
  setFieldErrors: SetState<FieldError[]>,
  toaster: ToastHandler,
  dispatch: Dispatch<CurrentGameActions>,
  t: TFunction
) => {
  setDisabled(true);
  setIsGameUpdated(false);

  const teams: TeamCreation[] = _.flow([
    _.groupBy("team"),
    _.toPairs,
    _.map(makeTeamCreation),
  ])(updatedPlayers);

  onUpdateGame(game.id, game.beginDate, game.duration, teams).then(
    (errorsOrGame) =>
      errorsOrGame.cata(
        (errors) => handleErrors(toaster, setFieldErrors, t, errors),
        (newGame) => {
          toaster.showSuccess(t("success.game.update"));

          if (gameLoaded)
            onLoadGame(
              newGame,
              gameLoaded,
              setGameLoaded,
              setDisabled,
              toaster,
              dispatch,
              t
            );
        }
      )
  );

  setDisabled(false);
};

const onLoadGame = (
  game: GameModel,
  gameLoaded: boolean,
  setGameLoaded: SetState<boolean>,
  setDisabled: SetState<boolean>,
  toaster: ToastHandler,
  dispatch: Dispatch<CurrentGameActions>,
  t: TFunction
) => {
  setDisabled(true);

  loadGame(game.id).then((maybeErrors) => {
    maybeErrors.cata(
      () => {
        toaster.showSuccess(t("success.game.load"));

        dispatch(setCurrentGame(game));
        return setGameLoaded(true);
      },
      (errors) => errors.forEach((error) => toaster.showError(error))
    );

    setDisabled(false);
  });
};

const onStartGame =
  (
    game: GameModel,
    toaster: ToastHandler,
    dispatch: Dispatch<CurrentGameActions>
  ) =>
  () =>
    startGame(game.id).then((maybeErrors) =>
      maybeErrors.cata(
        () =>
          dispatch(
            updateCurrentGame({
              ...game,
              started: true,
              beginDate: new Date().getTime() / 1000,
            })
          ),
        (errors) => errors.forEach((error) => toaster.showError(error))
      )
    );

export default StartGame;
