import * as React from 'react';
import {NavigationContainer} from '@react-navigation/native';
import {createNativeStackNavigator} from '@react-navigation/native-stack';
import {Home} from "../components/Home";
import {Calculator} from "../components/Calculator";
import {CostBasis} from "../components/CostBasis";
import {Portfolios} from "../components/Portfolios";

export const pages = {
  home: "Home",
  calculator: "Profit Calculator",
  costBasis: "Cost Basis",
  portfolios: "Portfolios"
}

const Stack = createNativeStackNavigator();

export const Navigation = () => {
  return (
    <NavigationContainer>
      <Stack.Navigator initialRouteName="Home">
        <Stack.Screen name={pages.home} component={Home}/>
        <Stack.Screen name={pages.calculator} component={Calculator}/>
        <Stack.Screen name={pages.costBasis} component={CostBasis} />
        <Stack.Screen name={pages.portfolios} component={Portfolios} />
      </Stack.Navigator>
    </NavigationContainer>
  )
}