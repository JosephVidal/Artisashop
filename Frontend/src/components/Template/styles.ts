import styled from "styled-components";

export const TemplateWrapper = styled.div`
  height: 100%;
  width: 100%;
  display: flex;
  flex-direction: row;
`;

interface ContentWrapperProps {
  background: string;
}

export const ContentWrapper = styled.div<ContentWrapperProps>`
  display: flex;
  flex: 1;
  order: 1;
  flex-direction: column;
  align-content: flex-start;
  background: ${(props) => props.background};
`;

export const ChildrenWrapper = styled.div`
  margin-top: 60px;
`;
