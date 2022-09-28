import React, { FC, useContext, useEffect, useState } from "react";
import EquipmentState from "components/EquipmentState";
import { useTranslation } from "react-i18next";
import { Either, Maybe } from "monet";
import { ToastHandler } from "components/Toaster";
import { Error } from "globals/error";
import { Log } from "models/logs";
import _ from "lodash/fp";
import { StoreContext } from "reducers/utils";
import {
  Equipment as EquipmentModel,
  EquipmentState as EquipmentStateModel,
} from "models/equipment";
import { Batteries } from "models/battery";
import { activateEquipment } from "equipments/api";
import Checkbox from "components/Checkbox";
import { GetEquipmentsState, getEquipmentsState } from "pages/Game/api";
import { EquipmentStateLog } from "reducers/logsReducer";
import { SetState } from "globals/state";
import { retrieveEquipments } from "equipments";
import Content from "components/Content";
import {
  EquipmentActivationCheckboxWrapper,
  EquipmentLetter,
  ParameterEquipment,
  ParameterWrapper,
} from "pages/Parameters/Equipments/styles";

interface Props {
  toastHandler: ToastHandler;
}

const Equipments: FC<Props> = ({ toastHandler }) => {
  const [equipments, setEquipments] = useState<EquipmentModel[]>([]);
  const [equipmentsState, setEquipmentsState] = useState<EquipmentStateModel[]>(
    []
  );
  const [loading, setLoading] = useState<boolean>(true);

  const { t } = useTranslation();

  const [{ logs }] = useContext(StoreContext);

  const lastBatteriesLog = Maybe.fromNull(
    _.last(logs.logsByType["batteries-info"]) as Log<Batteries>
  );

  useEffect(() => {
    retrieveEquipments(toastHandler, equipments, setEquipments).then((eq) => {
      retrieveEquipmentsState(
        toastHandler,
        equipmentsState,
        setEquipmentsState
      );

      if (eq.length > 0) setLoading(false);
    });
  }, []);

  useEffect(
    () =>
      updateEquipmentsState(
        logs.logsByType["player-headset-state"] as Log<EquipmentStateLog>[],
        setEquipmentsState
      ),
    [logs.logsByType["player-headset-state"]]
  );

  return (
    <Content title={t("parameters.equipments.title")} loading={loading}>
      <ParameterWrapper>
        {equipments.map((equipment) => (
          <ParameterEquipment key={equipment.letter}>
            <EquipmentLetter>{equipment.letter}</EquipmentLetter>

            <EquipmentState
              size="large"
              headsetConnected={
                equipmentsState.find((eS) => eS.letter === equipment.letter)
                  ?.headsetConnected || false
              }
              withPercentage
              equipmentBattery={lastBatteriesLog.flatMap((log) =>
                Maybe.fromNull(
                  log.data.batteriesInfo.find(
                    (battery) => battery.letter === equipment.letter
                  )
                )
              )}
            />

            <EquipmentActivationCheckbox
              toastHandler={toastHandler}
              equipment={equipment}
            />
          </ParameterEquipment>
        ))}
      </ParameterWrapper>
    </Content>
  );
};

const retrieveEquipmentsState = (
  toaster: ToastHandler,
  equipmentsState: EquipmentStateModel[],
  setEquipmentsState: SetState<EquipmentStateModel[]>
) => {
  if (equipmentsState.length <= 0) {
    getEquipmentsState()
      .then(saveEquipmentsState(toaster, equipmentsState, setEquipmentsState))
      .catch(saveEquipmentsState(toaster, equipmentsState, setEquipmentsState));
  }

  return Promise.resolve(equipmentsState);
};

const saveEquipmentsState =
  (
    toaster: ToastHandler,
    equipmentsState: EquipmentStateModel[],
    setEquipmentsState: SetState<EquipmentStateModel[]>
  ) =>
  (
    equipmentsStateOrErrors: Either<Error[], GetEquipmentsState>
  ): EquipmentStateModel[] => {
    equipmentsStateOrErrors.cata(
      (errors) => {
        toaster.showErrors(errors);
        setTimeout(() => {
          retrieveEquipmentsState(toaster, equipmentsState, setEquipmentsState);
        }, 2500);
      },
      (eS) => setEquipmentsState(eS.equipmentsState)
    );

    return equipmentsStateOrErrors.cata(
      () => [] as EquipmentStateModel[],
      (eS) => eS.equipmentsState
    );
  };

const updateEquipmentsState = (
  stateLogs: Log<EquipmentStateLog>[],
  setEquipmentsState: SetState<EquipmentStateModel[]>
) => {
  if (stateLogs.length === 0) return;

  const state = stateLogs[stateLogs.length - 1];

  if (state.type === "player-headset-state") {
    setEquipmentsState((prevState) =>
      _.map(
        (player) =>
          player.letter !== state.data.letter
            ? player
            : {
                ...player,
                headsetConnected: state.data.connected,
              },
        prevState
      )
    );
  }
};

interface EquipmentActivationCheckboxProps {
  equipment: EquipmentModel;
  toastHandler: ToastHandler;
}

const EquipmentActivationCheckbox: FC<EquipmentActivationCheckboxProps> = ({
  toastHandler,
  equipment,
}) => {
  const { t } = useTranslation();
  const [activated, setActivated] = useState<boolean>(equipment.activated);

  const onEquipmentStateChange = (newActivated: boolean) => {
    activateEquipment(equipment.letter, newActivated)
      .then(saveEquipmentActivation(newActivated))
      .catch(saveEquipmentActivation(newActivated));
  };

  const saveEquipmentActivation =
    (newActivated: boolean) => (errors: Maybe<Error[]>) =>
      errors.cata(() => setActivated(newActivated), toastHandler.showErrors);

  return (
    <EquipmentActivationCheckboxWrapper>
      <Checkbox
        id={equipment.letter}
        label={
          activated
            ? t("parameters.equipments.activated")
            : t("parameters.equipments.deactivated")
        }
        checked={activated}
        onChange={onEquipmentStateChange}
      />
    </EquipmentActivationCheckboxWrapper>
  );
};

export default Equipments;
