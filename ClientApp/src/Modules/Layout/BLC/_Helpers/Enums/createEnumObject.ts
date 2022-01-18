import { EnumObject } from "../../_Interfaces/Enums/EnumObject";

export const createEnumObject = <T extends EnumObject>(enumObject: T): T =>
  enumObject;
