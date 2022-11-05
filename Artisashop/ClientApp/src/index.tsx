import React from "react";
import { createRoot } from "react-dom/client";
import Routes from "routes";
import PrimeReact from "primereact/api";
import { GlobalStyles } from "globals/styles";
import Toaster from "components/Toaster";
import "primereact/resources/primereact.min.css";
import "primeicons/primeicons.css";
import "./custom-theme.css";
import { StoreProvider } from "reducers/utils";
import "./i18n";
import Loader from "components/Loader";
import { ProvideAuth } from "hooks/useAuth";

PrimeReact.ripple = true;

const container = document.getElementById("root");
const root = createRoot(container!);

root.render(
  <React.Suspense fallback={<Loader visible />}>
    <GlobalStyles />
    <ProvideAuth>
      <StoreProvider>
        <Toaster>
          {(toastHandler) => <Routes toastHandler={toastHandler} />}
        </Toaster>
      </StoreProvider>
    </ProvideAuth>
  </React.Suspense>
);
export { useInterval } from "globals/useInterval";
export { timetoSecondsString } from "globals/date";
export { timeToMinutesString } from "globals/date";
