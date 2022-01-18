import React, { Suspense } from "react";

import SuperLoadingIndicator from "Modules/Layout/Components/SuperLoadingIndicator/SuperLoadingIndicator";

// TODO: Change
import SiteMainNavigation from "Modules/Layout/SmartComponents/Navigation/SiteMain/SiteMainNavigation";

export default function AdminLayout() {
  return (
    <section className="adminLayout">
      <header>
        <h1>Admin</h1>
        <SiteMainNavigation />
      </header>

      <main className="content">
        <Suspense fallback={<SuperLoadingIndicator />}>TODO:Pages</Suspense>
      </main>

      <footer>
        <p>Footer.</p>
      </footer>
    </section>
  );
}
