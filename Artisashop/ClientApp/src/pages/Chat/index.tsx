import React, {FC, useEffect, useState} from "react";
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
import { random } from "lodash";
import {Maybe, None, Some} from "monet";
import useApi from "hooks/useApi";
import {Account, ApiChatHistoryGetRequest, ChatApi, ChatHistory, ChatMessage, ChatPreview} from "api";

const ref = new Date();

const Joseph: Account = {
  id: "1",
  userName: "Joseph",
  email: "",
  lastname: "Vidal",
  firstname: "Joseph",
}

type MaybeString = string | null | undefined;

type MaybeAccount = Account | undefined;

interface Conversation {
  history: ChatMessage[],
  interlocutor?: Account
}

const Chat: FC = () => {
  const [contactList, setContactList] = useState<ChatPreview[]>([]);
  const [conversation, setConversation] = useState<Conversation>({ history: [] });
  const [hover, setHover] = useState<number>(0);
  const [input, setInput] = useState<string>("");
  const [file, setFile] = useState<Maybe<File>>(None());
  const [edit, setEdit] = useState<Maybe<number>>(None());
  const useChat = useApi(ChatApi);

  useEffect(() => {
    useChat.apiChatListGet().then((r) => {
      setContactList(r);
      console.log(r);
    });
  }, [])

  const renderContact = (contact: ChatPreview) => {
    const interlocutor: string = contact.receive ? contact.lastMsg!.sender!.userName! : contact.lastMsg!.receiver!.userName!;

    return (
      <ContactWrapper selected={interlocutor === conversation.interlocutor?.userName} key={generate()} onClick={() => {
        getConversation(useChat, setConversation, contact.lastMsg!.sender!, contact.lastMsg!.receiver!);
        setInput("");
        setEdit(None());
        setFile(None());
      }}>
        {interlocutor}
        <ContactPreview>
          <MessagePreview>
            {contact.lastMsg?.sender?.userName}: {contact.lastMsg?.content}
          </MessagePreview>
          {timeIndicator(contact.lastMsg!.date!)}
        </ContactPreview>
      </ContactWrapper>
    )
  };

  const renderMessage = (message: ChatMessage) => {
    const self = message.sender!.userName! === "Joseph";

    return (
      <MessageTooltipWrapper key={message.id} self={self} onMouseOver={() => setHover(message.id!)} onMouseOut={() => setHover(0)}>
        {(self && hover === message.id) && (
          <>
            <BsPencil size="100%" onClick={() => {
              setEdit(Some(message.id!));
              setInput(message.content!);
            }} />
            <BsTrash size="100%" onClick={() => removeMessage(setConversation, message.id!)} />
          </>
          )
        }
        <MessageWrapper self={self}>
          {message.sender!.userName!}
          <MessageBubble self={self}>
            {message.content!}
          </MessageBubble>
          <MessageDate>
            {hover === message.id! && timeIndicator(message.date!)}
          </MessageDate>
        </MessageWrapper>
      </MessageTooltipWrapper>
    )
  };

  return (
    <Wrapper>
      <ContactList>
        {contactList.map(renderContact)}
      </ContactList>
      <ConversationWrapper>
        <ConversationTitle>Conversation avec
          {conversation.history[0].sender!.userName !== "Joseph" ?
            conversation.history[0].sender!.userName! :
            conversation.history[0].receiver!.userName!}
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
                <BsXLg onClick={() => setFile(None())}/>
              </FileWrapper>
            )
          )}
          <ChatInputWrapper focus={edit.isSome()}>
            <InputText
              placeholder="Ecrivez un message..."
              value={input}
              onChange={(e) => setInput(e.target.value)}
              onKeyDown={(e) => {
                if (e.code === "Enter") {
                  if (edit.isSome())
                    editMessage(setInput, setEdit, setConversation, conversation, edit, input)
                  else
                    sendMessage(setInput, setConversation, Joseph, conversation.interlocutor, input, file)
                }
              }} />
            <label htmlFor="file-upload">
              <input id="file-upload" type="file" style={{display: "none"}} onChange={(data) => onChangeFile(setFile, Maybe.fromNull(data.target.files))} multiple={false} />
              <ImAttachment size="100%" onClick={() => console.log("File")} />
            </label>
            <FaPaperPlane size="100%" onClick={() =>
              edit.isSome() ?
                editMessage(setInput, setEdit, setConversation, conversation, edit, input) :
                sendMessage(setInput, setConversation, Joseph, conversation.interlocutor, input, file)
            }/>
          </ChatInputWrapper>
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

const getConversation = (chatApi: ChatApi, setConversation: SetState<Conversation>, accountOne: Account, accountTwo: Account) => {
  const request: ApiChatHistoryGetRequest = {
    chatHistory: {
      userIDOne: accountOne.id!,
      userIDTwo: accountTwo.id!
    }
  };

  chatApi.apiChatHistoryGet(request).then((h: ChatMessage[]) => {
    if (accountOne.id! !== Joseph.id!) {
      setConversation({history: h, interlocutor: accountOne})
    }
    setConversation({history: h, interlocutor: accountTwo})
  }
);
}

const editMessage = (setInput: SetState<string>, setEdit: SetState<Maybe<number>>, setConversation: SetState<Conversation>, conversation: Conversation, messageId: Maybe<number>, message: string) => {
  messageId.cata(
    () => null,
    (id) => {
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
  )
}

const sendMessage = (setInput: SetState<string>, setConversation: SetState<Conversation>, user: Account, to: MaybeAccount, message: string, file: Maybe<File>) => {
  const newMessage: ChatMessage = {
    id: random(0, 1000),
    sender: user,
    receiver: to,
    date: new Date(),
    content: message
  };
  setConversation((prevState) => ({
    ...prevState,
    history: prevState.history.concat(newMessage)
  }))
  setInput("");
}

const removeMessage = (setConversation: SetState<Conversation>, id: number) => {
  setConversation((prevState) => ({
    ...prevState,
      history: prevState.history.filter((message) => message.id !== id)
  }))
}

const onChangeFile = (setFile: SetState<Maybe<File>>, fileList: Maybe<FileList>) => {
  fileList.cata(
    () => null,
    (files) => setFile(Some(files[0]))
  )
}

export default Chat;
