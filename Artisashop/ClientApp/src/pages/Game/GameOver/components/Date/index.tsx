import React, { FC } from "react";
import { useTranslation } from "react-i18next";
import {
  DateFormated,
  DateText,
  DateWrapper,
  TranslationText,
} from "pages/Game/GameOver/components/Date/styles";
import i18next from "i18next";
import { dateFormat } from "globals/date";

interface Props {
  beginDate: number;
  endDate: number;
}

const Date: FC<Props> = (props: Props) => {
  const { t } = useTranslation();
  return (
    <DateWrapper>
      <DateText>
        <TranslationText>{t("game.finished.begin-date")}</TranslationText>

        <DateFormated>
          {dateFormat(props.beginDate, i18next.language)}
        </DateFormated>
      </DateText>

      <DateText>
        <TranslationText>{t("game.finished.end-date")}</TranslationText>

        <DateFormated>
          {dateFormat(props.endDate, i18next.language)}
        </DateFormated>
      </DateText>
    </DateWrapper>
  );
};

export default Date;
