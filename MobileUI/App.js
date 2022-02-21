import * as React from 'react';
import {Navigation} from "./src/navigation";
import { Provider as PaperProvider } from 'react-native-paper';

export default function App() {
  return (
    <PaperProvider>
      <Navigation/>
    </PaperProvider>
  );
}
