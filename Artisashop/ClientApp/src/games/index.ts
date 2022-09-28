import { ToastHandler } from "components/Toaster";
import { SetState } from "globals/state";
import { Either } from "monet";
import { Error } from "globals/error";
import { GetGamesList, getGamesList } from "pages/Game/api";
import { GameList } from "models/gameList";
import { format } from "date-fns/fp";

export const retrieveGamesList = (
  toaster: ToastHandler,
  date: Date,
  gamesList: GameList[],
  setGamesList: SetState<GameList[]>
): Promise<GameList[]> =>
  getGamesList(format("yyyy-MM-dd")(date))
    .then(saveGamesList(toaster, setGamesList))
    .catch(saveGamesList(toaster, setGamesList));

const saveGamesList =
  (toaster: ToastHandler, setGamesList: SetState<GameList[]>) =>
  (errorsOrGamesList: Either<Error[], GetGamesList>): GameList[] => {
    errorsOrGamesList.cata(toaster.showErrors, (gameList) =>
      setGamesList(gameList.games)
    );

    return errorsOrGamesList.cata(
      () => [] as GameList[],
      (gameList) => gameList.games
    );
  };
