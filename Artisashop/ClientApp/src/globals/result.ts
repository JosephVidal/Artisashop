import { error, Error } from "globals/error";
import { Either, Left, Maybe, Right, Some, None } from "monet";
import { AxiosError, AxiosResponse } from "axios";
import * as _ from "lodash/fp";

export interface ResultContent<T> {
  success: boolean;
  data?: T;
  errors?: Error[];
}

interface ErrorGouv {
  error?: string;
}

export const parseAxiosResponseEither = <T extends {}>(
  axiosResponse: AxiosResponse<ResultContent<T>>
): Either<Error[], Maybe<T>> => Right(Maybe.fromNull(axiosResponse.data.data));

export const parseAxiosResponseMaybe = (): Maybe<Error[]> => None();

export const parseAxiosErrorEither = <T extends {}>(
  axiosError: AxiosError<ResultContent<T>>
): Either<Error[], Maybe<T>> => {
  if (_.isNil(axiosError.response))
    return Left([error("error", axiosError.message)]);
  if (_.isNil(axiosError.response.data.errors))
    return Left([error("error", axiosError.message)]);
  return Left(axiosError.response.data.errors);
};

export const parseAxiosErrorMaybe = <T>(
  axiosError: AxiosError<ResultContent<T>>
): Maybe<Error[]> => {
  if (_.isNil(axiosError.response))
    return Some([error("error", axiosError.message)]);
  if (_.isNil(axiosError.response.data.errors))
    return Some([error("error", axiosError.message)]);
  return Some(axiosError.response.data.errors);
};

export const extractData = <T extends {}>(
  errorOrResult: Either<Error[], Maybe<T>>
): Either<Error[], T> =>
  errorOrResult.cata(
    (errors) => Left(errors),
    (maybeValue) =>
      maybeValue.cata(
        () => Left([error("key", "error.noData")]),
        (value) => Right(value)
      )
  );

export const handleGouvResponse = <T extends {}>(
  axiosResponse: AxiosResponse<T>
): Either<Error[], Maybe<T>> =>
  axiosResponse.data
    ? Right(Maybe.fromNull(axiosResponse.data))
    : Left([error("API-Gouv", "error.no-data")]);

export const handleGouvError = <T extends {}>(
  axiosError: AxiosError<ErrorGouv>
): Either<Error[], Maybe<T>> =>
  axiosError.response
    ? Left([
        error(
          "API-Gouv",
          axiosError.response.data.error || "error.bad-request"
        ),
      ])
    : Left([error("API-Gouv", axiosError.message || "error.bad-request")]);
