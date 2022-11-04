export type DayOff = {
  id: string;
  date: string;
  allDay: boolean;
  closingHours?: DayOffHour[];
};

export interface DayOffHour {
  closingHour: string;
  reopeningHour: string;
}

export interface CalendarEvent {
  id: string;
  title: string;
  allDay: boolean;
  start: string;
  end: string;
}
