import React, { FC } from "react";
import { FaBatteryEmpty } from "react-icons/fa";
import { Icon } from "pages/Game/CurrentGame/components/Logs/styles";
import { useTranslation } from "react-i18next";
import { BatteriesInfos } from "models/battery";
import { BatteryLogWrapper } from "pages/Game/CurrentGame/components/Logs/BatteryLog/styles";

interface Props {
  infos: BatteriesInfos[];
}

const BatteryLog: FC<Props> = ({ infos }) => {
  const { t } = useTranslation();

  return (
    <>
      {infos.map((info) => {
        if (info.headsetCapacity <= 30) {
          return (
            <BatteryLogWrapper key={info.letter}>
              <Icon>
                <FaBatteryEmpty />
              </Icon>
              {t("error.battery-headset", { letter: info.letter })}
            </BatteryLogWrapper>
          );
        }
        return null;
      })}
    </>
  );
};

export default BatteryLog;
