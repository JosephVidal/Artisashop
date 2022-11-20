import React from "react";
import { ConfirmDialog as PRConfirmDialog } from "primereact/confirmdialog";
import { useTranslation } from "react-i18next";
import { DialogButtons } from "models/dialog";
import { ConfirmDialogWrapper } from "./styles";

interface Props {
  title: string;
  text: string;
  buttons: boolean;
  buttonsText: DialogButtons;
  visible?: boolean;
  onHide: () => void;
  onAccept?: () => void;
}

const ConfirmDialog: React.FunctionComponent<Props> = ({
  title,
  text,
  buttons,
  buttonsText,
  visible,
  onHide,
  onAccept,
}) => {
  const { t } = useTranslation();

  return (
    <ConfirmDialogWrapper>
      <PRConfirmDialog
        resizable={false}
        draggable={false}
        header={title}
        message={t(text)}
        acceptLabel={t(buttonsText.confirmButton)}
        rejectLabel={t(buttonsText.cancelButton)}
        closable
        onHide={onHide}
        visible={visible}
        accept={onAccept}
      />

      {buttons}
    </ConfirmDialogWrapper>
  );
};

export default ConfirmDialog;
