import React, { ReactNode } from "react";
import {
  DataTable,
  DataTableRowClickEventParams,
  DataTableRowGroupHeaderTemplateOptions,
} from "primereact/datatable";
import { DataTableWrapper } from "components/Table/styles";
import { ScrollPanel } from "primereact/scrollpanel";

interface Props<T> {
  data: T[];
  groupBy?: string;
  groupHeaderDisplay?: (
    data: T,
    options: DataTableRowGroupHeaderTemplateOptions
  ) => ReactNode;
  sortBy?: string;
  startingColor?: "BLUE" | "DARK";
  onRowClick?: (e: DataTableRowClickEventParams) => void;
  children: React.ReactNode;
}

const Table = <T extends any>({
  data,
  groupBy,
  groupHeaderDisplay,
  sortBy,
  startingColor,
  onRowClick,
  children,
}: Props<T>) => (
  <DataTableWrapper
    startingColor={startingColor}
    clickable={onRowClick !== undefined}
  >
    <ScrollPanel>
      <DataTable
        value={data}
        rowGroupMode={groupBy && "subheader"}
        groupRowsBy={groupBy}
        rowGroupHeaderTemplate={groupHeaderDisplay}
        sortField={sortBy}
        sortOrder={-1}
        onRowClick={onRowClick}
      >
        {children}
      </DataTable>
    </ScrollPanel>
  </DataTableWrapper>
);

export default Table;
