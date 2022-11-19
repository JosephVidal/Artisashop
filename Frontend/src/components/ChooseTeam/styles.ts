import styled from "styled-components";

interface TeamIconProps {
  teamcolor: string;
}

export const ChooseTeamWrapper = styled.div`
  width: 15px;
  height: 15px;
  position: relative;
`;

export const TeamIcon = styled.button<TeamIconProps>`
  width: 15px;
  height: 15px;
  border-radius: 50%;
  border: none;
  box-shadow: 0 0 8px 0 ${(props) => props.teamcolor};
  background-color: ${(props) => props.teamcolor};
  outline: none;
  cursor: pointer;
  padding: 0;
  position: relative;
  z-index: 2;
`;

interface TeamSelectorWrapperProps {
  visible: boolean;
}

export const TeamSelectorWrapper = styled.div<TeamSelectorWrapperProps>`
  width: 89px;
  background: black;
  border-radius: 10px;
  margin-left: -44px;
  padding: 2px 2px 7px 7px;
  position: absolute;
  bottom: 20px;
  left: 50%;
  display: ${(props) => (props.visible ? "flex" : "none")};
  flex-wrap: wrap;
  align-items: center;
  justify-content: space-evenly;

  & > ${TeamIcon} {
    margin: 5px 5px 0 0;
  }
`;

export const TeamSelectorArrow = styled.div`
  height: 12px;
  width: 12px;
  background: black;
  transform: rotate(45deg);
  position: absolute;
  left: 50%;
  bottom: 0;
  margin-bottom: -5px;
  margin-left: -6px;
  z-index: 1;
`;
