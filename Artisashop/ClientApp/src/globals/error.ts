import { ToastHandler } from "components/Toaster";
import { SetState } from "globals/state";
import { FieldError } from "models/gameCreation";
import { TFunction } from "i18next";
import _ from "lodash/fp";

export interface Error {
  key: string;
  message: string;
}

export const error = (key: string, message: string): Error => ({
  key,
  message,
});

export const handleErrors = (
  toaster: ToastHandler,
  setFieldErrors: SetState<FieldError[]>,
  t: TFunction,
  errors: Error[]
) => {
  setFieldErrors([]);
  errors.forEach((e) => {
    if (e.message === "error.required" || e.message === "error.invalid") {
      setFieldErrors((prevState) =>
        _.concat([
          {
            field: e.key,
            message: t(e.message),
          },
        ])(prevState)
      );
    } else toaster.showError(e);
  });
};
