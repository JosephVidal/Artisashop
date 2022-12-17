import React from 'react';
import { RouteObject } from 'react-router';

const ChatPage = React.lazy(() => import('./page'));

const routes: RouteObject[] = [
  { index: true, element: <ChatPage/> },
];

export default routes;
