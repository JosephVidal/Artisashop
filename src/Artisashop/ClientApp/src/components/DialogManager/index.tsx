import React, { FC } from "react";
import { DialogButtons } from "models/dialog";
import ConfirmDialog from "./ConfirmDialog";
import Dialog from "./Dialog";

interface Props {
  isConfirm: boolean;
  title: string;
  text: string;
  buttons: boolean;
  buttonsText?: DialogButtons;
  visible?: boolean;
  onHide: () => void;
  onAccept?: () => void;
}

const DialogManager: FC<Props> = ({
  isConfirm,
  title,
  text,
  buttons,
  buttonsText,
  visible,
  onHide,
  onAccept,
}) => {
  const buttonsTxts: DialogButtons = {
    confirmButton: "global.confirm",
    cancelButton: "global.cancel",
  };

  return isConfirm ? (
    <ConfirmDialog
      title={title}
      text={text}
      buttons={buttons}
      buttonsText={buttonsText ?? buttonsTxts}
      visible={visible}
      onAccept={onAccept}
      onHide={onHide}
    />
  ) : (
    <Dialog
      title={title}
      text={text}
      buttons={buttons}
      buttonsText={buttonsText ?? buttonsTxts}
      visible={visible}
      onAccept={onAccept}
      onHide={onHide}
    />
  );
};

DialogManager.defaultProps = { visible: false };

export default DialogManager;
