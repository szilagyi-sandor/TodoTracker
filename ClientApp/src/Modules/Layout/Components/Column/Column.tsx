import React, { PropsWithChildren } from "react";

import { ColumnProps } from "./interfaces";
import Col from "Modules/Layout/BLC/Components/Grid/Col/Col";
import { concatClassNames } from "Modules/Layout/BLC/_Helpers/concatClassNames";
import { capitalizeProp } from "Modules/Layout/BLC/Components/Grid/Col/_Helpers/capitalizeProp";

export default function Column({
  xxl,
  children,
  xxlOffset,
  className,
  ...colProps
}: PropsWithChildren<ColumnProps>) {
  const _className = concatClassNames(className || "", [
    { condition: !!xxl, className: `xxlCol${capitalizeProp(xxl)}` },
    { condition: !!xxlOffset, className: `xxlOffset${xxlOffset}` },
  ]);

  return (
    <Col className={_className} {...colProps}>
      {children}
    </Col>
  );
}
