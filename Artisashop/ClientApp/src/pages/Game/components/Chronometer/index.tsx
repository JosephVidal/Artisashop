import React, { Dispatch, FC, useContext, useState } from "react";
import { FiPauseCircle, FiPlayCircle, FiStopCircle } from "react-icons/fi";
import { SetState } from "globals/state";
import { pauseGame, resumeGame, stopGame } from "pages/Game/api";
import { ToastHandler } from "components/Toaster";
import { useTranslation } from "react-i18next";
import {
  CurrentGameActions,
  endCurrentGame,
  pauseCurrentGame,
  resumeCurrentGame,
} from "reducers/currentGameReducer";
import { StoreContext } from "reducers/utils";
import { timeToMinutesString, timetoSecondsString } from "globals/date";
import { useInterval } from "globals/useInterval";
import { format } from "date-fns/fp";
import DialogManager from "components/DialogManager";
import { ChronometerWrapper, Icon, PlayIcon, Time } from "./styles";

interface Props {
  gameId: string;
  toastHandler: ToastHandler;
  timeLeft: () => number;
  pause: boolean;
  countdown: number;
}

const Chronometer: FC<Props> = ({
  gameId,
  toastHandler,
  timeLeft,
  pause,
  countdown,
}) => {
  const [, dispatch] = useContext(StoreContext);
  const [time, setTime] = useState<number>(timeLeft);
  const [countdownTime, setCountdownTime] = useState<number>(countdown);
  const [paused, setPaused] = useState<boolean>(pause);
  const [stopped, setStopped] = useState<boolean>(time <= 0);
  const [visible, setVisible] = useState<boolean>(false);
  const { t } = useTranslation();

  useInterval(() => {
    if (countdownTime && countdownTime > 0)
      setCountdownTime(countdownTime - 1000);
    else if (!stopped && !paused) {
      if (time > 0) setTime(time - 1000 > 0 ? time - 1000 : 0);
      else {
        setStopped(true);
        dispatch(endCurrentGame());
      }
    }
  }, 1000);

  return (
    <ChronometerWrapper>
      {countdownTime > 0 ? (
        <Time paused>
          <span>{`-${format("mm:ss", countdownTime)}`}</span>
        </Time>
      ) : (
        <>
          <Time paused={paused}>
            <span>
              {`${timeToMinutesString(time)} : ${timetoSecondsString(time)}`}
            </span>

            <small>{t("game.current.paused")}</small>
          </Time>

          <Icon
            onClick={() =>
              playPauseHandler(
                gameId,
                toastHandler,
                paused,
                stopped,
                dispatch,
                setPaused,
                setStopped,
                setCountdownTime,
                setTime
              )
            }
          >
            {paused && !stopped && (
              <PlayIcon>
                <FiPlayCircle />
              </PlayIcon>
            )}

            {!paused && !stopped && <FiPauseCircle />}
          </Icon>

          {!stopped && (
            <>
              <DialogManager
                isConfirm
                visible={visible}
                onHide={() => setVisible(false)}
                text={t("game.current.stop-confirm-message")}
                title={t("global.confirm")}
                onAccept={() =>
                  stopHandler(gameId, toastHandler, dispatch, setStopped)
                }
                buttons
              />
              <Icon onClick={() => setVisible(true)}>
                <FiStopCircle />
              </Icon>
            </>
          )}
        </>
      )}
    </ChronometerWrapper>
  );
};

const stopHandler = (
  gameId: string,
  toaster: ToastHandler,
  dispatch: Dispatch<CurrentGameActions>,
  setStopped: SetState<boolean>
) => {
  stopGame(gameId).then((maybeErrors) =>
    maybeErrors.cata(
      () => {
        setStopped(true);
        dispatch(endCurrentGame());
      },
      (errors) => errors.forEach((error) => toaster.showError(error))
    )
  );
};

const playPauseHandler = (
  gameId: string,
  toaster: ToastHandler,
  paused: boolean,
  stopped: boolean,
  dispatch: Dispatch<CurrentGameActions>,
  setPaused: SetState<boolean>,
  setStopped: SetState<boolean>,
  setCountdown: SetState<number>,
  setTime: SetState<number>
) => {
  if (paused) {
    resumeGame(gameId).then((errorsOrRemainingTime) =>
      errorsOrRemainingTime.cata(
        (errors) => errors.forEach((error) => toaster.showError(error)),
        (time) => {
          setPaused(false);
          dispatch(resumeCurrentGame());
          setCountdown(
            (Number(process.env.REACT_APP_GAME_COUNTDOWN) || 3) * 1000
          );
          setTime(time.remainingTime * 1000);
        }
      )
    );
  } else {
    pauseGame(gameId).then((maybeErrors) =>
      maybeErrors.cata(
        () => {
          setPaused(true);
          dispatch(pauseCurrentGame());
        },
        (errors) => errors.forEach(toaster.showError)
      )
    );
  }

  if (stopped) {
    setStopped(false);
    setPaused(false);
  }
};

export default Chronometer;
