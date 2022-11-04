import logsReducer, { initialLogsState, LogsState } from "reducers/logsReducer";
import { Reducers } from "reducers/utils";
import currentGameReducer, {
  initialGameState,
} from "reducers/currentGameReducer";
import { Maybe } from "monet";
import { Game as GameModel } from "models/game";

export interface States {
  logs: LogsState;
  currentGame: Maybe<GameModel>;
}

export const initialStates: States = {
  logs: initialLogsState,
  currentGame: initialGameState,
};

export const reducers: Reducers = {
  logs: logsReducer,
  currentGame: currentGameReducer,
};
