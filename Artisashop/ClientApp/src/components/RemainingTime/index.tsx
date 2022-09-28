import React, { useEffect, useState } from "react";
import { ToastHandler } from "components/Toaster";
import { useInterval } from "globals/useInterval";
import { getRemainingTime } from "pages/Game/api";
import { SetState } from "globals/state";
import { timeToMinutesString, timetoSecondsString } from "globals/date";
import { RemainingTimeWrapper } from "./styles";

interface Props {
  toaster: ToastHandler;
  paused?: boolean;
}

const RemainingTime: React.FunctionComponent<Props> = ({
  toaster,
  paused = false,
}) => {
  const [time, setTime] = useState<number>(-1);

  useEffect(() => {
    getOnGoingGameTime(toaster, setTime);
  }, []);

  useInterval(() => {
    if (time > 0 && !paused) setTime(time - 1000 > 0 ? time - 1000 : 0);
  }, 1000);

  return (
    <RemainingTimeWrapper paused={paused}>
      {time > 0
        ? `${timeToMinutesString(time)} : ${timetoSecondsString(time)}`
        : "--:--"}
    </RemainingTimeWrapper>
  );
};

const getOnGoingGameTime = (toaster: ToastHandler, setTime: SetState<number>) =>
  getRemainingTime().then((errorsOrRemainingTime) =>
    errorsOrRemainingTime.cata(
      (errors) => errors.forEach((error) => toaster.showError(error)),
      (time) => setTime((time.remainingTime / 60) * 60000)
    )
  );

export default RemainingTime;
