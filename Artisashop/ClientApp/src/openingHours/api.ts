import { Either, Maybe } from "monet";
import { Error } from "globals/error";
import {
  parseAxiosResponseEither,
  parseAxiosErrorEither,
  parseAxiosResponseMaybe,
  parseAxiosErrorMaybe,
  extractData,
  handleGouvError,
  handleGouvResponse,
} from "globals/result";
import {
  CalendarName,
  OpeningHours,
  EducationAPIResponse,
  CalendarAPIResponse,
  GetOpeningHours,
} from "models/openingHours";
import { EducationAPI, CalendarAPI, getRequest, putRequest } from "globals/api";

export const getOpeningHours = (): Promise<Either<Error[], GetOpeningHours>> =>
  getRequest<GetOpeningHours>("/config/opening-hours")
    .then(parseAxiosResponseEither)
    .catch(parseAxiosErrorEither<GetOpeningHours>)
    .then(extractData);

export const updateOpeningHours = (
  calendarName: CalendarName,
  openingHours: OpeningHours[]
): Promise<Maybe<Error[]>> =>
  putRequest("/config/opening-hours", {
    calendar: calendarName,
    openingHours: openingHours.map((opHours) => ({
      ...opHours,
      day: opHours.day,
    })),
  })
    .then(parseAxiosResponseMaybe)
    .catch(parseAxiosErrorMaybe);

export const getVacation = (
  schoolYear: string,
  zone: string
): Promise<Either<Error[], EducationAPIResponse>> =>
  EducationAPI.get<EducationAPIResponse>("/records/1.0/search/", {
    params: {
      dataset: "fr-en-calendrier-scolaire",
      rows: "100",
      sort: "start_date",
      facet: [
        "description",
        "population",
        "start_date",
        "end_date",
        "location",
        "zones",
        "annee_scolaire",
      ],
      "refine.annee_scolaire": schoolYear,
      "refine.zones": zone,
      "exclude.population": "Enseignants",
    },
  })
    .then(handleGouvResponse)
    .catch(handleGouvError<EducationAPIResponse>)
    .then(extractData);

export const getHolidays = (
  year: string,
  zone: string
): Promise<Either<Error[], CalendarAPIResponse>> =>
  CalendarAPI.get<CalendarAPIResponse>(`/jours-feries/${zone}/${year}.json`)
    .then(handleGouvResponse)
    .catch(handleGouvError<CalendarAPIResponse>)
    .then(extractData);
