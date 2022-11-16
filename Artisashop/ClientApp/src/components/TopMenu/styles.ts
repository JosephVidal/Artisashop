import styled from "styled-components";
import { colors } from "globals/styles";

export const TopMenuWrapper = styled.div`
  background-color: ${colors.darkBlue};
  box-shadow: 0 10px 20px 0 black;
  position: fixed;
  z-index: 11;
  width: 100%;
  display: flex;
  justify-content: center;
  height: 48px;

  .p-image {
    z-index: 2;
    align-self: center;
    margin-top: 50px;
  }
`;

export const Quarter = styled.div`
  flex: 0.25;
`;

export const MenuItem = styled(Quarter)`
  justify-content: center;
  text-align: center;
  line-height: 1.6;
  font-size: 1.25rem;
  font-family: "Raleway-Black", sans-serif;
  padding: 0.5rem 1rem;

  & text {
    cursor: pointer;
  }

  & text:hover {
    color: ${colors.orange};
  }
`;

export const RightIcons = styled(Quarter)`
  display: flex;
  flex-direction: row;
  justify-content: flex-end;
  margin: 0.7rem 0 0.7rem 0;

  & svg {
    flex: 0.25;
    cursor: pointer;
  }

  & svg:hover {
    color: ${colors.orange};
  }
`;
