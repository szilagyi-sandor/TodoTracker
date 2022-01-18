import React from "react";

import { Link } from "react-router-dom";
import Container from "Modules/Layout/BLC/Components/Grid/Container/Container";
import { rootPaths } from "Views/_Common/Layout/rootPaths";

// TODO: Styling
// TODO: filter menu based on Auth
// TODO: Paths -> rootPath to sitePaths
export default function SiteMainNavigation() {
  return (
    <div className="siteMainNavigation">
      <Container>
        <div className="inner">
          <nav>
            <div className="brand">
              <h1>
                <Link to={rootPaths.site}>TODO Tracker</Link>
              </h1>
            </div>

            <ul>
              <li>
                <Link to={rootPaths.admin}>Admin</Link>
              </li>
            </ul>
          </nav>
        </div>
      </Container>
    </div>
  );
}
