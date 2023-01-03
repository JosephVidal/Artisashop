import styled from "styled-components";
import { colors } from "globals/styles";

export const Wrapper = styled.div`
  min-height: 70vh;
  display: flex;
  flex-direction: column;
  align-items: start;
  align-content: center;
  margin: 6vh;
`;

export const TabWrapper = styled.div`
  display: flex;
  flex-direction: row;
  width: 100%;
  align-content: space-between;
  margin-bottom: 30px;
`;

interface TabButtonProps {
  selected?: boolean;
}

export const TabButton = styled.div<TabButtonProps>`
  margin: 0 5px 0 5px;
  width: 100%;
  height: 50px;
  background: ${(props) => props.selected ? colors.darkRed : colors.beige};
  border: 1px solid ${colors.darkRed};
  border-radius: 10px;
  cursor: pointer;
  font-weight: bold;
  color: ${(props) => props.selected ? "white" : colors.darkRed};
  display: flex;
  justify-content: center;
  align-items: center;
  text-align: center;
`;
