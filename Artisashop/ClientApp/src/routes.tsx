import React from "react";
import {
  BrowserRouter as Router,
  Routes as Wrapper,
  Route,
} from "react-router-dom";
import { ToastHandler } from "components/Toaster";
import Home from "pages/Home";
import Register from "pages/Register";
import Login from "pages/Login";
import Search from "pages/Search";
import Template from "components/Template";
import Chat from "pages/Chat";
import {colors} from "globals/styles";

interface Props {
  toastHandler: ToastHandler;
}

const Routes: React.FunctionComponent<Props> = ({ toastHandler }) => (
  <Router>
    <Wrapper>
      <Route element={<Template toastHandler={toastHandler} background={colors.darkBlue} />} />
      <Route element={<Template toastHandler={toastHandler} background={colors.beige} />}>
        <Route path="/register" element={<Register />} />
        <Route path="/login" element={<Login />} />
        <Route path="/" element={<Home />} />
        <Route path="/search" element={<Search />} />
        <Route path="/chat" element={<Chat />} />
      </Route>
    </Wrapper>
  </Router>
);

export default Routes;
