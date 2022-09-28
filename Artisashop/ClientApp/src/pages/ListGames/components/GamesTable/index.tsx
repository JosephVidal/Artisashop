import React, { useEffect, useState } from "react";
import Table from "components/Table";
import * as _ from "lodash/fp";
import Column from "components/Table/Column";
import { useTranslation } from "react-i18next";
import i18next, { TFunction } from "i18next";
import { colors } from "globals/styles";
import { dateFromTime, timeFormat } from "globals/date";
import { Equipment } from "models/equipment";
import RemainingTime from "components/RemainingTime";
import { ToastHandler } from "components/Toaster";
import {
  addMinutes,
  differenceInMinutes,
  format,
  isSameDay,
  isWithinInterval,
} from "date-fns/fp";
import { GameList, GameListToDisplay } from "models/gameList";
import { Hour, OpeningHours } from "models/openingHours";
import { DayOff, DayOffHour } from "models/dayOff";
import { Maybe } from "monet";
import { isAfter, isBefore } from "date-fns";
import { AiOutlinePlusCircle } from "react-icons/ai";
import { DataTableRowClickEventParams } from "primereact/datatable";
import { useNavigate } from "react-router-dom";
import { NavigateFunction } from "react-router/lib/hooks";
import { Game } from "models/game";
import { RiDeleteBinLine } from "react-icons/ri";
import { deleteGame } from "pages/Game/api";
import { SetState } from "globals/state";

import DialogManager from "components/DialogManager";
import {
  BeginTimeWrapper,
  CreateGameWrapper,
  DeleteGameWrapper,
  DurationWrapper,
  EndTimeWrapper,
  GameTableWrapper,
  IndexWrapper,
  PlayersNumber,
  PlayersSquare,
  PlayersSquareWrapper,
  PlayersWrapper,
  Separator,
  Status,
  StatusWrapper,
  TimeLeft,
  TimeLeftWrapper,
} from "./styles";

interface Props {
  toaster: ToastHandler;
  date: Date;
  gameInterval: number;
  defaultDuration: number;
  openingHours: OpeningHours;
  activatedEquipments: Equipment[];
  maybeDayOff: Maybe<DayOff>;
  gamesList: GameList[];
  currentGame: Maybe<Game>;
}

interface Slot {
  index: number;
  time: string;
  gameList?: GameListToDisplay;
}

const GamesTable: React.FunctionComponent<Props> = ({
  toaster,
  date,
  gameInterval,
  defaultDuration,
  openingHours,
  activatedEquipments,
  maybeDayOff,
  gamesList,
  currentGame,
}) => {
  const { t } = useTranslation();
  const navigate: NavigateFunction = useNavigate();

  const hours: Hour[] = maybeDayOff.cata(
    () => openingHours.hours ?? [],
    (dayOff) =>
      dayOff.closingHours
        ? hoursCalculator(dayOff.closingHours, openingHours.hours ?? [])
        : []
  );

  const [visible, setVisible] = useState<boolean>(false);
  const [slots, setSlots] = useState<Slot[]>([]);
  const [gameToDelete, setGameToDelete] = useState<Slot>();

  useEffect(() => {
    setSlots(
      getSlots(hours, gamesList, currentGame, gameInterval, defaultDuration)
    );
  }, [gamesList]);

  const locale = i18next.language ?? "fr";

  return (
    <GameTableWrapper going={getOnGoingIndex(slots)}>
      <DialogManager
        title={t("game.list.table.delete.title")}
        text={t("game.list.table.delete.text")}
        visible={visible}
        onHide={() => setVisible(false)}
        buttons
        isConfirm
        onAccept={() => onDeleteGame(gameToDelete, slots, setSlots, toaster, t)}
      />

      <Table
        data={slots}
        startingColor={getOnGoingIndex(slots) % 2 ? "DARK" : "BLUE"}
        onRowClick={(e) => onRowClick(date, navigate)(e)}
      >
        <Column field="number" header="#" body={indexTemplate} align="left" />

        <Column
          field="beginTime"
          header={t("game.list.table.startTime")}
          body={beginTimeTemplate(locale)}
          align="left"
        />

        <Column
          field="playersNumber"
          header={t("global.players")}
          body={playersNumberTemplate(activatedEquipments.length, t)}
          align="center"
        />

        <Column
          field="status"
          header={t("game.list.table.status.title")}
          body={statusTemplate(t, toaster)}
          align="left"
        />

        <Column
          field="duration"
          header={t("game.list.table.duration")}
          body={durationTemplate}
          align="left"
        />

        <Column
          field="endTime"
          header={t("game.list.table.endTime")}
          body={endTimeTemplate(
            slots,
            setSlots,
            setVisible,
            setGameToDelete,
            locale
          )}
          align="left"
        />
      </Table>
    </GameTableWrapper>
  );
};

