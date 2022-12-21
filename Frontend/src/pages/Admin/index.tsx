import * as React from "react";
import {Admin, EditGuesser, ListGuesser, Resource, ShowGuesser} from "react-admin";
import simpleRestProvider from "ra-data-simple-rest";
import {REACT_APP_API_URL} from "conf";

import useFormattedDocumentTitle from "hooks/useFormattedDocumentTitle";
import ProductList from "./Resources/Products/List";

import UserCreate from "./Resources/Users/Create";

const AdminDashboard = () => {
  useFormattedDocumentTitle("Dashboard Admin");
  
  return (
    <Admin basename="/admin" dataProvider={simpleRestProvider(`${REACT_APP_API_URL}/api/admin`)}>
      <Resource name="product" list={ProductList} edit={EditGuesser} show={ShowGuesser} />
      <Resource name="complaint" list={ListGuesser} edit={EditGuesser} show={ShowGuesser} />
      <Resource name="user" list={ListGuesser} edit={EditGuesser} show={ShowGuesser} create={UserCreate} />
    </Admin>
  );
};

export default AdminDashboard;
