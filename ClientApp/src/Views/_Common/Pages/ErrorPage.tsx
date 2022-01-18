import React from "react";

import Container from "Modules/Layout/BLC/Components/Grid/Container/Container";

// TODO: Styling.
// TODO: DocTitle update
export default function ErrorPage() {
  return (
    <section className="errorPage">
      <header>
        <Container>
          <h1 className="srOnly">TODO Tracker</h1>

          <h2>Error page</h2>
        </Container>
      </header>

      <main className="content">
        <Container>
          <p>
            Sorry, something went wrong. Our team is working on fixing this.
          </p>
        </Container>
      </main>
    </section>
  );
}
