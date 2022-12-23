import React from 'react';

import { ChatMessage } from 'api';

const MessageView = ({
  message,
} : {
  message: ChatMessage,
}) => (
  <div>
    <div>{message.content}</div>
  </div>
)
