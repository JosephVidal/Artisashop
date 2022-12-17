import React, { useEffect } from "react";
import { BrowserRouter, useLocation } from "react-router-dom";
import { createRoot } from "react-dom/client";
import { Provider as JotaiProvider } from "jotai";
import PrimeReact from "primereact/api";
import "primereact/resources/primereact.min.css";
import "primeicons/primeicons.css";

import "./custom-theme.css";
import "./i18n";
import Loader from "./components/Loader";
import Toaster from "./components/Toaster";
import { GlobalStyles } from "./globals/styles";
import { StoreProvider } from "./reducers/utils";
import Routes from "./routes";

PrimeReact.ripple = true;

const container = document.getElementById("root");
const root = createRoot(container!);

const ScrollToTop = () => {
  const location = useLocation()
  useEffect(() => {
    window.scrollTo(0, 0)
  }, [location]);

  return (null)
}

root.render(
  <React.Suspense fallback={<Loader visible />}>
    <GlobalStyles />
    <JotaiProvider>
      <StoreProvider>
        <Toaster>
          {(toastHandler) => (
            <BrowserRouter>
              <ScrollToTop />
              <Routes toastHandler={toastHandler} />
            </BrowserRouter>
          )}
        </Toaster>
      </StoreProvider>
    </JotaiProvider>
  </React.Suspense>
);
export { useInterval } from "globals/useInterval";
export { timetoSecondsString } from "globals/date";
export { timeToMinutesString } from "globals/date";
