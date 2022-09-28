import React, { useEffect, useState } from "react";
import { DateSelectArg } from "@fullcalendar/react";
import {
  DayOffOverlayWrapper,
  TitleWrapper,
} from "pages/Parameters/DaysOff/components/dayOffOverlay/styles";
import { useTranslation } from "react-i18next";
import DayOffForm from "pages/Parameters/DaysOff/components/dayOffForm";
import { EventClickArg } from "@fullcalendar/core";
import { CalendarEvent, DayOff, DayOffHour } from "models/dayOff";
import { SetState } from "globals/state";
import { ToastHandler } from "components/Toaster";
import { dateToLocalIso } from "globals/date";
import { TFunction } from "i18next";

interface Props {
  toastHandler: ToastHandler;
  setEvents: SetState<CalendarEvent[]>;
  daysOffToEvents: (t: TFunction, daysOff: DayOff[]) => CalendarEvent[];
  data: DateSelectArg | EventClickArg | null;
  type: "date" | "event" | "new" | null;
  eventList: CalendarEvent[] | null;
}

const DayOffOverlay: React.FunctionComponent<Props> = ({
  toastHandler,
  setEvents,
  daysOffToEvents,
  data,
  type,
  eventList,
}) => {
  const [dayOff, setDayOff] = useState<DayOff>({
    id: "",
    date: "",
    allDay: true,
  });
  const [overlayType, setOverlayType] = useState<
    "date" | "event" | "new" | null
  >(type);
  const { t } = useTranslation();

  useEffect(() => {
    setOverlayType(type);
    if (type === "event")
      getEventsById(setDayOff, data as EventClickArg, eventList);
    else if (type === "date")
      getEventsByDate(
        setDayOff,
        setOverlayType,
        data as DateSelectArg,
        eventList
      );
  }, [data, eventList]);

  return (
    <DayOffOverlayWrapper>
      <TitleWrapper>{t("parameters.days-off.overlay.title")}</TitleWrapper>
      <DayOffForm
        toastHandler={toastHandler}
        setEvents={setEvents}
        daysOffToEvents={daysOffToEvents}
        data={data}
        type={overlayType}
        dayOff={dayOff}
        setDayOff={setDayOff}
      />
    </DayOffOverlayWrapper>
  );
};

const getEventsById = (
  setDayOff: SetState<DayOff>,
  data: EventClickArg,
  eventList: CalendarEvent[] | null
) => {
  if (data && eventList !== null) {
    /* eslint-disable-next-line no-underscore-dangle */
    const day = data.event._instance?.range.start;
    /* eslint-disable-next-line no-underscore-dangle */
    const def = data.event._def;

    if (day && def) {
      const calendarEvents = eventList.filter(
        (event) => event.id === def.publicId
      );

      if (calendarEvents.length > 0) eventsToDaysOff(setDayOff, calendarEvents);
    }
  }
};

const getEventsByDate = (
  setDayOff: SetState<DayOff>,
  setType: SetState<"date" | "event" | "new" | null>,
  data: DateSelectArg,
  eventList: CalendarEvent[] | null
) => {
  if (data && eventList !== null) {
    const calendarEvents = eventList.filter(
      (event) => dateToLocalIso(new Date(event.start)) === data.startStr
    );

    if (calendarEvents.length > 0) eventsToDaysOff(setDayOff, calendarEvents);
    else {
      setType("new");
      setDayOff({
        id: "",
        date: data.startStr,
        allDay: true,
      });
    }
  }
};

const eventsToDaysOff = (
  setDayOff: SetState<DayOff>,
  calendarEvents: CalendarEvent[]
) => {
  const closingHours: DayOffHour[] = calendarEvents.map(
    (event) =>
      ({
        closingHour: new Date(event.start).toLocaleTimeString().substring(0, 5),
        reopeningHour: new Date(event.end).toLocaleTimeString().substring(0, 5),
      } as DayOffHour)
  );

  setDayOff({
    id: calendarEvents[0].id,
    allDay: calendarEvents[0].allDay,
    date: calendarEvents[0].start.substring(
      0,
      calendarEvents[0].start.indexOf("T")
    ),
    closingHours,
  });
};

export default DayOffOverlay;
