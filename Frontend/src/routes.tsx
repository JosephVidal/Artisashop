import React from "react";
import { useRoutes } from "react-router-dom";

import { ToastHandler } from "components/Toaster";
import Template from "components/Template";
import { colors } from "globals/styles";

import adminRoutes from 'pages/admin';
import authRoutes from 'pages/auth';

import dashboardRoutes from 'pages/dashboard';

interface Props {
  toastHandler: ToastHandler;
}

const Routes: React.FC<Props> = ({ toastHandler }) => {
  const routes = useRoutes([
    { element: <Template toastHandler={toastHandler} background={colors.darkBlue} /> },
    { element: <Template toastHandler={toastHandler} background={colors.beige} /> },
    { path: 'auth', children: authRoutes },
    { path: 'admin/*', children: adminRoutes },
    { path: 'dashboard', children: dashboardRoutes },

  ]);

  return routes
}

export default Routes;
