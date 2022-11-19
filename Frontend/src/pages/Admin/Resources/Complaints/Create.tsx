import React from "react";
import { Create, ReferenceField, RichTextField, SimpleForm, TextInput } from 'react-admin';

const CreateComplaint = () => (
  <Create>
    <SimpleForm>
      <TextInput source="title" />
      <RichTextField source="description" />
    </SimpleForm>
  </Create>
);

export default CreateComplaint;
