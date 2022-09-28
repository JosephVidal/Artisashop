import { ToastHandler } from "components/Toaster";
import { SetState } from "globals/state";
import { DayOff } from "models/dayOff";
import { Either, Maybe, Some, None } from "monet";
import { Error } from "globals/error";
import { GetDaysOff, getDaysOff } from "daysOff/api";

export const retrieveDaysOff = (
  toaster: ToastHandler,
  year: string
): Promise<DayOff[]> =>
  getDaysOff(year).then(saveDaysOff(toaster)).catch(saveDaysOff(toaster));

const saveDaysOff =
  (toaster: ToastHandler) =>
  (errorsOrDaysOff: Either<Error[], GetDaysOff>): DayOff[] => {
    errorsOrDaysOff.cata(
      (errors) => toaster.showErrors(errors),
      () => {}
    );

    return errorsOrDaysOff.cata(
      () => [] as DayOff[],
      (dOff) => dOff.daysOff
    );
  };

export const retrieveDaysOffIntoState = (
  toaster: ToastHandler,
  year: string,
  setDaysOff: SetState<Maybe<DayOff[]>>
): Promise<Maybe<DayOff[]>> =>
  getDaysOff(year)
    .then(saveDaysOffToState(toaster, setDaysOff))
    .catch(saveDaysOffToState(toaster, setDaysOff));

const saveDaysOffToState =
  (toaster: ToastHandler, setDaysOff: SetState<Maybe<DayOff[]>>) =>
  (errorsOrDaysOff: Either<Error[], GetDaysOff>): Maybe<DayOff[]> => {
    errorsOrDaysOff.cata(toaster.showErrors, (daysOff) =>
      setDaysOff(Some(daysOff.daysOff))
    );

    return errorsOrDaysOff.cata(
      () => None(),
      (daysOff) => Some(daysOff.daysOff)
    );
  };
