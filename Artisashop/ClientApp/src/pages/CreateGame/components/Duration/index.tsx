import Input, { InputValue } from "components/Input";
import React, { FC } from "react";
import {
  DurationWrapper,
  TextLeft,
  TextRight,
} from "pages/CreateGame/components/Duration/styles";
import { useTranslation } from "react-i18next";
import { FieldError } from "models/gameCreation";
import { Maybe } from "monet";

interface Props {
  value: number;
  onChange: (value: InputValue) => void;
  fieldError: Maybe<FieldError>;
}

const Duration: FC<Props> = (props: Props) => {
  const { t } = useTranslation();

  return (
    <DurationWrapper>
      <TextLeft isError={props.fieldError.isSome()}>
        {t("game.create.duration")}
      </TextLeft>

      <Input
        type="number"
        label={t("game.create.duration-unit")}
        value={props.value}
        onChange={props.onChange}
        fieldError={props.fieldError.cata(
          () => undefined,
          (e) => e.message
        )}
      />

      <TextRight isError={props.fieldError.isSome()}>
        {t("game.create.duration-unit-short")}
      </TextRight>
    </DurationWrapper>
  );
};

export default Duration;
