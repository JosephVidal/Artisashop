import styled from "styled-components";

export const ParameterWrapper = styled.div`
  display: flex;
  flex-flow: row wrap;
  justify-content: space-around;
  margin: auto;
  width: 93%;
`;

export const EquipmentLetter = styled.span`
  font-size: 60px;
  margin-bottom: 5px;
`;

export const ParameterEquipment = styled.div`
  text-align: center;
  padding: 20px 10px;
  display: flex;
  flex-direction: column;
  align-items: center;
`;

export const EquipmentActivationCheckboxWrapper = styled.div`
  font-size: 16px;
  align-items: center;

  & > div {
    display: flex;
    flex-direction: row-reverse;
    margin-top: 10px;

    & > .p-checkbox {
      margin-left: 15px;
    }
  }
`;
