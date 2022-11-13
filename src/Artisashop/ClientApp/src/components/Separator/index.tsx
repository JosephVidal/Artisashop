import React, { FC } from "react";
import {
  Divider,
  DividerAlignType,
  DividerBorderType,
  DividerLayoutType,
} from "primereact/divider";
import { SeparatorWrapper } from "./styles";

interface Props {
  align?: string;
  layout?: string;
  type?: string;
  children?: React.ReactNode;
}

const Separator: FC<Props> = ({ align, layout, type, children }) => (
  <SeparatorWrapper>
    <Divider
      align={align as DividerAlignType}
      layout={layout as DividerLayoutType}
      type={type as DividerBorderType}
    >
      {children}
    </Divider>
  </SeparatorWrapper>
);

export default Separator;
