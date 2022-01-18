export const capitalizeProp = (prop?: string | number) =>
  prop === undefined
    ? ""
    : typeof prop === "number"
    ? prop
    : prop.charAt(0).toUpperCase() + prop.slice(1);
