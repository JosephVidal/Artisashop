import React from "react";
import { Button,
   CreateButton,
   Datagrid,
   ExportButton,
   FilterButton,
   List,
   TextField,
   TopToolbar } from "react-admin";
import IconEvent from "@mui/icons-material/Event";

const ProductList = () => (
  <List>
    <Datagrid>
      <TextField source="id" />
      <TextField source="name" />
      <TextField source="price" />
      <TextField source="description" />
      <TextField source="quantity" />
      <TextField source="" />
    </Datagrid>
  </List>
)

export default ProductList
