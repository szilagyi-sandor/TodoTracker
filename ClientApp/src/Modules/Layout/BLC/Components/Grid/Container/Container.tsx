import React, { PropsWithChildren } from "react";

import { ContainerProps } from "./interfaces";
import { concatClassNames } from "../../../_Helpers/concatClassNames";

export default function Container({
  style,
  children,
  className,
  fullWidth,
}: PropsWithChildren<ContainerProps>) {
  const _className = concatClassNames("container", [
    { className },
    { condition: !!fullWidth, className: "fullWidth" },
  ]);

  return (
    <div className={_className} style={style}>
      {children}
    </div>
  );
}
