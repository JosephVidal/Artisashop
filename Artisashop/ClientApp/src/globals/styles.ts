import styled, { createGlobalStyle } from "styled-components";
import * as _ from "lodash/fp";

export const colors = {
  beige: "#f4ebe1",
  darkBlue: "#141c26",
  darkRed: "#5a202e",
  surfaceB: "#17212f",
  surfaceC: "#233248",
  surfaceD: "#304562",
  surfaceE: "#121C29",
  borderColor: "#304562",
  textColor: "rgba(255, 255, 255, 0.87)",
  textColorSecondary: "rgba(255, 255, 255, 0.6)",
  errorColor: "#f44336",
  successColor: "#72bb53",
  red: "#d32f2f",
  blue: "#2196f3",
  green: "#72bb53",
  grey: "#707070",
  lightGrey: "rgba(255, 255, 255, 0.6)",
  orange: "#ff8f00",
  warning: "#ffcc00",
};

export const teamsColors = {
  red: "#d32f2f",
  blue: "#2196f3",
  green: "#72bb53",
  orange: "#ff8f00",
  purple: "#9c27b0",
  yellow: "#fdd600",
  pink: "#ec407a",
  grey: "#bdbdbd",
};

export const teamColorNameFromHex = (hexColor: string): string =>
  _.findKey((c) => c === hexColor)(teamsColors) || "white";

export const BaseText = styled.text`
  color: ${colors.textColor};
`;

export const GlobalStyles = createGlobalStyle` 
  html, body, #root {
    width: 100%;
    height: 100%;
  }
  
  body {
    margin: 0;
    font-family: 'Ubuntu';
    -webkit-font-smoothing: antialiased;
    -moz-osx-font-smoothing: grayscale;
    color: ${colors.textColor};
    background-color: ${colors.surfaceB};
  }
  
  code {
    font-family: source-code-pro, Menlo, Monaco, Consolas, 'Courier New',
      monospace;
  }
`;
