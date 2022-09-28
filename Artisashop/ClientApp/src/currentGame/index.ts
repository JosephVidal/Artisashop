import { ToastHandler } from "components/Toaster";
import { getCurrentGame, GetMaybeGame } from "pages/Game/api";
import { Either, Maybe } from "monet";
import { Error } from "globals/error";
import {
  CurrentGameActions,
  setCurrentGame,
} from "reducers/currentGameReducer";
import { Dispatch } from "react";

export const retrieveArtemisCurrentGame = (
  toaster: ToastHandler,
  dispatch: Dispatch<CurrentGameActions>
): Promise<void> =>
  getCurrentGame()
    .then(saveCurrentGame(toaster, dispatch))
    .catch(saveCurrentGame(toaster, dispatch));

export const saveCurrentGame =
  (toaster: ToastHandler, dispatch: Dispatch<CurrentGameActions>) =>
  (errorsOrMaybeGame: Either<Error[], GetMaybeGame>) => {
    errorsOrMaybeGame.cata(
      (errors) => toaster.showErrors(errors),
      (value) =>
        Maybe.fromNull(value.game).forEach((g) => {
          dispatch(setCurrentGame(g));
        })
    );
  };
