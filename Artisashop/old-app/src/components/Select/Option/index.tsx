import React from "react";

export interface OptionProps {
  label: string;
  value: any;
  className?: string;
  disabled?: boolean;
}

/* eslint-disable-next-line react/jsx-no-useless-fragment */
const Option: React.FunctionComponent<OptionProps> = () => <></>;

export default Option;

export const optionsFromChildren = (
  children:
    | React.ReactElement<OptionProps>
    | Array<React.ReactElement<OptionProps>>
): Array<OptionProps> =>
  (Array.isArray(children) ? children : [children]).map((node) => node.props);
