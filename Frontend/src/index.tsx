import React from "react";
import { createRoot } from "react-dom/client";
import Routes from "routes";
import { Provider as JotaiProvider } from "jotai";
import PrimeReact from "primereact/api";
import { GlobalStyles } from "globals/styles";
import Toaster from "components/Toaster";
import "primereact/resources/primereact.min.css";
import "primeicons/primeicons.css";
import "./custom-theme.css";
import { StoreProvider } from "reducers/utils";
import "./i18n";
import Loader from "components/Loader";
import { QueryClient, QueryClientProvider } from "@tanstack/react-query";

PrimeReact.ripple = true;

const container = document.getElementById("root");
const root = createRoot(container!);

const queryClient = new QueryClient();

root.render(
  <React.Suspense fallback={<Loader visible />}>
    <QueryClientProvider client={queryClient}>
      <GlobalStyles />
      <JotaiProvider>
        <StoreProvider>
          <Toaster>
            {(toastHandler) => <Routes toastHandler={toastHandler} />}
          </Toaster>
        </StoreProvider>
      </JotaiProvider>
    </QueryClientProvider>
  </React.Suspense>
);
export { useInterval } from "globals/useInterval";
export { timetoSecondsString } from "globals/date";
export { timeToMinutesString } from "globals/date";
