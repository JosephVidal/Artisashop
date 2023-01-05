import React, {FC, useEffect, useMemo, useState} from "react";
import {
  MessageBubble,
  ChatWrapper,
  ContactList,
  ContactWrapper,
  ConversationWrapper,
  ChatInputWrapper,
  Wrapper,
  MessageWrapper,
  ConversationTitle,
  ContactPreview,
  MessagePreview,
  MessageTooltipWrapper,
  MessageDate,
  FileWrapper,
  ChatBottomWrapper
} from "pages/Chat/styles";
import { BsTrash, BsPencil, BsXLg, BsFileEarmarkWord, BsFileEarmarkPdf } from "react-icons/bs";
import { FaPaperPlane } from "react-icons/fa";
import { ImAttachment } from "react-icons/im";
import { SetState } from "globals/state";
import { generate } from "shortid";
import {InputText} from "primereact/inputtext";
import {Maybe, None, Some} from "monet";
import {Account, ApiChatHistoryGetRequest, ChatApi, ChatMessage, ChatPreview} from "api";
import useApi from "hooks/useApi";
import useFormattedDocumentTitle from "hooks/useFormattedDocumentTitle";
import RealTimeChat from "pages/Chat/RealTimeChat";
import {useSearchParams} from "react-router-dom";

export interface Conversation {
  history: ChatMessage[],
  interlocutor?: Account
}

