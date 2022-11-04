import React, { FC } from "react";
import { useTranslation } from "react-i18next";
import { Maybe } from "monet";
import * as _ from "lodash/fp";
import { Dropdown, DropdownChangeParams } from "primereact/dropdown";
import {
  LabeledInputWrapper,
  LabelWrapper,
  InputLabel,
  DropdownWrapper,
} from "./styles";

interface Props {
  label: string;
  value: Maybe<string>;
  options: { label: string; value: string }[];
  optionLabel: string;
  onChange: (e: DropdownChangeParams) => void;
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

      <DropdownWrapper
        height={_.toString(props.height)}
        width={props.width}
        isCentered={props.isCentered}
      >
        <Dropdown
          value={props.value.orSome("")}
          options={props.options}
          onChange={props.onChange}
          width={props.width}
        />
      </DropdownWrapper>
    </LabeledInputWrapper>
  );
};

DropdownInline.defaultProps = {
  height: 35,
  width: 200,
  labelSize: 30,
  marginBottom: 40,
  isCentered: false,
};

export default DropdownInline;
