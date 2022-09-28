import React, { useEffect, useState } from "react";
import { DateSelectArg } from "@fullcalendar/react";
import { useTranslation } from "react-i18next";
import Button from "components/Button";
import Checkbox from "components/Checkbox";
import { SetState } from "globals/state";
import TimePicker from "components/TimePicker";
import {
  dateFromTime,
  dateToLocalIso,
  ISOToString,
  timeFormat,
} from "globals/date";
import {
  AddOrRemoveWrapper,
  HoursWrapper,
  HourText,
  TimePickerWrapper,
  TimeWrapper,
} from "pages/Parameters/OpeningHours/components/DayContent/styles";
import { AiOutlinePlus } from "react-icons/ai";
import { RiSubtractFill } from "react-icons/ri";
import { CalendarEvent, DayOff, DayOffHour } from "models/dayOff";
import { EventClickArg } from "@fullcalendar/core";
import { createDaysOff, deleteDaysOff, editDaysOff } from "daysOff/api";
import { ToastHandler } from "components/Toaster";
import { TFunction } from "i18next";
import { Maybe } from "monet";
import { Error } from "globals/error";
import {
  DayOffFormWrapper,
  CheckBoxWrapper,
  AllDayText,
  ButtonsWrapper,
} from "./styles";

interface Props {
  toastHandler: ToastHandler;
  setEvents: SetState<CalendarEvent[]>;
  daysOffToEvents: (t: TFunction, daysOff: DayOff[]) => CalendarEvent[];
  data: DateSelectArg | EventClickArg | null;
  type: "date" | "event" | "new" | null;
  dayOff: DayOff;
  setDayOff: SetState<DayOff>;
}

const DayOffForm: React.FunctionComponent<Props> = ({
  toastHandler,
  setEvents,
  daysOffToEvents,
  data,
  type,
  dayOff,
  setDayOff,
}) => {
  const [severalDays, setSeveralDays] = useState<boolean>(false);
  const { t } = useTranslation();

  useEffect(() => {
    if (type === "new" || type === "date") {
      const dateSelectArg = data as DateSelectArg;
      if (dateSelectArg?.start) {
        const startCompare = dateSelectArg.start;
        startCompare?.setDate(startCompare.getDate() + 1);
        setSeveralDays(startCompare?.getTime() !== dateSelectArg.end.getTime());
        startCompare?.setDate(startCompare.getDate() - 1);
      }
    }
  });

  return (
    <DayOffFormWrapper>
      <CheckBoxWrapper>
        <Checkbox
          onChange={() => onChangeAllDay(setDayOff, dayOff, severalDays)}
          checked={dayOff.allDay}
        />
        <AllDayText>{t("parameters.days-off.overlay.all-day")}</AllDayText>
      </CheckBoxWrapper>

      {!dayOff.allDay &&
        dayOff.closingHours &&
        dayOff.closingHours.map((hour, index) => (
          <HoursWrapper key={index}>
            <TimeWrapper>
              <HourText>{t("parameters.opening-hours.start")}</HourText>

              <TimePickerWrapper>
                <TimePicker
                  time={dateFromTime(hour.closingHour)}
                  onSelectTime={onTimeChange(setDayOff, dayOff, index, true)}
                />
              </TimePickerWrapper>
            </TimeWrapper>

            <TimeWrapper>
              <HourText>{t("parameters.opening-hours.end")}</HourText>

              <TimePickerWrapper>
                <TimePicker
                  time={dateFromTime(hour.reopeningHour)}
                  onSelectTime={onTimeChange(setDayOff, dayOff, index)}
                />
              </TimePickerWrapper>
            </TimeWrapper>

            <AddOrRemoveWrapper>
              {dayOff.closingHours &&
                index === dayOff.closingHours.length - 1 && (
                  <AiOutlinePlus
                    onClick={() => addHoursRow(setDayOff, dayOff)}
                  />
                )}
              {dayOff.closingHours &&
                index === dayOff.closingHours.length - 2 && (
                  <RiSubtractFill
                    onClick={() => removeOpeningHoursRow(setDayOff, dayOff)}
                  />
                )}
            </AddOrRemoveWrapper>
          </HoursWrapper>
        ))}

      <ButtonsWrapper>
        {type !== "new" && (
          <Button
            label={t("parameters.opening-hours.delete-label")}
            type="danger"
            size="medium"
            onClick={() =>
              severalDays
                ? onDeleteSeveralDaysOff(
                    toastHandler,
                    t,
                    daysOffToEvents,
                    setEvents,
                    data as DateSelectArg
                  )
                : onDeleteDayOff(
                    toastHandler,
                    t,
                    daysOffToEvents,
                    setEvents,
                    type === "date"
                      ? (data as DateSelectArg).startStr
                      : (data as EventClickArg).event.startStr
                  )
            }
            expand
          />
        )}
        <Button
          label={t("parameters.opening-hours.submit-label")}
          type="dark"
          onClick={() => {
            if (severalDays)
              onSubmitSeveralDaysOff(
                toastHandler,
                t,
                daysOffToEvents,
                setEvents,
                data as DateSelectArg
              );
            else if (type === "new")
              onSubmitDayOff(
                toastHandler,
                t,
                daysOffToEvents,
                setEvents,
                dayOff
              );
            else
              onEditDayOff(toastHandler, t, daysOffToEvents, setEvents, dayOff);
          }}
          expand
        />
      </ButtonsWrapper>
    </DayOffFormWrapper>
  );
};