const slotToDisplay = (slots: Slot[], interval: number): Slot[] =>
  _.sortBy<Slot>("gameList.beginDate")(slots).map((slot, index) => ({
    index: index + 1,
    time: slot.gameList ? slot.gameList.beginTime : slot.time,
    gameList: slot.gameList
      ? ({
          id: slot.gameList.id,
          beginTime: slot.gameList.beginTime,
          playersNumber: slot.gameList.playersNumber,
          status: slot.gameList.status,
          duration: slot.gameList.duration,
          endTime:
            slot.gameList.endTime ??
            timeFormat(
              addMinutes(slot.gameList.duration + interval / 2)(
                dateFromTime(slot.gameList.beginTime)
              ),
              "fr"
            ),
        } as GameListToDisplay)
      : undefined,
  }));

const indexTemplate = (item: Slot) => <IndexWrapper>{item.index}</IndexWrapper>;

const beginTimeTemplate = (locale: string) => (item: Slot) =>
  (
    <BeginTimeWrapper>
      {item.gameList?.beginTime ? (
        timeFormat(dateFromTime(item.gameList.beginTime), locale)
      ) : (
        <CreateGameWrapper>
          {item.time}
          <AiOutlinePlusCircle />
        </CreateGameWrapper>
      )}
    </BeginTimeWrapper>
  );

const playersNumberTemplate =
  (activatedEquipments: number, t: TFunction) => (item: Slot) =>
    (
      <PlayersWrapper>
        {item.gameList?.playersNumber
          ? playersColumn(item.gameList.playersNumber, activatedEquipments, t)
          : ""}
      </PlayersWrapper>
    );

const playersColumn = (
  playersNumber: number,
  activatedEquipments: number,
  t: TFunction
): React.ReactElement => (
  <>
    <PlayersNumber>
      {playersNumber}/{activatedEquipments === 0 ? "?" : activatedEquipments}{" "}
      {t("global.players").toLowerCase()}
    </PlayersNumber>

    <PlayersSquareWrapper>
      {_.range(0, activatedEquipments).map((a, index) => (
        <PlayersSquare
          key={index}
          colors={
            index < playersNumber
              ? playersSquareColor(playersNumber, activatedEquipments)
              : colors.darkGray
          }
        />
      ))}
    </PlayersSquareWrapper>
  </>
);

const playersSquareColor = (
  playersNumber: number,
  activatedEquipments: number
) => {
  if (playersNumber >= activatedEquipments * 0.75) return colors.green;

  if (playersNumber >= activatedEquipments * 0.5) return colors.orange;

  return colors.red;
};

const statusTemplate = (t: TFunction, toaster: ToastHandler) => (item: Slot) =>
  (
    <StatusWrapper>
      <Status>
        {item.gameList?.status ? (
          <>
            {t(`game.list.table.status.${item.gameList.status.toLowerCase()}`)}
          </>
        ) : (
          ""
        )}
      </Status>

      {item.gameList?.status &&
      (item.gameList?.status === "STARTED" ||
        item.gameList.status === "PAUSED") ? (
        <TimeLeftWrapper>
          <Separator>{" - "}</Separator>

          <TimeLeft>
            <RemainingTime
              toaster={toaster}
              paused={item.gameList.status === "PAUSED"}
            />
          </TimeLeft>
        </TimeLeftWrapper>
      ) : (
        ""
      )}
    </StatusWrapper>
  );

const durationTemplate = (item: Slot) => (
  <DurationWrapper>
    {item.gameList?.duration !== undefined ? (
      <>
        {getOverGameDuration(item.gameList)}
        {" min"}
      </>
    ) : (
      ""
    )}
  </DurationWrapper>
);

const endTimeTemplate =
  (
    slots: Slot[],
    setSlots: SetState<Slot[]>,
    setVisible: SetState<boolean>,
    setGameToDelete: SetState<Slot | undefined>,
    locale: string
  ) =>
  (item: Slot) =>
    (
      <EndTimeWrapper>
        {item.gameList?.endTime
          ? timeFormat(dateFromTime(item.gameList.endTime), locale)
          : ""}
        {item.gameList?.status === "CREATED" && (
          <DeleteGameWrapper
            onClick={(e) => {
              e.stopPropagation();
              setVisible(true);
              if (setGameToDelete) setGameToDelete(item);
            }}
          >
            <RiDeleteBinLine />
          </DeleteGameWrapper>
        )}
      </EndTimeWrapper>
    );

const onDeleteGame = (
  item: Slot | undefined,
  slots: Slot[],
  setSlots: SetState<Slot[]>,
  toaster: ToastHandler,
  t: TFunction
) => {
  if (item !== undefined) {
    Maybe.fromUndefined(item.gameList?.id).map((id) =>
      deleteGame(id).then((maybeErrors) =>
        maybeErrors.cata(() => {
          setSlots(
            slots.map((slot) =>
              slot.index === item.index
                ? {
                    ...slot,
                    gameList: undefined,
                  }
                : slot
            )
          );
          toaster.showSuccess(t("success.game.delete"));
        }, toaster.showErrors)
      )
    );
  }
};

