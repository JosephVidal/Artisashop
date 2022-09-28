import Select from "components/Select";
import Option from "components/Select/Option";
import React, { FC } from "react";
import {
  PlayerAmountWrapper,
  TextLeft,
  TextRight,
} from "pages/CreateGame/components/PlayerNumber/styles";
import _ from "lodash";
import { useTranslation } from "react-i18next";

interface Props {
  value: number | undefined;
  maxPlayers: number;
  onChange: (value: any) => void;
}

const PlayerNumber: FC<Props> = (props: Props) => {
  const { t } = useTranslation();

  return (
    <PlayerAmountWrapper>
      <TextLeft>{t("global.players")}</TextLeft>

      <div>
        <Select
          placeholder={t("global.player")}
          value={props.value}
          onChange={props.onChange}
        >
          {generateOptions(props.maxPlayers)}
        </Select>
      </div>

      <TextRight>{`/${props.maxPlayers}`}</TextRight>
    </PlayerAmountWrapper>
  );
};

const generateOptions = (maxNumber: number) => {
  const options: JSX.Element[] = [];

  _.range(2, maxNumber + 1).forEach((value) => {
    options.push(<Option label={value.toString()} value={value} key={value} />);
  });
  return options;
};

export default PlayerNumber;
