import { atom } from "jotai";
import UserContact from "models/ChatContact";

const chatContactsAtom = atom<UserContact[]>([]);

export default chatContactsAtom;
