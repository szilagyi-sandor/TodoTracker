import React, { Suspense } from "react";

import "./SiteLayout.scss";

import SuperLoadingIndicator from "Modules/Layout/Components/SuperLoadingIndicator/SuperLoadingIndicator";
import SiteMainNavigation from "Modules/Layout/SmartComponents/Navigation/SiteMain/SiteMainNavigation";

// TODO: Header
// TODO: Footer
// TODO: Scrollbars
// TODO: Helper div to keep content in place
export default function SiteLayout() {
  return (
    <section className="siteLayout">
      <header>
        <SiteMainNavigation />
      </header>

      <main className="content">
        <Suspense fallback={<SuperLoadingIndicator />}>TODO:Pages</Suspense>
      </main>

      <footer>
        <p>Footer</p>
      </footer>
    </section>
  );
}