const getSlots = (
  hours: Hour[],
  games: GameList[],
  currentGame: Maybe<Game>,
  interval: number,
  defaultDuration: number
): Slot[] =>
  slotToDisplay(
    hours.flatMap((opHours) =>
      _.range(0, slotCalculator(opHours, interval, defaultDuration)).map(
        (nb, index) =>
          ({
            time: timeFormat(
              addMinutes((interval + defaultDuration) * index)(
                dateFromTime(opHours.openingTime)
              ),
              "fr"
            ),
            gameList: gameExistInSlot(
              timeFormat(
                addMinutes((interval + defaultDuration) * index)(
                  dateFromTime(opHours.openingTime)
                ),
                "fr"
              ),
              games,
              interval + defaultDuration
            ).cata(
              () => undefined,
              (game) => game
            ),
          } as Slot)
      )
    ),
    interval
  );

const slotCalculator = (
  hours: Hour,
  interval: number,
  defaultDuration: number
) => getTime(hours) / (interval + defaultDuration);

const gameExistInSlot = (
  time: string,
  games: GameList[],
  gameDurationWithInterval: number
): Maybe<GameList> =>
  Maybe.fromNull(
    _.find<GameList>((game) =>
      isWithinInterval({
        start: dateFromTime(time),
        end: addMinutes(gameDurationWithInterval - 1)(dateFromTime(time)),
      })(dateFromTime(game.beginTime))
    )(games)
  );

const getOnGoingIndex = (slots: Slot[]) =>
  _.findIndex<Slot>(
    (slot) =>
      slot.gameList?.status === "STARTED" || slot.gameList?.status === "PAUSED"
  )(slots);

const getOverGameDuration = (gameList: GameListToDisplay) =>
  gameList.status === "OVER"
    ? differenceInMinutes(dateFromTime(gameList.beginTime))(
        dateFromTime(gameList.endTime)
      )
    : gameList.duration;

const getTime = (hours: Hour) =>
  differenceInMinutes(dateFromTime(hours.openingTime))(
    dateFromTime(hours.closingTime)
  );

const hoursCalculator = (dayOffHours: DayOffHour[], opHours: Hour[]): Hour[] =>
  opHours.flatMap(determineRealOpeningHours(dayOffHours));

const determineRealOpeningHours =
  (dayOffHours: DayOffHour[]) =>
  (hour: Hour): Hour[] =>
    Maybe.fromNull(_.head(dayOffHours)).cata(
      () => [hour],
      (dayOffHour) => {
        const exceptionalClosingHour = dateFromTime(dayOffHour.closingHour);
        const exceptionalReopeningHour = dateFromTime(dayOffHour.reopeningHour);

        const normalOpeningHour = dateFromTime(hour.openingTime);
        const normalClosingHour = dateFromTime(hour.closingTime);

        if (isAfter(normalOpeningHour, exceptionalClosingHour)) {
          if (isAfter(exceptionalReopeningHour, normalClosingHour))
            return [].flatMap(determineRealOpeningHours(_.tail(dayOffHours)));

          if (isAfter(normalClosingHour, exceptionalReopeningHour)) {
            return [
              {
                openingTime: dayOffHour.reopeningHour,
                closingTime: hour.closingTime,
              },
            ].flatMap(determineRealOpeningHours(_.tail(dayOffHours)));
          }
        }

        if (
          isBefore(normalOpeningHour, exceptionalClosingHour) ||
          isSameDay(normalOpeningHour)(exceptionalClosingHour)
        ) {
          if (isAfter(normalClosingHour, exceptionalReopeningHour)) {
            return [
              {
                openingTime: hour.openingTime,
                closingTime: dayOffHour.closingHour,
              },
              {
                openingTime: dayOffHour.reopeningHour,
                closingTime: hour.closingTime,
              },
            ].flatMap(determineRealOpeningHours(_.tail(dayOffHours)));
          }

          if (
            isBefore(normalClosingHour, exceptionalReopeningHour) &&
            isAfter(normalClosingHour, exceptionalClosingHour)
          ) {
            return [
              {
                openingTime: hour.openingTime,
                closingTime: dayOffHour.closingHour,
              },
            ].flatMap(determineRealOpeningHours(_.tail(dayOffHours)));
          }
        }

        return [hour].flatMap(determineRealOpeningHours(_.tail(dayOffHours)));
      }
    );

const onRowClick =
  (date: Date, navigate: NavigateFunction) =>
  (e: DataTableRowClickEventParams) => {
    const slot: Slot = e.data;
    /* eslint-disable-next-line @typescript-eslint/no-unsafe-call */ /* react.router typing for NavigateOptions.state is bad */
    if (slot.gameList) navigate(`/game/${slot.gameList.id}`);
    else {
      /* eslint-disable-next-line @typescript-eslint/no-unsafe-call */ /* react.router typing for NavigateOptions.state is bad */
      navigate(`/createGame/${format("yyyy-MM-dd-HH-mm")(
        new Date(
          date.getFullYear(),
          date.getMonth(),
          date.getDate(),
          dateFromTime(slot.time).getHours(),
          dateFromTime(slot.time).getMinutes()
        )
      )}
`);
    }
  };

export default GamesTable;
