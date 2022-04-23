import {IonPage, IonRouterOutlet, IonSplitPane} from "@ionic/react";
import Menu from "../components/Menu";
import {Route} from "react-router-dom";
import {IonReactRouter} from "@ionic/react-router";
import {  albumsOutline, calculatorOutline, cashOutline, homeOutline} from "ionicons/icons";
import {Calculator} from "../pages/Calculator";
import {Costs} from "../pages/Costs";
import {Portfolios} from "../pages/Portfolios";
import {Home} from "../pages/Home";
import {Header} from "../components/Header";

export const pages = {
  home: {
    title: "Home",
    url: "/",
    iosIcon: homeOutline,
    mdIcon: homeOutline
  },
  calculator: {
    title: 'Profit Calculator',
    url: '/calculator',
    iosIcon: calculatorOutline,
    mdIcon: calculatorOutline
  },
  cost: {
    title: 'Cost Basis',
    url: '/costBasis',
    iosIcon: cashOutline,
    mdIcon: cashOutline
  },
  portfolios: {
    title: 'Portfolios',
    url: '/portfolios',
    iosIcon: albumsOutline,
    mdIcon: albumsOutline
  }
}

export const getPagesArray = () => {
  let array = [];
  for (const [key,value] of Object.entries(pages)) {
    array.push(value);
  }
  return array;
}

export const getPage = (pageUrl) => {
  let toSearch = getPagesArray();
  return toSearch.find(x => x.url === pageUrl);
}

export const Navigation = () => {
  return <IonReactRouter>
    <IonSplitPane contentId="main">
      <Menu />
      <IonRouterOutlet id="main">
        <IonPage>
          <Header />
          <Route path="/" exact={true}>
            <Home />
          </Route>
          <Route path={pages.calculator.url} exact={true}>
            <Calculator />
          </Route>
          <Route path={pages.cost.url} exact={true}>
            <Costs />
          </Route>
          <Route path={pages.portfolios.url} exact={true}>
            <Portfolios />
          </Route>
        </IonPage>
      </IonRouterOutlet>
    </IonSplitPane>
  </IonReactRouter>
}