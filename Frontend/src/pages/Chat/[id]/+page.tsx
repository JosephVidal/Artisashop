import { Account, AccountApi, ChatApi, ChatMessage, CreateChatMessage, ProductApi } from "api";
import useApi from "hooks/useApi";
import useAsync from "hooks/useAsync";
import { atom, useAtom, PrimitiveAtom } from "jotai";
import { splitAtom } from "jotai/utils";
import React, { useEffect } from "react";
import { FaPaperPlane } from "react-icons/fa";
import { ImAttachment } from "react-icons/im";
import { useParams } from "react-router";
import userAtom from "states/atoms/user";
import {
  useQuery,
  useMutation,
  useQueryClient,
  QueryClient,
  QueryClientProvider,
} from '@tanstack/react-query';
import { Link } from "react-router-dom";

const meAtom = atom<Account | null>(null);
const interlocutorAtom = atom<Account | null>(null);


interface ChatMessageGroup {
  user: Account;
  messages: ChatMessage[];
}

const messagesAtom = atom<ChatMessage[]>([]);
const messagesAtomAtom = splitAtom(messagesAtom);

const ChatBubble = ({
  messageAtom,
  showHead,
}: {
  messageAtom: PrimitiveAtom<ChatMessage>;
  showHead: boolean;
}) => {
  const [me] = useAtom(meAtom);
  const [interlocutor] = useAtom(interlocutorAtom);
  const [message] = useAtom(messageAtom);

  const isOwn = me?.id === message.senderId;
  const user = isOwn ? me : interlocutor;

  let profilePicture = user?.profilePicture ?? "https://picsum.photos/200";

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

const MessageList = () => {
  const [messages, setMessages] = useAtom(messagesAtom);
  const [messageAtoms] = useAtom(messagesAtomAtom);

  setMessages(
    [
      {
        id: 1,
        senderId: "1",
        content: "Hello",
        createdAt: new Date(),
      },
      {
        id: 2,
        senderId: "2",
        content: "Hello",
        createdAt: new Date(),
      },
    ],
  )

  return (
    <div className="flex flex-col gap-3">
      {messageAtoms.map((messageAtom, index) => (
        <ChatBubble
          messageAtom={messageAtom}
          showHead={index === 0}
          key={messageAtom.read(x => x).id} />
      ))}
    </div>
  );
};

const ConversationPage = () => {
  const accountApi = useApi(AccountApi);
  const chatApi = useApi(ChatApi);
  const queryClient = useQueryClient();

  const { id } = useParams();

  const [user] = useAtom(userAtom);
  const [interlocutor, setInterlocutor] = useAtom(interlocutorAtom);
  const [me, setMe] = useAtom(userAtom);

  const messagesQuery = useQuery({
    queryKey: ['messages'],
    queryFn: () => { },
  });
  const postMessagesMutation = useMutation({
    mutationFn: (createChatMessage: CreateChatMessage) => chatApi.apiChatPost({ createChatMessage }),
    onSuccess: () => { queryClient.invalidateQueries({ queryKey: ['messages'] }) },
  });

  useAsync(async () => {
    if (id) {
      const res = await accountApi.apiAccountIdGet({ id })
      if (res.account) {
        setInterlocutor(res.account);
      }
    }
    if (user?.id) {
      const res = await accountApi.apiAccountIdGet({ id: user.id ?? "" });
      if (res.account) {
        setMe(res.account);
      }
    }
  }, true);

  return (
    <div className="w-100 md:max-h-[700px]">
      <div className="flex gap-5 items-center">
        <img src={`/img/craftsman/${interlocutor?.profilePicture ?? "default.svg"}`} alt="avatar" className="rounded-full w-12 h-12" />
        <div className="text-lg">
          <Link className="text-black" to={`/craftsman/${interlocutor?.id ?? ''}`}>{interlocutor?.firstname} {interlocutor?.lastname}</Link>
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
