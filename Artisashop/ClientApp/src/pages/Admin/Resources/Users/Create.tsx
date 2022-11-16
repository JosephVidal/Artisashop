import React from "react";
import { Create, SimpleForm, TextInput } from 'react-admin';

const CreateUser = () => (
  <Create>
    <SimpleForm>
      <TextInput source="firstname" />
      <TextInput source="lastname" />
    </SimpleForm>
  </Create>
);

export default CreateUser;