const Chat: FC = () => {
  const [contactList, setContactList] = useState<ChatPreview[]>([]);
  const [conversation, setConversation] = useState<Conversation>({ history: [] });
  const [hover, setHover] = useState<number>(0);
  const [input, setInput] = useState<string>("");
  const [file, setFile] = useState<Maybe<File>>(None());
  const [fileData, setFileData] = useState<Maybe<string>>(None());
  const reader = new FileReader();
  const [edit, setEdit] = useState<Maybe<number>>(None());
  const useChat = useApi(ChatApi);
  const [user, setUser] = useState<Account>();
  const [searchParams] = useSearchParams();
  const newMessage: boolean = useMemo(() => searchParams.get("new") === "true" || false, [searchParams]);
  const to: Account | null = useMemo(() => {
    const get = searchParams.get("to");
    if (get !== null)
      return JSON.parse(get) as Account
    return null;
  }, [searchParams]);

  reader.onloadend = () => {
    setFileData(Some(reader.result as string));
  }

  useFormattedDocumentTitle("Chat");

  useEffect(() => {
    const storedUser = localStorage.getItem("user");
    if (storedUser)
      setUser(JSON.parse(storedUser) as Account);
    useChat.apiChatListGet().then((r) => {
      setContactList(r);
    });
    if (newMessage && contactList.find((preview) =>
      preview.lastMsg?.senderId === (to )?.id ||
      preview.lastMsg?.receiverId === (to )?.id) === undefined)
      setConversation({history: [], interlocutor: (to!)});
  }, [])

  const renderContact = (contact: ChatPreview) => {
    const getInterlocutor = (): string => {
      if (!contact.lastMsg)
        return (to )!.userName!;
      return contact.receive ? contact.lastMsg.sender!.userName! : contact.lastMsg.receiver!.userName!;
    }

    const interlocutor: string = getInterlocutor();

    return (
      <ContactWrapper selected={interlocutor === conversation.interlocutor?.userName} key={generate()} onClick={() => {
        if (contact.lastMsg) {
          getConversation(useChat, setConversation, user!.id!, contact.lastMsg.sender!, contact.lastMsg.receiver!);
        } else {
          setConversation({history: [], interlocutor: to!})
        }
          setInput("");
          setEdit(None());
          setFile(None());
      }}>
        {interlocutor}
        {contact.lastMsg &&
          <ContactPreview>
            <MessagePreview>
              {contact.lastMsg?.sender?.userName}: {contact.lastMsg?.content}
            </MessagePreview>
            {contact.lastMsg.createdAt ? timeIndicator(contact.lastMsg.createdAt) : null}
          </ContactPreview>
        }
      </ContactWrapper>
    )
  };

  const renderMessage = (message: ChatMessage) => {
    const self = message.sender!.id! === user?.id;

    return (
      <MessageTooltipWrapper key={message.id} self={self} onMouseOver={() => setHover(message.id!)} onMouseOut={() => setHover(0)}>
        {(self && hover === message.id) && (
          <>
            <BsPencil size="100%" onClick={() => {
              setEdit(Some(message.id!));
              setInput(message.content!);
            }} />
            <BsTrash size="100%" onClick={() => removeMessage(useChat, setConversation, message.id!)} />
          </>
          )
        }
        <MessageWrapper self={self}>
          {message.sender!.userName!}
          <MessageBubble self={self}>
            {message.content!}
            {message.filename !== undefined && message.filename !== null && message.filename !== "" && (
              <FileWrapper isMessage>
                <img src={message.filename} alt="" />
              </FileWrapper>
            )}
          </MessageBubble>
          <MessageDate>
            {hover === message.id! && timeIndicator(message.createdAt!)}
          </MessageDate>
        </MessageWrapper>
      </MessageTooltipWrapper>
    )
  };

  return (
    <Wrapper>
      <ContactList>
        {(newMessage && contactList.find((preview) =>
          preview.lastMsg?.senderId === (to )?.id ||
          preview.lastMsg?.receiverId === (to )?.id) === undefined) &&
          renderContact({})}
        {contactList.map(renderContact)}
      </ContactList>
      <RealTimeChat setContactList={setContactList} setConversation={setConversation} contactList={contactList} conversation={conversation} />
      <ConversationWrapper>
        <ConversationTitle>
          {conversation.history.length !== 0 && (
            <div>
              Conversation avec {conversation.history[0].sender!.id !== user!.id ?
                conversation.history[0].sender!.userName! :
                conversation.history[0].receiver!.userName!}
            </div>
          )}
          {(conversation.history.length === 0 && newMessage) && (
            <div>
              Conversation avec {(to )?.userName}
            </div>
          )}
        </ConversationTitle>
        <ChatWrapper>
          {conversation.history.map(renderMessage)}
        </ChatWrapper>
        <ChatBottomWrapper>
          {file.cata(
            () => null,
            (f) => (
              <FileWrapper>
                {f.type.startsWith("image") && <img src={URL.createObjectURL(f)} alt="" />}
                {f.type === "application/vnd.openxmlformats-officedocument.wordprocessingml.document" && <BsFileEarmarkWord size={90} />}
                {f.type === "application/pdf" && <BsFileEarmarkPdf size={90} />}
                <BsXLg onClick={() => {
                  setFile(None())
                  setFileData(None())
                }}/>
              </FileWrapper>
            )
          )}
          {conversation.interlocutor &&
            <ChatInputWrapper focus={edit.isSome()}>
              <InputText
                placeholder="Ecrivez un message..."
                value={input}
                onChange={(e) => setInput(e.target.value)}
                onKeyDown={(e) => {
                  if (e.code === "Enter") {
                    if (edit.isSome())
                      editMessage(useChat, setInput, setEdit, setConversation, conversation, edit, input)
                    else
                      sendMessage(useChat, setInput, setFile, setFileData, setConversation, setContactList, user!, conversation.interlocutor!, input, fileData)
                  }
                }}/>
              <label htmlFor="file-upload">
                <input id="file-upload" type="file" style={{display: "none"}}
                       onChange={(data) => onChangeFile(reader, setFile, Maybe.fromNull(data.target.files))} multiple={false}/>
                <ImAttachment size="100%"/>
              </label>
              <FaPaperPlane size="100%" onClick={() =>
                edit.isSome() ?
                  editMessage(useChat, setInput, setEdit, setConversation, conversation, edit, input) :
                  sendMessage(useChat, setInput, setFile, setFileData, setConversation, setContactList, user!, conversation.interlocutor!, input, fileData)
              }/>
            </ChatInputWrapper>
          }
        </ChatBottomWrapper>
      </ConversationWrapper>
    </Wrapper>
  );
}

