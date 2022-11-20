export interface Log<T> {
  type: string;
  timestamp: number;
  data: T;
}

export interface PlayerIdentity {
  id: number;
  name: string;
}

export interface Frag {
  fragger: PlayerIdentity;
  victim: PlayerIdentity;
}

export interface Disconnection {
  player: string;
}
