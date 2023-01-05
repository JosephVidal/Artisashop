import { Account, AccountApi, ChatApi, ChatMessage, CreateChatMessage, ProductApi } from "api";
import useApi from "hooks/useApi";
import useAsync from "hooks/useAsync";
import React, { useEffect } from "react";
import { FaPaperPlane } from "react-icons/fa";
import { ImAttachment } from "react-icons/im";
import { useParams } from "react-router";
import userAtom from "states/atoms/user";
import { Link } from "react-router-dom";
import { useAtom } from "jotai";

const ChatBubble = ({
  isOwn,
  message,
  showHead,
}: {
  isOwn: boolean;
  message: ChatMessage;
  showHead: boolean;

}) => {
  const user = message.sender!;
  let profilePicture = user.profilePicture ?? "https://picsum.photos/200";

  if (profilePicture.endsWith(".jpg") || profilePicture.endsWith(".png") || profilePicture.endsWith(".jpeg") || profilePicture.endsWith(".svg")) {
    profilePicture = `/img/craftsman/${profilePicture}`;
  }

  return (
    <div className={`flex ${isOwn ? 'flex-row-reverse ml-[40%]' : 'flex-row mr-[40%]'} gap-4`}>
      {showHead && (<img src={profilePicture} alt="avatar" className="rounded-full w-8 h-8" />)}
      <div className="flex flex-col gap-1">
        {showHead && (
          <div className={`text-sm ${isOwn ? "text-right" : "text-left"}`}>
            <b>{user?.firstname} {user?.lastname}</b> le 12/12/2021 à 12:12
          </div>
        )}
        <div className="flex flex-col gap-1">

          <div
            className={`flex gap-3 p-4 rounded-lg text-slate-200 ${isOwn ? "justify-end bg-[#5a202e] text-right" : "justify-start bg-[#141C26] text-left"} `} >
            <div className="flex flex-col">
              <div className="text-md">{message.content}</div>
              {message.joined && <img src={message.joined} alt={message.filename ?? "Image"} />}
            </div>
          </div>
        </div>
      </div>
    </div>
  );
};

const MessageList = ({
  messages,
}: {
  messages: ChatMessage[];
}) => (
    <div className="flex flex-col gap-3">
      {messages?.map((message, index) => (
        <ChatBubble
          message={message}
          showHead={index === 0}
          key={message.id} isOwn={false} />
      ))}
    </div>
  );

const ConversationPage = () => {
  const accountApi = useApi(AccountApi);
  const chatApi = useApi(ChatApi);

  const [me] = useAtom(userAtom);
  const { id: interlocutorId } = useParams<{ id: string }>();

  const fetchInterlocutor = useAsync(async () => interlocutorId ? accountApi.apiAccountIdGet({ id: interlocutorId }).then(res => res.account) : null, false);
  const fetchMessages = useAsync(async () => interlocutorId ? chatApi.apiChatHistoryGet({ users: [me!.id!, interlocutorId] }) : null, false);
  
  useEffect(() => {
    fetchInterlocutor.execute();
    fetchMessages.execute();
  }, []);

  return (
    <div className="w-100 md:max-h-[700px]">
      <div className="flex gap-5 items-center">
        <img src={`/img/craftsman/${fetchInterlocutor.value?.profilePicture ?? "default.svg"}`} alt="avatar" className="rounded-full w-12 h-12" />
        <div className="text-lg">
          <Link className="text-black" to={`/craftsman/${fetchInterlocutor.value?.id ?? ''}`}>{fetchInterlocutor.value?.firstname} {fetchInterlocutor.value?.lastname}</Link>
        </div>

      </div>
      <div className="w-100 md:max-h-[700px] flex-1 flex flex-col gap-5 p-5 border rounded-3xl border-solid border-black">

        <div>
          <div className="overflow-auto overscroll-contain">
            {/* <MessageList /> */}
          </div>

        </div>
        <div className="w-100 h-10 max-h-10 flex justify-between">
          <input
            type="text"
            className="m-0 p-3 border-black bg-white w-100 grow"
            placeholder="Ecrivez un message..." />
          <label htmlFor="file-upload" className="shrink w-10 p-2">
            <input
              id="file-upload"
              type="file"
              style={{ display: "none" }}
              multiple={false} />
            <ImAttachment size="100%" />
          </label>
          <div className="shrink w-10 p-2">
            <FaPaperPlane size="100%" />
          </div>
        </div>
      </div>
    </div>
  );
};

export default ConversationPage;
