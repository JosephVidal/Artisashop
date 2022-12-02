import React, { useEffect } from "react";
// import {
//   BrowserRouter as Router,
//   Routes as Wrapper,
//   Route, Navigate, useLocation,
// } from "react-router-dom";
import ReactDOM from 'react-dom/client';
import {
  Outlet,
  RouterProvider,
  Link,
  createReactRouter,
  createRouteConfig,
} from '@tanstack/react-router';

import { ToastHandler } from "components/Toaster";
import { colors } from "globals/styles";
import HomeView from "pages";
import Register from "pages/Register";
import Login from "pages/auth/Login";
import Search from "pages/recherche";
import ProductView from "pages/produits/[id]";
import CraftsmanView from "pages/artisans";
import PrivacyPolicy from "pages/a-propos/politique-de-confidentialite";
import Template from "components/Template";
import Chat from "pages/chat";
import Basket from "pages/panier";
import ProfilePage from "pages/profil";
import ContactView from "pages/a-propos/contact";
import CreateProductView from "pages/produits/creer";
import UpdateProductView from "pages/espace-artisan/produits/[id]";
import ReclamationView from "pages/produits/reclamation";
import NewsletterPage from "pages/newsletter";
import CraftsmanPres from "pages/a-propos/artisans";
import ProductPres from "pages/a-propos/produits";
import CraftsmanDashboard from "pages/espace-artisan";

const rootRoute = createRouteConfig();

const AdminDashboard = React.lazy(() => import("pages/admin"));

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



const Routes: React.FunctionComponent<Props> = ({ toastHandler }) =>
(
  <Router>
    <ScrollToTop />
    <Wrapper>
      <Route element={<Template toastHandler={toastHandler} background={colors.darkBlue} />} />
      <Route element={<Template toastHandler={toastHandler} background={colors.beige} />}>
        <Route index element={<HomeView />} />
        <Route path="auth">
          <Route index element={<Navigate to="/auth/login" />} />
          <Route path="register" element={<Register />} />
          <Route path="login" element={<Login />} />
        </Route>
        <Route path="recherche" element={<Search />} />
        <Route path="products">
          <Route path=":id" element={<ProductView />} />
        </Route>
        <Route path="artisans">
          <Route path=":id" element={<CraftsmanView />} />
        </Route>
        <Route path="chat">
          <Route index element={<Chat />} />
          {/* TODO: indexed chat list */}
          {/* <Route path=":id" element={<Chat />} /> */}
        </Route>
        <Route path="panier" element={<Basket />} />
        <Route path="a-propos">
          <Route path="artisans" element={<CraftsmanPres />} />
          <Route path="produits" element={<ProductPres />} />
          <Route path="politique-de-confidentialite" element={<PrivacyPolicy />} />
          <Route path="contact" element={<ContactView />} />
        </Route>
        <Route path="produits">
          <Route index element={<Navigate to="/produits/creer" />} />
          <Route path="creer" element={<CreateProductView />} />
          <Route path=":id">
            <Route index element={<ProductView />} />
            <Route path="modifier" element={<UpdateProductView />} />
            <Route path="reclamer" element={<ReclamationView />} />
          </Route>
        </Route>
        <Route path="newsletter" element={<NewsletterPage />} />
        <Route path="chat" element={<Chat />} />
        <Route path="profile" element={<ProfilePage />} />
        <Route path="create-product" element={<CreateProductView />} />
        <Route path="update-product/:productId" element={<UpdateProductView />} />
        <Route path="reclamation" element={<ReclamationView />} />
        <Route path="dashboard" element={<CraftsmanDashboard />} />
      </Route>
      <Route path="admin/*" element={<AdminDashboard />} />
      <Route path="*" element={<Navigate to="/" />} />
    </Wrapper>
  </Router>
);

export default Routes;
