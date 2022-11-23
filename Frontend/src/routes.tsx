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
import ContactView from "pages/Contact";
import CreateProductView from "pages/CreateProduct";
import UpdateProductView from "pages/UpdateProduct";
import ReclamationView from "pages/Reclamation";
import { Account } from "api";

const AdminDashboard = React.lazy(() => import("pages/Admin"));

const Joseph: Account = {
  id: "14d8b8f2-9446-4485-95f7-bb657de7c54e",
  lastname: "Osmont",
  firstname: "Yann",
  suspended: false,
  validation: false,
  userName: "yann@artisashop.fr"
}

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
            <Route path="chat" element={<Chat newMessage to={Joseph}/>}/>
            <Route path="profile" element={<ProfilePage />}/>
            <Route path="contact" element={<ContactView />} />
            <Route path="create-product" element={<CreateProductView />} />
            <Route path="update-product" element={<UpdateProductView />} />
            <Route path="reclamation" element={<ReclamationView />} />
          </Route>
          <Route path="admin/*" element={<AdminDashboard/>}/>
        </Route>
        <Route index element={<Navigate to="/app"/>}/>
      </Wrapper>
    </Router>
  );

export default Routes;
