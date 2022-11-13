import { Log } from "models/logs";
import _ from "lodash/fp";
import { Action } from "reducers/utils";
import { Reducer } from "react";

export interface EquipmentStateLog {
  letter: string;
  connected: boolean;
}

type AddLog = Action<"ADD_LOG"> & { log: Log<any> };
export const addLog = (log: Log<any>): AddLog => ({
  type: "ADD_LOG",
  log,
});

type LogsOrder = "recent_top" | "old_top";

type ReorderLogs = Action<"REORDER_LOGS"> & { order: LogsOrder };
export const reorderLogs = (order: LogsOrder): ReorderLogs => ({
  type: "REORDER_LOGS",
  order,
});

export type LogsActions = AddLog | ReorderLogs;

export interface LogsState {
  allLogs: Log<any>[];
  logsByType: { [key: string]: Log<any>[] };
  order: LogsOrder;
}

export const initialLogsState: LogsState = {
  allLogs: [],
  logsByType: {
    frag: [],
    "batteries-info": [],
    "player-headset-state": [],
    error: [],
  },
  order: "recent_top",
};

const mergeLogsIfSameType = (
  newLog: Log<any>,
  logs: { [p: string]: Log<any>[] }
): { [p: string]: Log<any>[] } =>
  logs[newLog.type] && {
    ...logs,
    [newLog.type]: logs[newLog.type].concat([newLog]),
  };

export type LogsReducer = Reducer<LogsState, LogsActions>;

const reducer: LogsReducer = (
  /* eslint-disable-next-line @typescript-eslint/default-param-last */
  state: LogsState = initialLogsState,
  action: LogsActions
) => {
  switch (action.type) {
    case "ADD_LOG":
      return {
        ...state,
        allLogs:
          state.order === "recent_top"
            ? _.concat([action.log], state.allLogs)
            : state.allLogs.concat([action.log]),
        logsByType: mergeLogsIfSameType(action.log, state.logsByType),
      };

    case "REORDER_LOGS":
      return {
        ...state,
        allLogs: _.orderBy(
          ["timestamp"],
          [action.order === "recent_top" ? "desc" : "asc"],
          state.allLogs
        ),
        order: action.order,
      };

    default:
      return state;
  }
};

export default reducer;
