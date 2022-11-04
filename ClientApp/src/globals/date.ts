import { format, fromUnixTime, parse } from "date-fns/fp";

export enum WeekDay {
  "SUNDAY",
  "MONDAY",
  "TUESDAY",
  "WEDNESDAY",
  "THURSDAY",
  "FRIDAY",
  "SATURDAY",
  "HOLIDAY",
}

export const dateFormat = (timestamp: number, locale: string) => {
  switch (locale) {
    case "en":
      return format("yyyy-MM-dd h:mm aaa")(fromUnixTime(timestamp));

    case "fr":
      return format("dd/MM/yyyy HH:mm")(fromUnixTime(timestamp));

    default:
      return format("dd/MM/yyyy HH:mm")(fromUnixTime(timestamp));
  }
};

export const dateFromTime = (time: string): Date =>
  parse(new Date())("HH:mm")(time);

export const timeFormat = (date: Date, locale: string) => {
  switch (locale) {
    case "en":
      return format("h:mm aaa")(date);

    case "fr":
      return format("HH:mm")(date);

    default:
      return format("HH:mm")(date);
  }
};

export const timeToMinutesString = (time: number): string =>
  Math.floor(time / 60000).toLocaleString("en-US", { minimumIntegerDigits: 2 });

export const timetoSecondsString = (time: number): string =>
  ((time - Math.floor(time / 60000) * 60000) / 1000)
    .toLocaleString("en-US", { minimumIntegerDigits: 2 })
    .substring(0, 2);

export const addDays = (date: Date, days: number) => {
  date.setDate(date.getDate() + days);
  return date;
};

export const dateToLocalIso = (date: Date) => {
  const day = date.getDate().toString().padStart(2, "0");
  const month = (date.getMonth() + 1).toString().padStart(2, "0");
  return `${date.getFullYear()}-${month}-${day}`;
};

export const ISOToString = (iso: string) => iso.substring(0, iso.indexOf("T"));
