import styled from "styled-components";
import {colors} from "globals/styles";

export const Wrapper = styled.div`
  display: flex;
  flex-direction: row;
  margin: 10vh;
  height: 70vh;
`;

export const ContactList = styled.div`
  flex: 0.2;
  width: 20%;
  border: 2px solid ${colors.darkBlue};
  border-radius: 10px;
  padding: 1vh 1vh 0 1vh;
`;

interface ContactProps {
  selected: boolean
}

export const ContactWrapper = styled.div<ContactProps>`
  border-radius: 10px;
  padding: 1vh;
  margin-bottom: 1vh;
  background: ${(props) => props.selected ? colors.darkRed : colors.darkBlue};
  cursor: pointer;
  font-size: 18px;
  overflow: hidden;
  white-space: nowrap;
  text-overflow: ellipsis;
  height: 60px;
`;

export const ContactPreview = styled.div`
  display: flex;
  flex-direction: row;
  font-size: 14px;
  justify-content: space-between;
`;

export const MessagePreview = styled.div`
  text-align: left;
  overflow: hidden;
  white-space: nowrap;
  text-overflow: ellipsis;
`;

export const MessageTime = styled.div`
  text-align: right;
`;

export const ConversationWrapper = styled.div`
  flex: 0.8;
  display: flex;
  flex-direction: column;
  border: 2px solid ${colors.darkBlue};
  border-radius: 10px;
  margin-left: 2vh;
  padding: 2vh;
`;

export const ConversationTitle = styled.div`
  font-size: 30px;
  color: ${colors.darkBlue};
  font-weight: bold;
`;

export const ChatWrapper = styled.div`
  display: flex;
  flex-direction: column;
  flex: 1;
  margin-top: 2vh;
`;

interface MessageProps {
  self: boolean
}

export const MessageTooltipWrapper = styled.div<MessageProps>`
  align-self: ${(props) => props.self ? "end" : "start"};
  display: flex;
  max-width: 50%;
  flex-direction: row;
  align-items: center;

  & svg {
    width: 15px;
    color: black;
    margin: 0 5px 0 5px;
    cursor: pointer;
  }
`;

export const MessageWrapper = styled.div<MessageProps>`
  text-align: ${(props) => props.self ? "right" : "left"};
  display: flex;
  flex-direction: column;
  border-radius: 10px;
  margin: 1vh 0 1vh 0;
  color: ${colors.darkBlue};
`;

export const MessageBubble = styled.div<MessageProps>`
  background: ${(props) => props.self ? colors.darkRed : colors.darkBlue};
  display: flex;
  flex-direction: column;
  border-radius: 10px;
  padding: 1vh;
  color: white;
  text-align: left;
`;

export const MessageDate = styled.div`
  font-size: 12px;
`;

export const ChatBottomWrapper = styled.div`
  justify-self: end;
  display: flex;
  flex-direction: column;
`;

interface ChatInputProps {
  focus: boolean
}

export const ChatInputWrapper = styled.div<ChatInputProps>`
  display: flex;
  flex-direction: row;
  align-items: center;
  justify-content: center;
  padding: 0 1vh 0 1vh;
  
  & input {
    border: 1px solid ${colors.darkRed};
    box-shadow: ${(props) => props.focus ? `0 0 0 1px ${  colors.darkRed}` : "none"};
    border-radius: 10px;
    width: 100%;
    margin-right: 5px;
    background: ${colors.beige};
    color: black;
  }

  .p-inputtext:enabled:focus {
    border-color: ${colors.darkRed};
    box-shadow: 0 0 0 1px ${colors.darkRed};
  }

  .p-inputtext:enabled:hover {
    border-color: ${colors.darkRed};
  }
  
  & svg {
    color: ${colors.darkRed};
    width: 20px;
    cursor: pointer;
    margin: 0 5px 0 5px;
  }
`;

interface FileWrapperProps {
  isMessage?: boolean
}

export const FileWrapper = styled.div<FileWrapperProps>`
  width: ${(props) => props.isMessage ? "90%" : "120px"};
  height: ${(props) => props.isMessage ? "200px" : "100px"};
  background: ${colors.darkRed};
  border-radius: 5px;
  display: flex;
  flex-direction: row;
  align-items: center;
  justify-content: ${(props) => props.isMessage ? "center" : "start"};
  margin: ${(props) => props.isMessage ? "10px 0 10px 10px" : "0 0 10px 10px"};
  
  & img {
    margin: 0 5px 0 5px;
    max-width: ${(props) => props.isMessage ? "100%" : "90px"};
    max-height: ${(props) => props.isMessage ? "100%" : "90px"};
  }

  & svg {
    cursor: pointer;
  }
`;
