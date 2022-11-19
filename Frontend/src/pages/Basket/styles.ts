import styled from "styled-components";
import { colors } from "globals/styles";
import {InputText} from "primereact/inputtext";

export const Wrapper = styled.div`
  min-height: 70vh;
  display: flex;
  flex-direction: row;
  align-items: start;
  align-content: center;
  margin: 6vh;
`;

export const BasketDeliveryWrapper = styled.div`
  display: flex;
  flex-direction: column;
  ;
  width: 65%;
`;

interface CardProps {
  isBill?: boolean,
  isDelivery?: boolean
}

export const Card = styled.div<CardProps>`
  display: flex;
  flex-direction: column;
  width: ${(props) => props.isBill ? "35%" : "100%"};
  border: 1px solid ${colors.darkBlue};
  border-radius: 10px;
  margin-left: ${(props) => props.isBill ? "6vw" : "0"};
  margin-top: ${(props) => props.isDelivery ? "3vh" : "0"};
  background: ${colors.darkBlue};
  font-family: HelveticaNeue;
  
  .p-divider {
    color: gray;
    width: 90%;
    align-self: center;
    margin-bottom: 20px;
  }
`;

export const CardTitle = styled.div`
  background: ${colors.darkBlue};
  border-radius: 10px 10px 0 0;
  font-size: 20px;
  height: 50px;
  padding: 15px;
  font-weight: bold;
`;

interface CardBodyProps {
  isBill?: boolean
}

export const CardBody = styled.div<CardBodyProps>`
  background: ${(props) => props.isBill ? colors.darkBlue : colors.beige};
  border-radius: 0 0 10px 10px;
  display: flex;
  flex-direction: column;
  padding: ${(props) => props.isBill ? "30px 15px 30px 15px" : "15px"};
  font-size: 20px;
  color: ${(props) => props.isBill ? "white" : "black"};
  height: fit-content;

  .p {
    color: white !important;
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
`;

export const ProductDetails = styled.div`
  display: flex;
  flex-direction: column;
  justify-content: center;
  flex: 0.7;
  
  & div {
    display: flex;
    align-items: center;
    height: 30px;
  }
`;

export const LeftWrapper = styled(ProductDetails)`
  flex: 0.15;

  .p-dropdown {
    margin-top: 10px;
    background: ${colors.darkRed};
    color: black;
    border: none;
    height: 40px;
    width: 200px;
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
