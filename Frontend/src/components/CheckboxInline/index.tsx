import React, { FC } from "react";
import { useTranslation } from "react-i18next";
import * as _ from "lodash/fp";
import { Checkbox, CheckboxChangeParams } from "primereact/checkbox";
import {
  LabeledInputWrapper,
  LabelWrapper,
  InputLabel,
  InputWrapper,
} from "./styles";

interface Props {
  label: string;
  checked: boolean;
  onChange?: (e: CheckboxChangeParams) => void;
  height?: number;
  width?: number;
  labelSize?: number;
  marginBottom?: number;
  isCentered?: boolean;
  suffix?: string;
}

const DropdownInline: FC<Props> = (props: Props) => {
  const { t } = useTranslation();

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
        <Checkbox checked={props.checked} onChange={props.onChange} />
      </InputWrapper>
    </LabeledInputWrapper>
  );
};

DropdownInline.defaultProps = {
  onChange: undefined,
  height: 35,
  width: 200,
  labelSize: 30,
  marginBottom: 40,
  isCentered: false,
};

export default DropdownInline;
