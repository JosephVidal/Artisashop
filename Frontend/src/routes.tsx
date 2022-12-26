import React, { useEffect } from "react";
import {
  BrowserRouter as Router,
  Routes as Wrapper,
  Route, Navigate, useLocation,
} from "react-router-dom";

import {ToastHandler} from "components/Toaster";
import {colors} from "globals/styles";
import HomeView from "pages/Home";
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
import NewsletterPage from "pages/Newsletter";
import CraftsmanPres from "pages/CraftsmanPres";
import ProductPres from "pages/ProductPres";
import CraftsmanDashboard from "pages/CraftsmanDashboard";

const AdminDashboard = React.lazy(() => import("pages/Admin"));

interface Props {
  toastHandler: ToastHandler;
}

const ScrollToTop = () => {
  const location = useLocation()
  useEffect(() => {
    window.scrollTo(0, 0)
  }, [location]);

  return (null)
}

const Routes: React.FunctionComponent<Props> = ({toastHandler}) =>
  (
    <Router>
      <ScrollToTop />
      <Wrapper>
        <Route path="/app">
          <Route element={<Template toastHandler={toastHandler} background={colors.darkBlue}/>}/>
          <Route element={<Template toastHandler={toastHandler} background={colors.beige}/>}>
            <Route index element={<HomeView/>}/>
            <Route path="register" element={<Register/>}/>
            <Route path="login" element={<Login/>}/>
            <Route path="search" element={<Search/>}/>
            <Route path="product/:id" element={<ProductView/>}/>
            <Route path="mon-panier" element={<Basket />}/>
            <Route path="craftsman/:id" element={<CraftsmanView/>}/>
            <Route path="politique-de-confidentialite" element={<PrivacyPolicy/>}/>
            <Route path="chat" element={<Chat/>}/>
            <Route path="profile" element={<ProfilePage />}/>
            <Route path="contact" element={<ContactView />} />
            <Route path="create-product" element={<CreateProductView />} />
            <Route path="update-product" element={<UpdateProductView />} />
            <Route path="reclamation" element={<ReclamationView />} />
            <Route path="newsletter" element={<NewsletterPage />} />
            <Route path="about/craftsmans" element={<CraftsmanPres />} />
            <Route path="about/products" element={<ProductPres />} />
            <Route path="dashboard" element={<CraftsmanDashboard />}/>
          </Route>
          <Route path="admin/*" element={<AdminDashboard/>}/>
        </Route>
        <Route index element={<Navigate to="/app"/>}/>
      </Wrapper>
    </Router>
  );

export default Routes;
