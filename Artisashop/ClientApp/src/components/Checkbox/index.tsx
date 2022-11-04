import React, { FC, useState } from "react";
import { Checkbox as PRCheckbox } from "primereact/checkbox";
import ShortId from "shortid";
import { CheckboxWrapper } from "./styles";

interface Props {
  checked?: boolean;
  onChange: (checked: boolean) => void;
  id?: string;
  label?: string;
}

const Checkbox: FC<Props> = (props: Props) => {
  const [id] = useState<string>(props.id || ShortId.generate());

  return (
    <CheckboxWrapper>
      <PRCheckbox
        inputId={id}
        checked={props.checked}
        onChange={onCheckboxChange(props)}
      />

      {props.label && <label htmlFor={id}>{props.label}</label>}
    </CheckboxWrapper>
  );
};

const onCheckboxChange = (props: Props) => (event: { checked: boolean }) =>
  props.onChange && props.onChange(event.checked);

export default Checkbox;
