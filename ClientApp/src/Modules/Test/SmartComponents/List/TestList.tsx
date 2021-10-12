import React, { useEffect, useState } from "react";

import axios from "axios";
import { Test } from "Modules/Test/_Interfaces/Test";

export default function TestList() {
  const [tests, setTests] = useState<Test[]>();

  useEffect(() => {
    // TODO: Add config file
    axios
      .get("http://localhost:5000/api/tests")
      .then((response) => setTests(response.data));
  }, []);

  return (
    <ul>
      {tests &&
        tests.map((test) => (
          <li key={test.id}>
            Title: {test.title}
            <br /> Id: {test.id}
            <br /> Date: {test.date}
          </li>
        ))}
    </ul>
  );
}
