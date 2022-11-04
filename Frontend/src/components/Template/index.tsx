import React from "react";
import TopMenu from "components/TopMenu";
import LogHandler from "components/LogHandler";
import Footer from "components/Footer";
import { ToastHandler } from "components/Toaster";
import { Outlet } from "react-router-dom";
import { ContentWrapper, TemplateWrapper, ChildrenWrapper } from "./styles";

interface Props {
  toastHandler: ToastHandler;
}

const Template: React.FunctionComponent<Props> = ({ toastHandler }) => (
  <TemplateWrapper>
    <ContentWrapper>
      <TopMenu />
      <ChildrenWrapper>
        <LogHandler toastHandler={toastHandler} />
        <Outlet />
      </ChildrenWrapper>
      <Footer />
    </ContentWrapper>
  </TemplateWrapper>
);

export default Template;
