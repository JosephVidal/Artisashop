import {useEffect, useState, FC} from "react";
import {HubConnection, HubConnectionBuilder} from "@microsoft/signalr";
import {REACT_APP_CHAT_URL} from "conf";
import {SetState} from "globals/state";
import {ChatPreview} from "api";
import {Conversation} from "pages/Chat/index";
import userAtom from "states/atoms/user";
import { useAtom } from "jotai";

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
} : Props) => {
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
