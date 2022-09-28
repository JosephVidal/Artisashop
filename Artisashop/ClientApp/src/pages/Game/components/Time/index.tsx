import React, { FC } from "react";
import { RiTimerLine } from "react-icons/ri";
import { TimeWrapper, Icon, Text } from "./styles";

interface Props {
  value: number;
}

const Time: FC<Props> = ({ value }) => (
  <TimeWrapper>
    <Text>{value} : 00</Text>

    <Icon>
      <RiTimerLine />
    </Icon>
  </TimeWrapper>
);

export default Time;
