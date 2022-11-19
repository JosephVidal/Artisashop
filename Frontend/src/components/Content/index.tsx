import React from "react";
import PageTitle from "components/PageTitle";
import ContentLoader from "components/ContentLoader";
import { ContentWrapper } from "./styles";

interface Props {
  title: React.ReactNode;
  loading?: boolean;
  fixedHeight?: boolean;
  centered?: boolean;
  children: React.ReactNode;
}

const Content: React.FunctionComponent<Props> = ({
  title,
  children,
  loading = false,
  fixedHeight,
  centered = false,
}) => (
  <ContentWrapper fixedHeight={fixedHeight}>
    <PageTitle centered={centered}>{title}</PageTitle>
    <ContentLoader loading={loading}>{children}</ContentLoader>
  </ContentWrapper>
);

export default Content;
