export const isNum = (x) => {
  return !Number.isNaN(x) && !Number.isNaN(parseNum(x));
}
export const parseNum = (x) => {
  return parseFloat(x);
}

export const valOrFalse = (x) => {
  return isNum(x) && parseNum(x);
}

export const numRetVal = (x) => {
  return x ? `${x}` : "";
}