import React, { useState } from "react";
import { teamsColors } from "globals/styles";
import { SetState } from "globals/state";
import * as _ from "lodash/fp";
import {
  ChooseTeamWrapper,
  TeamIcon,
  TeamSelectorArrow,
  TeamSelectorWrapper,
} from "./styles";

type Team = string;

interface Props {
  value: string;
  onChangeTeam: (team: string) => void;
}

const ChooseTeam: React.FunctionComponent<Props> = ({
  value,
  onChangeTeam,
}) => {
  const [showTeamSelector, setShowTeamSelector] = useState<boolean>(false);

  return (
    <ChooseTeamWrapper>
      <TeamSelectorWrapper visible={showTeamSelector}>
        {_.values(teamsColors).map((color) => (
          <TeamIcon
            key={Math.random()}
            teamcolor={color}
            onClick={selectTeam(color, onChangeTeam, setShowTeamSelector)}
          />
        ))}

        <TeamSelectorArrow />
      </TeamSelectorWrapper>

      <TeamIcon
        teamcolor={value}
        onClick={() => setShowTeamSelector(!showTeamSelector)}
      />
    </ChooseTeamWrapper>
  );
};

const selectTeam =
  (
    team: Team,
    onChangeTeam: (team: string) => void,
    setShowTeamSelector: SetState<boolean>
  ) =>
  () => {
    onChangeTeam(team);
    setShowTeamSelector(false);
  };

export default ChooseTeam;
