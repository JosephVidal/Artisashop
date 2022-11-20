import React, { useState } from "react";
import { Dropdown, DropdownChangeParams } from "primereact/dropdown";
import ShortId from "shortid";
import { OptionProps, optionsFromChildren } from "components/Select/Option";
import { SelectWrapper } from "./styles";

interface Props<T> {
  id?: string;
  value?: T;
  editable?: boolean;
  placeholder?: string;
  onChange?: (value: any) => void;
  visible?: boolean;
  children:
    | React.ReactElement<OptionProps>
    | Array<React.ReactElement<OptionProps>>;
}

const Select = <T extends any>(props: Props<T>) => {
  const [id] = useState<string>(props.id || ShortId.generate());
  const options = optionsFromChildren(props.children);

  return (
    <SelectWrapper
      className="p-input-filled p-float-label"
      visible={props.visible === undefined ? true : props.visible}
    >
      <Dropdown
        id={id}
        value={props.value}
        options={options}
        editable={props.editable}
        placeholder={props.placeholder}
        onChange={onChange(props)}
      />
    </SelectWrapper>
  );
};

const onChange =
  <T extends any>(props: Props<T>) =>
  (e: DropdownChangeParams) =>
    props.onChange && props.onChange(e.value);

Select.defaultProps = {
  id: undefined,
  value: undefined,
  editable: undefined,
  placeholder: undefined,
  onChange: undefined,
  visible: undefined,
};

export default Select;
