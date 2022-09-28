import styled from "styled-components";

export const ScoreTableWrapper = styled.div`
  flex: 1;
  overflow: hidden;

  & .p-datatable-wrapper {
    .p-rowgroup-header > td {
      padding: 0;
    }

    .p-selection-column {
      text-align: center;
    }
  }
`;

interface TeamsSeparatorProps {
  color: string;
}

export const TeamsSeparator = styled.div<TeamsSeparatorProps>`
  height: 7px;
  background-color: ${(props) => props.color};
`;
