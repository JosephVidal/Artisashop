import React, { FC } from "react";
import { useAtom } from "jotai";
import ChatContact from "models/ChatContact";
import chatContactsAtom from "states/atoms/chatContacts";

const ContactListItem: FC<ChatContact> = (contact) => (
  <div className="d-flex flex-row align-items-center p-3">
    <div className="d-flex flex-column">
      <div className="font-weight-bold">{contact.interlocutor?.firstname} {contact.interlocutor?.lastname}</div>
      <div>
        {
          contact.lastMessage?.id === contact.interlocutor?.id
            ? <div className="text-black-50">Vous: {contact.lastMessage?.content}</div>
            : <div className="text-black-50">{contact.lastMessage?.content}</div>
        }
      </div>
    </div>
  </div>
)

const ContactList = () => {
  const [conversations] = useAtom(chatContactsAtom);

  return (
    <div className="d-flex flex-column flex-grow-1">
      {conversations.map((conversation) => (
        <ContactListItem
          key={conversation.id}
          conversation={conversation}
          selected={selectedConversationId === conversation.id}
        />
      ))}
    </div>
  );
};

export default ContactList;
