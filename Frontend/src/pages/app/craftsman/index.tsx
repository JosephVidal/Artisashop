import React from 'react';
import { RouteObject } from 'react-router';

const CraftsmanView = React.lazy(() => import('./page'));

const routes: RouteObject[] = [
  { index: true, element: <CraftsmanView/> },
];

export default routes;
