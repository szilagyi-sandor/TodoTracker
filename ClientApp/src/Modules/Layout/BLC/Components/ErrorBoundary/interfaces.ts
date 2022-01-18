import { ErrorInfo } from "react";

export interface ErrorBoundaryProps {
  onCatch?: (error: Error, errorInfo: ErrorInfo) => void;
  renderForError?: JSX.Element;
}

export interface ErrorBoundaryState {
  hasError: boolean;
}
