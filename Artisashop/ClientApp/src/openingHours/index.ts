import { ToastHandler } from "components/Toaster";
import {
  Calendar,
  CalendarAPIResponse,
  EducationAPIResponse,
  GetOpeningHours,
  Vacation,
} from "models/openingHours";
import { SetState } from "globals/state";
import { getHolidays, getOpeningHours, getVacation } from "openingHours/api";
import { Either, Maybe, Some, None } from "monet";
import { Error } from "globals/error";
import * as _ from "lodash";

export const retrieveOpeningHours = (
  toaster: ToastHandler,
  openingHours: Calendar,
  setOpeningHours: SetState<Calendar>
): Promise<Calendar> =>
  getOpeningHours()
    .then(saveOpeningHours(toaster, setOpeningHours))
    .catch(saveOpeningHours(toaster, setOpeningHours));

const saveOpeningHours =
  (toaster: ToastHandler, setOpeningHours: SetState<Calendar>) =>
  (errorsOrOpeningHours: Either<Error[], GetOpeningHours>): Calendar => {
    errorsOrOpeningHours.cata(
      (errors) => toaster.showErrors(errors),
      (opHours) => setOpeningHours(opHours.calendar)
    );

    return errorsOrOpeningHours.cata(
      () =>
        ({
          schoolingDays: [],
          schoolVacation: [],
          holiday: {
            id: "",
            day: "HOLIDAY",
            closed: true,
          },
        } as Calendar),
      (op) => op.calendar
    );
  };

export const retrieveVacations = (
  toaster: ToastHandler,
  schoolYear: string,
  zone: string,
  setVacations: SetState<Maybe<Vacation[]>>
): Promise<Maybe<Vacation[]>> =>
  getVacation(schoolYear, zone)
    .then(saveVacation(toaster, setVacations))
    .catch(saveVacation(toaster, setVacations));

const saveVacation =
  (toaster: ToastHandler, setVacations: SetState<Maybe<Vacation[]>>) =>
  (
    errorsOrVacations: Either<Error[], EducationAPIResponse>
  ): Maybe<Vacation[]> => {
    errorsOrVacations.cata(toaster.showErrors, (vacations) =>
      setVacations(Some(parseVacationData(vacations)))
    );

    return errorsOrVacations.cata(
      () => None(),
      (vacations) => Some(parseVacationData(vacations))
    );
  };

const parseVacationData = (data: EducationAPIResponse): Vacation[] =>
  _.uniqBy(
    data.records.map((r) => r.fields),
    "description"
  ).map((c) => ({
    start: new Date(c.start_date),
    end: new Date(c.end_date),
  }));

export const retrieveHolidays = (
  toaster: ToastHandler,
  year: string,
  zone: string,
  setHolidays: SetState<Maybe<string[]>>
): Promise<Maybe<string[]>> =>
  getHolidays(year, zone)
    .then(saveHolidays(toaster, setHolidays))
    .catch(saveHolidays(toaster, setHolidays));

const saveHolidays =
  (toaster: ToastHandler, setHolidays: SetState<Maybe<string[]>>) =>
  (errorsOrHolidays: Either<Error[], CalendarAPIResponse>): Maybe<string[]> => {
    errorsOrHolidays.cata(toaster.showErrors, (holidays) =>
      setHolidays(Some(Object.keys(holidays)))
    );

    return errorsOrHolidays.cata(
      () => None(),
      (holidays) => Some(Object.keys(holidays))
    );
  };
