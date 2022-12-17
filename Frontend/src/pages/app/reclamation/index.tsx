import React from 'react';
import { RouteObject } from 'react-router';

const ReclamationView = React.lazy(() => import('./page'));

const routes: RouteObject[] = [
  { index: true, element: <ReclamationView/> },
];

export default routes;
