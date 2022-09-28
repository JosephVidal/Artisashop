import { Either, Maybe } from "monet";
import { Error } from "globals/error";
import { DayOff } from "models/dayOff";
import {
  parseAxiosResponseEither,
  parseAxiosErrorEither,
  parseAxiosResponseMaybe,
  parseAxiosErrorMaybe,
  extractData,
} from "globals/result";
import {
  getRequest,
  postRequest,
  putRequest,
  deleteRequest,
} from "globals/api";

export type GetDaysOff = { daysOff: DayOff[] };

export const getDaysOff = (
  year: string
): Promise<Either<Error[], GetDaysOff>> =>
  getRequest<GetDaysOff>(`/config/days-off/${year}`)
    .then(parseAxiosResponseEither)
    .catch(parseAxiosErrorEither<GetDaysOff>)
    .then(extractData);

export const createDaysOff = (dayOff: DayOff): Promise<Maybe<Error[]>> =>
  postRequest("/config/day-off", dayOff)
    .then(parseAxiosResponseMaybe)
    .catch(parseAxiosErrorMaybe);

export const editDaysOff = (dayOff: DayOff): Promise<Maybe<Error[]>> =>
  putRequest(`/config/day-off/${dayOff.date}`, dayOff)
    .then(parseAxiosResponseMaybe)
    .catch(parseAxiosErrorMaybe);

export const deleteDaysOff = (date: string): Promise<Maybe<Error[]>> =>
  deleteRequest(`/config/day-off/${date}`)
    .then(parseAxiosResponseMaybe)
    .catch(parseAxiosErrorMaybe);
