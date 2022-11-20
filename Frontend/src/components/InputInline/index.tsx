import React, { FC, ChangeEvent } from "react";
import { useSpring, config } from "@react-spring/web";
import { useTranslation } from "react-i18next";
import { Maybe } from "monet";
import * as _ from "lodash/fp";
import {
  InputNumber,
  InputNumberValueChangeParams,
} from "primereact/inputnumber";
import {
  LabeledInputWrapper,
  LabelWrapper,
  InputLabel,
  InputWrapper,
  TextInput,
  WarningMessageWrapper,
  WarningMessage,
  WarningIcon,
} from "./styles";

interface Props {
  type: "text" | "minmax";
  label: string;
  value: Maybe<any>;
  min?: number;
  max?: number;
  onChange?: (event: ChangeEvent<HTMLInputElement>) => void;
  onValueChange?: (event: InputNumberValueChangeParams) => void;
  height?: number;
  width?: number;
  labelSize?: number;
  marginBottom?: number;
  isCentered?: boolean;
  suffix?: string;
  withWarningMessage?: boolean;
  warningMessage?: string;
}

const InputInline: FC<Props> = (props: Props) => {
  const { t } = useTranslation();

  const warningMessageSpring = useSpring({
    to: { opacity: props.withWarningMessage ? 1 : 0 },
    from: { opacity: 0 },
    delay: 100,
    config: config.molasses,
  });

  const renderTextInputInline = () => (
    <TextInput
      value={props.value.orSome("")}
      onChange={props.onChange}
      height={_.toString(props.height)}
      width={_.toString(props.width)}
    />
  );

  const renderMinMaxInputInline = () => (
    <InputNumber
      value={_.toInteger(props.value.orSome(props.min))}
      onValueChange={props.onValueChange}
      showButtons
      min={props.min}
      max={props.max}
      suffix={props.suffix && ` ${t(props.suffix)}`}
    />
  );

  const renderWarningMessage = () => (
    <WarningMessageWrapper style={warningMessageSpring}>
      <WarningIcon className="pi pi-exclamation-triangle" />

      <WarningMessage>
        {props.warningMessage && t(props.warningMessage)}
      </WarningMessage>
    </WarningMessageWrapper>
  );

  return (
    <LabeledInputWrapper
      className="p-input-filled"
      marginBottom={_.toString(props.marginBottom)}
    >
      <LabelWrapper isCentered={props.isCentered}>
        <InputLabel
          labelSize={_.toString(props.labelSize)}
          isCentered={props.isCentered}
        >
          {t(props.label)}
        </InputLabel>
      </LabelWrapper>

      <InputWrapper
        height={_.toString(props.height)}
        width={props.width}
        isCentered={props.isCentered}
      >
        {props.type === "text" && renderTextInputInline()}
        {props.type === "minmax" && renderMinMaxInputInline()}
        {renderWarningMessage()}
      </InputWrapper>
    </LabeledInputWrapper>
  );
};

InputInline.defaultProps = {
  min: 1,
  max: 100,
  onChange: undefined,
  onValueChange: undefined,
  height: 35,
  width: 200,
  labelSize: 30,
  marginBottom: 40,
  isCentered: false,
  withWarningMessage: false,
  warningMessage: "",
};

export default InputInline;
