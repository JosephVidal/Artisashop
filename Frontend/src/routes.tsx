import React from "react";
import {
  BrowserRouter as Router,
  Routes as Wrapper,
  Route, Navigate,
} from "react-router-dom";
import {ToastHandler} from "components/Toaster";
import {colors} from "globals/styles";
import Home from "pages/Home";
import Register from "pages/Register";
import Login from "pages/Login";
import Search from "pages/Search";
import ProductView from "pages/Product";
import CraftsmanView from "pages/Craftsman";
import PrivacyPolicy from "pages/PrivacyPolicy";
import Template from "components/Template";
import Chat from "pages/Chat";
import Basket from "pages/Basket";
import ProfilePage from "pages/Profile";

const AdminDashboard = React.lazy(() => import("pages/Admin"));

interface Props {
  toastHandler: ToastHandler;
}

const Routes: React.FunctionComponent<Props> = ({toastHandler}) =>
  (
    <Router>
      <Wrapper>
        <Route path="/app">
          <Route element={<Template toastHandler={toastHandler} background={colors.darkBlue}/>}/>
          <Route element={<Template toastHandler={toastHandler} background={colors.beige}/>}>
            <Route index element={<Home/>}/>
            <Route path="register" element={<Register/>}/>
            <Route path="login" element={<Login/>}/>
            <Route path="search" element={<Search/>}/>
            <Route path="product/:id" element={<ProductView/>}/>
            <Route path="mon-panier" element={<Basket />}/>
            <Route path="craftsman/:id" element={<CraftsmanView/>}/>
            <Route path="politique-de-confidentialite" element={<PrivacyPolicy/>}/>
            <Route path="chat" element={<Chat/>}/>
            <Route path="profile" element={<ProfilePage />}/>
          </Route>
          <Route path="admin/*" element={<AdminDashboard/>}/>
        </Route>
        <Route index element={<Navigate to="/app"/>}/>
      </Wrapper>
    </Router>
  );

export default Routes;
