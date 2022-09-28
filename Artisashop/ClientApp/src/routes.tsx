import React, { useEffect, useState } from "react";
import {
  BrowserRouter as Router,
  Routes as Wrapper,
  Route,
} from "react-router-dom";
import { ToastHandler } from "components/Toaster";
import Home from "pages/Home";
import ParametersEquipments from "pages/Parameters/Equipments";
import GamesList from "pages/ListGames";
import CreateGame from "pages/CreateGame";
import Game from "pages/Game";
import ParametersOpeningHours from "pages/Parameters/OpeningHours";
import ExceptionalClosures from "pages/Parameters/DaysOff";
import Template from "components/Template";
import Configuration from "pages/Parameters/Configuration";
import Setup from "pages/Parameters/Setup";
import Loader from "components/Loader";
import { getSetupStatus } from "configurations";

interface Props {
  toastHandler: ToastHandler;
}

const Routes: React.FunctionComponent<Props> = ({ toastHandler }) => {
  const [setupDone, setSetupDone] = useState<boolean>(false);
  const [loading, setLoading] = useState<boolean>(true);

  useEffect(() => {
    getSetupStatus(toastHandler, setSetupDone, setLoading);
  });

  return (
    <>
      <Loader visible={loading} />
      {!loading &&
        (!setupDone ? (
          <Setup toastHandler={toastHandler} setSetupDone={setSetupDone} />
        ) : (
          <Router>
            <Wrapper>
              <Route element={<Template toastHandler={toastHandler} />}>
                <Route path="/" element={<Home />} />
                <Route
                  path="/games"
                  element={<GamesList toastHandler={toastHandler} />}
                />
                <Route
                  path="/createGame/:beginDate"
                  element={<CreateGame toastHandler={toastHandler} />}
                />
                <Route
                  path="/game/:id"
                  element={<Game toastHandler={toastHandler} />}
                />
                <Route
                  path="/parameters/equipments"
                  element={<ParametersEquipments toastHandler={toastHandler} />}
                />
                <Route
                  path="/parameters/openingHours"
                  element={
                    <ParametersOpeningHours toastHandler={toastHandler} />
                  }
                />
                <Route
                  path="/parameters/daysOff"
                  element={<ExceptionalClosures toastHandler={toastHandler} />}
                />
                <Route
                  path="/parameters/configuration"
                  element={<Configuration toastHandler={toastHandler} />}
                />
              </Route>
            </Wrapper>
          </Router>
        ))}
    </>
  );
};

export default Routes;
