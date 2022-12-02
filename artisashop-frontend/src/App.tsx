import { lazy } from 'react'
import ReactDOM from 'react-dom/client';
import {
  Outlet,
  RouterProvider,
  Link,
  createReactRouter,
  createRouteConfig,
} from '@tanstack/react-router';

const Index = lazy(() => import('./pages/index.page'));

const rootRoute = createRouteConfig()

const indexRoute = rootRoute.createRoute({
  path: '/',
  component: Index,
});

const routeConfig = rootRoute.addChildren([indexRoute]);

const router = createReactRouter({ routeConfig });

function App() {
  return (
    <RouterProvider router={router}>
      <Outlet />
    </RouterProvider>
  )
}

export default App
