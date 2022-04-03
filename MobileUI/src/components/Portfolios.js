import * as React from 'react';
import {Button, Modal, Provider, Text, List, TextInput} from "react-native-paper";
import {useModal} from "../hooks/useModal";

const reducer = (state, action) => {
  const val = action.value;
  switch(action.type) {
    case actions.tempCrypto:
      return {
        ...state,
        tempCrypto: val
      }
    case actions.tempName:
      return {
        ...state,
        tempName: val
      }
    case actions.tempDescription:
      return {
        ...state,
        tempDescription: val
      }
    case actions.setTempRecord:
      return {
        ...state,
        tempRecord: val
      }
    case actions.commitTempRecord:
      let index = val?.index;
      let portfolio = {
        name: val?.name,
        description: val?.description,
        crypto: val?.crypto
      };
      
      let updatedPortfolios = state.portfolios;
      if (index == addIndexVal) {
        updatedPortfolios = [...updatedPortfolios, portfolio];
      } else {
        updatedPortfolios[index].name = portfolio.name;
        updatedPortfolios[index].description = portfolio.description;
        updatedPortfolios[index].crypto = portfolio.crypto;
      }
      
      return {
        ...state,
        portfolio: updatedPortfolios
      }
  }
}

const actions = {
  tempName: "tempName",
  tempDescription: "tempDescription",
  tempCrypto: "tempCrypto",
  commitTempRecord: "commitTempRecord",
  setTempRecord: "setTempRecord"
}

const addIndexVal = -1;

export const Portfolios = () => {
  const [state, dispatch] = React.useReducer(reducer, {
    portfolios: [
      {
        name: "name",
        description: "description",
        crypto: "crypto name"
      },
      {
        name: "name 2",
        description: "description 2",
        crypto: "crypto name 2"
      }
    ],
    tempRecord: {
      index: -1,
      name: "",
      description: "",
      crypto: ""
    }
  });
  
  const modal = useModal({ startingVal: false });
  
  const getModalObject = (index) => {
    console.log("Get modal objecr", index)
    if (index == addIndexVal) {
      return {
        index: addIndexVal,
        name: "",
        description: "",
        crypto: ""
      }
    }
    
    return {
      ...state.portfolios[index],
      index
    }
  };
  
  const addEditPortfolio = (index) => {
    modal.open();
    dispatch({ type: actions.setTempRecord, value: getModalObject(index) });
  }
  
  return <Provider>
    <Modal visible={modal.visible} onDismiss={modal.close}>
      <Text>{state.tempRecord.index == addIndexVal ? "Add" : "Edit"} Modal</Text>
      <TextInput
        label="Name"
        value={`${state.tempRecord.name}`}
        onChangeText={text => dispatch({type: actions.tempName, value: text})}
      />
      <TextInput
        label="Description"
        value={`${state.tempRecord.description}`}
        onChangeText={text => dispatch({type: actions.tempDescription, value: text})}
      />
      <TextInput
        label="Crypto"
        value={`${state.tempRecord.crypto}`}
        onChangeText={text => dispatch({type: actions.tempCrypto, value: text})}
      />
      <Button onPress={() => {
        dispatch({});
        modal.close();
      }}>{state.tempRecord.index == addIndexVal ? "Add" : "Edit"}</Button>
    </Modal>
    <Text>Portfolios</Text>
    <Button onPress={() => addEditPortfolio(addIndexVal)}>Add Portfolio</Button>
    {
      state?.portfolios?.length > 0 && state?.portfolios?.map((portfolio, index) => {
        return <List.Section>
          <List.Accordion
            title={portfolio?.name}
            description={portfolio?.description}
          >
            <List.Item title="Edit" onPress={() => addEditPortfolio(index)} />
          </List.Accordion>
        </List.Section>
      })
    }
  </Provider>
};