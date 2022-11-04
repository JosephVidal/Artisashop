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
import Template from "components/Template";
import {useAuth} from "./hooks/useAuth";

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
        </Route>
      </Wrapper>
    </Router>
  );

export default Routes;