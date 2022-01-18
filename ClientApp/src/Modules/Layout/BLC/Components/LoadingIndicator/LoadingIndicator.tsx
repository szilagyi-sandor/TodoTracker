import React from "react";

import { LoadingIndicatorProps } from "./interfaces";
import { concatClassNames } from "../../_Helpers/concatClassNames";

export default function LoadingIndicator({
  style,
  altText,
  loading,
  className,
}: LoadingIndicatorProps) {
  const _className = concatClassNames("loadingIndicator", [{ className }]);

  return loading !== false ? (
    <div className={_className} style={style}>
      <div className="indicator">
        <span className="altText">{altText ? altText : "loading"}</span>
      </div>
    </div>
  ) : null;
}
