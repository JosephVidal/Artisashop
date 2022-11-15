import * as React from "react";
import {Admin, EditGuesser, ListGuesser, Resource, ShowGuesser} from "react-admin";
import simpleRestProvider from "ra-data-simple-rest";
import {REACT_APP_API_URL} from "conf";

const AdminDashboard = () => (
  <Admin basename="/app/admin" dataProvider={simpleRestProvider(`${REACT_APP_API_URL}/admin`)}>
    <Resource name="product" list={ListGuesser} edit={EditGuesser} show={ShowGuesser} />
    <Resource name="complaint" list={ListGuesser} edit={EditGuesser} show={ShowGuesser} />
    <Resource name="user" list={ListGuesser} edit={EditGuesser} show={ShowGuesser} />
  </Admin>
);

export default AdminDashboard;
