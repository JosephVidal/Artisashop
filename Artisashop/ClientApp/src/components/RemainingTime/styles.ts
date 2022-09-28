import styled from "styled-components";
import { colors } from "globals/styles";

interface RemainingTimeWrapperProps {
  paused: boolean;
}

export const RemainingTimeWrapper = styled.div<RemainingTimeWrapperProps>`
  ${(props) => (props.paused ? `color: ${colors.red}` : "")}
`;
