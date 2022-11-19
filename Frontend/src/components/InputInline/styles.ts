import styled from "styled-components";
import { colors } from "globals/styles";
import { InputText } from "primereact/inputtext";
import { animated } from "@react-spring/web";
import * as _ from "lodash/fp";

interface LabeledInputWrapperProps {
  marginBottom?: string;
}

interface LabelWrapperProps {
  isCentered?: boolean;
}

interface InputLabelProps {
  labelSize?: string;
  isCentered?: boolean;
}

interface InputWrapperProps {
  height?: string;
  width?: number;
  isCentered?: boolean;
}

interface TextInputProps {
  height?: string;
  width?: string;
}

export const LabeledInputWrapper = styled.div<LabeledInputWrapperProps>`
  display: flex;
  align-items: center;
  width: 100%;
  margin-bottom: ${(props) =>
    props.marginBottom ? `${props.marginBottom}px` : "40px"};
`;

export const LabelWrapper = styled.div<LabelWrapperProps>`
  flex: ${(props) => (props.isCentered ? 0.5 : 0.3)};
  margin-right: 5px;
`;

export const InputLabel = styled.p<InputLabelProps>`
  font-size: ${(props) => (props.labelSize ? `${props.labelSize}px` : "30px")};
  margin: 0 10px 0 0;
  text-align: ${(props) => (props.isCentered ? "end" : "start")};
`;

export const InputWrapper = styled.div<InputWrapperProps>`
  display: flex;
  align-items: center;
  flex: ${(props) => (props.isCentered ? 0.5 : 0.7)};

  & > .p-inputnumber {
    height: ${(props) => (props.height ? `${props.height}px` : "35px")};
  }

  & > .p-inputnumber > .p-inputnumber-input {
    width: ${(props) =>
      props.width ? `${_.toString(_.subtract(props.width, 35))}px` : "165px"};
  }

  & > .p-inputnumber > .p-inputnumber-button-group > .p-inputnumber-button-up,
  &
    > .p-inputnumber
    > .p-inputnumber-button-group
    > .p-inputnumber-button-down {
    width: 35px;
  }
`;

export const TextInput = styled(InputText)`
  width: ${(props: TextInputProps) =>
    props.width ? `${props.width}px` : "35px"};
  height: ${(props: TextInputProps) =>
    props.height ? `${props.height}px` : "35px"};
`;

export const WarningMessageWrapper = styled(animated.div)`
  display: flex;
  align-items: center;
  margin-left: 15px;
  color: ${colors.warning};
`;

export const WarningIcon = styled.i`
  font-size: 30px;
`;

export const WarningMessage = styled.p`
  margin-left: 10px;
`;
