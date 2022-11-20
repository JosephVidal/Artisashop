export type CalendarName = "schooling-days" | "school-vacation" | "holiday";

type Weekday =
  | "MONDAY"
  | "TUESDAY"
  | "WEDNESDAY"
  | "THURSDAY"
  | "FRIDAY"
  | "SATURDAY"
  | "SUNDAY"
  | "HOLIDAY";

export interface GetOpeningHours {
  calendar: Calendar;
}

export interface Calendar {
  schoolingDays: OpeningHours[];
  schoolVacation: OpeningHours[];
  holiday: OpeningHours;
}

export interface OpeningHours {
  id: string;
  day: Weekday;
  closed: boolean;
  hours?: Hour[];
}

export interface Hour {
  openingTime: string;
  closingTime: string;
}

export interface Vacation {
  start: Date;
  end: Date;
}

export interface EducationAPIResponse {
  nhits: number;
  records: Record[];
}

export interface Record {
  fields: {
    zones: string;
    start_date: string;
    end_date: string;
  };
}

export interface CalendarAPIResponse {
  [key: string]: string;
}

export const defaultCalendar = {
  schoolingDays: [
    {
      id: "",
      day: "MONDAY",
      closed: true,
    },
    {
      id: "",
      day: "TUESDAY",
      closed: true,
    },
    {
      id: "",
      day: "WEDNESDAY",
      closed: true,
    },
    {
      id: "",
      day: "THURSDAY",
      closed: true,
    },
    {
      id: "",
      day: "FRIDAY",
      closed: true,
    },
    {
      id: "",
      day: "SATURDAY",
      closed: true,
    },
    {
      id: "",
      day: "SUNDAY",
      closed: true,
    },
  ],
  schoolVacation: [
    {
      id: "",
      day: "MONDAY",
      closed: true,
    },
    {
      id: "",
      day: "TUESDAY",
      closed: true,
    },
    {
      id: "",
      day: "WEDNESDAY",
      closed: true,
    },
    {
      id: "",
      day: "THURSDAY",
      closed: true,
    },
    {
      id: "",
      day: "FRIDAY",
      closed: true,
    },
    {
      id: "",
      day: "SATURDAY",
      closed: true,
    },
    {
      id: "",
      day: "SUNDAY",
      closed: true,
    },
  ],
  holiday: {
    id: "",
    day: "HOLIDAY",
    closed: true,
  },
} as Calendar;
