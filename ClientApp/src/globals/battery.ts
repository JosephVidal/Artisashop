import { Maybe } from "monet";
import { colors } from "./styles";

export const equipmentColor = (
  connected: boolean,
  equipmentBattery: Maybe<number>
): string => {
  if (!connected) return colors.grey;

  return equipmentBattery
    .map((battery) => {
      if (battery > 50) return colors.green;

      if (battery > 30) return colors.orange;

      return colors.red;
    })
    .getOrElse(colors.red);
};
