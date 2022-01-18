import React, { PropsWithChildren, useEffect, useRef, useState } from "react";

import { DCRProps } from "./interface";

export default function DCR({
  alt,
  delay,
  showAlt,
  minTime,
  children,
}: PropsWithChildren<DCRProps>) {
  const timer = useRef<NodeJS.Timeout | null>(null);
  const altAppeared = useRef<Date | null>(null);

  const [show, setShow] = useState(delay ? true : !showAlt);

  useEffect(() => {
    if (!show) {
      altAppeared.current = new Date();
    }
  }, [show]);

  useEffect(() => {
    if (timer.current !== null) {
      clearTimeout(timer.current);
    }

    if (showAlt) {
      timer.current = setTimeout(() => {
        setShow(false);
      }, delay || 0);
    } else {
      // If alt does not even appeared we don't need to do anything.
      if (altAppeared.current) {
        const _minTime = minTime || 0;
        const timeDiff = new Date().getTime() - altAppeared.current.getTime();
        const timeLeft = _minTime - timeDiff;

        timer.current = setTimeout(() => setShow(true), Math.max(0, timeLeft));
      }
    }

    return () => {
      if (timer.current !== null) {
        clearTimeout(timer.current);
      }
    };
  }, [delay, minTime, showAlt]);

  return <>{show ? children : alt}</>;
}
