import { Equipment } from "./equipment";

export interface Config {
  equipments: Equipment[];
  parameter: ConfigParameter;
}

export interface ConfigParameter {
  key: string;
  value: string;
}
