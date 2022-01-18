import { EnumItem } from "../../_Interfaces/Enums/EnumItem";

export const autoCreateEnumObject = <
  T extends Record<string, Partial<EnumItem>>
>(
  partialEnumObject: T,
  startingIndex = 0
): Record<keyof T, EnumItem> => {
  const output: Record<string, EnumItem> = {};

  Object.keys(partialEnumObject).forEach((key, index) => {
    const item = partialEnumObject[key];

    const keyParts = key.split(/(?=[A-Z])/);
    keyParts[0] = keyParts[0].charAt(0).toUpperCase() + keyParts[0].slice(1);

    const patchedItem: EnumItem = {
      ...item,
      id: item.id || index + startingIndex,
      name:
        item.name ||
        key.split(/(?=[A-Z])/).reduce((acc, curr, idx) => {
          if (idx === 0) {
            return curr.charAt(0).toUpperCase() + curr.slice(1);
          }

          return acc + " " + curr.toLocaleLowerCase();
        }, ""),
      value: item.value || key.charAt(0).toUpperCase() + key.slice(1),
    };

    output[key] = patchedItem;
  });

  return output as Record<keyof T, EnumItem>;
};
