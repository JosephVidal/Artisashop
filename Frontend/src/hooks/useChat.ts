import { useEffect, useState } from "react";
import { HubConnection, HubConnectionBuilder } from "@microsoft/signalr";
import { atom, useAtom } from "jotai";
import { splitAtom } from "jotai/utils";

import { REACT_APP_CHAT_URL } from "conf";
import { Account, ChatApi, ChatMessage, ChatPreview } from "api";
import userAtom from "states/atoms/user";

import useApi from "./useApi";

interface ChatContact {
  interlocutor?: Account,
  lastMessage?: ChatMessage,
  // history: ChatMessage[],
}

const chatContactsAtom = atom<UserContact[]>([]);
export default chatContactsAtom;

const selectedContactAtom = atom<ChatContact | null>(null);

const messagesAtom = atom<ChatMessage[]>([]);
const messagesAtomAtom = splitAtom(messagesAtom);

const useChat = () => {
  const [user] = useAtom(userAtom);
  const [contactList, setContactList] = useAtom(chatContactsAtom);
  const [connection, setConnection] = useState<HubConnection>();
  const [selectedContact, _setSelectedContact] = useAtom(selectedContactAtom);

  const setSelectedContact = (userId: string) => {
    if (selectedContact?.interlocutor?.id === userId) {
      console.log("already selected !");
    }
    else {
      _setSelectedContact(contactList.);
    }
  }

  useEffect(() => {
    const newConnection = new HubConnectionBuilder()
      .withUrl(REACT_APP_CHAT_URL)
      .withAutomaticReconnect()
      .build();
    setConnection(newConnection);
  }, [])

  useEffect(() => {
    console.log("connected")
    if (connection) {
      connection.start()
        .then(() => connection.invoke("Connect", user?.id, user?.username)
          .then(() => connection.on("OnConnected", (userID: string) => {
            connection.on('PrivateMessage', (isSendByMe: boolean, otherUserID: string, filename: string | null, message: string | null, date: Date, file: string | null, msgId: number) => {

            })
            connection.on('DeleteMsg', (msgId: number) => {
              console.log("DeleteMsg", msgId);
            })
            connection.on('UpdateMsg', (msgId: number, content: string) => {
              console.log("UpdateMsg", msgId, content);
            })
          }))
        )
    }
  }, [connection])


  const chatApi = useApi(ChatApi);

  useEffect(() => { }, [])
}

interface Props {
  setContactList: SetState<ChatPreview[]>,
  setConversation: SetState<Conversation>,
  contactList: ChatPreview[],
  conversation: Conversation
}

const useRealTimeChat = ({
  setContactList,
  setConversation,
  contactList,
  conversation
}: Props) => {
  const [user] = useAtom(userAtom);
  const [connection, setConnection] = useState<HubConnection>();

  useEffect(() => {
    const newConnection = new HubConnectionBuilder()
      .withUrl(REACT_APP_CHAT_URL)
      .withAutomaticReconnect()
      .build();
    setConnection(newConnection);
  }, [])

  useEffect(() => {
    console.log("connected")
    if (connection) {
      connection.start()
        .then(() => connection.invoke("Connect", user?.id, user?.username)
          .then(() => connection.on("OnConnected", (userID: string) => {
            connection.on('PrivateMessage', (isSendByMe: boolean, otherUserID: string, filename: string | null, message: string | null, date: Date, file: string | null, msgId: number) => {
              console.log("PrivateMessage", isSendByMe, otherUserID, filename, message, date, file, msgId);
            })
            connection.on('DeleteMsg', (msgId: number) => {
              console.log("DeleteMsg", msgId);
            })
            connection.on('UpdateMsg', (msgId: number, content: string) => {
              console.log("UpdateMsg", msgId, content);
            })
          }))
        )
    }
  }, [connection])
}

export default useRealTimeChat;
