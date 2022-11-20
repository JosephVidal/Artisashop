import React from "react";
import { BsDashLg, BsPlusLg } from "react-icons/bs";
import { QuantityInputWrapper, PlusMinus, Input } from "./styles";

interface Props {
  quantity: number;
  onChange: (value: number | null) => void;
}

const QuantityInput: React.FC<Props> = ({ quantity, onChange }) => (
  <QuantityInputWrapper>
    <PlusMinus isRight={false} onClick={() => onChange(quantity - 1)}>
      <BsDashLg />
    </PlusMinus>
    <Input
      value={quantity}
      onChange={(value) => onChange(value.value)}
    />
    <PlusMinus isRight onClick={() => onChange(quantity + 1)}>
      <BsPlusLg />
    </PlusMinus>
  </QuantityInputWrapper>
);

export default QuantityInput;
