import { RouteObject } from 'react-router';

import adminRoutes from './admin';
import appRoutes from './app';
import authRoutes from './auth';
import dashboardRoutes from './dashboard';

const routes: RouteObject[] = [
  ...authRoutes,
  ...adminRoutes,
  ...appRoutes,
  ...dashboardRoutes,
];

export default routes;
