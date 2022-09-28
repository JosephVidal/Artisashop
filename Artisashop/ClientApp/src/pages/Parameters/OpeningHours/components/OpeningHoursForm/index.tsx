import React from "react";
import { useTranslation } from "react-i18next";
import {
  Calendar,
  CalendarName,
  OpeningHours as OpeningHoursModel,
} from "models/openingHours";
import { ToastHandler } from "components/Toaster";
import {
  OpeningHoursButtonWrapper,
  OpeningText,
  OpeningTextWrapper,
} from "pages/Parameters/OpeningHours/styles";
import { ScrollPanel } from "primereact/scrollpanel";
import Button from "components/Button";
import { SetState } from "globals/state";
import { TFunction } from "i18next";
import * as _ from "lodash/fp";
import { updateOpeningHours } from "openingHours/api";
import { Maybe } from "monet";
import { Error } from "globals/error";
import DayContent from "../DayContent";

interface Props {
  toastHandler: ToastHandler;
  period: CalendarName;
  openingHours: OpeningHoursModel[] | OpeningHoursModel;
  setOpeningHours: SetState<Calendar>;
  showSubmit?: boolean;
}

const OpeningHoursForm: React.FunctionComponent<Props> = ({
  toastHandler,
  period,
  openingHours,
  setOpeningHours,
  showSubmit,
}) => {
  const { t } = useTranslation();

  return (
    <>
      <OpeningTextWrapper>
        <OpeningText>{t("parameters.opening-hours.opening")}</OpeningText>

        <OpeningText>{t("parameters.opening-hours.closing")}</OpeningText>
      </OpeningTextWrapper>

      {_.isArray(openingHours) ? (
        <ScrollPanel>
          {openingHours.map(
            (hours) =>
              hours.day !== "HOLIDAY" && (
                <DayContent
                  key={hours.day}
                  toaster={toastHandler}
                  openingHours={hours}
                  onOpeningHoursChange={onOpeningHoursChange(
                    openingHours,
                    setOpeningHours,
                    period
                  )}
                />
              )
          )}
        </ScrollPanel>
      ) : (
        <ScrollPanel>
          <DayContent
            key="HOLIDAY"
            toaster={toastHandler}
            openingHours={openingHours}
            onOpeningHoursChange={onOpeningHoursChange(
              openingHours,
              setOpeningHours,
              period
            )}
          />
        </ScrollPanel>
      )}

      {showSubmit && (
        <OpeningHoursButtonWrapper>
          <Button
            label={t("parameters.opening-hours.submit-label")}
            type="primary"
            size="large"
            onClick={onSubmitOpeningHours(
              openingHours,
              period,
              toastHandler,
              t
            )}
            expand
          />
        </OpeningHoursButtonWrapper>
      )}
    </>
  );
};

const onOpeningHoursChange =
  (
    openingHours: OpeningHoursModel[] | OpeningHoursModel,
    setOpeningHours: SetState<Calendar>,
    period: CalendarName
  ) =>
  (newOpeningHours: OpeningHoursModel) => {
    switch (period) {
      case "schooling-days":
        return setOpeningHours(
          (prevState) =>
            ({
              ...prevState,
              schoolingDays: (openingHours as OpeningHoursModel[]).map(
                (opHours) =>
                  opHours.day === newOpeningHours.day
                    ? newOpeningHours
                    : opHours
              ),
            } as Calendar)
        );
      case "school-vacation":
        return setOpeningHours(
          (prevState) =>
            ({
              ...prevState,
              schoolVacation: (openingHours as OpeningHoursModel[]).map(
                (opHours) =>
                  opHours.day === newOpeningHours.day
                    ? newOpeningHours
                    : opHours
              ),
            } as Calendar)
        );
      default:
        return setOpeningHours(
          (prevState) =>
            ({
              ...prevState,
              holiday: newOpeningHours,
            } as Calendar)
        );
    }
  };

const onSubmitOpeningHours =
  (
    openingHours: OpeningHoursModel[] | OpeningHoursModel,
    calendar: CalendarName,
    toaster: ToastHandler,
    t: TFunction
  ) =>
  () => {
    updateOpeningHours(
      calendar,
      _.isArray(openingHours) ? openingHours : [openingHours]
    )
      .then(saveOpeningHoursUpdate(toaster, t))
      .catch(saveOpeningHoursUpdate(toaster, t));
  };

const saveOpeningHoursUpdate =
  (toaster: ToastHandler, t: TFunction) => (maybeErrors: Maybe<Error[]>) =>
    maybeErrors.cata(
      () => toaster.showSuccess(t("success.opening-hours")),
      toaster.showErrors
    );

OpeningHoursForm.defaultProps = {
  showSubmit: true,
};

export default OpeningHoursForm;
