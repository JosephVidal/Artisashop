import React, { FC, ReactNode } from "react";
import { Maybe, Some } from "monet";
import * as _ from "lodash/fp";
import InputInline from "components/InputInline";
import { SetState } from "globals/state";
import DropdownInline from "components/DropdownInline";
import CheckboxInline from "components/CheckboxInline";

interface Props {
  centerName: Maybe<string>;
  defaultDuration: Maybe<string>;
  gameInterval: Maybe<string>;
  equipmentNumber: Maybe<string>;
  vacationZone: Maybe<string>;
  holidayZone: Maybe<string>;
  setCenterName: SetState<Maybe<string>>;
  setDefaultDuration: SetState<Maybe<string>>;
  setGameInterval: SetState<Maybe<string>>;
  setEquipmentNumber: SetState<Maybe<string>>;
  setVacationZone: SetState<Maybe<string>>;
  setHolidayZone: SetState<Maybe<string>>;
  setStep: (value: number) => void;
  renderButtons: (
    first: boolean,
    confirmation: boolean,
    onClickFirst: () => void,
    onClickSecond: () => void
  ) => ReactNode;
}

const Settings: FC<Props> = ({
  centerName,
  defaultDuration,
  gameInterval,
  equipmentNumber,
  vacationZone,
  holidayZone,
  setCenterName,
  setDefaultDuration,
  setGameInterval,
  setEquipmentNumber,
  setVacationZone,
  setHolidayZone,
  setStep,
  renderButtons,
}) => {
  const vacationZones = [
    { label: "Zone A", value: "Zone A" },
    { label: "Zone B", value: "Zone B" },
    { label: "Zone C", value: "Zone C" },
  ];

  const isIntervalTooShort: boolean =
    _.subtract(
      _.toInteger(gameInterval.orSome("11")),
      _.toInteger(defaultDuration.orSome("0"))
    ) <= 10;

  return (
    <>
      <InputInline
        type="text"
        label="parameters.configuration.center-name-label"
        value={centerName}
        onChange={(e) => setCenterName(Some(e.target.value))}
        isCentered
        labelSize={18}
      />

      <InputInline
        type="minmax"
        label="parameters.configuration.default-duration-label"
        suffix="game.duration-unit"
        value={defaultDuration}
        onValueChange={(e) => setDefaultDuration(Some(_.toString(e.value)))}
        isCentered
        labelSize={18}
      />

      <InputInline
        type="minmax"
        label="parameters.configuration.game-interval-label"
        suffix="game.duration-unit"
        value={gameInterval}
        onValueChange={(e) => setGameInterval(Some(_.toString(e.value)))}
        isCentered
        withWarningMessage={isIntervalTooShort}
        warningMessage="parameters.configuration.interval-warning"
        labelSize={18}
      />

      <InputInline
        type="minmax"
        max={32}
        label="parameters.configuration.equipment-number-label"
        value={equipmentNumber}
        onValueChange={(e) => setEquipmentNumber(Some(_.toString(e.value)))}
        isCentered
        labelSize={18}
      />

      <DropdownInline
        label="parameters.configuration.vacation-zone-label"
        value={vacationZone}
        options={vacationZones}
        optionLabel="name"
        onChange={(e) => {
          if (e.value !== "Zone B") setHolidayZone(Some("metropole"));
          setVacationZone(Some(e.value));
        }}
        labelSize={18}
        isCentered
      />

      {vacationZone.orSome("") === "Zone B" && (
        <CheckboxInline
          label="parameters.configuration.holiday-zone-label"
          checked={holidayZone.orSome("") === "alsace-moselle"}
          onChange={(e) =>
            setHolidayZone(Some(e.checked ? "alsace-moselle" : "metropole"))
          }
          labelSize={18}
          isCentered
        />
      )}

      {renderButtons(
        true,
        false,
        () => () => setStep(0),
        () => setStep(1)
      )}
    </>
  );
};

export default Settings;
