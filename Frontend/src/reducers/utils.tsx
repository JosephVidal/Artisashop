import _ from "lodash/fp";
import React, { createContext, Reducer, useReducer } from "react";
import { initialStates, reducers, States } from "reducers";

export interface Action<T> {
  type: T;
}

interface Props {
  children?: React.ReactNode;
}

export type Reducers = { [key: string]: Reducer<any, any> };

export const combineReducers =
  (slices: Reducers): Reducer<States, Action<any>> =>
  (state: States, action: Action<any>) =>
    _.flow([
      _.keys,
      _.reduce(
        (stateAcc, key: keyof States) => ({
          ...stateAcc,
          [key]: slices[key](stateAcc[key], action),
        }),
        state
      ),
    ])(slices) as States;

export const StoreContext = createContext<
  [States, React.Dispatch<Action<any>>]
>([initialStates, () => {}]);

export const StoreProvider: React.FC<Props> = ({ children }) => {
  const [state, dispatch] = useReducer(
    combineReducers(reducers),
    initialStates
  );

  const store: [States, React.Dispatch<Action<any>>] = React.useMemo(
    () => [state, dispatch],
    [state]
  );

  return (
    <StoreContext.Provider value={store}>{children}</StoreContext.Provider>
  );
};
