import { ToastHandler } from "components/Toaster";
import { Equipment } from "models/equipment";
import { SetState } from "globals/state";
import { GetEquipments, listEquipments } from "equipments/api";
import { Either, Maybe, Some, None } from "monet";
import { Error } from "globals/error";
import * as _ from "lodash/fp";

export const getEquipmentsNumber = (
  toaster: ToastHandler,
  setEquipmentsNumber: SetState<Maybe<string>>
): Promise<Maybe<string>> =>
  listEquipments()
    .then(setEquipmentsQuantity(toaster, setEquipmentsNumber))
    .catch(setEquipmentsQuantity(toaster, setEquipmentsNumber));

export const setEquipmentsQuantity =
  (toaster: ToastHandler, setEquipmentsNumber: SetState<Maybe<string>>) =>
  (errorsOrEquipments: Either<Error[], GetEquipments>): Maybe<string> => {
    errorsOrEquipments.cata(toaster.showErrors, (equipmentsList) =>
      setEquipmentsNumber(Some(_.toString(equipmentsList.equipments.length)))
    );

    return errorsOrEquipments.cata(
      () => None(),
      (equipmentsList) => Some(_.toString(equipmentsList.equipments.length))
    );
  };

export const retrieveEquipments = (
  toaster: ToastHandler,
  equipments: Equipment[],
  setEquipments: SetState<Equipment[]>
): Promise<Equipment[]> => {
  if (equipments.length <= 0) {
    return listEquipments()
      .then(saveEquipments(toaster, setEquipments))
      .catch(saveEquipments(toaster, setEquipments));
  }

  return Promise.resolve(equipments);
};

const saveEquipments =
  (toaster: ToastHandler, setEquipments: SetState<Equipment[]>) =>
  (errorsOrEquipments: Either<Error[], GetEquipments>): Equipment[] => {
    errorsOrEquipments.cata(
      (errors) => toaster.showErrors(errors),
      (eL) => setEquipments(eL.equipments)
    );

    return errorsOrEquipments.cata(
      () => [] as Equipment[],
      (c) => c.equipments
    );
  };
