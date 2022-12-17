import React from 'react';
import { RouteObject } from 'react-router';

const ContactView = React.lazy(() => import("./contact/page"));
const CraftsmanPres = React.lazy(() => import("./les-artisans/page"));
const ProductPres = React.lazy(() => import("./les-produits/page"));
const NewsletterPage = React.lazy(() => import('./newsletter/page'));
const PrivacyPolicyPage = React.lazy(() => import("./politique-de-confidentialite/page"));

const routes: RouteObject[] = [
  // { index: true, element: <Navigate to="les-produits" /> },
  { path: 'contact', element: <ContactView /> },
  { path: 'les-artisans', element: <CraftsmanPres /> },
  { path: 'les-produits', element: <ProductPres /> },
  { path: 'newsletter', element: <NewsletterPage /> },
  { path: 'politique-de-confidentialite', element: <PrivacyPolicyPage /> },
];

export default routes;
