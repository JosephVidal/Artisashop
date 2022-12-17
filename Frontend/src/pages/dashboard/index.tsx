import React from 'react';
import { RouteObject } from 'react-router';

const DashboardPage = React.lazy(() => import('./page'));

const routes: RouteObject[] = [
  { index: true, element: <DashboardPage/> },
];

export default routes;
