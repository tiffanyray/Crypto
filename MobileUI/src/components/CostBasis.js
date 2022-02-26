import * as React from 'react';
import {Text} from 'react-native';
import {Button, List, Modal, Portal, Provider, TextInput} from "react-native-paper";
import {parseNum} from "../utils/Numbers";

// Questions
// 1.) Do I want the add new cost to be on a different page?? Like navigate you to a new page?? If so, I need to either, add a store or contextAPI...
// Make decision about question above. I would say store since I plan on having integrations with coinbase??
// 2.) Is this going to be persistant data? 
// We eventually. Let's first focus on building out the UI feature. Then we can think about the backend...

// object: coinQuantity, coinPrice, usdPrice

const reducer = (state, action) => {
  const val = action?.value;
  switch (action.type) {
    case actions.averageCostBasis:

      return {
        ...state,
        averageCostBasis: val
      };

    case actions.setTempRecord:
      return {
        ...state,
        tempRecord: val
      };
    case actions.tempQuantity:
      return {
        ...state,
        tempRecord: {
          ...state.tempRecord,
          quantity: val
        }
      }
    case actions.tempUsdPrice:
      return {
        ...state,
        tempRecord: {
          ...state.tempRecord,
          usdPrice: val
        }
      }
    case actions.commitTempRecord:
      let index = val?.index;
      let asset = {
        quantity: val?.quantity,
        usdPrice: val?.usdPrice
      };

      let updatedAssets = state.assets;
      // need type cohesion
      if (index == addIndexVal) {
        updatedAssets = [...updatedAssets, asset];
      } else {
        updatedAssets[index].quantity = asset.quantity;
        updatedAssets[index].usdPrice = asset.usdPrice;
      }

      return {
        ...state,
        assets: updatedAssets
      }
  }
}

const actions = {
  averageCostBasis: "averageCostBasis",
  setTempRecord: "setTempRecord",
  tempQuantity: "tempQuantity",
  tempUsdPrice: "tempUsdPrice",
  commitTempRecord: "commitTempRecord"
}

const addIndexVal = -1;

// interesting idea. Be able to select which ones you want active in the calculations.
export const CostBasis = ({}) => {
  const [state, dispatch] = React.useReducer(reducer, {
    assets: [{
      quantity: 1,
      usdPrice: 10
    }, {
      quantity: 1,
      usdPrice: 16
    }, {
      quantity: 1,
      usdPrice: 20
    }],
    averageCostBasis: 0,
    tempRecord: {
      index: `-2`,
      quantity: `1`,
      usdPrice: `1`
    }
  })

  const [modalVisible, setModalVisible] = React.useState(false);
  const getModalObject = (index) => {
    if (index === -1) {
      //empty object
      return {
        index: `${addIndexVal}`,
        quantity: `0`,
        usdPrice: `0`
      }
    }
    
    return {
      ...state.assets[index],
      index
    };
  }
  
  const addAsset = () => {
    showModal();
    dispatch({type: actions.setTempRecord, value: getModalObject(-1)});
  }
  
  const editAsset = (index) => {
    showModal();
    dispatch({type: actions.setTempRecord, value: getModalObject(index)});
  }
  
  const showModal = () => setModalVisible(true);
  const hideModal = () => setModalVisible(false);
  const containerStyle = {backgroundColor: 'white', padding: 20};

  const getAverageCost = (assets) => {
    const totalQuantity = assets.reduce((prev, curr) => {
      let currQuantity = parseNum(curr?.quantity);
      return prev + currQuantity;
    }, 0);
    const totalPrice = assets.reduce((prev, curr) => {
      let currPrice = parseNum(curr?.usdPrice);
      return prev + currPrice;
    }, 0);

    const average = totalPrice / totalQuantity;
    dispatch({type: actions.averageCostBasis, value: average});
  };

  React.useEffect(() => {
    getAverageCost(state.assets);
  }, [state.assets])

  // (doesn't include any fees unless you add in your fees to the usdPrice.)
  return <Provider>
    <Portal>
      <Modal visible={modalVisible} onDismiss={hideModal} contentContainerStyle={containerStyle}>
        <Text>This is the edit/add modal.</Text>
        <TextInput
          label="Coin Quantity"
          value={`${state.tempRecord.quantity}`}
          keyboardType='numeric'
          onChangeText={text => dispatch({type: actions.tempQuantity, value: text})}
        />
        <TextInput
          label="USD Price"
          value={`${state.tempRecord.usdPrice}`}
          keyboardType='numeric'
          onChangeText={text => dispatch({type: actions.tempUsdPrice, value: text})}
        />
        <Button onPress={() => {
          dispatch({
            type: actions.commitTempRecord,
            value: state.tempRecord
          })
          hideModal();
        }}>{state.tempRecord.index == addIndexVal ? "Add" : "Edit"}</Button>
      </Modal>
    </Portal>
    <Text>Average Cost Basis: {state.averageCostBasis}</Text>
    <Button onPress={addAsset}>Add Asset</Button>
    {
      state?.assets?.map((asset, index) => {
        return <List.Section key={index}>
          <List.Accordion
            title={`USD Price: ${asset.usdPrice}`}
            left={() => <Text>{asset.quantity} -</Text>}
          >
            <List.Item title="Edit" onPress={() => editAsset(index)}></List.Item>
            <List.Item title="Active"></List.Item>
          </List.Accordion>
        </List.Section>
      })
    }
  </Provider>
}