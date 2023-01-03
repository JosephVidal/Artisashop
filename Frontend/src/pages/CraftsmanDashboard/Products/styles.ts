import styled from "styled-components";
import { colors } from "globals/styles";
import {InputText} from "primereact/inputtext";
import {Accordion, AccordionTab} from "primereact/accordion";

export const Wrapper = styled.div`
  width: 100%;
  min-height: 70vh;
  display: flex;
  flex-direction: column;
  align-items: start;
  align-content: center;
`;

export const NewProductButton = styled.div`
  width: 190px;
  height: 40px;
  background: ${colors.darkRed};
  border-radius: 10px;
  cursor: pointer;
  font-weight: bold;
  color: white;
  display: flex;
  justify-content: center;
  align-items: center;
  text-align: center;
  margin-bottom: 10px;
  
  :hover {
    background: ${colors.orange};
  }
  
  & svg {
    margin-right: 10px;
    color: white;
  }
`;

export const ProductWrapper = styled.div`
  display: flex;
  flex-direction: row;
  color: black;
  height: 125px;
  padding: 10px;
  margin-bottom: 10px;
  width: 100%;
  border: 2px solid ${colors.darkRed};
  border-radius: 10px;
  cursor: pointer;

  & img {
    width: 100px;
    height: 100px;
    align-self: center;
  }
  
  :hover {
    border: 2px solid ${colors.orange};
  }
`;

export const ImageWrapper = styled.div`
  width: 100px !important;
  max-width: 100px !important;
  margin-right: 20px;
`;

export const ProductDetails = styled.div`
  display: flex;
  width: 100%;
  margin-right: 10px;
`;

export const ProductName = styled.div`
  width: 50%;
  display: flex;
  justify-content: start;
  align-items: center;
`;

export const Quantity = styled.div`
  width: 30%;
  display: flex;
  justify-content: start;
  align-items: center;
`;

export const PriceWrapper = styled.div`
  width: 20%;
  display: flex;
  justify-content: end;
  align-items: center;
  color: black;
  font-weight: bold;
`;
