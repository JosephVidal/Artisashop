import {useEffect, useState, VFC} from "react";
import {HubConnection, HubConnectionBuilder} from "@microsoft/signalr";
import {REACT_APP_CHAT_URL} from "conf";
import {SetState} from "globals/state";
import {ChatPreview} from "api";
import {Conversation} from "pages/Chat/index";

interface Props {
  setContactList: SetState<ChatPreview[]>,
  setConversation: SetState<Conversation>,
  contactList: ChatPreview[],
  conversation: Conversation
}

const RealTimeChat: VFC<Props> = ({
  setContactList,
  setConversation,
  contactList,
  conversation
}) => {
  const [connection, setConnection] = useState<HubConnection>();

  useEffect(() => {
    const newConnection = new HubConnectionBuilder()
      .withUrl(REACT_APP_CHAT_URL)
      .withAutomaticReconnect()
      .build();
    setConnection(newConnection);
  }, [])

  useEffect(() => {
    if (connection) {
      connection.start()
        .then(() => connection.invoke("Connect", "", "test")
          .then(() => connection.on("OnConnected", (userID: string) => {
            connection.on('PrivateMessage', (isSendByMe: boolean, otherUserID: string, filename: string | null, message: string | null, date: Date, file: string | null, msgId: number) => {
              console.log(message);
            })
            connection.on('DeleteMsg', (msgId: number) => {
              console.log(msgId);
            })
            connection.on('UpdateMsg', (msgId: number, content: string) => {
              console.log(content);
            })
          }))
        )
    }
  }, [connection])

  return null;
}

export default RealTimeChat;
