// CHECKED 1.1
import { getScrollbarWidth } from "../../../_Helpers/Scrollbar/getScrollbarWidth";

export const setScrollbarWidthSP = () =>
  document.documentElement.style.setProperty(
    "--scrollbarWidth",
    `${getScrollbarWidth()}px`
  );
