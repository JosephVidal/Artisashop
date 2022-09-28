import { ToastHandler } from "components/Toaster";
import React, { FC, useContext, useEffect, useState } from "react";
import { ContentWrapper } from "components/Content/styles";
import PageTitle from "components/PageTitle";
import { useTranslation } from "react-i18next";
import DatePicker from "pages/ListGames/components/DatePicker";
import GamesTable from "pages/ListGames/components/GamesTable";
import { Equipment } from "models/equipment";
import { Calendar, OpeningHours, Vacation } from "models/openingHours";
import { GameList } from "models/gameList";
import * as _ from "lodash/fp";
import { SetState } from "globals/state";
import { Maybe, None } from "monet";
import { DayOff } from "models/dayOff";
import {
  format,
  fromUnixTime,
  getDay,
  getYear,
  isAfter,
  isBefore,
  isSameYear,
} from "date-fns/fp";
import { retrieveGamesList } from "games";
import { retrieveEquipments } from "equipments";
import { retrieveDaysOffIntoState } from "daysOff";
import { StoreContext } from "reducers/utils";
import { retrieveArtemisCurrentGame } from "currentGame";
import { getConfigScreenParameters } from "configurations";
import ContentLoader from "components/ContentLoader";
import {
  retrieveHolidays,
  retrieveOpeningHours,
  retrieveVacations,
} from "openingHours";
import { WeekDay } from "globals/date";
import { NavigateOptions } from "react-router";
import { useLocation } from "react-router-dom";
import { ClosedDay } from "./styles";

interface Props {
  toastHandler: ToastHandler;
  locationState?: NavigateOptions;
}

const ListGames: FC<Props> = ({ toastHandler }) => {
  const { t } = useTranslation();

  const { state } = useLocation() as {
    state: { createdGameDate: number } | null;
  };

  const [{ currentGame }, dispatch] = useContext(StoreContext);
  const [openingHours, setOpeningHours] = useState<Calendar>({
    schoolingDays: [],
    schoolVacation: [],
    holiday: {
      id: "",
      day: "HOLIDAY",
      closed: true,
    },
  });
  const [currentYearVacations, setCurrentYearVacation] = useState<
    Maybe<Vacation[]>
  >(None());
  const [nextYearVacations, setNextYearVacation] = useState<Maybe<Vacation[]>>(
    None()
  );
  const [holidays, setHolidays] = useState<Maybe<string[]>>(None());
  const [daysOff, setDaysOff] = useState<Maybe<DayOff[]>>(None());
  const [gamesList, setGamesList] = useState<GameList[]>([]);
  const [equipments, setEquipments] = useState<Equipment[]>([]);
  const [date, setDate] = useState<Date>(
    state ? fromUnixTime(state.createdGameDate) : new Date()
  );
  const [loading, setLoading] = useState<boolean>(true);

  useEffect(() => {
    retrieveOpeningHours(toastHandler, openingHours, setOpeningHours)
      .then(() => retrieveEquipments(toastHandler, equipments, setEquipments))
      .then(() => retrieveArtemisCurrentGame(toastHandler, dispatch));
  }, []);

  useEffect(() => {
    retrieveGamesList(toastHandler, date, gamesList, setGamesList);
  }, [date]);

  useEffect(() => {
    const currentYear = getYear(date);
    const currentScholarYear = `${currentYear - 1}-${currentYear}`;
    const nextScholarYear = `${currentYear}-${currentYear + 1}`;

    fetchVacationsCalendars(currentScholarYear, nextScholarYear)
      .then(fetchHolidaysCalendar(currentYear))
      .then(() =>
        retrieveDaysOffIntoState(
          toastHandler,
          _.toString(currentYear),
          setDaysOff
        )
      )
      .then(() => setLoading(false));
  }, [getYear(date)]);

  const fetchVacationsCalendars = (
    currentScholarYear: string,
    nextScholarYear: string
  ): Promise<void> =>
    getConfigScreenParameters(toastHandler, "vacation-zone").then(
      (maybeVacationZone) =>
        maybeVacationZone.cata(() => {},
        fetchAllVacations(currentScholarYear, nextScholarYear))
    );

  const fetchAllVacations =
    (currentScholarYear: string, nextScholarYear: string) =>
    (zone: string): Promise<Maybe<Vacation[]>[]> =>
      Promise.all([
        retrieveVacations(
          toastHandler,
          currentScholarYear,
          zone,
          setCurrentYearVacation
        ),
        retrieveVacations(
          toastHandler,
          nextScholarYear,
          zone,
          setNextYearVacation
        ),
      ]);

  const fetchHolidaysCalendar = (currentYear: number) => (): Promise<void> =>
    getConfigScreenParameters(toastHandler, "holiday-zone").then(
      (maybeHolidayZone) =>
        maybeHolidayZone.cata(() => {}, fetchHolidays(currentYear))
    );

  const fetchHolidays =
    (currentYear: number) =>
    (zone: string): Promise<Maybe<string[]>> =>
      retrieveHolidays(
        toastHandler,
        _.toString(currentYear),
        zone,
        setHolidays
      );

  const activatedEquipments = _.filter((eL: Equipment) => eL.activated)(
    equipments
  );

  return (
    <ContentWrapper>
      <ContentLoader loading={loading}>
        <PageTitle>{t("game.list.title")}</PageTitle>

        {!loading && (
          <DatePicker
            date={date}
            onSelectDate={onDateChange(toastHandler, date, setDate, setLoading)}
          />
        )}

        {!loading &&
        !isClosedDay(
          date,
          openingHours,
          daysOff.some(),
          holidays.some(),
          _.concat(currentYearVacations.some(), nextYearVacations.some())
        ) ? (
          <GamesTable
            toaster={toastHandler}
            date={date}
            gamesList={gamesList}
            defaultDuration={20}
            activatedEquipments={activatedEquipments}
            gameInterval={10}
            maybeDayOff={getDayOff(daysOff.some(), date)}
            openingHours={getOpeningHours(
              _.concat(currentYearVacations.some(), nextYearVacations.some()),
              holidays.some(),
              openingHours,
              date
            )}
            currentGame={currentGame}
          />
        ) : (
          <ClosedDay>{t("game.list.closed")}</ClosedDay>
        )}
      </ContentLoader>
    </ContentWrapper>
  );
};

