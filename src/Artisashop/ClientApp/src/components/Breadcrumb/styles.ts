import styled from "styled-components";

interface BreadcrumbWrapperProps {
  noBorder: boolean;
}

export const BreadcrumbWrapper = styled.div<BreadcrumbWrapperProps>`
  ${(props) =>
    props.noBorder &&
    `
    .p-breadcrumb > a {
      border: none;
      box-shadow: none;
      padding: 0px;
    }
    .p-breadcrumb {
      border: none;
      padding: 0px;
    }
  `}
`;
