import React from "react";
import { LogoWrapper, LogoImg, TextImg } from "./styles";
import LogoWhite from "./assets/logo-white.svg";
import LogoLight from "./assets/logo-light.svg";
import LogoDark from "./assets/logo-dark.svg";
import TextWhite from "./assets/text-white.svg";
import TextDark from "./assets/text-dark.svg";

type LogoType = "white" | "light" | "dark";

interface Props {
  type: LogoType;
  withText?: boolean;
}

const imagesFromType: { [K in LogoType]: { logo: string; text: string } } = {
  white: {
    logo: LogoWhite,
    text: TextWhite,
  },
  light: {
    logo: LogoLight,
    text: TextWhite,
  },
  dark: {
    logo: LogoDark,
    text: TextDark,
  },
};

const Logo: React.FunctionComponent<Props> = ({ type, withText }) => (
  <LogoWrapper>
    <LogoImg src={imagesFromType[type].logo} withText={withText || false} />

    {withText && <TextImg src={imagesFromType[type].text} />}
  </LogoWrapper>
);

export default Logo;
