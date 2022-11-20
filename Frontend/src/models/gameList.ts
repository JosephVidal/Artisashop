export interface GameList {
  id: string;
  beginTime: string;
  playersNumber: number;
  status: "CREATED" | "LOADED" | "STARTED" | "PAUSED" | "OVER";
  duration: number;
  endTime?: string;
}

export interface GameListToDisplay {
  id: string;
  beginTime: string;
  playersNumber: number;
  status: "CREATED" | "LOADED" | "STARTED" | "PAUSED" | "OVER";
  duration: number;
  endTime: string;
}
