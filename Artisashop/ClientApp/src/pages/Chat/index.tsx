import React, {FC, useState} from "react";
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

const ref = new Date();

interface Account {
  Id: string,
  UserName: string,
  Email: string,
  Lastname: string,
  Firstname: string,
  Role: AccountType
}

enum AccountType {
  NONE = -1,
  CONSUMER = 0,
  CRAFTSMAN = 1,
  PARTNER = 2,
  ADMIN = 3
}

const Joseph = {
  Id: "1",
  UserName: "Joseph",
  Email: "",
  Lastname: "Vidal",
  Firstname: "Joseph",
  Role: AccountType.CONSUMER
}

const Margot = {
  Id: "2",
  UserName: "Margot",
  Email: "",
  Lastname: "Togram",
  Firstname: "Margot",
  Role: AccountType.CRAFTSMAN
}

const Jojo = {
  Id: "3",
  UserName: "Jojo",
  Email: "",
  Lastname: "Vidul",
  Firstname: "Jojo",
  Role: AccountType.CRAFTSMAN
}

interface ChatMessage {
  Id: number;
  SenderId: Account;
  ReceiverId: Account;
  Date: Date;
  Content: string;
  Joined?: string;
  Filename?: string;
}

interface Contact {
  LastMsg: ChatMessage,
  Receive: boolean
}

const contacts: Contact[] = [
  {
    LastMsg: {
      Id: 1,
      SenderId: Jojo,
      ReceiverId: Joseph,
      Date: new Date(ref.getTime() - 30000),
      Content: "Tu veux voir ma chaise"
    },
    Receive: true
  },
  {
    LastMsg: {
      Id: 2,
      SenderId: Margot,
      ReceiverId: Joseph,
      Date: new Date(ref.getTime() - 172800000),
      Content: "Mes meubles c'est du bois d'arbre top qualité tavu"
    },
    Receive: true
  }
];

const historyMargot: ChatMessage[] = [{
  Id: 1,
  SenderId: Margot,
  ReceiverId: Joseph,
  Date: new Date(ref.getTime() - 172800000),
  Content: "Mes meubles c'est du bois d'arbre top qualité tavu"
},{
  Id: 2,
  SenderId: Joseph,
  ReceiverId: Margot,
  Date: new Date(ref.getTime() - 21600000),
  Content: "Ptdr j'avoue"
},{
  Id: 3,
  SenderId: Joseph,
  ReceiverId: Margot,
  Date: new Date(ref.getTime() - 360000),
  Content: "C'est bô"
}]

const historyJojo: ChatMessage[] = [{
  Id: 1,
  SenderId: Jojo,
  ReceiverId: Joseph,
  Date: new Date(ref.getTime() - 30000),
  Content: "Tu veux voir ma chaise"
}]

interface Conversation {
  history: ChatMessage[],
  interlocutor: Account
}

const Chat: FC = () => {
  const [contactList, setContactList] = useState<Contact[]>(contacts);
  const [conversation, setConversation] = useState<Conversation>({ history: historyMargot, interlocutor: Margot });
  const [hover, setHover] = useState<number>(0);
  const [input, setInput] = useState<string>("");
  const [file, setFile] = useState<Maybe<File>>(None());
  const [edit, setEdit] = useState<Maybe<number>>(None());

  const renderContact = (contact: Contact) => {
    const interlocutor = contact.Receive ? contact.LastMsg.SenderId.UserName : contact.LastMsg.ReceiverId.UserName;

    return (
      <ContactWrapper selected={interlocutor === conversation.interlocutor.UserName} key={generate()} onClick={() => {
        getConversation(setConversation, contact.LastMsg.SenderId.Id, contact.LastMsg.ReceiverId.Id);
        setInput("");
        setEdit(None());
        setFile(None());
      }}>
        {interlocutor}
        <ContactPreview>
          <MessagePreview>
            {contact.LastMsg.SenderId.UserName}: {contact.LastMsg.Content}
          </MessagePreview>
          {timeIndicator(contact.LastMsg.Date)}
        </ContactPreview>
      </ContactWrapper>
    )
  };

  const renderMessage = (message: ChatMessage) => {
    const self = message.SenderId.UserName === "Joseph";

    return (
      <MessageTooltipWrapper key={message.Id} self={self} onMouseOver={() => setHover(message.Id)} onMouseOut={() => setHover(0)}>
        {(self && hover === message.Id) && (
          <>
            <BsPencil size="100%" onClick={() => {
              setEdit(Some(message.Id));
              setInput(message.Content);
            }} />
            <BsTrash size="100%" onClick={() => removeMessage(setConversation, message.Id)} />
          </>
          )
        }
        <MessageWrapper self={self}>
          {message.SenderId.UserName}
          <MessageBubble self={self}>
            {message.Content}
          </MessageBubble>
          <MessageDate>
            {hover === message.Id && timeIndicator(message.Date)}
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
          {conversation.history[0].SenderId.UserName !== "Joseph" ?
            conversation.history[0].SenderId.UserName :
            conversation.history[0].ReceiverId.UserName}
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
                    sendMessage(setInput, setConversation, Joseph, conversation.interlocutor.Id, input, file)
                }
              }} />
            <label htmlFor="file-upload">
              <input id="file-upload" type="file" style={{display: "none"}} onChange={(data) => onChangeFile(setFile, Maybe.fromNull(data.target.files))} multiple={false} />
              <ImAttachment size="100%" onClick={() => console.log("File")} />
            </label>
            <FaPaperPlane size="100%" onClick={() =>
              edit.isSome() ?
                editMessage(setInput, setEdit, setConversation, conversation, edit, input) :
                sendMessage(setInput, setConversation, Joseph, conversation.interlocutor.Id, input, file)
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

const getConversation = (setConversation: SetState<Conversation>, idOne: string, idTwo: string) => {
  if (idOne === "2")
    setConversation({history: historyMargot, interlocutor: Margot});
  if (idOne === "3")
    setConversation({history: historyJojo, interlocutor: Jojo})
  if (idTwo === "2")
    setConversation({history: historyMargot, interlocutor: Margot})
  if (idTwo === "3")
  setConversation({history: historyJojo, interlocutor: Jojo})
}

const editMessage = (setInput: SetState<string>, setEdit: SetState<Maybe<number>>, setConversation: SetState<Conversation>, conversation: Conversation, messageId: Maybe<number>, message: string) => {
  messageId.cata(
    () => null,
    (id) => {
      const toEdit = conversation.history.find((m) => m.Id === id);
      if (!toEdit)
        return;
      setConversation((prevState) => ({
        ...prevState,
        history: prevState.history.filter((m) => m.Id !== id)
      }));
      setConversation((prevState) => ({
        ...prevState,
        history: prevState.history.concat({
          ...toEdit,
          Content: message
        })
      }));
      setInput("");
      setEdit(None());
    }
  )
}

const sendMessage = (setInput: SetState<string>, setConversation: SetState<Conversation>, user: Account, to: string, message: string, file: Maybe<File>) => {
  const newMessage: ChatMessage = {
    Id: random(0, 1000),
    SenderId: user,
    ReceiverId: to === "2" ? Margot : Jojo,
    Date: new Date(),
    Content: message
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
      history: prevState.history.filter((message) => message.Id !== id)
  }))
}

const onChangeFile = (setFile: SetState<Maybe<File>>, fileList: Maybe<FileList>) => {
  fileList.cata(
    () => null,
    (files) => setFile(Some(files[0]))
  )
}

export default Chat;
