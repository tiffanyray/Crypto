﻿import * as React from 'react';
import {View, Text, Button} from 'react-native';
import {pages} from "../navigation";

export const Home = ({navigation}) => {
  console.log('loaded home...')
  return (
    <View style={{ flex: 1, alignItems: 'center', justifyContent: 'center' }}>
      <Text>Home</Text>
      <Button
          title={"Calc"}
          onPress={() => navigation.navigate(pages.calculator)}
      />
    </View>
  )
}