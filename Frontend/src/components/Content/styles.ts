import styled from "styled-components";

interface ContentWrapperProps {
  fixedHeight?: boolean;
}

export const ContentWrapper = styled.div<ContentWrapperProps>`
  height: ${(props) => (props.fixedHeight ? "calc(100vh - 61px)" : "100%")};
  width: 100%;
  padding: 40px 50px;
  position: relative;
  display: flex;
  flex-direction: column;
`;
