import { lazy } from "react";

export const lazyRootElements = {
  SiteLayout: lazy(() => import("Views/Site/Layout/SiteLayout")),
  AdminLayout: lazy(() => import("Views/Admin/Layout/AdminLayout")),
};
