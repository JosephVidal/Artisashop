import React, { FC } from "react";
import { Frag, Log } from "models/logs";
import { GiPistolGun } from "react-icons/gi";
import { Icon } from "pages/Game/CurrentGame/components/Logs/styles";
import { useTranslation } from "react-i18next";
import { FragLogWrapper } from "pages/Game/CurrentGame/components/Logs/FragLog/styles";

interface Props {
  log: Log<Frag>;
}

const FragLog: FC<Props> = ({ log }) => {
  const { t } = useTranslation();

  return (
    <FragLogWrapper>
      <Icon>
        <GiPistolGun />
      </Icon>
      {t("game.current.logs.frag", {
        killer: log.data.fragger.name,
        victim: log.data.victim.name,
      })}
    </FragLogWrapper>
  );
};

export default FragLog;
