import { colors } from "globals/styles";
import styled from "styled-components";

interface VerticalMenuWrapperProps {
  noBorder: boolean;
}

export const VerticalMenuWrapper = styled.div<VerticalMenuWrapperProps>`
  .no-children > .p-toggleable-content {
    display: none;
  }

  ${(props) =>
    props.noBorder &&
    `
    .p-panelmenu .p-panelmenu-header > a {
      border: none;
      box-shadow: none;
    }
    
    .p-panelmenu .p-panelmenu-content {
      border: none;
    }
    
    .p-panelmenu .p-panelmenu-content .p-menuitem .p-menuitem-link {
      box-shadow: none;
    }
    
    .p-panelmenu .p-panelmenu-panel.active a {
      background: ${colors.surfaceB};
    }
    
    .p-panelmenu .p-panelmenu-content .p-menuitem.active .p-menuitem-link {
      background: ${colors.surfaceB};
    }
    
    .p-panelmenu .p-panelmenu-panel .p-panelmenu-header a.p-panelmenu-header-link {
      border-radius: 0;
    }
  `}
`;
