import {useEffect, useState, FC} from "react";
import {useAtom} from "jotai";
import {HubConnection, HubConnectionBuilder} from "@microsoft/signalr";
import {REACT_APP_CHAT_URL} from "conf";
import {SetState} from "globals/state";
import {ChatMessage, ChatPreview} from "api";
import {Conversation} from "pages/Chat/index";
import userAtom from "../../../states/atoms/user";

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
  const [connection, setConnection] = useState<HubConnection>();
  const [user] = useAtom(userAtom);

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
        .then(() => connection.invoke("Connect", user!.id, user!.username)
          .then(() => {
            connection.on('PrivateMessage', (isSendByMe: boolean, otherUserID: string, filename: string | null, message: string | null, date: Date, file: string | null, msgId: number) => {
              if (isSendByMe) return;
              if (otherUserID === conversation.interlocutor?.id) {
                const newMessage: ChatMessage = {
                  id: msgId,
                  content: message,
                  createdAt: date,
                  joined: file,
                  filename,
                };
                setConversation(prev => ({
                  interlocutor: prev.interlocutor,
                  history: [...prev.history, newMessage],
                }));
              }
              // TODO: Insert into contact list
              // TODO: Create new conversation if not exist
              console.log("PrivateMessage", message);
            })
            connection.on('DeleteMsg', (msgId: number) => {
              setConversation(prev => ({
                interlocutor: prev.interlocutor,
                history: prev.history.filter(msg => msg.id !== msgId),
              }));
              console.log("DeleteMsg", msgId);
            });
            connection.on('UpdateMsg', (msgId: number, content: string) => {
              const newHistory = conversation.history.map(msg => {
                if (msg.id === msgId) {
                  return {
                    ...msg,
                    content
                  }
                }
                return msg;
              });
              setConversation(prev => ({
                interlocutor: prev.interlocutor,
                history: newHistory,
              }));
              console.log("UpdateMsg", content);
            });
          })
        )
    }
  }, [connection])
}

export default useRealTimeChat;
