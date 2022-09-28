import styled from "styled-components";
import { colors } from "globals/styles";

export const DaysWrapper = styled.div`
  height: 560px;
  display: flex;
  flex-direction: column;
  z-index: 0;

  & .p-tabview-nav {
    border: none;
  }

  & .p-tabview-nav li {
    border: solid ${colors.borderColor};
    border-width: 0 0 2px 0;
  }

  & .p-tabview .p-tabview-nav .p-tabview-nav-link {
    background: transparent;
  }

  & .p-tabview .p-tabview-nav li.p-highlight .p-tabview-nav-link {
    background: transparent;
  }

  & .p-tabview-panels {
    background: transparent;
    padding-top: 50px;
  }

  & .p-tabview .p-tabview-nav li .p-tabview-nav-link:not(.p-disabled):focus {
    box-shadow: none;
  }

  .p-scrollpanel.p-component {
    height: inherit;

    .p-scrollpanel-content {
      height: 109%;
      overflow-x: hidden;
      z-index: 0;
    }
  }
`;

export const OpeningTextWrapper = styled.div`
  margin-left: 29.4%;
  width: 31%;
  display: flex;
  flex: 1;
  justify-content: space-between;
  margin-bottom: 20px;
`;

export const OpeningText = styled.span`
  font-size: 20px;
  font-weight: bolder;
`;

export const OpeningHoursButtonWrapper = styled.div`
  width: 250px;
  margin-top: 40px;
  align-self: end;
`;
