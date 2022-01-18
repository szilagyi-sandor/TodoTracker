import { useLayoutEffect, useRef } from "react";

import { setVhsSP } from "./_Helpers/setVhsSP";
import { setScrollbarWidthSP } from "./_Helpers/setScrollbarWidthSP";

export const useStyleProperties = () => {
  const timer = useRef<NodeJS.Timeout>();

  useLayoutEffect(() => {
    setVhsSP();
    setScrollbarWidthSP();

    const onResize = () => {
      if (timer.current != null) {
        clearTimeout(timer.current);
      }

      timer.current = setTimeout(() => {
        setVhsSP();
      }, 100);
    };

    window.addEventListener("resize", onResize);

    return () => {
      window.removeEventListener("resize", onResize);
    };
  }, []);
};
