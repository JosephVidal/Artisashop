import React, { FC, ReactNode } from "react";
import { Maybe } from "monet";
import { SetState } from "globals/state";
import { Calendar, OpeningHours } from "models/openingHours";
import { useTranslation } from "react-i18next";
import { ScrollPanel } from "primereact/scrollpanel";
import { ToastHandler } from "components/Toaster";
import { TFunction } from "i18next";
import { setConfigParameter } from "configurations/api";
import { generateEquipments } from "equipments/api";
import { updateOpeningHours } from "openingHours/api";
import { Error } from "globals/error";
import * as _ from "lodash/fp";
import {
  Wrapper,
  ConfirmationTitle,
  InlineTextLeft,
  InlineTextRight,
  InlineTextWrapper,
  TextLight,
} from "./styles";

interface Props {
  toastHandler: ToastHandler;
  centerName: Maybe<string>;
  defaultDuration: Maybe<string>;
  gameInterval: Maybe<string>;
  equipmentNumber: Maybe<string>;
  vacationZone: Maybe<string>;
  holidayZone: Maybe<string>;
  calendar: Calendar;
  setSetupDone: SetState<boolean>;
  setStep: SetState<number>;
  renderButtons: (
    first: boolean,
    confirmation: boolean,
    onClickFirst: () => void,
    onClickSecond: () => void,
    allCompleted?: boolean
  ) => ReactNode;
}

const Confirmation: FC<Props> = ({
  toastHandler,
  centerName,
  defaultDuration,
  gameInterval,
  equipmentNumber,
  vacationZone,
  holidayZone,
  calendar,
  setSetupDone,
  setStep,
  renderButtons,
}) => {
  const { t } = useTranslation();

  const renderOpeningHours = (openingHours: OpeningHours): ReactNode => {
    if (openingHours.closed || !openingHours.hours)
      return <>{t("parameters.opening-hours.closed")}</>;
    return openingHours.hours.map((hours, index) => (
      <>
        {index !== 0 ? (
          <TextLight> {t("parameters.configuration.and")}</TextLight>
        ) : (
          <>{t("parameters.opening-hours.opening")}</>
        )}
        <TextLight> {t("parameters.opening-hours.start")} </TextLight>
        {hours.openingTime}
        <TextLight> {t("parameters.opening-hours.end")} </TextLight>
        {hours.closingTime}
      </>
    ));
  };
  return (
    <Wrapper>
      <ScrollPanel>
        <ConfirmationTitle>
          {t("parameters.configuration.confirmation-title")}
        </ConfirmationTitle>
        <InlineTextWrapper>
          <InlineTextLeft>
            {t("parameters.configuration.center-name-label")}
          </InlineTextLeft>
          <InlineTextRight>{centerName}</InlineTextRight>
        </InlineTextWrapper>
        <InlineTextWrapper>
          <InlineTextLeft>
            {t("parameters.configuration.default-duration-label")}
          </InlineTextLeft>
          <InlineTextRight>
            {defaultDuration} {t("game.duration-unit")}
          </InlineTextRight>
        </InlineTextWrapper>
        <InlineTextWrapper>
          <InlineTextLeft>
            {t("parameters.configuration.game-interval-label")}
          </InlineTextLeft>
          <InlineTextRight>
            {gameInterval} {t("game.duration-unit")}
          </InlineTextRight>
        </InlineTextWrapper>
        <InlineTextWrapper>
          <InlineTextLeft>
            {t("parameters.configuration.equipment-number-label")}
          </InlineTextLeft>
          <InlineTextRight>{equipmentNumber}</InlineTextRight>
        </InlineTextWrapper>
        <InlineTextWrapper>
          <InlineTextLeft>
            {t("parameters.configuration.vacation-zone-label")}
          </InlineTextLeft>
          <InlineTextRight>{vacationZone}</InlineTextRight>
        </InlineTextWrapper>
        {vacationZone.orSome("") === "Zone B" && (
          <InlineTextWrapper>
            <InlineTextLeft>
              {t("parameters.configuration.holiday-zone-label")} :
            </InlineTextLeft>
            <InlineTextRight>
              {holidayZone.orSome("") === "alsace-moselle"
                ? t("global.yes")
                : t("global.no")}
            </InlineTextRight>
          </InlineTextWrapper>
        )}

        <ConfirmationTitle marginTop>
          {t("parameters.configuration.confirmation-opening-hours")}
        </ConfirmationTitle>
        {calendar.schoolingDays.map((openingHours) => (
          <InlineTextWrapper>
            <InlineTextLeft>
              {`${t(
                `parameters.opening-hours.week-day.${openingHours.day
                  .toString()
                  .toLowerCase()}`
              )} `}
              :
            </InlineTextLeft>
            <InlineTextRight>
              {renderOpeningHours(openingHours)}
            </InlineTextRight>
          </InlineTextWrapper>
        ))}

        <ConfirmationTitle marginTop>
          {t("parameters.configuration.confirmation-vacations")}
        </ConfirmationTitle>
        {calendar.schoolVacation.map((openingHours) => (
          <InlineTextWrapper>
            <InlineTextLeft>
              {`${t(
                `parameters.opening-hours.week-day.${openingHours.day
                  .toString()
                  .toLowerCase()}`
              )} `}
              :
            </InlineTextLeft>
            <InlineTextRight>
              {renderOpeningHours(openingHours)}
            </InlineTextRight>
          </InlineTextWrapper>
        ))}

        <ConfirmationTitle marginTop>
          {t("parameters.configuration.confirmation-holidays")}
        </ConfirmationTitle>
        <InlineTextWrapper>
          <InlineTextLeft>
            {`${t(
              `parameters.opening-hours.week-day.${calendar.holiday.day
                .toString()
                .toLowerCase()}`
            )} `}
            :
          </InlineTextLeft>
          <InlineTextRight>
            {renderOpeningHours(calendar.holiday)}
          </InlineTextRight>
        </InlineTextWrapper>

        {renderButtons(
          false,
          true,
          () => setStep((prevState) => prevState - 1),
          () =>
            onConfirm(
              toastHandler,
              t,
              setSetupDone,
              centerName.some(),
              defaultDuration.some(),
              gameInterval.some(),
              equipmentNumber.some(),
              vacationZone.some(),
              holidayZone.some(),
              calendar
            ),
          centerName.isSome() &&
            defaultDuration.isSome() &&
            gameInterval.isSome() &&
            equipmentNumber.isSome() &&
            vacationZone.isSome() &&
            holidayZone.isSome()
        )}
      </ScrollPanel>
    </Wrapper>
  );
};

