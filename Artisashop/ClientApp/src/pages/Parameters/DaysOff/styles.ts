import styled from "styled-components";
import { colors } from "globals/styles";
import { OverlayPanel } from "primereact/overlaypanel";

export const CalendarWrapper = styled.div`
  height: 100%;
  width: 100%;
  margin-left: 100px;
  margin-right: 100px;
  background-color: ${colors.surfaceA};
  padding: 20px;

  & .fc-theme-standard td {
    border-color: ${colors.surfaceD};
  }

  & .fc-theme-standard th {
    border-color: ${colors.surfaceD};
  }

  & .fc-scrollgrid {
    border-color: ${colors.surfaceD};
  }

  & .fc-highlight {
    background: ${colors.surfaceD};
  }

  & .fc-daygrid-day.fc-day-today {
    background: ${colors.surfaceD};
  }
`;

export const CustomOverlayPanel = styled(OverlayPanel)`
  background: ${colors.surfaceD};
  box-shadow: 0 0 20px 10px rgba(0, 0, 0, 0.34);

  &.p-overlaypanel:after {
    border-bottom-color: ${colors.surfaceD} !important;
    border-width: 8px !important;
    margin-left: -10px !important;
  }

  &.p-overlaypanel:before {
    border: none;
  }
`;