const onChangeAllDay = (
  setDayOff: SetState<DayOff>,
  dayOff: DayOff,
  severalDays: boolean
) => {
  if (!severalDays) {
    setDayOff({
      ...dayOff,
      allDay: !dayOff.allDay,
      closingHours: !dayOff.allDay
        ? undefined
        : [
            {
              closingHour: "00:00",
              reopeningHour: "00:00",
            },
          ],
    });
  }
};

const addHoursRow = (setDayOff: SetState<DayOff>, dayOff: DayOff) => {
  setDayOff({
    ...dayOff,
    closingHours: [
      ...(dayOff.closingHours ?? []),
      {
        closingHour: "00:00",
        reopeningHour: "00:00",
      } as DayOffHour,
    ],
  });

  return dayOff;
};

const removeOpeningHoursRow = (setDayOff: SetState<DayOff>, dayOff: DayOff) => {
  setDayOff({
    ...dayOff,
    closingHours: dayOff.closingHours?.slice(0, dayOff.closingHours.length - 1),
  });
};

const onTimeChange =
  (
    setDayOff: SetState<DayOff>,
    dayOff: DayOff,
    index: number,
    isClosing: boolean = false
  ) =>
  (newTime: Date) =>
    setDayOff({
      ...dayOff,
      closingHours: dayOff.closingHours?.map((hour, i) =>
        i === index ? changeCorrectHour(hour, newTime, isClosing) : hour
      ),
    });

const changeCorrectHour = (
  hour: DayOffHour,
  newTime: Date,
  isClosing: boolean
): DayOffHour =>
  isClosing
    ? {
        closingHour: timeFormat(newTime, "fr"),
        reopeningHour: hour.reopeningHour,
      }
    : {
        closingHour: hour.closingHour,
        reopeningHour: timeFormat(newTime, "fr"),
      };

const saveNewEvents = (
  t: TFunction,
  daysOffToEvents: (t: TFunction, daysOff: DayOff[]) => CalendarEvent[],
  setEvents: SetState<CalendarEvent[]>,
  daysOff: DayOff[]
) => {
  setEvents((prevState) => prevState.concat(daysOffToEvents(t, daysOff)));
};

const onSubmitDayOff = (
  toaster: ToastHandler,
  t: TFunction,
  daysOffToEvents: (t: TFunction, daysOff: DayOff[]) => CalendarEvent[],
  setEvents: SetState<CalendarEvent[]>,
  dayOff: DayOff
) => {
  createDaysOff(dayOff)
    .then(saveDaysOffUpdate(toaster, t))
    .then((maybeErrors) =>
      maybeErrors.cata(
        () => saveNewEvents(t, daysOffToEvents, setEvents, [dayOff]),
        () => {}
      )
    );
};

