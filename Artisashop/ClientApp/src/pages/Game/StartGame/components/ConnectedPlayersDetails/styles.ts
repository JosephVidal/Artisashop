import styled from "styled-components";
import { colors } from "globals/styles";
import { EquipmentStateIcons } from "components/EquipmentState/styles";
import { ChooseTeamWrapper } from "components/ChooseTeam/styles";

export const ConnectedPlayersDetailsWrapper = styled.div`
  width: 100%;
  margin: 12px 0;
  display: flex;
  align-items: center;
  height: 60px;

  ${EquipmentStateIcons} {
    margin-left: 25px;
    width: 50px;
  }

  ${ChooseTeamWrapper} {
    margin-left: 1.5rem;
  }
`;

interface DeletePlayerProps {
  visible: boolean;
}

export const DeletePlayer = styled.div<DeletePlayerProps>`
  display: ${(props) => (props.visible ? "flex" : "none")};
  top: 15px;
  width: 15px;
  height: 15px;
  margin: 5px;
  cursor: pointer;

  :before,
  :after {
    position: absolute;
    content: " ";
    height: 15px;
    width: 3px;
    background-color: ${colors.errorColor};
  }

  :before {
    transform: rotate(45deg);
  }
  :after {
    transform: rotate(-45deg);
  }
`;

export const PlayerName = styled.div`
  text-align: left;
  margin: 0 20px;
  flex: 1;
`;

export const PlayerSkin = styled.div`
  width: 120px;
  margin-right: 20px;
`;

export const PlayerComputer = styled.span`
  width: 44px;
  font-size: 40px;
  text-align: right;
  margin-left: 15px;
`;
