import React from "react";
import {
  BrowserRouter as Router,
  Routes as Wrapper,
  Route,
} from "react-router-dom";
import { ToastHandler } from "components/Toaster";
import Home from "pages/Home";
import Register from "pages/Register";
import Template from "components/Template";

interface Props {
  toastHandler: ToastHandler;
}

const Routes: React.FunctionComponent<Props> = ({ toastHandler }) => (
  <Router>
    <Wrapper>
      <Route element={<Template toastHandler={toastHandler} />}>
        <Route path="/" element={<Home />} />
        <Route path="/register" element={<Register />} />
      </Route>
    </Wrapper>
  </Router>
);

export default Routes;
