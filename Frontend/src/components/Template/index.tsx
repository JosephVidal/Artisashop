import React from "react";
import TopMenu from "components/TopMenu";
import Footer from "components/Footer";
import { ToastHandler } from "components/Toaster";
import { Outlet } from "react-router-dom";
import { ContentWrapper, TemplateWrapper, ChildrenWrapper } from "./styles";

interface Props {
  toastHandler: ToastHandler;
  background: string;
}

const Template: React.FunctionComponent<Props> = ({ toastHandler, background }) => (
  <TemplateWrapper>
    <ContentWrapper background={background}>
      <TopMenu />
      <ChildrenWrapper>
        <Outlet />
      </ChildrenWrapper>
      <Footer />
    </ContentWrapper>
  </TemplateWrapper>
);

export default Template;
