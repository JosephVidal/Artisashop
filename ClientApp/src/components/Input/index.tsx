import React, { useState } from "react";
import { InputText } from "primereact/inputtext";
import ShortId from "shortid";
import { InputNumber, InputNumberChangeParams } from "primereact/inputnumber";
import { InputWrapper } from "./styles";

type InputType = "text" | "number" | "checkbox";

export type InputValue = string | number;

interface Props {
  type: InputType;
  id?: string;
  label?: string;
  value?: InputValue;
  onChange?: (value: InputValue) => void;
  onKeyPress?: (event: KeyboardEvent, value: InputValue) => void;
  onBlur?: (event: FocusEvent, value: InputValue) => void;
  autoFocus?: boolean;
  fieldError?: string | undefined;
}

const Input: React.FunctionComponent<Props> = (props: Props) => {
  const [id] = useState<string>(props.id || ShortId.generate());

  return (
    <InputWrapper
      className="p-input-filled p-float-label"
      error={props.fieldError}
    >
      {props.type === "text" && (
        <InputText
          id={id}
          value={props.value ? props.value.toString() : ""}
          onChange={onInputTextChange(props)}
          onKeyPress={onInputTextKeyPress(props)}
          onBlur={onInputTextBlur(props)}
          autoFocus={props.autoFocus}
        />
      )}

      {props.type === "number" && (
        <InputNumber
          id={id}
          value={Number(props.value)}
          onChange={onInputNumberChange(props)}
          onBlur={onInputNumberBlur(props)}
          allowEmpty={false}
          min={1}
        />
      )}

      {props.label && <label htmlFor={id}>{props.label}</label>}

      {props.fieldError && (
        <small className="p-message-error">{props.fieldError}</small>
      )}
    </InputWrapper>
  );
};

const onInputTextChange =
  (props: Props) => (event: React.FormEvent<HTMLInputElement>) =>
    props.onChange && props.onChange(event.currentTarget.value);

const onInputTextKeyPress =
  (props: Props) => (event: React.KeyboardEvent<HTMLInputElement>) =>
    props.onKeyPress &&
    props.onKeyPress(event.nativeEvent, event.currentTarget.value);

const onInputTextBlur =
  (props: Props) => (event: React.FocusEvent<HTMLInputElement>) =>
    props.onBlur && props.onBlur(event.nativeEvent, event.currentTarget.value);

const onInputNumberChange =
  (props: Props) => (event: InputNumberChangeParams) => {
    if (props.onKeyPress)
      props.onKeyPress(
        event.originalEvent as unknown as KeyboardEvent,
        event.value as InputValue
      );

    if (props.onChange) props.onChange(event.value as InputValue);
  };

const onInputNumberBlur =
  (props: Props) => (event: React.FocusEvent<HTMLInputElement>) =>
    props.onBlur && props.onBlur(event.nativeEvent, props.value || NaN);

Input.defaultProps = {
  id: undefined,
  label: undefined,
  value: undefined,
  onChange: undefined,
  onKeyPress: undefined,
  onBlur: undefined,
  autoFocus: undefined,
};

export default Input;