const timeIndicator = (date: Date): string => {
  const now = new Date();
  const diff = now.getTime() - date.getTime();

  if (diff <= 86400000) {
    const indicator = new Date(diff);
    if (indicator.getHours() > 1)
      return `${indicator.getHours() - 1  } h`;
    if (indicator.getMinutes() !== 0)
      return `${indicator.getMinutes()  } m`;
    return `${indicator.getSeconds()  } s`;
  }
  return `${Math.floor(diff / 86400000)  } j`;
}

const getConversation = (chatApi: ChatApi, setConversation: SetState<Conversation>, self: string, accountOne: Account, accountTwo: Account) => {
  const request: ApiChatHistoryGetRequest = {
    users: [accountOne.id!, accountTwo.id!]
  };


  chatApi.apiChatHistoryGet(request).then((h: ChatMessage[]) => {
    h.sort((first, second) => first.createdAt!.getTime() > second.createdAt!.getTime() ? 1 : -1);
    if (accountOne.id! !== self) {
      setConversation({history: h, interlocutor: accountOne});
      return;
    }
    setConversation({history: h, interlocutor: accountTwo})
  }
);
}

const editMessage = (chatApi: ChatApi, setInput: SetState<string>, setEdit: SetState<Maybe<number>>, setConversation: SetState<Conversation>, conversation: Conversation, messageId: Maybe<number>, message: string) => {
  messageId.cata(
    () => null,
    (id) => {
      chatApi.apiChatPatch({
        msgId: id,
        content: message
      }).then((mess) => {
        if (mess != null) {
          const toEdit = conversation.history.find((m) => m.id === id);
          if (!toEdit)
            return;
          setConversation((prevState) => ({
            ...prevState,
            history: prevState.history.filter((m) => m.id !== id)
          }));
          setConversation((prevState) => ({
            ...prevState,
            history: prevState.history.concat({
              ...toEdit,
              content: message
            })
          }));
          setInput("");
          setEdit(None());
        }
      })
    }
  )
}

const sendMessage = (chatApi: ChatApi, setInput: SetState<string>, setFile: SetState<Maybe<File>>, setFileData: SetState<Maybe<string>>, setConversation: SetState<Conversation>, setContactList: SetState<ChatPreview[]>, user: Account, to: Account, message: string, file: Maybe<string>) => {
  chatApi.apiChatPost({
    createChatMessage: {
      fromUserId: user.id!,
      toUserID: to.id!,
      content: message,
      filename: file.orSome("")
    }
  }).then((m) => {
    if (m !== null) {
      setConversation((prevState) => ({
        ...prevState,
        history: prevState.history.concat(m)
      }))
      setInput("");
      setFile(None());
      setFileData(None());
      // setContactList((prevState) =>
      //   prevState.map((contact) => {
      //     const interlocutor = contact.receive ? contact.lastMsg!.sender!.userName! : contact.lastMsg.receiver!.userName!;
      //     if (interlocutor === conversation.interlocutor?.userName) {
      //       return {
      //         ...contact,
      //         lastMsg: m
      //       }
      //     }
      //     return contact;
      //   }))
    }
  })
}

const removeMessage = (chatApi: ChatApi, setConversation: SetState<Conversation>, id: number) => {
  chatApi.apiChatMsgIdDelete({
    msgId: id
  }).then(() => {
    setConversation((prevState) => ({
      ...prevState,
      history: prevState.history.filter((message) => message.id !== id)
    }))
  })
}

const onChangeFile = (reader: FileReader, setFile: SetState<Maybe<File>>, fileList: Maybe<FileList>) => {
  fileList.cata(
    () => null,
    (files) => {
      if ((files[0].size / 1024 / 1024) <= 200) {
        setFile(Some(files[0]));
        reader.readAsDataURL(files[0]);
      }
    })
}

export default Chat;
