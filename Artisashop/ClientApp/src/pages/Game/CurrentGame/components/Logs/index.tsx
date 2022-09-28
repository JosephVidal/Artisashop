import React, { useContext } from "react";
import { Card } from "primereact/card";
import { ScrollPanel } from "primereact/scrollpanel";
import { Frag, Log } from "models/logs";
import ErrorLog from "pages/Game/CurrentGame/components/Logs/ErrorLog";
import FragLog from "pages/Game/CurrentGame/components/Logs/FragLog";
import {
  HiOutlineArrowNarrowDown,
  HiOutlineArrowNarrowUp,
} from "react-icons/hi";
import { reorderLogs } from "reducers/logsReducer";
import { StoreContext } from "reducers/utils";
import BatteryLog from "pages/Game/CurrentGame/components/Logs/BatteryLog";
import { Batteries } from "models/battery";
import {
  Icon,
  LogCard,
  OrderArrows,
} from "pages/Game/CurrentGame/components/Logs/styles";

const Logs = () => {
  const [{ logs }, dispatch] = useContext(StoreContext);

  return (
    <LogCard>
      <OrderArrows lastTop={logs.order === "recent_top"}>
        <Icon>
          <HiOutlineArrowNarrowDown
            className="arrowDown"
            onClick={() => dispatch(reorderLogs("old_top"))}
          />
        </Icon>
        <Icon>
          <HiOutlineArrowNarrowUp
            className="arrowUp"
            onClick={() => dispatch(reorderLogs("recent_top"))}
          />
        </Icon>
      </OrderArrows>
      <Card>
        <ScrollPanel>
          {logs.allLogs.map((log, index) => (
            <React.Fragment key={index.toString()}>
              {log.type === "error" && <ErrorLog log={log} />}

              {log.type === "frag" && <FragLog log={log as Log<Frag>} />}

              {log.type === "batteries-info" && (
                <BatteryLog
                  infos={(log as Log<Batteries>).data.batteriesInfo}
                />
              )}
            </React.Fragment>
          ))}
        </ScrollPanel>
      </Card>
    </LogCard>
  );
};

export default Logs;
