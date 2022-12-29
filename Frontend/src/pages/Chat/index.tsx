import { PrimitiveAtom, atom, useAtom } from 'jotai';
import { splitAtom } from 'jotai/utils';
import React from 'react';

interface ContactListItemProps {
  name: string;
  lastMessage: string;
  avatarSrc?: string;
  selected: boolean;
}

const initialContactList: ContactListItemProps[] = Array.from({ length: 10 }).map((_, index) => ({
  name: `Name ${index}`,
  lastMessage: `Last message ${index}`,
  avatarSrc: 'https://picsum.photos/200',
  selected: false,
}));

const contactListAtom = atom<ContactListItemProps[]>(initialContactList);
const contactListAtomAtom = splitAtom(contactListAtom);
const selectedIndexAtom = atom(0);

const setSelectedIndex = (index: number) => {
  const [contactList] = useAtom(contactListAtom);
  const [selectedIndex, iSetSelectedIndex] = useAtom(selectedIndexAtom);

  contactList[selectedIndex].selected = false;
  iSetSelectedIndex(index);
};

const ContactListItem = ({
  contactListItemAtom,
}: {
  contactListItemAtom: PrimitiveAtom<ContactListItemProps>,
}) => {
  const [contactListItem, setContactListItem] = useAtom(contactListItemAtom);
  const { name, lastMessage, avatarSrc, selected } = contactListItem;

  const handleClick = () => {
    setContactListItem((prev) => ({
      ...prev,
      selected: !prev.selected,
    }));
  };

  return (
    <div onClick={handleClick} className="select-none">
      <div className={`
          overflow-hidden relative max-w-sm mx-auto 
        ${selected ? "bg-[#141C26]" : "bg-[#F9ECE2]"} shadow-lg ring-1 ring-black/5 rounded-xl flex items-center gap-6 
         dark:highlight-white/5`}>
        <img className="absolute -left-6 w-24 h-24 rounded-full shadow-lg" src={avatarSrc} alt={name} />
        <div className="flex flex-col py-5 pl-24">
          <strong className="text-slate-900 text-base font-medium dark:text-slate-200">{name}</strong>
          <span className="text-slate-500 text-sm font-medium dark:text-slate-400">{lastMessage}</span>
        </div>
      </div>
    </div>
  );
}

const ContactList = () => {
  const [contactListAtoms] = useAtom(contactListAtomAtom);

  return (
    <div>
      <div className="flex flex-col gap-2">
        {contactListAtoms.map((item, index) => (
          <ContactListItem contactListItemAtom={item} key={index} />
        ))}
      </div>
    </div>
  );
};

const ChatMessageBubble = () => (
  <div className="flex gap-5">
    <div className="flex flex-col">
      <div className="text-xs">Last message</div>
    </div>
  </div>
)

const ChatMessageBubbleGroup = () => (
  <div className="flex flex-row">
    <div>
      <img src="https://picsum.photos/200" alt="avatar" className="rounded-full w-8 h-8" />
      <div className="text-sm">Name</div>
    </div>
    <div className="flex flex-col gap-3">
      {Array.from({ length: 3 }).map((_, index) => (
        <ChatMessageBubble key={index} />
      ))}
    </div>
  </div>
);

const MessageList = () => (
  <div className="flex flex-col gap-3">
    {Array.from({ length: 25 }).map((_, index) => (
      <ChatMessageBubbleGroup key={index} />
    ))}
  </div>
);

const MessageForm = () => (
  <div>MessageForm</div>
);

const ChatPage = () => (
  <div className="text-black px-6 pb-5">
    <h1>Messagerie</h1>
    <div className="flex flex-col md:flex-row justify-between gap-5">
      <div className="md:w-1/3 md:max-h-96 flex flex-col gap-5 p-3 border rounded-3xl border-solid border-black text-white">
        {/* <div className="md:w-1/4 p-3 border rounded-3xl border-solid border-black"> */}
        {/* <div className="text-xl font-bold">Contacts</div> */}
        <div className="overflow-auto overscroll-contain px-1">
          <ContactList />
        </div>
      </div>
      <div className="md:max-h-96 flex-1 flex flex-col gap-5 p-5 border rounded-3xl border-solid border-black">
        <div className="overflow-auto overscroll-contain">
          <MessageList />
        </div>
        <div>
          <MessageForm />
        </div>
      </div>
    </div>
  </div>
);

export default ChatPage;
