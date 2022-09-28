import styled from "styled-components";
import { colors } from "globals/styles";

interface LineProps {
  startingColor?: "BLUE" | "DARK";
  clickable?: boolean;
}

export const DataTableWrapper = styled.div<LineProps>`
  height: 100%;

  .p-scrollpanel.p-component {
    height: 100%;
  }

  .p-scrollpanel-content {
    padding-bottom: 0;
    height: 99%;
    overflow-x: hidden;

    .p-datatable.p-component {
      margin-left: 9px;
    }

    .p-column-title {
      font-size: 28px;
    }

    & > .p-datatable > .p-datatable-wrapper > table {
      & > .p-datatable-thead {
        z-index: 1000;
        position: sticky;
        top: 0;

        & > tr > th {
          font-weight: 300;
          background: ${colors.surfaceE};
          border: none;
        }
      }

      & > tbody > tr {
        background: ${colors.surfaceA};

        ${(props) =>
          props.clickable &&
          `
          cursor: pointer
        `}
      }

      & > .p-datatable-tbody > tr {
        &:nth-child(${(props) =>
              props.startingColor === "DARK"
                ? "odd"
                : "even"}):not(.p-rowgroup-header) {
          background: ${colors.surfaceE};
        }

        &:not(.p-rowgroup-header):hover {
          ${(props) =>
            props.clickable &&
            `
            background: ${colors.surfaceD};
          `}
        }

        & > td {
          font-weight: 300;
          border: none;
        }
      }

      & > .p-datatable-tfoot {
        max-height: 0;
        display: none;
      }
    }

    td {
      font-size: 24px;
    }
  }
`;
