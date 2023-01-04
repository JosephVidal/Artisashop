import React from "react";
import { FaPaperPlane } from "react-icons/fa";
import { ImAttachment } from "react-icons/im";

const ChatMessageBubble = () => (
  <div className="flex gap-5">
    <div className="flex flex-col">
      <div className="text-md">Last message</div>
    </div>
  </div>
);

const ChatMessageBubbleGroup = () => (
  <div className="flex flex-row">
    <div>
      <img
        src="https://picsum.photos/200"
        alt="avatar"
        className="rounded-full w-8 h-8"
      />
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
