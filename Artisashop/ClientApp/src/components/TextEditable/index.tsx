import React, { useState } from "react";
import Input from "components/Input";
import { SetState } from "globals/state";
import { Inplace, InplaceContent, InplaceDisplay } from "primereact/inplace";
import { TextEditableWrapper } from "./styles";

interface Props {
  value: string;
  placeholder?: string;
  onChange?: (value: any) => void;
  onValidateValue?: (value: any) => void;
  fieldError: string | undefined;
}

const TextEditable: React.FunctionComponent<Props> = (props: Props) => {
  const [localValue, setLocalValue] = useState<string>(props.value);
  const [active, setActive] = useState<boolean>(false);

  return (
    <TextEditableWrapper active={active}>
      <Inplace active={active} onToggle={onToggle(setActive)}>
        <InplaceDisplay>
          {localValue}
          {props.fieldError && <small>{props.fieldError}</small>}
        </InplaceDisplay>

        <InplaceContent>
          <Input
            type="text"
            label={props.placeholder}
            value={localValue}
            onChange={onChange(props, setLocalValue)}
            onKeyPress={onKeyPress(props, setActive)}
            onBlur={onBlur(props, setActive)}
            autoFocus
            fieldError={props.fieldError}
          />
        </InplaceContent>
      </Inplace>
    </TextEditableWrapper>
  );
};

const onChange =
  (props: Props, setLocalValue: SetState<string>) => (value: any) => {
    setLocalValue(value as string);

    if (props.onChange) props.onChange(value);
  };

const onKeyPress =
  (props: Props, setActive: SetState<boolean>) =>
  (event: KeyboardEvent, value: any) => {
    if (event.key === "Enter") validateValue(props, setActive)(value);
  };

const onBlur =
  (props: Props, setActive: SetState<boolean>) => (event: Event, value: any) =>
    validateValue(props, setActive)(value);

const validateValue =
  (props: Props, setActive: SetState<boolean>) => (value: any) => {
    setActive(false);

    if (props.onValidateValue) props.onValidateValue(value);
  };

const onToggle =
  (setActive: SetState<boolean>) => (event: { value: boolean }) =>
    setActive(event.value);

TextEditable.defaultProps = {
  placeholder: undefined,
  onChange: undefined,
  onValidateValue: undefined,
};

export default TextEditable;
