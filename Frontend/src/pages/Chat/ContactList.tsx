import React, { FC } from "react";
import { PrimitiveAtom, useAtom } from "jotai";

import { ChatPreview } from "api";

import { chatContactsAtomAtom } from "./atoms";

const ContactListItem = ({
  conversationAtom,
  // selected,
} : {
  conversationAtom: PrimitiveAtom<ChatPreview>,
  // selected: boolean,
}) => {
  const [conversation] = useAtom(conversationAtom);

    return (
      <div>
        {conversation.lastMsg?.content}
      </div>
    );
  }

const ContactList = () => {
  const [conversations] = useAtom(chatContactsAtomAtom);

  return (
    <div className="d-flex flex-column flex-grow-1">
      {conversations.map((conversationAtom) => (
        <ContactListItem
          conversationAtom={conversationAtom}
          // selected={selectedConversationId === conversation.id}
        />
      ))}
    </div>
  );
};

export default ContactList;
