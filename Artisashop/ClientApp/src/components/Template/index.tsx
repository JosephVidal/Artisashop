import React from "react";
import SideMenu from "components/SideMenu";
import TopMenu from "components/TopMenu";
import CurrentGameHandler from "pages/Game/components/CurrentGameHandler";
import LogHandler from "components/LogHandler";
import { ToastHandler } from "components/Toaster";
import { Outlet } from "react-router-dom";
import { ContentWrapper, TemplateWrapper, ChildrenWrapper } from "./styles";

interface Props {
  toastHandler: ToastHandler;
}

const Template: React.FunctionComponent<Props> = ({ toastHandler }) => (
  <TemplateWrapper>
    <>
      <SideMenu />
      <ContentWrapper>
        <TopMenu />
        <ChildrenWrapper>
          <CurrentGameHandler />
          <LogHandler toastHandler={toastHandler} />
          <Outlet />
        </ChildrenWrapper>
      </ContentWrapper>
    </>
  </TemplateWrapper>
);

export default Template;
