import React, { ReactElement } from "react";
import { Dialog as PRDialog } from "primereact/dialog";
import { useTranslation } from "react-i18next";
import Button from "components/Button";
import { TFunction } from "i18next";
import { DialogButtons } from "models/dialog";
import { DialogWrapper, FooterWrapper } from "./styles";

interface Props {
  title: string;
  text: string;
  buttons: boolean;
  buttonsText: DialogButtons;
  visible?: boolean;
  onHide: () => void;
  onAccept?: () => void;
}

const Dialog: React.FunctionComponent<Props> = ({
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
    <DialogWrapper>
      <PRDialog
        resizable={false}
        draggable={false}
        header={title}
        footer={buttons && footerTemplate(buttonsText)(t, onAccept, onHide)}
        onHide={onHide}
        visible={visible}
        closable
      >
        {t(text)}
      </PRDialog>
    </DialogWrapper>
  );
};

const footerTemplate =
  (buttonsText: DialogButtons) =>
  (t: TFunction, onAccept?: () => void, onHide?: () => void): ReactElement =>
    (
      <FooterWrapper>
        <Button label={t(buttonsText.cancelButton)} onClick={onHide} />
        <Button label={t(buttonsText.confirmButton)} onClick={onAccept} />
      </FooterWrapper>
    );

export default Dialog;
