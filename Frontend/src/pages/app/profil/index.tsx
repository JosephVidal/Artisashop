import React from 'react';
import { RouteObject } from 'react-router';

const ProfilePage = React.lazy(() => import('./page'));

const routes: RouteObject[] = [
  { index: true, element: <ProfilePage/> }
];

export default routes;
