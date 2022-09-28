import styled from "styled-components";
import { colors } from "globals/styles";
import { LogoWrapper } from "components/Logo/styles";

export const SideMenuWrapper = styled.div`
  height: 100%;
  width: 250px;
  background-color: ${colors.surfaceA};
  border-right: 1px solid;
  border-color: ${colors.surfaceD};
  flex-direction: column;
  position: fixed;
  z-index: 1;

  & > ${LogoWrapper} {
    width: 180px;
    margin: 30px auto;
  }
`;
