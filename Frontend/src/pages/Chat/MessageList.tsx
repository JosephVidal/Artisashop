import { ChatMessage } from 'api';
import { PrimitiveAtom, atom, useAtom } from 'jotai';
import { splitAtom } from 'jotai/utils';
import React from 'react'

const messageListAtom = atom<ChatMessage[]>([])
const messageListAtomAtom = splitAtom(messageListAtom);

const MessageListItem = ({
  messageAtom,
  remove,
}: {
  messageAtom: PrimitiveAtom<ChatMessage>,
  remove: () => void,
}) => {
  const [message, setMessage] = useAtom(messageAtom);

  return (
    <div>
      {message.content}
    </div>
  );
}

const MessageList = () => {
  const [messageList, dispatch] = useAtom(messageListAtomAtom);

  return (
    <div>
      <div>MessageList</div>
      {messageList.map((messageAtom) => (
        <MessageListItem
          messageAtom={messageAtom}
          remove={() => dispatch((old) => old.filter((m) => m.id !== messageAtom.id))}
        />
      ))}
    </div>
  );
}

export default MessageList;
