import React, { FC, useState } from "react";
import { Calendar as PRCalendar } from "primereact/calendar";
import i18next from "i18next";
import * as _ from "lodash";
import { TimePickerWrapper } from "./styles";

interface Props {
  time: Date;
  onSelectTime: (date: Date) => void;
}

const TimePicker: FC<Props> = ({ time, onSelectTime }) => {
  const [visible, setVisible] = useState<boolean>(false);

  return (
    <TimePickerWrapper>
      <PRCalendar
        value={time}
        visible={visible}
        onVisibleChange={() => setVisible(!visible)}
        locale={i18next.language ?? "fr"}
        timeOnly
        stepMinute={5}
        onChange={(e) => !_.isNil(e.value) && onSelectTime(changeTime(e.value))}
      />
    </TimePickerWrapper>
  );
};

const changeTime = (date: Date | Date[]) => (_.isArray(date) ? date[0] : date);

export default TimePicker;
