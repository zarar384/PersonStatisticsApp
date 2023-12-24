export {};

declare global {
  interface String {
    toInt(): number | undefined;
  }
}

String.prototype.toInt = function (this: string): number | undefined {
  const intValue = Number.parseInt(this, 10);
  return Number.isNaN(intValue) ? undefined : intValue;
};
