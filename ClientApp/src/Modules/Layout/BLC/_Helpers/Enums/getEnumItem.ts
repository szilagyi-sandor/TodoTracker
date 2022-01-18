import { EnumItem } from "../../_Interfaces/Enums/EnumItem";
import { EnumObject } from "../../_Interfaces/Enums/EnumObject";

export const getEnumItem = (
  enumObject: EnumObject,
  key: number | string
): EnumItem | undefined => {
  const keys = Object.keys(enumObject);

  for (let i = 0; i < keys.length; i++) {
    const item = enumObject[keys[i]];

    if (item.id === key || item.value === key) {
      return item;
    }
  }

  return undefined;
};