const onConfirm = (
  toastHandler: ToastHandler,
  t: TFunction,
  setSetupDone: SetState<boolean>,
  centerName: string,
  defaultDuration: string,
  gameInterval: string,
  equipmentNumber: string,
  vacationZone: string,
  holidayZone: string,
  calendar: Calendar
) => {
  Promise.all([
    setConfigParameter("center-name", centerName),
    setConfigParameter("default-duration", defaultDuration),
    setConfigParameter("game-Interval", gameInterval),
    setConfigParameter("vacation-zone", vacationZone),
    setConfigParameter("holiday-zone", holidayZone),
    generateEquipments(_.toInteger(equipmentNumber)),
    updateOpeningHours("schooling-days", calendar.schoolingDays),
    updateOpeningHours("school-vacation", calendar.schoolVacation),
    updateOpeningHours("holiday", [calendar.holiday]),
  ]).then((maybeErrorsArray) =>
    showErrorOrSuccess(maybeErrorsArray, toastHandler, t, setSetupDone)
  );
};

const showErrorOrSuccess = (
  maybeErrorsArray: Maybe<Error[]>[],
  toaster: ToastHandler,
  t: TFunction,
  setSetupDone: SetState<boolean>
): void => {
  if (_.isEmpty(maybeErrorsArray)) {
    setSetupDone(true);
    setConfigParameter("setup-completed", "1").then((maybeErrors) =>
      maybeErrors.cata(
        () => {
          removeSavedValues();
          toaster.showSuccess(t("parameters.configuration.success"));
        },
        (errors) => toaster.showErrors(errors)
      )
    );
  } else {
    maybeErrorsArray[0].cata(
      () =>
        showErrorOrSuccess(_.tail(maybeErrorsArray), toaster, t, setSetupDone),
      toaster.showErrors
    );
  }
};

const removeSavedValues = () => {
  localStorage.removeItem("settings.centerName");
  localStorage.removeItem("settings.defaultDuration");
  localStorage.removeItem("settings.gameInterval");
  localStorage.removeItem("settings.equipmentNumber");
  localStorage.removeItem("settings.vacationZone");
  localStorage.removeItem("settings.holidayZone");
  localStorage.removeItem("settings.calendar");
  localStorage.removeItem("settings.currentStep");
};

export default Confirmation;
