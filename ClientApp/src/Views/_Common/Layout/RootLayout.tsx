import React, { Suspense } from "react";

import { Route, Routes } from "react-router-dom";

import { rootPaths } from "./rootPaths";
import { lazyRootElements } from "./lazyRootElements";
import SuperLoadingIndicator from "Modules/Layout/Components/SuperLoadingIndicator/SuperLoadingIndicator";

export default function RootLayout() {
  return (
    <Suspense fallback={<SuperLoadingIndicator />}>
      <Routes>
        <Route element={<lazyRootElements.SiteLayout />} />

        <Route
          path={rootPaths.admin}
          element={<lazyRootElements.AdminLayout />}
        />
      </Routes>
    </Suspense>
  );
}
