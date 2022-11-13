import { Player } from "./players";

export interface Game {
  id: string;
  started: boolean;
  paused: boolean;
  over: boolean;
  beginDate: number;
  endDate: number;
  duration: number;
  remainingTime?: number;
  teams: Team[];
}

export interface Team {
  id: string;
  color: string;
  score: number;
  players: GamePlayer[];
}

export interface GamePlayer {
  id: string;
  connected: boolean;
  name: string;
  score: number;
  deaths: number;
  skin: string;
  equipmentLetter: string;
  battery: number;
  stats: PlayerStat[];
}

export interface TeamPlayersNumber {
  color: string;
  playersNb: number;
}

export const gamePlayersToPlayers = (team: Team): Player[] =>
  team.players.map(
    (p) =>
      ({
        id: p.id,
        team: team.color,
        name: p.name,
        skin: p.skin,
        equipment: p.equipmentLetter,
      } as Player)
  );

export interface PlayerStat {
  id: string;
  key: string;
  value: number;
  unit: string;
}