const onSubmitSeveralDaysOff = (
  toaster: ToastHandler,
  t: TFunction,
  daysOffToEvents: (t: TFunction, daysOff: DayOff[]) => CalendarEvent[],
  setEvents: SetState<CalendarEvent[]>,
  data: DateSelectArg
) => {
  const date = new Date(data.startStr);

  for (
    date;
    ISOToString(date.toISOString()) !== data.endStr;
    date.setDate(date.getDate() + 1)
  ) {
    const dayOff = {
      id: "",
      allDay: true,
      date: ISOToString(date.toISOString()),
      closingHours: undefined,
    };
    onSubmitDayOff(toaster, t, daysOffToEvents, setEvents, dayOff);
  }
};

const editEvent = (
  t: TFunction,
  daysOffToEvents: (t: TFunction, daysOff: DayOff[]) => CalendarEvent[],
  setEvents: SetState<CalendarEvent[]>,
  dayOff: DayOff
) => {
  setEvents((prevState) =>
    prevState.filter(
      (event) =>
        ISOToString(new Date(event.start).toISOString()) !== dayOff.date
    )
  );
  setEvents((prevState) => prevState.concat(daysOffToEvents(t, [dayOff])));
};

const onEditDayOff = (
  toaster: ToastHandler,
  t: TFunction,
  daysOffToEvents: (t: TFunction, daysOff: DayOff[]) => CalendarEvent[],
  setEvents: SetState<CalendarEvent[]>,
  dayOff: DayOff
) => {
  editDaysOff(dayOff)
    .then(saveDaysOffUpdate(toaster, t))
    .then((maybeErrors) =>
      maybeErrors.cata(
        () => editEvent(t, daysOffToEvents, setEvents, dayOff),
        () => {}
      )
    );
};

const removeEvent = (
  t: TFunction,
  daysOffToEvents: (t: TFunction, daysOff: DayOff[]) => CalendarEvent[],
  setEvents: SetState<CalendarEvent[]>,
  date: string
) => {
  setEvents((prevState) =>
    prevState.filter((event) => dateToLocalIso(new Date(event.start)) !== date)
  );
};

const onDeleteDayOff = (
  toaster: ToastHandler,
  t: TFunction,
  daysOffToEvents: (t: TFunction, daysOff: DayOff[]) => CalendarEvent[],
  setEvents: SetState<CalendarEvent[]>,
  date: string
) => {
  const localDate = date.length > 10 ? dateToLocalIso(new Date(date)) : date;
  deleteDaysOff(localDate)
    .then(saveDaysOffUpdate(toaster, t))
    .then((maybeErrors) =>
      maybeErrors.cata(
        () => removeEvent(t, daysOffToEvents, setEvents, localDate),
        () => {}
      )
    );
};

const onDeleteSeveralDaysOff = (
  toaster: ToastHandler,
  t: TFunction,
  daysOffToEvents: (t: TFunction, daysOff: DayOff[]) => CalendarEvent[],
  setEvents: SetState<CalendarEvent[]>,
  data: DateSelectArg
) => {
  const date = new Date(data.startStr);

  for (
    date;
    ISOToString(date.toISOString()) !== data.endStr;
    date.setDate(date.getDate() + 1)
  )
    onDeleteDayOff(
      toaster,
      t,
      daysOffToEvents,
      setEvents,
      ISOToString(date.toISOString())
    );
};

const saveDaysOffUpdate =
  (toaster: ToastHandler, t: TFunction) => (maybeErrors: Maybe<Error[]>) => {
    maybeErrors.cata(
      () => toaster.showSuccess(t("success.days-off")),
      toaster.showErrors
    );
    return maybeErrors;
  };

export default DayOffForm;
