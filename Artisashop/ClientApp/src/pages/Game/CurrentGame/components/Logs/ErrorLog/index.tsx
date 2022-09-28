import React, { FC } from "react";
import { Log } from "models/logs";
import { FiAlertTriangle } from "react-icons/fi";
import { Icon } from "pages/Game/CurrentGame/components/Logs/styles";
import { ErrorLogWrapper } from "pages/Game/CurrentGame/components/Logs/ErrorLog/styles";

interface Props {
  log: Log<Error>;
}

const ErrorLog: FC<Props> = ({ log }) => (
  <ErrorLogWrapper>
    <Icon>
      <FiAlertTriangle />
    </Icon>
    {log.data.message}
  </ErrorLogWrapper>
);

export default ErrorLog;
