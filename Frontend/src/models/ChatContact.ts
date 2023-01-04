import { Account, ChatMessage } from "api/models";

export default interface ChatContact {
  interlocutor?: Account,
  lastMessage?: ChatMessage,
  // history: ChatMessage[],
}
