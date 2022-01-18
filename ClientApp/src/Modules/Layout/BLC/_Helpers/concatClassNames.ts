export const concatClassNames = (
  base: string,
  additionals: Array<{
    className?: string;
    condition?: boolean;
  }>
) => {
  const classes = base ? [base] : [];

  additionals.forEach((a) => {
    if (a.condition !== false && a.className) {
      classes.push(a.className);
    }
  });

  return classes.join(" ");
};
