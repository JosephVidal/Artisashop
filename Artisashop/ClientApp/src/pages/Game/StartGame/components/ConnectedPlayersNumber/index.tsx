import React, { FC } from "react";
import { useTranslation } from "react-i18next";
import {
  ConnectedAmountWrapper,
  TextLeft,
  TextRight,
} from "pages/Game/StartGame/components/ConnectedPlayersNumber/styles";
import Select from "components/Select";
import _ from "lodash";
import Option from "components/Select/Option";

interface Props {
  value: number;
  connectedPlayers: number;
  maxPlayers: number;
  onChange: (value: any) => void;
}

const ConnectedPlayersNumber: FC<Props> = (props: Props) => {
  const { t } = useTranslation();

  return (
    <ConnectedAmountWrapper>
      <TextLeft>{t("game.start.connected-players")}</TextLeft>

      <TextRight>{`${props.connectedPlayers}/`}</TextRight>

      <div>
        <Select
          placeholder={t("global.player")}
          value={props.value}
          onChange={props.onChange}
        >
          {generateOptions(props.maxPlayers)}
        </Select>
      </div>
    </ConnectedAmountWrapper>
  );
};

const generateOptions = (maxNumber: number) => {
  const options: JSX.Element[] = [];

  _.range(2, maxNumber + 1).forEach((value) => {
    options.push(<Option label={value.toString()} value={value} key={value} />);
  });
  return options;
};

export default ConnectedPlayersNumber;
