import React, { PropsWithChildren } from "react";

import { ColProps } from "./interfaces";
import { capitalizeProp } from "./_Helpers/capitalizeProp";
import { concatClassNames } from "../../../_Helpers/concatClassNames";

export default function Col({
  df,
  sm,
  md,
  lg,
  xl,
  children,
  dfOffset,
  smOffset,
  mdOffset,
  lgOffset,
  xlOffset,
  className,
  style,
}: PropsWithChildren<ColProps>) {
  const _df = df ? df : "equal";

  const _className = concatClassNames("col", [
    { condition: !!className, className: className },

    { className: `dfCol${capitalizeProp(_df)}` },
    { condition: !!sm, className: `smCol${capitalizeProp(sm)}` },
    { condition: !!md, className: `mdCol${capitalizeProp(md)}` },
    { condition: !!lg, className: `lgCol${capitalizeProp(lg)}` },
    { condition: !!xl, className: `xlCol${capitalizeProp(xl)}` },

    { condition: !!dfOffset, className: `dfOffset${dfOffset}` },
    { condition: !!smOffset, className: `smOffset${smOffset}` },
    { condition: !!mdOffset, className: `mdOffset${mdOffset}` },
    { condition: !!lgOffset, className: `lgOffset${lgOffset}` },
    { condition: !!xlOffset, className: `xlOffset${xlOffset}` },
  ]);

  return (
    <div className={_className} style={style}>
      {children}
    </div>
  );
}
