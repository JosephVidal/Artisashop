import React, { Dispatch, useContext, useEffect } from "react";
import { ResultContent } from "globals/result";
import { StoreContext } from "reducers/utils";
import {
  CurrentGameActions,
  updateCurrentGame,
} from "reducers/currentGameReducer";
import { Game as GameModel } from "models/game";

interface Props {}

const hermesBasePath =
  process.env.REACT_APP_HERMES_BASE_PATH || "http://localhost:3000";

const CurrentGameHandler: React.FunctionComponent<Props> = () => {
  const [, dispatch] = useContext(StoreContext);

  useEffect(getGameUpdatesInRealTime(dispatch), []);

  return null;
};

const getGameUpdatesInRealTime =
  (dispatch: Dispatch<CurrentGameActions>) => () => {
    const stateSource = new EventSource(
      `${hermesBasePath}/game/current/real-time`
    );

    stateSource.onmessage = (event: MessageEvent<string>) => {
      const json = JSON.parse(event.data) as ResultContent<Partial<GameModel>>;

      if (json.data) dispatch(updateCurrentGame(json.data));
    };
  };

export default CurrentGameHandler;
