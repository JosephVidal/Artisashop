import { PrimitiveAtom, atom, useAtom } from "jotai";
import { splitAtom } from "jotai/utils";
import React, { useMemo } from "react";
import { Outlet, useNavigate, useParams } from "react-router";
import { Link } from "react-router-dom";

interface ContactListItemProps {
  userId: string;
  name: string;
  lastMessage: string;
  avatarSrc?: string;
}

const initialContactList: ContactListItemProps[] = Array.from({
  length: 10,
}).map((_, index) => ({
  userId: index.toString(),
  name: `Name ${index}`,
  lastMessage: `Last message ${index}`,
  avatarSrc: "https://picsum.photos/200",
}));

export const contactListAtom = atom<ContactListItemProps[]>(initialContactList);
export const contactListAtomAtom = splitAtom(contactListAtom);

const ContactListItem = ({
  contactListItemAtom,
  selected,
}: {
  contactListItemAtom: PrimitiveAtom<ContactListItemProps>;
  selected?: boolean;
}) => {
  const [contactListItem] = useAtom(contactListItemAtom);
  const { userId, name, lastMessage, avatarSrc } = contactListItem;

  return (
    <div className="select-none" id={`contact_${userId}`}>
      <div
        className={`
          overflow-hidden relative mx-auto 
        ${
          selected ? "bg-[#5a202e]" : "bg-[#141C26]"
        } shadow-lg ring-1 ring-black/5 rounded-xl flex items-center gap-6 
         dark:highlight-white/5`}
      >
        <img
          className="absolute -left-6 w-24 h-24 rounded-full shadow-lg"
          src={avatarSrc}
          alt={name}
        />
        <div className="flex flex-col py-5 pl-24">
          <strong className="text-slate-900 text-base font-medium dark:text-slate-200">
            {name}
          </strong>
          <span className="text-slate-500 text-sm font-medium dark:text-slate-400">
            {lastMessage}
          </span>
        </div>
      </div>
    </div>
  );
};

const ContactList = () => {
  const [contactListAtoms] = useAtom(contactListAtomAtom);
  const { id } = useParams();

  return (
    <div>
      <div className="flex flex-col gap-2">
        {contactListAtoms.map((item, index) => (
          <Link to={`/chat/${index}`} className="decoration-transparent">
            <ContactListItem
              contactListItemAtom={item}
              key={index}
              selected={id === index.toString()}
            />
          </Link>
        ))}
      </div>
    </div>
  );
};

const ChatPage = () => (
  <div className="text-black px-6 pb-5">
    <h1>Messagerie</h1>
    <div className="flex flex-col md:flex-row justify-between gap-5">
      <div className="md:w-1/3 md:max-h-[700px] flex flex-col gap-5 p-3 border rounded-3xl border-solid border-black text-white">
        {/* <div className="md:w-1/4 p-3 border rounded-3xl border-solid border-black"> */}
        {/* <div className="text-xl font-bold">Contacts</div> */}
        <div className="overflow-auto overscroll-contain px-1">
          <ContactList />
        </div>
      </div>
      <div className="md:w-2/3">
        <Outlet />
      </div>
    </div>
  </div>
);

export default ChatPage;
