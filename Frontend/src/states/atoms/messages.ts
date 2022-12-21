import { atom } from "jotai";
import { ChatMessage } from "api/models";

const messages = atom<ChatMessage[]>([]);

export default messages;
