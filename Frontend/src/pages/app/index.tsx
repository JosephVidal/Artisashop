import React from 'react';
import { RouteObject } from 'react-router';

import AppLayout from './layout';

import aProposRoutes from './a-propos';
import basketRoutes from './basket';
import chatRoutes from './chat';
import craftsmanRoutes from './craftsman';
import produitsRoutes from './produits';
import profilRoutes from './profil';
import rechercheRoutes from './recherche';
import reclamationRoutes from './reclamation';

const HomePage = React.lazy(() => import('./page'));

const routes: RouteObject[] = [
  {
    element: <AppLayout />,
    children: [
      { index: true, element: <HomePage /> },
      { path: 'a-propos', children: aProposRoutes },
      { path: 'basket', children: basketRoutes },
      { path: 'chat', children: chatRoutes },
      { path: 'craftsman', children: craftsmanRoutes },
      { path: 'produits', children: produitsRoutes },
      { path: 'profil', children: profilRoutes },
      { path: 'recherche', children: rechercheRoutes },
      { path: 'reclamation', children: reclamationRoutes },
    ],
  },
];

export default routes;
