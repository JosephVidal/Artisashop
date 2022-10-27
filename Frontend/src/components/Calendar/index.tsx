import React, { FC, useRef } from "react";
import { Calendar as PRCalendar } from "primereact/calendar";
import { addLocale } from "primereact/api";
import i18next from "i18next";
import { AiOutlineCalendar } from "react-icons/ai";
import * as _ from "lodash";
import { format } from "date-fns/fp";
import { CalendarWrapper, DateText, DateAndIconWrapper } from "./styles";

interface Props {
  date: Date;
  dateFormat?: string;
  onSelectDate: (date: Date | Date[] | undefined) => void;
}

const Calendar: FC<Props> = ({
  date,
  dateFormat = "dd/MM/yyyy",
  onSelectDate,
}) => {
  const calendarRef = useRef<PRCalendar>(null);

  return (
    <CalendarWrapper>
      <PRCalendar
        ref={calendarRef}
        locale={i18next.language ?? "fr"}
        value={date}
        dateFormat={dateFormat}
        showButtonBar
        hideOnDateTimeSelect
        clearButtonClassName="clear-button"
        onChange={(p) => onSelectDate(changeDate(p.value))}
      />

      <DateAndIconWrapper
        onClick={() =>
          !_.isNil(calendarRef.current) && calendarRef.current.show()
        }
      >
        <DateText>{format(dateFormat)(date)}</DateText>

        <AiOutlineCalendar />
      </DateAndIconWrapper>
    </CalendarWrapper>
  );
};

const changeDate = (date: Date | Date[] | undefined) =>
  _.isArray(date) ? date[0] : date;

addLocale("fr", {
  firstDayOfWeek: 1,
  dayNames: [
    "Dimanche",
    "Lundi",
    "Mardi",
    "Mercredi",
    "Jeudi",
    "Vendredi",
    "Samedi",
  ],
  dayNamesShort: ["Dim", "Lun", "Mar", "Mer", "Jeu", "Ven", "Sam"],
  dayNamesMin: ["D", "L", "M", "M ", "J", "V", "S"],
  monthNames: [
    "Janvier",
    "Février",
    "Mars",
    "Avril",
    "Mai",
    "Juin",
    "Juillet",
    "Août",
    "Septembre",
    "Octobre",
    "Novembre",
    "Décembre",
  ],
  monthNamesShort: [
    "Jan",
    "Fév",
    "Mar",
    "Avr",
    "Mai",
    "Jun",
    "Jul",
    "Aoû",
    "Sep",
    "Oct",
    "Nov",
    "Déc",
  ],
  today: "Aujourd'hui",
  clear: "Fermer",
});

export default Calendar;
