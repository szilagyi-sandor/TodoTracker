import React, { lazy, Suspense } from "react";

import "./App.scss";

import ErrorPage from "Views/_Common/Pages/ErrorPage";
import ErrorBoundary from "Modules/Layout/BLC/Components/ErrorBoundary/ErrorBoundary";
import { useStyleProperties } from "Modules/Layout/BLC/Hooks/useStyleProperties/useStyleProperties";
import SuperLoadingIndicator from "Modules/Layout/Components/SuperLoadingIndicator/SuperLoadingIndicator";

const RootLayout = lazy(() => import("Views/_Common/Layout/RootLayout"));

export default function App() {
  useStyleProperties();

  return (
    <div id="app">
      <ErrorBoundary renderForError={<ErrorPage />}>
        <Suspense fallback={<SuperLoadingIndicator />}>
          <h1>Hello World!!</h1>
        </Suspense>
      </ErrorBoundary>
    </div>
  );
}
