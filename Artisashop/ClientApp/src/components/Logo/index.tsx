import React from "react";
import LogoOvale from "./assets/LogoOvale.png";
import LogoRound from "./assets/Logox150.png";
import { LogoWrapper, LogoImg } from "./styles";

type LogoType = "ovale" | "round";

interface Props {
  type: LogoType;
  width: string;
}

const imagesFromType: { [K in LogoType]: { logo: string } } = {
  round: {
    logo: LogoRound,
  },
  ovale: {
    logo: LogoOvale,
  },
};

const Logo: React.FunctionComponent<Props> = ({ type, width }) => (
  <LogoWrapper>
    <LogoImg src={imagesFromType[type].logo} width={width} />
  </LogoWrapper>
);

export default Logo;
