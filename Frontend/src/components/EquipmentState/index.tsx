import React from "react";
import { SiGooglecardboard } from "react-icons/si";
import {
  EquipmentCapacity,
  EquipmentStateIcons,
  StateIcon,
} from "components/EquipmentState/styles";
import { equipmentColor } from "globals/battery";
import { Maybe } from "monet";
import { BatteriesInfos } from "models/battery";

type Size = "small" | "large";

interface Props {
  size: Size;
  withPercentage?: boolean;
  equipmentBattery: Maybe<BatteriesInfos>;
  headsetConnected: boolean;
}

const EquipmentState: React.FunctionComponent<Props> = ({
  size,
  withPercentage,
  equipmentBattery,
  headsetConnected,
}) => {
  const headsetColor = equipmentColor(
    headsetConnected,
    equipmentBattery.map((b) => b.headsetCapacity)
  );

  return (
    <EquipmentStateIcons size={size}>
      <StateIcon size={size}>
        <SiGooglecardboard color={headsetColor} />

        <EquipmentCapacity color={headsetColor}>
          {withPercentage &&
            headsetConnected &&
            equipmentBattery
              .map((battery) => `${battery.headsetCapacity}%`)
              .getOrElse("")}
        </EquipmentCapacity>
      </StateIcon>
    </EquipmentStateIcons>
  );
};

export default EquipmentState;
