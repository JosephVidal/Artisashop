import { Action } from "reducers/utils";
import { Reducer } from "react";
import { Game as GameModel } from "models/game";
import { Just, Maybe, None } from "monet";
import _ from "lodash/fp";

type SetCurrentGame = Action<"SET_GAME"> & { currentGame: GameModel };
export const setCurrentGame = (currentGame: GameModel): SetCurrentGame => ({
  type: "SET_GAME",
  currentGame,
});

type UpdateCurrentGame = Action<"UPDATE_GAME"> & {
  updatedGame: Partial<GameModel>;
};
export const updateCurrentGame = (
  updatedGame: Partial<GameModel>
): UpdateCurrentGame => ({
  type: "UPDATE_GAME",
  updatedGame,
});

type StartGame = Action<"START_GAME">;
export const startCurrentGame = (): StartGame => ({ type: "START_GAME" });

type ResumeGame = Action<"RESUME_GAME">;
export const resumeCurrentGame = (): ResumeGame => ({ type: "RESUME_GAME" });

type PauseGame = Action<"PAUSE_GAME">;
export const pauseCurrentGame = (): PauseGame => ({ type: "PAUSE_GAME" });

type EndGame = Action<"END_GAME">;
export const endCurrentGame = (): EndGame => ({ type: "END_GAME" });

export type CurrentGameActions =
  | SetCurrentGame
  | UpdateCurrentGame
  | StartGame
  | ResumeGame
  | PauseGame
  | EndGame;

export const initialGameState: Maybe<GameModel> = None();

export type CurrentGameReducer = Reducer<Maybe<GameModel>, CurrentGameActions>;

const reducer: CurrentGameReducer = (
  /* eslint-disable-next-line @typescript-eslint/default-param-last */
  state: Maybe<GameModel> = initialGameState,
  action: CurrentGameActions
) => {
  switch (action.type) {
    case "SET_GAME":
      return Just(action.currentGame);

    case "UPDATE_GAME":
      return state.map((game) => _.merge(game, action.updatedGame));

    case "START_GAME":
      return state.map((game) => ({
        ...game,
        started: true,
        beginDate: new Date().getTime() / 1000,
      }));

    case "RESUME_GAME":
      return state.map((game) => ({
        ...game,
        paused: false,
      }));

    case "PAUSE_GAME":
      return state.map((game) => ({
        ...game,
        paused: true,
      }));

    case "END_GAME":
      return state.map((game) => ({
        ...game,
        over: true,
        endDate: new Date().getTime() / 1000,
      }));

    default:
      return state;
  }
};

export default reducer;
