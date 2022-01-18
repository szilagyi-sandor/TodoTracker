import { CommonComponentProps } from "../../../_Interfaces/CommonComponentProps";

export interface ColProps extends CommonComponentProps {
  // Units.
  df?: PossibleGridUnits | "auto" | "equal";
  sm?: PossibleGridUnits | "auto" | "equal";
  md?: PossibleGridUnits | "auto" | "equal";
  lg?: PossibleGridUnits | "auto" | "equal";
  xl?: PossibleGridUnits | "auto" | "equal";

  // Offsets.
  dfOffset?: PossibleGridUnits;
  smOffset?: PossibleGridUnits;
  mdOffset?: PossibleGridUnits;
  lgOffset?: PossibleGridUnits;
  xlOffset?: PossibleGridUnits;
}

export type PossibleGridUnits =
  | 1
  | 2
  | 3
  | 4
  | 5
  | 6
  | 7
  | 8
  | 9
  | 10
  | 11
  | 12;
