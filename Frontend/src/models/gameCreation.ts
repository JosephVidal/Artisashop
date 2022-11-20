export interface GameCreation {
  id: string;
  beginDate: number;
  duration: number;
  teams: TeamCreation[];
}

export interface TeamCreation {
  color: string;
  players: PlayerCreation[];
}

export interface PlayerCreation {
  id?: string;
  name: string;
  skin: string;
  equipmentLetter: string;
}

export interface FieldError {
  field: string;
  message: string;
}
