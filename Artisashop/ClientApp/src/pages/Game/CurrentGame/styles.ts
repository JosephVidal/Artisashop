import styled from "styled-components";

export const CurrentGameWrapper = styled.div`
  width: 100%;
  max-height: 650px;
  display: flex;
`;

export const Players = styled.div`
  flex: 1;
  flex-basis: 50%;
  display: flex;
  margin-left: 10px;
  margin-right: 10px;
  flex-direction: column;

  & .p-scrollpanel .p-component {
    height: 600px;
  }

  & .p-scrollpanel-wrapper {
    height: 100%;
  }

  & .p-scrollpanel-content {
    overflow-x: hidden;
    height: 99%;
  }

  &
    .p-accordion
    .p-accordion-header:not(.p-disabled).p-highlight
    .p-accordion-header-link {
    border-color: #17212f;
  }

  &
    .p-accordion
    .p-accordion-header:not(.p-disabled).p-highlight:hover
    .p-accordion-header-link {
    border-color: #17212f;
  }

  &
    .p-accordion
    .p-accordion-header:not(.p-disabled):not(p-highlight):hover
    .p-accordion-header-link {
    border: none;
  }

  & .p-accordion .p-accordion-header .p-accordion-header-link {
    padding: 0 20px;
    display: flex;
    background: transparent;
    border: none;
    box-shadow: none;
    border-bottom: 1px solid #17212f;

    &:focus {
      box-shadow: none;
    }

    & .p-accordion-header-text {
      flex: 1;
    }
  }

  & .p-accordion .p-accordion-content {
    border: none;
  }
`;

export const GameInfo = styled.div`
  flex: 1;
  flex-basis: 50%;
  display: flex;
  margin-left: 30px;
  margin-right: 10px;
  flex-direction: column;
`;
