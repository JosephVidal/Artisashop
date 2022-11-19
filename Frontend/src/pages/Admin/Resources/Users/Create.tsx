import React from "react";
import { Create, SelectField, SimpleForm, TextInput } from 'react-admin';

const choices=[
  { id: 'USER', name: 'User' },
  { id: 'ADMIN', name: 'Admin' },
];

interface TransformProps {
  email: string;
  firstname: string;
  lastname: string;
  role: string;
}

const CreateUser = () => {
  const transform = (data : TransformProps) => ({
    ...data,
    userName: data.email,
    normalizedUserName: data.email.toUpperCase(),
  })
  
  return (
    <Create transform={transform}>
      <SimpleForm>
        <TextInput source="email" />
        <TextInput source="firstname" />
        <TextInput source="lastname" />
        <SelectField source="role" choices={choices} />
      </SimpleForm>
    </Create>
  );
};

export default CreateUser;
