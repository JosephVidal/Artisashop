import { Account, ChatMessage, ChatPreview } from "api";
import { atom } from "jotai";
import { splitAtom } from "jotai/utils";

export const chatContactsAtom = atom<ChatPreview[]>([]);
export const chatContactsAtomAtom = splitAtom(chatContactsAtom);

export const interlocutorAtom = atom<Account | null>(null);

export const messagesAtom = atom<ChatMessage[]>([]);
export const messagesAtomAtom = splitAtom(messagesAtom);
