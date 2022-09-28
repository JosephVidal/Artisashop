import { Accordion, AccordionTab } from "primereact/accordion";
import { ScrollPanel } from "primereact/scrollpanel";
import React, { FC, useContext } from "react";
import OngoingPlayersDetails from "pages/Game/CurrentGame/components/OngoingPlayerDetails";
import OngoingPlayersScore from "pages/Game/CurrentGame/components/OngoingPlayersScore";
import { Game as GameModel } from "models/game";
import Score from "pages/Game/components/Score";
import Logs from "pages/Game/CurrentGame/components/Logs";
import { StoreContext } from "reducers/utils";
import _ from "lodash/fp";
import { Log } from "models/logs";

import { EquipmentState } from "models/equipment";
import { Batteries } from "models/battery";
import {
  CurrentGameWrapper,
  GameInfo,
  Players,
} from "pages/Game/CurrentGame/styles";

interface Props {
  currentGame: GameModel;
  equipmentsState: EquipmentState[];
}

const CurrentGame: FC<Props> = ({ currentGame, equipmentsState }) => {
  const [{ logs }] = useContext(StoreContext);

  return (
    <CurrentGameWrapper>
      <Players>
        <ScrollPanel>
          <Accordion multiple>
            {currentGame?.teams &&
              currentGame?.teams.map((team) =>
                team.players.map((player) => (
                  <AccordionTab
                    header={
                      <OngoingPlayersDetails
                        key={player.id}
                        player={player}
                        teamColor={team.color}
                        equipmentState={equipmentsState.find(
                          (equipment) =>
                            equipment.letter === player.equipmentLetter
                        )}
                        equipmentBattery={(
                          _.last(
                            logs.logsByType["batteries-info"]
                          ) as Log<Batteries>
                        )?.data.batteriesInfo.find(
                          (equipment) =>
                            equipment.letter === player.equipmentLetter
                        )}
                      />
                    }
                  >
                    <OngoingPlayersScore player={player} />
                  </AccordionTab>
                ))
              )}
          </Accordion>
        </ScrollPanel>
      </Players>
      <GameInfo>
        <Score teams={currentGame.teams} />

        <Logs />
      </GameInfo>
    </CurrentGameWrapper>
  );
};

export default CurrentGame;
