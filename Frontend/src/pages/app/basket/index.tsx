import React from 'react';
import { RouteObject } from 'react-router';

const BasketView = React.lazy(() => import('./page'));

const routes: RouteObject[] = [
  { index: true, element: <BasketView/> },
];

export default routes;
