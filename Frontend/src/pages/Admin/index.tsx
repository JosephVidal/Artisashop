import React from 'react';
import { RouteObject } from 'react-router';

import AdminLayout from './layout';

const AdminDashboard = React.lazy(() => import('./page'));

const routes: RouteObject[] = [
  {
    element: <AdminLayout />,
    children: [
      { index: true, element: <AdminDashboard /> },
    ],
  },
];

export default routes;
