import * as React from 'react';
import {View, Text, ScrollView, StyleSheet} from 'react-native';
import {TextInput} from "react-native-paper";

const isNum = (x) => {
  return !Number.isNaN(x) && !Number.isNaN(parseNum(x));
}
const parseNum = (x) => {
  return parseFloat(x);
}

const valOrFalse = (x) => {
  return isNum(x) && parseNum(x);
}

const numRetVal = (x) => {
  return x ? `${x}` : "";
}

// TODO: Need to be able to return a value .
const reducer = (state, action) => {
  let quantity = valOrFalse(state.quantity);
  let coinBuy = valOrFalse(state.coinBuy);
  let coinSell = valOrFalse(state.coinSell);
  let usdBuy = valOrFalse(state.usdBuy);
  let usdSell = valOrFalse(state.usdSell);
  let profitLoss = valOrFalse(state.profitLoss);
    
  switch (action.type) {
    case actions.quantity:
      quantity = valOrFalse(action.value);
      
      if (quantity >= 0 && coinBuy >= 0)
        usdBuy = coinBuy * quantity;
      
      if (quantity >= 0 && coinSell >= 0)
        usdSell = coinSell * quantity;
      
      if (usdBuy >= 0 && usdSell >= 0)
        profitLoss = usdSell - usdBuy;
      
      
      return { 
        ...state,
        quantity: numRetVal(quantity),
        usdBuy: numRetVal(usdBuy),
        usdSell: numRetVal(usdSell),
        profitLoss: numRetVal(profitLoss)
      };
      
    case actions.coinBuy:
      coinBuy = valOrFalse(action.value);
      
      if (quantity >= 0 && coinBuy >= 0)
        usdBuy = coinBuy * quantity;
      
      console.log("usdBuy", usdBuy, quantity, coinBuy)

      if (usdBuy >= 0 && usdSell >= 0)
        profitLoss = usdSell - usdBuy;
      
      return {
        ...state,
        coinBuy: numRetVal(coinBuy),
        usdBuy: numRetVal(usdBuy),
        profitLoss: numRetVal(profitLoss)
      }
      
    case actions.usdBuy:
      usdBuy = valOrFalse(action.value);
      
      if (usdBuy >= 0 && coinBuy >= 0)
        quantity = usdBuy / coinBuy;
      
      if (quantity >= 0 && coinSell >= 0)
        usdSell = quantity * coinSell;

      if (usdBuy >= 0 && usdSell >= 0)
        profitLoss = usdSell - usdBuy;
      
      return {
        ...state,
        usdBuy: numRetVal(usdBuy),
        usdSell: numRetVal(usdSell),
        quantity: numRetVal(quantity),
        profitLoss: numRetVal(profitLoss)
      };
      
    case actions.coinSell:
      coinSell = valOrFalse(action.value);
      
      if (coinSell >= 0 && quantity >= 0)
        usdSell = coinSell * quantity;

      if (usdBuy >= 0 && usdSell >= 0)
        profitLoss = usdSell - usdBuy;

      return {
        ...state,
        coinSell: numRetVal(coinSell),
        usdSell: numRetVal(usdSell),
        profitLoss: numRetVal(profitLoss)
      };
      
    case actions.usdSell:
      usdSell = valOrFalse(action.value);
      
      if (usdBuy >= 0 && usdSell >= 0)
        profitLoss = usdSell - usdBuy;
      
      // TODO: need to implement figuring out coinSellPrice when this var changes.

      return {
        ...state,
        usdSell: numRetVal(usdSell),
        profitLoss: numRetVal(profitLoss),
      };
      
    case actions.profitLoss:
      profitLoss = valOrFalse(action.value);
      
      // TODO: need to implement switch / changing the price to gain the particular profit margin.

      return {
        ...state,
        profitLoss: numRetVal(profitLoss)
      };
  }
}

const actions = {
  quantity: "quantity",
  coinBuy: "coinBuy",
  coinSell: "coinSell",
  usdBuy: "usdBuy",
  usdSell: "usdSell",
  profitLoss: "profitLoss"
};

export const Calculator = () => {
  const [state, dispatch] = React.useReducer(reducer, {
    quantity: "0",
    coinBuy: "0",
    usdBuy: "0",
    coinSell: "0",
    usdSell: "0",
    profitLoss: "0"
  });
  
  return (
    <ScrollView
      keyboardShouldPersistTaps='handled'
    >
      <TextInput
        onChangeText={text => dispatch({ type: actions.quantity, value: text })}
        label="Coin Quantity"
        value={state.quantity}
        style={styles.input}
        keyboardType='numeric'
      />
      <Text>Buy Price</Text>
      <TextInput
        onChangeText={text => dispatch({ type: actions.coinBuy, value: text })}
        label="Coin Price"
        value={state.coinBuy}
        style={styles.input}
        keyboardType='numeric'
      />
      <TextInput
        onChangeText={text => dispatch({ type: actions.usdBuy, value: text })}
        label="USD Price"
        value={state.usdBuy}
        style={styles.input}
        keyboardType='numeric'
      />
      <Text>Sell Price</Text>
      <TextInput
        onChangeText={text => dispatch({ type: actions.coinSell, value: text })}
        label="Coin Price"
        value={state.coinSell}
        style={styles.input}
        keyboardType='numeric'
      />
      <TextInput
        onChangeText={text => dispatch({ type: actions.usdSell, value: text })}
        label="USD Price"
        value={state.usdSell}
        style={styles.input}
        keyboardType='numeric'
      />
      <TextInput
        onChangeText={text => dispatch({ type: actions.profitLoss, value: text })}
        label="Profit/Loss"
        value={state.profitLoss}
        style={styles.input}
        keyboardType='numeric'
      />
    </ScrollView>
  )
}

const styles = StyleSheet.create({
  input: {
    margin: 10,
  }
});
