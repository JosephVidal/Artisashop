import React from "react";
import { PageTitleWrapper } from "./styles";

interface Props {
  centered?: boolean;
  children: React.ReactNode;
}

const PageTitle: React.FunctionComponent<Props> = ({ children, centered }) => (
  <PageTitleWrapper centered={centered}>{children}</PageTitleWrapper>
);

export default PageTitle;
