import React from "react";
import { dateFromTime, timeFormat } from "globals/date";
import { useTranslation } from "react-i18next";
import Checkbox from "components/Checkbox";
import { Hour, OpeningHours } from "models/openingHours";
import TimePicker from "components/TimePicker";
import { ToastHandler } from "components/Toaster";
import { AiOutlinePlus } from "react-icons/ai";
import { RiSubtractFill } from "react-icons/ri";
import {
  AddOrRemoveWrapper,
  CheckboxWrapper,
  DayContentWrapper,
  DayInputsWrapper,
  DayTextWrapper,
  HoursWrapper,
  HourText,
  TimePickerWrapper,
  TimeWrapper,
} from "pages/Parameters/OpeningHours/components/DayContent/styles";

interface Props {
  toaster: ToastHandler;
  openingHours: OpeningHours;
  onOpeningHoursChange: (openingHours: OpeningHours) => void;
}

const DayContent: React.FunctionComponent<Props> = ({
  toaster,
  openingHours,
  onOpeningHoursChange,
}) => {
  const { t } = useTranslation();

  return (
    <DayContentWrapper>
      <DayTextWrapper>
        {t(
          `parameters.opening-hours.week-day.${openingHours.day
            .toString()
            .toLowerCase()}`
        )}
      </DayTextWrapper>

      <DayInputsWrapper>
        {!openingHours.closed &&
          openingHours.hours &&
          openingHours.hours.map((hour, index) => (
            <TimePickerTemplate
              key={`${openingHours.day}-${index}`}
              hour={hour}
              toaster={toaster}
              openingHours={openingHours}
              onOpeningHoursChange={onOpeningHoursChange}
              index={index}
            />
          ))}
      </DayInputsWrapper>

      <CheckboxWrapper>
        {t("parameters.opening-hours.closed")}
        <Checkbox
          onChange={() => onCloseDayChange(openingHours, onOpeningHoursChange)}
          checked={openingHours.closed}
        />
      </CheckboxWrapper>
    </DayContentWrapper>
  );
};

interface TimePickerTemplateProps {
  hour: Hour;
  index: number;
  openingHours: OpeningHours;
  onOpeningHoursChange: (openingHours: OpeningHours) => void;
  toaster: ToastHandler;
}

const TimePickerTemplate: React.FunctionComponent<TimePickerTemplateProps> = ({
  hour,
  index,
  openingHours,
  onOpeningHoursChange,
  toaster,
}) => {
  const { t } = useTranslation();

  return (
    <HoursWrapper>
      <TimeWrapper>
        <HourText>{t("parameters.opening-hours.start")}</HourText>

        <TimePickerWrapper>
          <TimePicker
            time={dateFromTime(hour.openingTime)}
            onSelectTime={onTimeChange(
              toaster,
              openingHours,
              onOpeningHoursChange,
              index,
              true
            )}
          />
        </TimePickerWrapper>
      </TimeWrapper>

      <TimeWrapper>
        <HourText>{t("parameters.opening-hours.end")}</HourText>

        <TimePickerWrapper>
          <TimePicker
            time={dateFromTime(hour.closingTime)}
            onSelectTime={onTimeChange(
              toaster,
              openingHours,
              onOpeningHoursChange,
              index
            )}
          />
        </TimePickerWrapper>
      </TimeWrapper>

      <AddOrRemoveWrapper>
        {openingHours.hours && index === openingHours.hours.length - 1 && (
          <AiOutlinePlus
            onClick={() => addHoursRow(openingHours, onOpeningHoursChange)}
          />
        )}
        {openingHours.hours && index === openingHours.hours.length - 2 && (
          <RiSubtractFill
            onClick={() =>
              removeOpeningHoursRow(openingHours, onOpeningHoursChange)
            }
          />
        )}
      </AddOrRemoveWrapper>
    </HoursWrapper>
  );
};

const onCloseDayChange = (
  newOpeningHours: OpeningHours,
  onOpeningHoursChange: (openingHours: OpeningHours) => void
) => {
  onOpeningHoursChange({
    ...newOpeningHours,
    hours: newOpeningHours.closed
      ? [
          {
            openingTime: "00:00",
            closingTime: "00:00",
          },
        ]
      : undefined,
    closed: !newOpeningHours.closed,
  });
};

const addHoursRow = (
  newOpeningHours: OpeningHours,
  onOpeningHoursChange: (openingHours: OpeningHours) => void
) => {
  onOpeningHoursChange({
    ...newOpeningHours,
    hours: [
      ...(newOpeningHours.hours ?? []),
      {
        openingTime: "00:00",
        closingTime: "00:00",
      } as Hour,
    ],
  });

  return newOpeningHours.hours;
};

const removeOpeningHoursRow = (
  newOpeningHours: OpeningHours,
  onOpeningHoursChange: (openingHours: OpeningHours) => void
) => {
  onOpeningHoursChange({
    ...newOpeningHours,
    hours: newOpeningHours.hours?.slice(0, newOpeningHours.hours.length - 1),
  });
};

const onTimeChange =
  (
    toaster: ToastHandler,
    openingHours: OpeningHours,
    onOpeningHoursChange: (openingHours: OpeningHours) => void,
    index: number,
    isOpening: boolean = false
  ) =>
  (newTime: Date) =>
    onOpeningHoursChange({
      ...openingHours,
      hours: openingHours.hours?.map((hour, i) =>
        i === index ? changeCorrectHour(hour, newTime, isOpening) : hour
      ),
    });

const changeCorrectHour = (
  hour: Hour,
  newTime: Date,
  isOpening: boolean
): Hour =>
  isOpening
    ? {
        openingTime: timeFormat(newTime, "fr"),
        closingTime: hour.closingTime,
      }
    : {
        openingTime: hour.openingTime,
        closingTime: timeFormat(newTime, "fr"),
      };

export default DayContent;
