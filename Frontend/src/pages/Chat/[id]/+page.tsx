import React from "react";
import { FaPaperPlane } from "react-icons/fa";
import { ImAttachment } from "react-icons/im";

interface ChatMessageBubbleProps {
  text: string;
  isOwn?: boolean;
  isFirst?: boolean;
  isLast?: boolean;
}

const initialMessages = [
  "Hello",
  "How are you?",
  "What are you doing?",
  "Answer me !!",
]

const ChatMessageBubble = ({
  text,
  isOwn,
  isFirst,
  isLast,
}: ChatMessageBubbleProps) => (
  <div className={`flex gap-5 bg-slate-500 p-4 rounded-full
    ${isOwn ? "justify-end" : "justify-start"}
    ${(isOwn && isLast) ? 'rounded-br-full' : 'rounded-br-none'}
    ${(isOwn && isFirst) ? 'rounded-tr-full' : 'rounded-tr-none'}
    ${(!isOwn && isLast) ? 'rounded-bl-full' : 'rounded-bl-none'}
    ${(!isOwn && isFirst) ? 'rounded-tl-full' : 'rounded-tl-none'}
  `}>
    <div className="flex flex-col">
      <div className="text-md">{text}</div>
    </div>
  </div>
);

interface ChatMessageBubbleGroupProps {
  name: string;
  messages: string[];
  isOwn?: boolean;
}

const ChatMessageBubbleGroup = ({ name, messages, isOwn }: ChatMessageBubbleGroupProps) => (
  <div className={`flex ${ 'flex-row'} gap-4`}>
    <img src="https://picsum.photos/200" alt="avatar" className="rounded-full w-8 h-8" />
    <div className="flex flex-col gap-1">
      <div className="text-sm">{name}</div>
      <div className="flex flex-col gap-1">
        {messages.map((text, index) => (
          <ChatMessageBubble key={index} isFirst={index === 0} isLast={index === messages.length - 1}
            text={text} isOwn={isOwn} />
        ))}
      </div>
    </div>
  </div>
);

const MessageList = () => (
    <div className="flex flex-col gap-3">
      {Array.from({ length: 25 }).map((_, index) => (
        <ChatMessageBubbleGroup name={index % 2 === 0 ? "Brandon" : "Me"} key={index} isOwn={index % 2 === 0} messages={initialMessages} />
      ))}
    </div>
  );

const ConversationPage = () => (
  <div className="w-100 md:max-h-[700px] flex-1 flex flex-col gap-5 p-5 border rounded-3xl border-solid border-black">
    <div className="overflow-auto overscroll-contain">
      <MessageList />
    </div>
    <div className="w-100 h-10 max-h-10 flex justify-between">
      <input
        type="text"
        className="m-0 p-3 border-black bg-white w-100 grow"
        placeholder="Ecrivez un message..."
      />
      <label htmlFor="file-upload" className="shrink w-10 p-2">
        <input
          id="file-upload"
          type="file"
          style={{ display: "none" }}
          multiple={false}
        />
        <ImAttachment size="100%" />
      </label>
      <div className="shrink w-10 p-2">
        <FaPaperPlane size="100%" />
      </div>
    </div>
  </div>
);

export default ConversationPage;
