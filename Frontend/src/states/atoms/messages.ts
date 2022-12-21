import { atom } from "jotai";
import { Conversation } from "pages/Chat";

const conversationsAtom = atom<Conversation[]>([]);

export default conversationsAtom;
