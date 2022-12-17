import React from 'react';
import { RouteObject } from 'react-router';

const Search = React.lazy(() => import('./page'));

const routes: RouteObject[] = [
  { index: true, element: <Search/> },
];

export default routes;
