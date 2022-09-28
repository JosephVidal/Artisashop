import styled from "styled-components";

export const TemplateWrapper = styled.div`
  height: 100%;
  width: 100%;
  display: flex;
  flex-direction: row;
`;

export const ContentWrapper = styled.div`
  display: flex;
  flex: 1;
  order: 1;
  margin-left: 250px;
  flex-direction: column;
  align-content: flex-start;
`;

export const ChildrenWrapper = styled.div`
  margin-top: 60px;
`;
