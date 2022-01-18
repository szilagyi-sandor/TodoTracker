import { EnumItem } from "../../_Interfaces/Enums/EnumItem";
import { EnumObject } from "../../_Interfaces/Enums/EnumObject";

export const createEnumArray = <T extends EnumObject>(
  enumObj: T,
  excludedIds?: Array<string | number>
): EnumItem[] => {
  const output: EnumItem[] = [];

  Object.keys(enumObj).forEach((key) => {
    const enumItem = enumObj[key];

    if (
      excludedIds &&
      !excludedIds.includes(enumItem.id) &&
      !excludedIds.includes(enumItem.value)
    ) {
      output.push(enumItem);
    }
  });

  return output;
};
