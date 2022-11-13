import React from "react";
import { ProgressSpinner } from "primereact/progressspinner";
import { LoaderWrapper } from "./styles";

interface Props {
  visible: boolean;
}

const Loader: React.FunctionComponent<Props> = ({ visible }) => (
  <LoaderWrapper visible={visible}>
    <ProgressSpinner strokeWidth="2" animationDuration="1s" />
  </LoaderWrapper>
);

export default Loader;
