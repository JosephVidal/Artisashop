export interface BatteriesInfos {
  letter: string;
  headsetCapacity: number;
  mustStop: boolean;
}

export interface Batteries {
  batteriesInfo: BatteriesInfos[];
}
