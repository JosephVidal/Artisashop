import i18n from "i18next";
import HttpApi from "i18next-http-backend";
import { initReactI18next } from "react-i18next";
import LanguageDetector from "i18next-browser-languagedetector";

i18n
  .use(HttpApi)
  .use(LanguageDetector)
  .use(initReactI18next)
  .init({
    supportedLngs: ["fr", "en"],
    fallbackLng: "fr",
    backend: {
      loadPath: "/langs/{{lng}}.json",
      allowMultiLoading: false,
    },
    interpolation: { escapeValue: false },
  });

export default i18n;
