import React from "react";
import {
  BrowserRouter as Router,
  Routes as Wrapper,
  Route,
} from "react-router-dom";
import { ToastHandler } from "components/Toaster";
import { colors } from "globals/styles";
import Home from "pages/Home";
import Register from "pages/Register";
import Login from "pages/Login";
import Search from "pages/Search";
import ProductView from "pages/Product";
import CraftsmanView from "pages/Craftsman";
import PrivacyPolicy from "pages/PrivacyPolicy";
import Template from "components/Template";
import Chat from "pages/Chat";

interface Props {
  toastHandler: ToastHandler;
}

const Routes: React.FunctionComponent<Props> = ({toastHandler}) =>
  (
    <Router>
      <Wrapper>
        <Route element={<Template toastHandler={toastHandler} background={colors.darkBlue} />} />
        <Route element={<Template toastHandler={toastHandler} background={colors.beige} />}>
          <Route path="/" element={<Home/>}/>
          <Route path="/register" element={<Register/>}/>
          <Route path="/login" element={<Login/>}/>
          <Route path="/search" element={<Search/>}/>
          <Route path="/product/:id" element={<ProductView/>}/>
          <Route path="/craftsman/:id" element={<CraftsmanView/>}/>
          <Route path="/politique-de-confidentialite" element={<PrivacyPolicy />}/>
          <Route path="/chat" element={<Chat />} />
        </Route>
      </Wrapper>
    </Router>
  );

export default Routes;
