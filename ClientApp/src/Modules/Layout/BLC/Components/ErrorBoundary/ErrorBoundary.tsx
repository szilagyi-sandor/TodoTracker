import { Component, ErrorInfo } from "react";

import { ErrorBoundaryProps, ErrorBoundaryState } from "./interfaces";

export default class ErrorBoundary extends Component<
  ErrorBoundaryProps,
  ErrorBoundaryState
> {
  state: ErrorBoundaryState = {
    hasError: false,
  };

  static getDerivedStateFromError(error: Error) {
    return { hasError: true };
  }

  componentDidCatch(error: Error, errorInfo: ErrorInfo) {
    const { onCatch } = this.props;
    onCatch && onCatch(error, errorInfo);
  }

  render() {
    const { hasError } = this.state;
    const { children, renderForError } = this.props;

    if (hasError) {
      return renderForError !== undefined ? renderForError : null;
    }

    return children;
  }
}
