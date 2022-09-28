import styled from "styled-components";

interface HorizontalMenuWrapperProps {
  noBorder: boolean;
}

export const HorizontalMenuWrapper = styled.div<HorizontalMenuWrapperProps>`
  height: 60px;

  .no-children > .p-toggleable-content {
    display: none;
  }

  ${(props) =>
    props.noBorder &&
    `
    .p-menubar > a {
      border: none;
      box-shadow: none;
    }
    .p-menubar {
      border: none;
    }`}
`;
