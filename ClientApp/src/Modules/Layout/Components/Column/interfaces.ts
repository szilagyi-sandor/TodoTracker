import {
  ColProps,
  PossibleGridUnits,
} from "Modules/Layout/BLC/Components/Grid/Col/interfaces";

export interface ColumnProps extends ColProps {
  // Units.
  xxl?: PossibleGridUnits | "auto" | "equal";

  // Offsets.
  xxlOffset?: PossibleGridUnits;
}
