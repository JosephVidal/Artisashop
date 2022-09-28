import React, { FC, useContext, useEffect, useState } from "react";
import { useParams } from "react-router-dom";
import Content from "components/Content";
import _ from "lodash/fp";
import { Either, Left, Maybe, None, Right, Some } from "monet";
import { Error } from "globals/error";
import { ToastHandler } from "components/Toaster";
import { Game as GameModel, GamePlayer } from "models/game";
import { SetState } from "globals/state";
import CurrentGame from "pages/Game/CurrentGame";
import StartGame from "pages/Game/StartGame";
import { StoreContext } from "reducers/utils";
import { useTranslation } from "react-i18next";
import { TFunction } from "i18next";
import { Log } from "models/logs";
import { Equipment, EquipmentState } from "models/equipment";
import { GetEquipments, listEquipments } from "equipments/api";
import { Batteries } from "models/battery";
import GameOver from "pages/Game/GameOver";
import { differenceInSeconds } from "date-fns/fp";
import { EquipmentStateLog } from "reducers/logsReducer";
import { retrieveArtemisCurrentGame } from "currentGame";
import { TeamCreation } from "models/gameCreation";
import { GameWrapper, Title, TitleWithChrono } from "./styles";
import Chronometer from "./components/Chronometer";
import Time from "./components/Time";
import { getEquipmentsState, GetGame, getGameById, updateGame } from "./api";

interface Props {
  toastHandler: ToastHandler;
}

const Game: FC<Props> = ({ toastHandler }) => {
  const [{ currentGame, logs }, dispatch] = useContext(StoreContext);
  const [maybeGame, setMaybeGame] = useState<Maybe<GameModel>>(None());
  const [equipmentsState, setEquipmentsState] = useState<EquipmentState[]>([]);
  const [loading, setLoading] = useState<boolean>(true);
  const [playerNumber, setPlayerNumber] = useState<number>(-1);
  const [equipments, setEquipments] = useState<Equipment[]>([]);
  const { t } = useTranslation();

  const { id } = useParams();

  useEffect(() => {
    retrieveArtemisCurrentGame(toastHandler, dispatch);
  }, []);

  useEffect(() => {
    if (currentGame.exists((game) => game.id === id)) setMaybeGame(currentGame);
  }, [currentGame]);

  useEffect(() => {
    retrieveGameById().then(() => setPlayerNumber(2));
  }, []);

  useEffect(() => {
    if (playerNumber >= 2) {
      retrieveEquipments(toastHandler).then(() => setLoading(false));
    }
  }, [playerNumber]);

  useEffect(() => initConnectedPlayers(setEquipmentsState, toastHandler), []);

  useEffect(
    updateEquipmentsState(
      equipmentsState,
      setEquipmentsState,
      logs.logsByType["player-headset-state"] as Log<EquipmentStateLog>[]
    ),
    [logs.logsByType["player-headset-state"]]
  );

  const retrieveGameById = (): Promise<void> =>
    // @ts-ignore: React router useParams() typing possibly return undefined
    getGameById(id).then(saveGameById).catch(saveGameById);

  const saveEquipments =
    (toaster: ToastHandler) =>
    (equipmentsOrError: Either<Error[], GetEquipments>): Equipment[] => {
      equipmentsOrError.cata(
        (errors) => toaster.showErrors(errors),
        (eL) => setEquipments(eL.equipments)
      );

      return equipmentsOrError.cata(
        () => [] as Equipment[],
        (c) => c.equipments
      );
    };

  const retrieveEquipments = (toaster: ToastHandler): Promise<Equipment[]> => {
    if (equipments.length <= 0) {
      return listEquipments()
        .then(saveEquipments(toaster))
        .catch(saveEquipments(toaster))
        .then((result) => result);
    }

    return Promise.resolve(equipments);
  };

  const saveGameById = (gameOrErrors: Either<Error[], GetGame>) => {
    gameOrErrors.forEach((g) => {
      setMaybeGame(Some(g.game));
    });
  };

  const onUpdateGame = (
    gameId: string,
    beginDate: number,
    duration: number,
    teams: TeamCreation[]
  ): Promise<Either<Error[], GameModel>> =>
    updateGame(gameId, beginDate, duration, teams).then((errorsOrGame) =>
      errorsOrGame.cata(
        (errors) => Left(errors),
        (newGame) => {
          setMaybeGame(Some(newGame.game));
          return Right(newGame.game);
        }
      )
    );

  return (
    <Content title={title(toastHandler, t, maybeGame)} loading={loading}>
      <GameWrapper>
        {maybeGame.map((game) => (
          <>
            {game.over && (
              <GameOver currentGame={gameWithPlayersSorted(game)} />
            )}

            {!game.over && game.started && (
              <CurrentGame
                currentGame={gameWithPlayersSorted(game)}
                equipmentsState={equipmentsState}
              />
            )}

            {!game.started && (
              <StartGame
                game={gameWithPlayersSorted(game)}
                onUpdateGame={onUpdateGame}
                toastHandler={toastHandler}
                currentGame={currentGame}
                equipmentsState={equipmentsState}
                equipmentBattery={
                  (_.last(logs.logsByType["batteries-info"]) as Log<Batteries>)
                    ?.data.batteriesInfo
                }
              />
            )}
          </>
        ))}
      </GameWrapper>
    </Content>
  );
};

