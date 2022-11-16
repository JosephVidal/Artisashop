import React from "react";
import {
  BrowserRouter as Router,
  Routes as Wrapper,
  Route,
} from "react-router-dom";
import {ToastHandler} from "components/Toaster";
import Home from "pages/Home";
import Register from "pages/Register";
import Login from "pages/Login";
import Search from "pages/Search";
import Product from "pages/Product";
import PrivacyPolicy from "pages/PrivacyPolicy";
import Template from "components/Template";
import Basket from "pages/Basket";

interface Props {
  toastHandler: ToastHandler;
}

const Routes: React.FunctionComponent<Props> = ({toastHandler}) =>
  (
    <Router>
      <Wrapper>
        <Route element={<Template toastHandler={toastHandler}/>}>
          <Route path="/" element={<Home/>}/>
          <Route path="/register" element={<Register/>}/>
          <Route path="/login" element={<Login/>}/>
          <Route path="/search" element={<Search/>}/>
          <Route path="/product" element={<Product/>}/>
          <Route path="/mon-panier" element={<Basket />}/>
          <Route path="/politique-de-confidentialite" element={<PrivacyPolicy />}/>
          <Route path="*" element={<div>404</div>}/>
        </Route>
      </Wrapper>
    </Router>
  );

export default Routes;
