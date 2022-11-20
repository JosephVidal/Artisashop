import React, { FC, ReactNode, RefObject, useEffect, useRef } from "react";
import { Toast, ToastMessage } from "primereact/toast";
import { error, Error } from "globals/error";
import i18next from "i18next";
import { saveItem, deleteItem, getLogs } from "globals/localStorage";
import _ from "lodash/fp";
import { ToastWrapper } from "./styles";

interface ToastModel {
  show: (message: ToastMessage | ToastMessage[]) => void;
  clear: () => void;
}

interface Props {
  children: (toastHandler: ToastHandler) => ReactNode;
}

const Toaster: FC<Props> = ({ children }) => {
  const toastRef = useRef<Toast>(null);
  const toastHandler = new ToastHandler(toastRef);

  useEffect(() => displaySavedErrors(toastHandler), []);

  return (
    <ToastWrapper>
      <Toast
        ref={toastRef}
        onRemove={(toastMessage) => {
          deleteItem(toastMessage.detail as string);
        }}
      />
      {children(toastHandler)}
    </ToastWrapper>
  );
};

export class ToastHandler {
  toastRef: RefObject<ToastModel> | null;

  constructor(toastRef: RefObject<ToastModel> | null) {
    this.toastRef = toastRef;
  }

  showErrorMessage = (title: string, message: string) =>
    this.toastRef &&
    this.toastRef.current &&
    this.toastRef.current.show({
      severity: "error",
      summary: <>{i18next.t("error.title")}</>,
      detail: <>{i18next.t(message)}</>,
      life: 3000,
    });

  showSuccess = (success: string) => {
    const toasts: ToastMessage | ToastMessage[] = [];

    toasts.push({
      severity: "success",
      summary: <>{i18next.t("success.title")}</>,
      detail: success,
      life: 5000,
    });

    return toasts.length > 0
      ? this.toastRef &&
          this.toastRef.current &&
          this.toastRef.current.show(toasts)
      : null;
  };

  showError = (err: Error) =>
    this.toastRef && this.toastRef.current && this.showErrors([err]);

  showErrors = (errors: Error[], save: boolean = true) => {
    const toasts: ToastMessage | ToastMessage[] = [];

    errors.forEach((err) => {
      if (save && !saveItem(err.message)) return;

      toasts.push({
        severity: "error",
        summary: <>{i18next.t("error.title")}</>,
        detail: <>{i18next.t(err.message)}</>,
        life: 10000,
      });
    });

    return toasts.length > 0
      ? this.toastRef &&
          this.toastRef.current &&
          this.toastRef.current.show(toasts)
      : null;
  };
}

const displaySavedErrors = (toastHandler: ToastHandler) => {
  const errors: string[] = getLogs().filter(_.negate(_.isNil)) as string[];

  if (errors !== undefined && errors.length > 0)
    i18next.on("initialized", () =>
      toastHandler.showErrors(
        errors.map((errorLog) => error("error", errorLog)),
        false
      )
    );
};

export default Toaster;