const title = (
  toastHandler: ToastHandler,
  t: TFunction,
  maybeGame: Maybe<GameModel>
): React.ReactNode =>
  maybeGame.map((game) => {
    if (game.over) {
      return (
        <Title>
          <>{t("game.finished.title")}</>
        </Title>
      );
    }

    if (game.started) {
      return (
        <TitleWithChrono>
          <Title>
            <>{t("game.current.title")}</>
          </Title>

          <Chronometer
            gameId={game.id}
            toastHandler={toastHandler}
            timeLeft={() => timeLeft(game)}
            pause={game.paused}
            countdown={countdownCalculator(game)}
          />
        </TitleWithChrono>
      );
    }

    return (
      <TitleWithChrono>
        <Title>
          <>{t("game.start.title")}</>
        </Title>

        <Time value={game.duration} />
      </TitleWithChrono>
    );
  });

const timeLeft = (currentGame: GameModel | undefined): number => {
  if (currentGame && currentGame.started) {
    const time =
      (currentGame.remainingTime
        ? currentGame.remainingTime / 60
        : currentGame.duration) * 60000;
    return time > 0 ? time : 0;
  }
  return 600000;
};

const countdownCalculator = (game: GameModel): number => {
  const maxCountdown = Number(process.env.REACT_APP_GAME_COUNTDOWN) || 3;
  const actualDiff = differenceInSeconds(new Date(game.beginDate * 1000))(
    new Date()
  );

  if (actualDiff < maxCountdown) return (maxCountdown - actualDiff) * 1000;

  return 0;
};

const initConnectedPlayers = (
  setEquipmentsState: SetState<EquipmentState[]>,
  toaster: ToastHandler
) => {
  getEquipmentsState().then((dataOrError) => {
    dataOrError.cata(
      (errors) => {
        toaster.showErrors(errors);
        setTimeout(
          () => initConnectedPlayers(setEquipmentsState, toaster),
          2500
        );
      },
      (playerEquipment) =>
        setEquipmentsState(playerEquipment.equipmentsState || [])
    );
  });
};

const updateEquipmentsState =
  (
    connectedPlayers: EquipmentState[],
    setConnectedPlayers: SetState<EquipmentState[]>,
    stateLogs: Log<EquipmentStateLog>[]
  ) =>
  () => {
    if (stateLogs.length === 0) return;

    const state = stateLogs[stateLogs.length - 1];

    if (state.type === "player-headset-state") {
      setConnectedPlayers((prevState) =>
        _.map(
          (player) =>
            player.letter !== state.data.letter
              ? player
              : {
                  ...player,
                  headsetConnected: state.data.connected,
                },
          prevState
        )
      );
    }
  };

const gameWithPlayersSorted = (game: GameModel): GameModel => ({
  ...game,
  teams: game.teams.map((team) => ({
    ...team,
    players: _.sortBy<GamePlayer>("equipmentLetter")(team.players),
  })),
});

export default Game;
