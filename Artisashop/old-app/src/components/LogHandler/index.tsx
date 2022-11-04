import React, { Dispatch, useContext, useEffect } from "react";
import { addLog, EquipmentStateLog, LogsActions } from "reducers/logsReducer";
import { ResultContent } from "globals/result";
import { Log } from "models/logs";
import { StoreContext } from "reducers/utils";
import { useTranslation } from "react-i18next";
import { ToastHandler } from "components/Toaster";
import { TFunction } from "i18next";
import { error, Error } from "globals/error";
import _ from "lodash/fp";
import { Batteries } from "models/battery";

interface Props {
  toastHandler: ToastHandler;
}

const hermesBasePath =
  process.env.REACT_APP_HERMES_BASE_PATH || "http://localhost:3000";

const LogHandler: React.FunctionComponent<Props> = ({ toastHandler }) => {
  const [{ logs }, dispatch] = useContext(StoreContext);
  const { t } = useTranslation();

  useEffect(getRealTimeLogs(dispatch), []);

  useEffect(
    () =>
      displayErrorLog(
        toastHandler,
        t,
        _.last<Log<Error>>(logs.logsByType.error)
      ),
    [logs.logsByType.error]
  );

  useEffect(
    () =>
      displayBatteryLog(
        toastHandler,
        t,
        _.last<Log<Batteries>>(logs.logsByType["batteries-info"])
      ),
    [logs.logsByType["batteries-info"]]
  );

  useEffect(
    () =>
      displayDisconnectionLog(
        toastHandler,
        t,
        "error.disconnected-headset",
        _.last<Log<EquipmentStateLog>>(logs.logsByType["player-headset-state"])
      ),
    [logs.logsByType["player-headset-state"]]
  );

  return null;
};

const getRealTimeLogs = (dispatch: Dispatch<LogsActions>) => () => {
  const stateSource = new EventSource(`${hermesBasePath}/log`);

  stateSource.onmessage = (event: MessageEvent<string>) => {
    const json = JSON.parse(event.data) as ResultContent<Log<any>>;

    if (json.data) dispatch(addLog(json.data));
  };
};

const displayErrorLog = (
  toaster: ToastHandler,
  t: TFunction,
  log?: Log<Error>
) => {
  if (!_.isNil(log))
    toaster.showErrors([error(t("error.title"), t(log.data.message))]);
};

const displayBatteryLog = (
  toaster: ToastHandler,
  t: TFunction,
  log?: Log<Batteries>
) => {
  if (!_.isNil(log)) {
    const errors: (Error | null)[] = log.data.batteriesInfo.map((info) => {
      if (info.headsetCapacity <= 30)
        return error(
          "batteries",
          t("error.battery-headset", { letter: info.letter })
        );

      return null;
    });

    displayErrors(toaster, errors.filter(_.negate(_.isNil)) as Error[]);
  }
};

const displayDisconnectionLog = (
  toaster: ToastHandler,
  t: TFunction,
  errorMessageKey: string,
  log?: Log<EquipmentStateLog>
) => {
  if (!_.isNil(log) && !log.data.connected)
    displayErrors(toaster, [
      error("disconnection", t(errorMessageKey, { letter: log.data.letter })),
    ]);
};

const displayErrors = (toaster: ToastHandler, errors: Error[]) =>
  errors.length !== 0 && toaster.showErrors(errors);

export default LogHandler;
