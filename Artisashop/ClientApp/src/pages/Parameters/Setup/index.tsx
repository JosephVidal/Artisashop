import React, { FC, useState, useEffect, ReactNode } from "react";
import { useTranslation } from "react-i18next";
import { Maybe, None, Some } from "monet";
import { ToastHandler } from "components/Toaster";
import Content from "components/Content";
import { SetState } from "globals/state";
import { Steps } from "primereact/steps";
import Settings from "pages/Parameters/Setup/Settings";
import { Calendar, defaultCalendar } from "models/openingHours";
import OpeningHoursForm from "pages/Parameters/OpeningHours/components/OpeningHoursForm";
import Confirmation from "pages/Parameters/Setup/Confirmation";
import Logo from "components/Logo";
import Button from "components/Button";
import * as _ from "lodash/fp";
import { ButtonsWrapper, LogoWrapper, StepsWrapper } from "./styles";
import { DaysWrapper } from "../OpeningHours/styles";

interface Props {
  toastHandler: ToastHandler;
  setSetupDone: SetState<boolean>;
}

const Setup: FC<Props> = ({ toastHandler, setSetupDone }) => {
  const [loading, setLoading] = useState<boolean>(true);
  const [step, setStep] = useState<number>(0);
  const [centerName, setCenterName] = useState<Maybe<string>>(None());
  const [defaultDuration, setDefaultDuration] = useState<Maybe<string>>(None());
  const [gameInterval, setGameInterval] = useState<Maybe<string>>(None());
  const [equipmentNumber, setEquipmentNumber] = useState<Maybe<string>>(None());
  const [vacationZone, setVacationZone] = useState<Maybe<string>>(None());
  const [holidayZone, setHolidayZone] = useState<Maybe<string>>(None());
  const [calendar, setCalendar] = useState<Calendar>(defaultCalendar);

  const { t } = useTranslation();

  const steps = [
    { label: t("parameters.configuration.step1") },
    { label: t("parameters.configuration.step2") },
    { label: t("parameters.configuration.step3") },
    { label: t("parameters.configuration.step4") },
    { label: t("parameters.configuration.step5") },
  ];

  const fetchIfExists = (
    storageKey: string,
    setStateMaybe?: SetState<Maybe<string>>,
    setStateCalendar: SetState<Calendar> = setCalendar,
    setStateStep: SetState<number> = setStep
  ): void => {
    const storageValue = localStorage.getItem(storageKey);
    if (!_.isNil(storageValue))
      switch (storageKey) {
        case "settings.calendar":
          setStateCalendar(JSON.parse(storageValue) as Calendar);
          break;
        case "settings.currentStep":
          setStateStep(parseInt(storageValue, 10));
          break;
        default:
          return setStateMaybe && setStateMaybe(Some(storageValue));
      }
    return undefined;
  };

  const fetchConfiguration = (): void => {
    fetchIfExists("settings.centerName", setCenterName);
    fetchIfExists("settings.defaultDuration", setDefaultDuration);
    fetchIfExists("settings.gameInterval", setGameInterval);
    fetchIfExists("settings.equipmentNumber", setEquipmentNumber);
    fetchIfExists("settings.vacationZone", setVacationZone);
    fetchIfExists("settings.holidayZone", setHolidayZone);
    fetchIfExists("settings.calendar");
    fetchIfExists("settings.currentStep");
    setLoading(false);
  };

  useEffect(() => {
    fetchConfiguration();
  }, []);

  const setInLocalStorage = (
    storageKey: string,
    item: string | Calendar
  ): void =>
    storageKey === "settings.calendar"
      ? localStorage.setItem(storageKey, JSON.stringify(item))
      : localStorage.setItem(storageKey, item as string);

  const changeStep = (value: number) => {
    const storedStep = localStorage.getItem("settings.currentStep");
    switch (step) {
      case 0:
        if (centerName.isSome())
          setInLocalStorage("settings.centerName", centerName.some());
        if (defaultDuration.isSome())
          setInLocalStorage("settings.defaultDuration", defaultDuration.some());
        if (gameInterval.isSome())
          setInLocalStorage("settings.gameInterval", gameInterval.some());
        if (equipmentNumber.isSome())
          setInLocalStorage("settings.equipmentNumber", equipmentNumber.some());
        if (vacationZone.isSome())
          setInLocalStorage("settings.vacationZone", vacationZone.some());
        if (holidayZone.isSome())
          setInLocalStorage("settings.holidayZone", holidayZone.some());
        break;
      default:
        setInLocalStorage("settings.calendar", calendar);
    }
    if (_.isNil(storedStep) || value > parseInt(storedStep, 10))
      setInLocalStorage("settings.currentStep", value.toString());
    return setStep(value);
  };

  const renderButtons = (
    first: boolean,
    confirmation: boolean,
    onClickFirst: () => void,
    onClickSecond: () => void,
    allCompleted?: boolean
  ): ReactNode => (
    <ButtonsWrapper>
      <Button
        label={t("global.previous")}
        type="secondary"
        disabled={first}
        onClick={onClickFirst}
      />
      <Button
        label={confirmation ? t("global.confirm") : t("global.next")}
        type={confirmation ? "primary" : "secondary"}
        disabled={confirmation ? !allCompleted : false}
        onClick={onClickSecond}
      />
    </ButtonsWrapper>
  );

  const renderForm = (): ReactNode => {
    switch (step) {
      case 0:
        return (
          <Settings
            centerName={centerName}
            defaultDuration={defaultDuration}
            gameInterval={gameInterval}
            equipmentNumber={equipmentNumber}
            vacationZone={vacationZone}
            holidayZone={holidayZone}
            setCenterName={setCenterName}
            setDefaultDuration={setDefaultDuration}
            setGameInterval={setGameInterval}
            setEquipmentNumber={setEquipmentNumber}
            setVacationZone={setVacationZone}
            setHolidayZone={setHolidayZone}
            setStep={changeStep}
            renderButtons={renderButtons}
          />
        );
      case 1:
        return (
          <DaysWrapper>
            <OpeningHoursForm
              period="schooling-days"
              setOpeningHours={setCalendar}
              openingHours={calendar.schoolingDays}
              toastHandler={toastHandler}
              showSubmit={false}
            />
            {renderButtons(
              false,
              false,
              () => changeStep(step - 1),
              () => changeStep(step + 1)
            )}
          </DaysWrapper>
        );
      case 2:
        return (
          <DaysWrapper>
            <OpeningHoursForm
              period="school-vacation"
              setOpeningHours={setCalendar}
              openingHours={calendar.schoolVacation}
              toastHandler={toastHandler}
              showSubmit={false}
            />
            {renderButtons(
              false,
              false,
              () => changeStep(step - 1),
              () => changeStep(step + 1)
            )}
          </DaysWrapper>
        );
      case 3:
        return (
          <DaysWrapper>
            <OpeningHoursForm
              period="holiday"
              setOpeningHours={setCalendar}
              openingHours={calendar.holiday}
              toastHandler={toastHandler}
              showSubmit={false}
            />
            {renderButtons(
              false,
              false,
              () => changeStep(step - 1),
              () => changeStep(step + 1)
            )}
          </DaysWrapper>
        );
      default:
        return (
          <Confirmation
            toastHandler={toastHandler}
            centerName={centerName}
            defaultDuration={defaultDuration}
            gameInterval={gameInterval}
            equipmentNumber={equipmentNumber}
            vacationZone={vacationZone}
            holidayZone={holidayZone}
            calendar={calendar}
            setSetupDone={setSetupDone}
            setStep={setStep}
            renderButtons={renderButtons}
          />
        );
    }
  };

  return (
    <Content
      title={t("parameters.configuration.initial-setup")}
      loading={loading}
      centered
    >
      <LogoWrapper>
        <Logo type="light" withText={false} />
      </LogoWrapper>
      <StepsWrapper>
        <Steps
          model={steps}
          activeIndex={step}
          onSelect={(e) => changeStep(e.index)}
          readOnly={false}
        />
      </StepsWrapper>
      {!loading && renderForm()}
    </Content>
  );
};

export default Setup;
