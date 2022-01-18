export const getScrollbarWidth = () => {
  const outer = document.createElement("div");

  outer.style.overflow = "scroll";
  outer.style.visibility = "hidden";

  document.body.appendChild(outer);

  const inner = document.createElement("div");

  outer.appendChild(inner);

  const scrollbarWidth = outer.offsetWidth - inner.offsetWidth;

  document.body.removeChild(outer);

  return scrollbarWidth;
};
