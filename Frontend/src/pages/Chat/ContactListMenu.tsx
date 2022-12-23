import React, { FC } from 'react'

import { PrimitiveAtom, atom, useAtom } from 'jotai';
import { splitAtom } from 'jotai/utils';

import { ChatPreview } from 'api';
import { ContactWrapper } from './styles';

interface ChatPreviewItem extends ChatPreview {
  selected: boolean;
}

const contactListAtom = atom<ChatPreviewItem[]>([]);
const contactListAtomAtom = splitAtom(contactListAtom);

const ContactListItem = ({
  chatPreviewAtom,
}: {
  chatPreviewAtom: PrimitiveAtom<ChatPreviewItem>,
}) => {
  const [chatPreview] = useAtom(chatPreviewAtom);

  return (
    <ContactWrapper selected={chatPreview.selected}>
      <div>
        {chatPreview.lastMsg?.content}
      </div>
    </ContactWrapper>
  );
}

const ContactListMenu = () => (
  <div className="py-5">
    ContactListMenu
  </div>
)

export default ContactListMenu;
