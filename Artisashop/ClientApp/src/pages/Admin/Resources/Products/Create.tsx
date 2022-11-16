import React from "react";
import { Create, ImageInput, SimpleForm, TextInput } from 'react-admin';

const CreateProduct = () => (
  <Create>
    <SimpleForm>
      <TextInput source="name" />
      <TextInput source="description" />
      <TextInput source="price" />
      <TextInput source="stock" />
      <ImageInput source="image" />
    </SimpleForm>
  </Create>
);

export default CreateProduct;
