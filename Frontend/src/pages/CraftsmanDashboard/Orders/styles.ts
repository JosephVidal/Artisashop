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

export const CustomAccordion = styled(Accordion)`
  display: flex;
  flex-direction: column;
  width: 100%;
  background: ${colors.beige};
  font-family: HelveticaNeue;
  
  .p-accordion-tab {
    min-height: 30px;
    border: 2px solid ${colors.darkRed};
    border-radius: 10px;
    padding: 10px;
    margin: 10px 0 10px 0;
    
    & span {
      color: black;
      margin-right: 5px;
    }
  }

  .p-accordion-header-link {
    width: 100%;
    align-items: center;
  }

  .p-accordion-header-text {
    width: 100%;
  }
`;

export const ProductWrapper = styled.div`
  display: flex;
  flex-direction: row;
  color: black;
  height: 100px;
  margin: 10px;

  & img {
    width: 100px;
    height: 100px;
    align-self: center;
  }
`;

export const ImageWrapper = styled.div`
  flex: 0.3;
  width: 120px !important;
  max-width: 120px !important;
  margin-right: 20px;
`;

export const ProductDetails = styled.div`
  display: flex;
  flex-direction: row;
  justify-content: space-between;
  align-items: center;
  width: 100%;

  & div {
    display: flex;
    align-items: center;
    height: 30px;
  }
  
  .p-dropdown {
    margin-top: 10px;
    background: ${colors.darkRed};
    color: black;
    border: none;
    height: 40px;
    width: 200px;

    & span {
      color: ${colors.beige};
      margin-right: 5px;
    }
  }

  .p-input-filled .p-inputtext {
    background: ${colors.beige};
    border: 1px solid ${colors.darkRed};
    color: black;
    font-weight: bold;
    height: 40px;
  }

  .p-dropdown-panel {
    background: ${colors.darkRed};
  }

  .p-input-filled .p-dropdown:not(.p-disabled):hover {
    background: ${colors.orange};
  }

  .p-dropdown:not(.p-disabled):hover {
    border-color: ${colors.orange};
  }
`;

export const HeaderWrapper = styled.div`
  width: 100%;
  display: flex;
  flex-direction: row;
  align-items: center;
`;

export const ClientName = styled.div`
  flex: 1;
  justify-self: left;
`;

export const HeaderRight = styled.div`
  flex: 0.15;
  justify-self: right;
`;

export const LeftWrapper = styled(ProductDetails)`
  flex: 0.15;
`;


export const PriceWrapper = styled.div`
  flex: 0.15;
  display: flex;
  flex-direction: row;
  justify-content: end;
  align-items: center;
  color: black;
  font-weight: bold;
`;

export const AddressInput = styled(InputText)`
  justify-content: center;
  margin-top: 10px;
  height: 30px;
  background: ${colors.beige};
  color: black;
  border: 1px solid ${colors.darkRed};
  border-radius: 5px;

  :enabled:focus {
    border-color: ${colors.darkRed};
    box-shadow: 0 0 0 1px ${colors.darkRed};
  }
`;

export const Bill = styled.div`
  display: flex;
  flex-direction: column;
  width: 30%;
  border-radius: 10px;
  justify-items: center;
`;

export const BillElement = styled.div`
  margin-bottom: 20px;
  min-height: 40px;
`;

export const TextRight = styled.div`
  text-align: right;
`;

export const ProductBill = styled.div`
  display: flex;
  flex-direction: row;
  justify-content: space-between;
  font-size: 15px;
`;
