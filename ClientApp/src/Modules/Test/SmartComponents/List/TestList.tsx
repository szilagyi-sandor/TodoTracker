import React, { useEffect, useState } from "react";

import agent from "Modules/API/agent";
import { Test } from "Modules/Test/_Interfaces/Test";

export default function TestList() {
  const [tests, setTests] = useState<Test[]>();

  useEffect(() => {
    const list = async () => {
      const tests = await agent.Tests.listTests();

      setTests(tests);
    };

    list();
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
