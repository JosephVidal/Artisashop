import {
  parseAxiosResponseEither,
  parseAxiosErrorEither,
  parseAxiosResponseMaybe,
  parseAxiosErrorMaybe,
  extractData,
} from "globals/result";
import { Either, Maybe } from "monet";
import { Error } from "globals/error";
import { TeamCreation } from "models/gameCreation";
import { Game } from "models/game";
import { EquipmentState } from "models/equipment";
import { GameList } from "models/gameList";
import {
  deleteRequest,
  getRequest,
  postRequest,
  putRequest,
} from "globals/api";

export type GetGame = { game: Game };

export type GetMaybeGame = { game?: Game };

export type GetGamesList = { games: GameList[] };

export const sendCreatedGame = (
  beginDate: number,
  duration: number,
  teams: TeamCreation[]
): Promise<Either<Error[], GetGame>> =>
  postRequest<GetGame>("/game/create", {
    beginDate,
    duration,
    teams,
  })
    .then(parseAxiosResponseEither)
    .catch(parseAxiosErrorEither<GetGame>)
    .then(extractData);

export const getGamesList = (
  date: string
): Promise<Either<Error[], GetGamesList>> =>
  getRequest<GetGamesList>(`/games/${date}`)
    .then(parseAxiosResponseEither)
    .catch(parseAxiosErrorEither<GetGamesList>)
    .then(extractData);

export const getGameById = (id: string): Promise<Either<Error[], GetGame>> =>
  getRequest<GetGame>(`/game/${id}`)
    .then(parseAxiosResponseEither)
    .catch(parseAxiosErrorEither<GetGame>)
    .then(extractData);

export const loadGame = (id: string): Promise<Maybe<Error[]>> =>
  postRequest(`/game/${id}/load`)
    .then(parseAxiosResponseMaybe)
    .catch(parseAxiosErrorMaybe);

export const updateGame = (
  id: string,
  beginDate: number,
  duration: number,
  teams: TeamCreation[]
): Promise<Either<Error[], GetGame>> =>
  putRequest<GetGame>(`game/${id}`, {
    beginDate,
    duration,
    teams,
  })
    .then(parseAxiosResponseEither)
    .catch(parseAxiosErrorEither<GetGame>)
    .then(extractData);

export const startGame = (id: string): Promise<Maybe<Error[]>> =>
  postRequest(`/game/${id}/start`)
    .then(parseAxiosResponseMaybe)
    .catch(parseAxiosErrorMaybe);

export const pauseGame = (id: string): Promise<Maybe<Error[]>> =>
  postRequest(`/game/${id}/pause`)
    .then(parseAxiosResponseMaybe)
    .catch(parseAxiosErrorMaybe);

export const deleteGame = (id: string): Promise<Maybe<Error[]>> =>
  deleteRequest(`/game/${id}`)
    .then(parseAxiosResponseMaybe)
    .catch(parseAxiosErrorMaybe);

type GetRemainingTime = { remainingTime: number };

export const resumeGame = (
  id: string
): Promise<Either<Error[], GetRemainingTime>> =>
  postRequest<GetRemainingTime>(`/game/${id}/resume`)
    .then(parseAxiosResponseEither)
    .catch(parseAxiosErrorEither<GetRemainingTime>)
    .then(extractData);

export const getRemainingTime = (): Promise<
  Either<Error[], GetRemainingTime>
> =>
  getRequest<GetRemainingTime>("/game/current/time")
    .then(parseAxiosResponseEither)
    .catch(parseAxiosErrorEither<GetRemainingTime>)
    .then(extractData);

export const getCurrentGame = (): Promise<Either<Error[], GetMaybeGame>> =>
  getRequest<GetMaybeGame>("/game/current")
    .then(parseAxiosResponseEither)
    .catch(parseAxiosErrorEither<GetMaybeGame>)
    .then(extractData);

export const stopGame = (id: string): Promise<Maybe<Error[]>> =>
  postRequest(`/game/${id}/stop`)
    .then(parseAxiosResponseMaybe)
    .catch(parseAxiosErrorMaybe);

export type GetEquipmentsState = { equipmentsState: EquipmentState[] };

export const getEquipmentsState = (): Promise<
  Either<Error[], GetEquipmentsState>
> =>
  getRequest<GetEquipmentsState>("/equipments/state")
    .then(parseAxiosResponseEither)
    .catch(parseAxiosErrorEither<GetEquipmentsState>)
    .then(extractData);
