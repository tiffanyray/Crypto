export const isNum = (x) => {
  return !Number.isNaN(x) && !Number.isNaN(parseNum(x));
}

export const parseNum = (x) => {
  return parseFloat(x);
}

export const parseNumForUI = (x) => {
  let value = x.replace(/[^\d.]/g, '');
  if (value > 0) {
    //trim leading 0s
    while( value.charAt( 0 ) == '0' )
      value = value.slice( 1 );
  }
  return value;
}

export const valOrFalse = (x) => {
  return isNum(x) && parseNumForUI(x);
}

export const numRetVal = (x) => {
  return x ? `${x}` : "";
}