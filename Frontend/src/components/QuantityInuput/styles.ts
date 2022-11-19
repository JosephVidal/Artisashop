import styled from "styled-components";
import { InputNumber } from "primereact/inputnumber";
import { colors } from "globals/styles";

export const QuantityInputWrapper = styled.div`
  display: flex;
  flex-direction: row;
  align-items: center;
  height: 30px;

  & svg {
    width: 15px;
    margin: 2px;
  }
`;

export const Input = styled(InputNumber)`
  justify-content: center;
  height: 25px;
  
  & input {
    background: ${colors.beige};
    color: black;
    font-weight: bold;
    height: 25px;
    width: 40px;
    text-align: center;
    border: 1px solid ${colors.darkRed};
    border-radius: 0;
  }

  .p-inputnumber-button-group {
    height: 25px;
  }

  .p-inputtext:enabled:hover {
    border-color: ${colors.darkRed};
  }

  .p-inputtext:enabled:focus {
    border-color: ${colors.darkRed};
    box-shadow: none;
  }
`;

interface PlusMinusProps {
  isRight: boolean
}

export const PlusMinus = styled.div<PlusMinusProps>`
  background: ${colors.darkRed};
  height: 25px !important;
  width: 20px;
  color: white;
  display: flex;
  border-radius: ${(props) => props.isRight ? "0 5px 5px 0" : "5px 0 0 5px"};
  margin-left: ${(props) => props.isRight ? "0" : "10px"};
  justify-content: center;
  align-items: center;
  cursor: pointer;
  
  :hover {
    background: ${colors.orange};
  }

  & svg {
    width: 10px;
    height: 10px;
    margin: 2px;
  }
`;
