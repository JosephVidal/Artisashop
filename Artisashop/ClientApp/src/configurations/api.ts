import { Either, Maybe } from "monet";
import { Error } from "globals/error";
import {
  parseAxiosResponseEither,
  parseAxiosErrorEither,
  parseAxiosResponseMaybe,
  parseAxiosErrorMaybe,
  extractData,
} from "globals/result";
import { ConfigParameter } from "models/config";
import { getRequest, putRequest } from "globals/api";

export const getConfigParameter = (
  key: string
): Promise<Either<Error[], ConfigParameter>> =>
  getRequest<ConfigParameter>(`/config/${key}`)
    .then(parseAxiosResponseEither)
    .catch(parseAxiosErrorEither<ConfigParameter>)
    .then(extractData);

export const setConfigParameter = (
  key: string,
  value: string
): Promise<Maybe<Error[]>> =>
  putRequest(`config/${key}`, { value })
    .then(parseAxiosResponseMaybe)
    .catch(parseAxiosErrorMaybe);
