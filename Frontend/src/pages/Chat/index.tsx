import React from 'react';

const ContactList = () => (
  <div>ContactList</div>
);

const MessageList = () => (
  <div className="flex flex-col gap-3">
    {Array.from({ length: 25 }).map((_, index) => (
      <div key={index} className="flex gap-5">
        <img src="https://picsum.photos/200" alt="avatar" className="rounded-full w-7 h-7" />
        <div className="flex flex-col">
          <div className="text-sm">Name</div>
          <div className="text-xs">Last message</div>
        </div>
      </div>
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
      <div className="md:w-1/4 p-5 border rounded-3xl border-solid border-black">
        <ContactList />
      </div>
      <div className="flex-1 flex flex-col gap-5 p-5 border rounded-3xl border-solid border-black">
        <div className="overflow-auto overscroll-contain max-h-96">
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
