import * as React from 'react';
import {View, Text, ScrollView, StyleSheet} from 'react-native';
import {RadioButton, TextInput} from "react-native-paper";
import {numRetVal, parseNumForUI} from "../utils/Numbers";

const reducer = (state, action) => {
  let quantity = parseNumForUI(state.quantity);
  let coinBuy = parseNumForUI(state.coinBuy);
  let coinSell = parseNumForUI(state.coinSell);
  let usdBuy = parseNumForUI(state.usdBuy);
  let usdSell = parseNumForUI(state.usdSell);
  let profitLoss = parseNumForUI(state.profitLoss);
  let profitChanges = state.profitChanges;
    
  switch (action.type) {
    case actions.quantity:
      quantity = parseNumForUI(action.value);
      
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
      coinBuy = parseNumForUI(action.value);
      
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
      usdBuy = parseNumForUI(action.value);
      
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
      coinSell = parseNumForUI(action.value);
      
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
      usdSell = parseNumForUI(action.value);
      
      if (usdBuy >= 0 && usdSell >= 0)
        profitLoss = usdSell - usdBuy;
      
      if (usdSell >= 0 && quantity >= 0)
        coinSell = usdSell / quantity;

      return {
        ...state,
        usdSell: numRetVal(usdSell),
        profitLoss: numRetVal(profitLoss),
      };
      
    case actions.profitLoss:
      profitLoss = parseNumForUI(action.value);
      
      if (profitChanges === profitChangesOptions.sell) {
        usdSell = profitLoss + usdBuy;

        if (usdSell >= 0 && quantity >= 0)
          coinSell = usdSell / quantity;
        
      } else if (profitChanges === profitChangesOptions.buy) {
        usdBuy = usdSell - profitLoss;
        
        if (usdBuy >= 0 && quantity >= 0)
          coinBuy = usdBuy / quantity;
        
      } else if (profitChanges === profitChangesOptions.quantity) {
        let perCoinProfitLoss = coinSell - coinBuy;
        quantity = profitLoss / (perCoinProfitLoss);
        usdBuy = coinBuy * quantity;
        usdSell = coinSell * quantity;
      }

      return {
        ...state,
        profitLoss: numRetVal(profitLoss),
        usdSell: numRetVal(usdSell),
        usdBuy: numRetVal(usdBuy),
        coinSell: numRetVal(coinSell),
        coinBuy: numRetVal(coinBuy),
        quantity: numRetVal(quantity)
      };
      
    case actions.profitChanges:
      return {
        ...state,
        profitChanges: action.value
      }
  }
}

const actions = {
  quantity: "quantity",
  coinBuy: "coinBuy",
  coinSell: "coinSell",
  usdBuy: "usdBuy",
  usdSell: "usdSell",
  profitLoss: "profitLoss",
  profitChanges: "profitChanges"
};

const profitChangesOptions = {
  buy: "buy",
  sell: "sell",
  quantity: "quantity"
}

export const Calculator = () => {
  const [state, dispatch] = React.useReducer(reducer, {
    quantity: "n4.47",
    coinBuy: "0",
    usdBuy: "0",
    coinSell: "0",
    usdSell: "0",
    profitLoss: "0",
    profitChanges: profitChangesOptions.sell
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
      <Text>Sell</Text>
      <RadioButton
        value={profitChangesOptions.sell}
        status={state.profitChanges === profitChangesOptions.sell ? 'checked' : 'unchecked'}
        onPress={() => dispatch({ type: actions.profitChanges, value: profitChangesOptions.sell })}
      />
      <Text>Quantity</Text>
      <RadioButton
        value={profitChangesOptions.quantity}
        status={state.profitChanges === profitChangesOptions.quantity ? 'checked' : 'unchecked'}
        onPress={() => dispatch({ type: actions.profitChanges, value: profitChangesOptions.quantity })}
      />
      <Text>Buy</Text>
      <RadioButton
        value={profitChangesOptions.buy}
        status={state.profitChanges === profitChangesOptions.buy ? 'checked' : 'unchecked'}
        onPress={() => dispatch({ type: actions.profitChanges, value: profitChangesOptions.buy })}
      />
    </ScrollView>
  )
}

const styles = StyleSheet.create({
  input: {
    margin: 10,
  }
});
