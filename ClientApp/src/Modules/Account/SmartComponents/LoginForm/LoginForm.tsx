import React, { useEffect, useState } from "react";

import agent from "Modules/API/agent";
import { User } from "Modules/Account/_Interfaces/User";
import { LoginParam } from "Modules/Account/_Interfaces/LoginParam";
import { userTokenLS } from "Modules/Account/_Constants/userTokenLS";

// TODO: just a mock-up
export default function LoginForm() {
  const [loginParam, setLoginParam] = useState<LoginParam>({
    email: "",
    password: "",
  });

  const [user, setUser] = useState<User>();

  useEffect(() => {
    const token = localStorage.getItem(userTokenLS);

    if (token) {
      const login = async () => {
        const user = await agent.Account.getCurrentUser();

        setUser(user);
        localStorage.setItem(userTokenLS, user.token);
      };

      login();
    }
  }, []);

  if (user) {
    return (
      <div>
        <div>{JSON.stringify(user)}</div>

        <button
          onClick={() => {
            setUser(undefined);
            localStorage.removeItem(userTokenLS);
          }}
        >
          logout
        </button>
      </div>
    );
  }

  return (
    <form
      onSubmit={(e) => {
        e.preventDefault();

        const login = async () => {
          const user = await agent.Account.login(loginParam);

          setUser(user);
          localStorage.setItem(userTokenLS, user.token);
        };

        login();
      }}
    >
      <div>
        <input
          type="email"
          value={loginParam.email}
          onChange={(e) =>
            setLoginParam({ ...loginParam, email: e.target.value })
          }
        />
      </div>

      <div>
        <input
          type="password"
          value={loginParam.password}
          onChange={(e) =>
            setLoginParam({ ...loginParam, password: e.target.value })
          }
        />
      </div>

      <button type="submit">Send</button>
    </form>
  );
}
