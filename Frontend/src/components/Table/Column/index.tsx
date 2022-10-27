import React from "react";
import { Column as PRColumn, ColumnAlignType } from "primereact/column";

interface Props {
  field?: string;
  header: string;
  body?: any;
  children?: any;
  align?: ColumnAlignType;
}

const Column = ({ field, header, body, children }: Props) => (
  <PRColumn field={field} header={header} body={body}>
    {children}
  </PRColumn>
);

export default Column;
