import React from 'react';

const ChatMessageBubble = () => (
  <div className="flex gap-5">
    <div className="flex flex-col">
      <div className="text-xs">Last message</div>
    </div>
  </div>
);

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

const Conversation = () => (
  <>
    <div className="overflow-auto overscroll-contain">
      <MessageList />
    </div>
    <div>
      <MessageForm />
    </div>
  </>
);

export default Conversation;
