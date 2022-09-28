import { Either, Maybe } from "monet";
import { Error } from "globals/error";
import { Equipment } from "models/equipment";
import {
  parseAxiosResponseEither,
  parseAxiosErrorEither,
  parseAxiosResponseMaybe,
  parseAxiosErrorMaybe,
  extractData,
} from "globals/result";
import { getRequest, putRequest, postRequest } from "globals/api";

export type GetEquipments = { equipments: Equipment[] };

export const listEquipments = (): Promise<Either<Error[], GetEquipments>> =>
  getRequest<GetEquipments>("/config/equipments")
    .then(parseAxiosResponseEither)
    .catch(parseAxiosErrorEither<GetEquipments>)
    .then(extractData);

export const activateEquipment = (
  letter: string,
  active: boolean
): Promise<Maybe<Error[]>> =>
  putRequest("/config/equipment/activate", {
    equipmentLetter: letter,
    active,
  })
    .then(parseAxiosResponseMaybe)
    .catch(parseAxiosErrorMaybe);

export const generateEquipments = (
  equipmentsToGenerateQuantity: number
): Promise<Maybe<Error[]>> =>
  postRequest(`/equipments/generate/${equipmentsToGenerateQuantity}`)
    .then(parseAxiosResponseMaybe)
    .catch(parseAxiosErrorMaybe);
