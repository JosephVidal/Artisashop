import { ToastHandler } from "components/Toaster";
import { SetState } from "globals/state";
import { Either, Maybe, Some, None } from "monet";
import { Error } from "globals/error";
import { getConfigParameter } from "configurations/api";
import { ConfigParameter } from "models/config";

export const getConfigScreenParameters = (
  toaster: ToastHandler,
  key: string,
  setConfig?: SetState<Maybe<string>>
): Promise<Maybe<string>> =>
  getConfigParameter(key)
    .then(saveConfigToState(toaster, setConfig))
    .catch(saveConfigToState(toaster, setConfig));

const saveConfigToState =
  (toaster: ToastHandler, setConfigParameter?: SetState<Maybe<string>>) =>
  (
    errorsOrConfigParameter: Either<Error[], ConfigParameter>
  ): Maybe<string> => {
    if (setConfigParameter) {
      errorsOrConfigParameter.cata(toaster.showErrors, (configParameter) =>
        setConfigParameter(Some(configParameter.value))
      );
    }

    return errorsOrConfigParameter.cata(
      () => None(),
      (configParameter) => Some(configParameter.value)
    );
  };

export const retrieveConfigParameter = (
  toaster: ToastHandler,
  key: string,
  config: string,
  setConfig: SetState<string>
): Promise<string> => {
  if (config) {
    return getConfigParameter(key)
      .then(saveConfigParameter(toaster, setConfig))
      .catch(saveConfigParameter(toaster, setConfig));
  }

  return Promise.resolve(config);
};

const saveConfigParameter =
  (toaster: ToastHandler, setConfigParameter: SetState<string>) =>
  (errorsOrConfigParameter: Either<Error[], ConfigParameter>): string => {
    errorsOrConfigParameter.cata(
      (errors) => toaster.showErrors(errors),
      (cP) => setConfigParameter(cP.value)
    );

    return errorsOrConfigParameter.cata(
      () => "",
      (cP) => cP.value
    );
  };

export const getSetupStatus = (
  toastHandler: ToastHandler,
  setSetupDone: SetState<boolean>,
  setLoading: SetState<boolean>
) => {
  getConfigParameter("setup-completed")
    .then(saveSetupStatusToState(toastHandler, setSetupDone))
    .then(() => setLoading(false))
    .catch(saveSetupStatusToState(toastHandler, setSetupDone));
};

export const saveSetupStatusToState =
  (toaster: ToastHandler, setSetupDone: SetState<boolean>) =>
  (errorsOrConfigParameter: Either<Error[], ConfigParameter>) => {
    errorsOrConfigParameter.cata(toaster.showErrors, (configParameter) =>
      setSetupDone(configParameter.value === "1")
    );
  };
