import React, { PropsWithChildren } from "react";

import { RowProps } from "./interfaces";
import { concatClassNames } from "../../../_Helpers/concatClassNames";

export default function Row({
  style,
  children,
  noGutters,
  className,
}: PropsWithChildren<RowProps>) {
  const _className = concatClassNames("row", [
    { className },
    { condition: !!noGutters, className: "noGutters" },
  ]);

  return (
    <div className={_className} style={style}>
      {children}
    </div>
  );
}
