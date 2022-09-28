import React from "react";
import { IoIosArrowBack, IoIosArrowForward } from "react-icons/io";
import { addDays, subDays } from "date-fns/fp";
import Calendar from "components/Calendar";
import { Arrow, CalendarWrapper } from "./styles";

interface Props {
  date: Date;
  onSelectDate: (date: Date | Date[] | undefined) => void;
}

const DatePicker: React.FunctionComponent<Props> = ({ date, onSelectDate }) => (
  <CalendarWrapper>
    <Arrow>
      <IoIosArrowBack onClick={() => onSelectDate(subDays(1, date))} />
    </Arrow>

    <Calendar date={date} onSelectDate={onSelectDate} />

    <Arrow>
      <IoIosArrowForward onClick={() => onSelectDate(addDays(1, date))} />
    </Arrow>
  </CalendarWrapper>
);

export default DatePicker;
