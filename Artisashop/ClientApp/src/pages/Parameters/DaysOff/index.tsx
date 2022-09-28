import React, { FC, useEffect, useRef, useState } from "react";
import Content from "components/Content";
import { useTranslation } from "react-i18next";
import FullCalendar, { DateSelectArg } from "@fullcalendar/react";
import interactionPlugin from "@fullcalendar/interaction";
import dayGridPlugin from "@fullcalendar/daygrid";
import frLocale from "@fullcalendar/core/locales/fr";
import enLocale from "@fullcalendar/core/locales/en-gb";
import i18next, { TFunction } from "i18next";
import { ToastHandler } from "components/Toaster";
import { retrieveDaysOff } from "daysOff";
import { CalendarEvent, DayOff, DayOffHour } from "models/dayOff";
import { OverlayPanel } from "primereact/overlaypanel";
import { DatesSetArg, EventClickArg } from "@fullcalendar/core";
import { dateToLocalIso } from "globals/date";
import { SetState } from "globals/state";
import DayOffOverlay from "./components/dayOffOverlay";
import { CalendarWrapper, CustomOverlayPanel } from "./styles";

interface Props {
  toastHandler: ToastHandler;
}

const ExceptionalClosures: FC<Props> = ({ toastHandler }) => {
  const [events, setEvents] = useState<CalendarEvent[]>([]);
  const [loading, setLoading] = useState<boolean>(true);
  const [overlayContent, setOverlayContent] = useState<"date" | "event" | null>(
    null
  );
  const [arg, setArg] = useState<DateSelectArg | EventClickArg | null>(null);
  const lang = i18next.language === "fr" ? frLocale : enLocale;
  const op = useRef<OverlayPanel>(null);
  const [year, setYear] = useState<string>(new Date().getFullYear().toString());
  const { t } = useTranslation();

  useEffect(() => {
    retrieveDaysOff(toastHandler, year).then((daysOffList) => {
      if (daysOffList.length > 0) setEvents(daysOffToEvents(t, daysOffList));
      setLoading(false);
    });
  }, [year]);

  return (
    <Content
      title={t("parameters.days-off.title")}
      loading={loading}
      fixedHeight
    >
      <CalendarWrapper
        onMouseDown={(e) => {
          const target = e.target as HTMLElement;

          if (
            e.button === 0 &&
            target.className &&
            typeof target.className === "string"
          ) {
            if (target.className.includes("fc-daygrid")) {
              op.current?.show(e, target);
              setOverlayContent("date");
            } else if (target.className.includes("fc-event")) {
              op.current?.show(e, target);
              setOverlayContent("event");
            }
          }
        }}
      >
        <FullCalendar
          plugins={[dayGridPlugin, interactionPlugin]}
          initialView="dayGridMonth"
          events={events}
          locale={lang}
          height="100%"
          headerToolbar={{
            left: "today",
            center: "title",
            right: "prev,next",
          }}
          eventTimeFormat={{
            hour: "2-digit",
            minute: "2-digit",
            omitZeroMinute: false,
            meridiem: false,
          }}
          displayEventEnd
          handleWindowResize
          selectable
          select={(dateSelectArg) => {
            setArg(dateSelectArg);
          }}
          eventClick={(eventClickArg) => {
            setArg(eventClickArg);
          }}
          datesSet={(datesSetArg) => onViewUpdate(setYear, datesSetArg)}
          unselectAuto
        />

        <CustomOverlayPanel
          ref={op}
          className="overlay-panel-day-off"
          appendTo={document.body}
          onHide={() => {
            setArg(null);
          }}
          showCloseIcon
        >
          <DayOffOverlay
            toastHandler={toastHandler}
            setEvents={setEvents}
            daysOffToEvents={daysOffToEvents}
            data={arg}
            type={overlayContent}
            eventList={events}
          />
        </CustomOverlayPanel>
      </CalendarWrapper>
    </Content>
  );
};

const daysOffToEvents = (t: TFunction, daysOff: DayOff[]): CalendarEvent[] =>
  daysOff.flatMap((dayOff: DayOff) => {
    if (dayOff.allDay) {
      const date = new Date(dayOff.date).toISOString();
      return {
        id: dayOff.id,
        title: t("parameters.days-off.closed"),
        allDay: true,
        start: date,
        end: date,
      } as CalendarEvent;
    }
    if (dayOff.closingHours) {
      return dayOff.closingHours.map((hours: DayOffHour) => {
        const hourDetails = {
          start: hours.closingHour.split(":").map((hour) => parseInt(hour, 10)),
          end: hours.reopeningHour.split(":").map((hour) => parseInt(hour, 10)),
        };

        return {
          id: dayOff.id,
          title: t("parameters.days-off.closed"),
          allDay: false,
          start: getDate(dayOff.date, hourDetails.start),
          end: getDate(dayOff.date, hourDetails.end),
        } as CalendarEvent;
      });
    }
    return [];
  });

const getDate = (day: string, hours: number[]): string => {
  const date = new Date(day);
  date.setHours(hours[0], hours[1]);
  return date.toISOString();
};

const onViewUpdate = (setYear: SetState<string>, data: DatesSetArg) => {
  const newYear = dateToLocalIso(data.view.currentStart).substring(0, 4);
  setYear((prevYear) => (prevYear !== newYear ? newYear : prevYear));
};

export default ExceptionalClosures;
