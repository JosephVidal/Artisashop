/* eslint-disable @typescript-eslint/no-unsafe-call */
/* eslint-disable no-param-reassign */
import * as React from "react";
import { Admin, AuthProvider, EditGuesser, ListGuesser, Resource, ShowGuesser, fetchUtils } from "react-admin";
import simpleRestProvider from "ra-data-simple-rest";
import { REACT_APP_API_URL } from "conf";

import useFormattedDocumentTitle from "hooks/useFormattedDocumentTitle";
import { useAtom } from "jotai";
import tokenAtom from "states/atoms/token";
import useAuth from "states/auth";
import userAtom from "states/atoms/user";

import ProductList from "./Resources/Products/List";
import UserCreate from "./Resources/Users/Create";
// import fetchJson from "./fetchJson";

const AdminDashboard = () => {
  useFormattedDocumentTitle("Dashboard Admin");
  const auth = useAuth();
  // const [user] = useAtom(userAtom);
  const [token] = useAtom(tokenAtom);

  const authProvider: AuthProvider = {
    login: ({ username, password }: { username: string, password: string }) => auth.signin(username, password),
    logout: () => { auth.signout(); return Promise.resolve(); },
    checkAuth: () => token ? Promise.resolve() : Promise.reject(),
    checkError: () => Promise.resolve(),
    getPermissions: () => Promise.resolve(),
  };

  return (
    <Admin
      basename="/admin"
      dataProvider={simpleRestProvider(`${REACT_APP_API_URL}/api/admin`, (url, options = {}) => {
        options.user = {
          authenticated: true,
          token: `Bearer ${token ?? ''}`,
        }

        return fetchUtils.fetchJson(url, options);
      })}
    authProvider={authProvider} requireAuth
    >
      <Resource name="product" list={ProductList} edit={EditGuesser} show={ShowGuesser} />
      <Resource name="complaint" list={ListGuesser} edit={EditGuesser} show={ShowGuesser} />
      <Resource name="user" list={ListGuesser} edit={EditGuesser} show={ShowGuesser} create={UserCreate} />
    </Admin>
  );
};

export default AdminDashboard;
