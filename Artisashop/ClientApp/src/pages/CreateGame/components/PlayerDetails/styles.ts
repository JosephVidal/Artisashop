import { colors } from "globals/styles";
import styled from "styled-components";

export const PlayerDetailsWrapper = styled.div`
  width: 100%;
  margin: 12px 0;
  display: flex;
  flex-direction: row;
  align-items: center;
  justify-content: space-between;
`;

interface DeletePlayerProps {
  visible: boolean;
}

export const DeletePlayer = styled.div<DeletePlayerProps>`
  display: ${(props) => (props.visible ? "flex" : "none")};
  right: 15px;
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
