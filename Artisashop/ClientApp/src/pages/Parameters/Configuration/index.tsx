import React, { FC, useState, useEffect, ReactNode } from "react";
import { useTranslation } from "react-i18next";
import { TFunction } from "i18next";
import { Maybe, Some } from "monet";
import { getConfigScreenParameters } from "configurations";
import { setConfigParameter } from "configurations/api";
import * as _ from "lodash/fp";
import { Error } from "globals/error";
import { ToastHandler } from "components/Toaster";
import Content from "components/Content";
import InputInline from "components/InputInline";
import Button from "components/Button";
import { ConfirmButtonWrapper } from "./styles";

interface Props {
  toastHandler: ToastHandler;
}

const Configuration: FC<Props> = ({ toastHandler }) => {
  const [loading, setLoading] = useState<boolean>(true);
  const [centerName, setCenterName] = useState<Maybe<string>>(Maybe.None());
  const [defaultDuration, setDefaultDuration] = useState<Maybe<string>>(
    Maybe.None()
  );
  const [gameInterval, setGameInterval] = useState<Maybe<string>>(Maybe.None());

  const { t } = useTranslation();

  const isIntervalTooShort: boolean =
    _.subtract(
      _.toInteger(gameInterval.orSome("11")),
      _.toInteger(defaultDuration.orSome("0"))
    ) <= 10;

  const fetchConfiguration = (): Promise<void> =>
    Promise.all([
      getConfigScreenParameters(toastHandler, "center-name", setCenterName),
      getConfigScreenParameters(
        toastHandler,
        "default-duration",
        setDefaultDuration
      ),
      getConfigScreenParameters(toastHandler, "game-interval", setGameInterval),
    ]).then(() => setLoading(false));

  useEffect(() => {
    fetchConfiguration();
  }, []);

  const renderForm = (): ReactNode => (
    <>
      <InputInline
        type="text"
        label="parameters.configuration.center-name-label"
        value={centerName}
        onChange={(e) => setCenterName(Some(e.target.value))}
        isCentered
      />

      <InputInline
        type="minmax"
        label="parameters.configuration.default-duration-label"
        suffix="game.duration-unit"
        value={defaultDuration}
        onValueChange={(e) => setDefaultDuration(Some(_.toString(e.value)))}
        isCentered
      />

      <InputInline
        type="minmax"
        label="parameters.configuration.game-interval-label"
        suffix="game.duration-unit"
        value={gameInterval}
        onValueChange={(e) => setGameInterval(Some(_.toString(e.value)))}
        isCentered
        withWarningMessage={isIntervalTooShort}
        warningMessage="parameters.configuration.interval-warning"
      />

      <ConfirmButtonWrapper>
        <Button
          label={t("parameters.configuration.confirm-button-label")}
          type="primary"
          size="large"
          disabled={
            centerName.isNone() ||
            defaultDuration.isNone() ||
            gameInterval.isNone()
          }
          onClick={() =>
            onSaveChanges(
              toastHandler,
              t,
              centerName.some(),
              defaultDuration.some(),
              gameInterval.some()
            )
          }
        />
      </ConfirmButtonWrapper>
    </>
  );

  return (
    <Content title={t("parameters.configuration.title")} loading={loading}>
      {!loading && renderForm()}
    </Content>
  );
};

const onSaveChanges = (
  toastHandler: ToastHandler,
  t: TFunction,
  centerName: string,
  defaultDuration: string,
  gameInterval: string
) => {
  Promise.all([
    setConfigParameter("center-name", centerName),
    setConfigParameter("default-duration", defaultDuration),
    setConfigParameter("game-Interval", gameInterval),
  ]).then((maybeErrorsArray) =>
    showErrorOrSuccess(maybeErrorsArray, toastHandler, t)
  );
};

const showErrorOrSuccess = (
  maybeErrorsArray: Maybe<Error[]>[],
  toaster: ToastHandler,
  t: TFunction
): void | null =>
  _.isEmpty(maybeErrorsArray)
    ? toaster.showSuccess(t("parameters.configuration.success"))
    : maybeErrorsArray[0].cata(
        () => showErrorOrSuccess(_.tail(maybeErrorsArray), toaster, t),
        toaster.showErrors
      );

export default Configuration;