const onDateChange =
  (
    toaster: ToastHandler,
    date: Date,
    setDate: SetState<Date>,
    setLoading: SetState<boolean>
  ) =>
  (newDate: Date | Date[] | undefined) => {
    if (!isSameYear(newDate as Date)(date)) setLoading(true);

    setDate(newDate as Date);
  };

const getDayOff = (daysOff: DayOff[], date: Date): Maybe<DayOff> =>
  Maybe.fromNull(_.find<DayOff>({ date: format("yyyy-MM-dd")(date) })(daysOff));

const getOpeningHours = (
  vacation: Vacation[],
  holidays: string[],
  calendar: Calendar,
  date: Date
): OpeningHours => {
  if (isHoliday(date, holidays)) return calendar.holiday;

  if (isSchoolVacation(date, vacation))
    return getOpeningHoursFromDate(date, calendar.schoolVacation);

  return getOpeningHoursFromDate(date, calendar.schoolingDays);
};

const isClosedDay = (
  date: Date,
  calendar: Calendar,
  daysOffList: DayOff[],
  holidays: string[],
  allVacations: Vacation[]
): boolean => {
  if (isDayOff(date, daysOffList)) return isClosedDayOff(date, daysOffList);

  if (isHoliday(date, holidays)) return calendar.holiday.closed;

  if (isSchoolVacation(date, allVacations))
    return isClosedRegularDay(date, calendar.schoolVacation);

  return isClosedRegularDay(date, calendar.schoolingDays);
};

const isClosedDayOff = (date: Date, daysOffList: DayOff[]): boolean =>
  _.find((d: DayOff) => d.date === format("yyyy-MM-dd")(date))(daysOffList)
    ?.allDay as boolean;

const isClosedRegularDay = (
  date: Date,
  openingHoursList: OpeningHours[]
): boolean => getOpeningHoursFromDate(date, openingHoursList).closed;

const isDayOff = (date: Date, daysOffList: DayOff[]): boolean =>
  _.flow([_.map("date"), _.includes(format("yyyy-MM-dd")(date))])(
    daysOffList
  ) as boolean;

const isHoliday = (date: Date, holidays: string[]): boolean =>
  _.includes(format("yyyy-MM-dd")(date))(holidays);

const isSchoolVacation = (date: Date, allVacations: Vacation[]): boolean =>
  _.some((d: Vacation) => isAfter(d.start)(date) && isBefore(d.end)(date))(
    allVacations
  );

const getOpeningHoursFromDate = (
  date: Date,
  openingHoursList: OpeningHours[]
): OpeningHours =>
  _.find((o: OpeningHours) => o.day === WeekDay[getDay(date)])(
    openingHoursList
  ) as OpeningHours;

export default ListGames;
