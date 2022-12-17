import React from 'react';
import { RouteObject } from 'react-router';

const Login = React.lazy(() => import('./login/page'));
const Register = React.lazy(() => import('./register/page'));

const routes: RouteObject[] = [
  { path: 'login', element: <Login/> },
  { path: 'register', element: <Register/> },
];

export default routes;
