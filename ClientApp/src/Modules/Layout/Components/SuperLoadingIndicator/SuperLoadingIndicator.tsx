import React from "react";

import DCR from "Modules/Layout/BLC/Components/DCR/DCR";
import { SuperLoadingIndicatorProps } from "./interfaces";
import LoadingIndicator from "Modules/Layout/BLC/Components/LoadingIndicator/LoadingIndicator";

export default function SuperLoadingIndicator({
  loading,
}: SuperLoadingIndicatorProps) {
  return (
    <DCR
      showAlt={loading !== false}
      alt={<LoadingIndicator />}
      delay={1000}
      minTime={2000}
    />
  );
}
