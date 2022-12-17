import React from 'react';
import { RouteObject } from 'react-router';

const ProductView = React.lazy(() => import('./page'));

const routes: RouteObject[] = [
  { index: true, element: <ProductView/> },
];

export default routes;
