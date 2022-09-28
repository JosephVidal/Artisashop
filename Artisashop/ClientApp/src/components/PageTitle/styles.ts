import styled from "styled-components";

interface PageTitleWrapperProps {
  centered?: boolean;
}

export const PageTitleWrapper = styled.div<PageTitleWrapperProps>`
  line-height: 1.15;
  font-size: 40px;
  margin-bottom: 65px;
  text-align: ${(props) => (props.centered ? "center" : "left")};
`;
