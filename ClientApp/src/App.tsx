import React from "react";

import TestList from "Modules/Test/SmartComponents/List/TestList";
import LoginForm from "Modules/Account/SmartComponents/LoginForm/LoginForm";

export default function App() {
  return (
    <div id="app">
      <h1>TODO Tracker</h1>

      <TestList />

      <LoginForm />
    </div>
  );
}
