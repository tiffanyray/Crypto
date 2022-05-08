import {IonPage, IonRouterOutlet, IonSplitPane} from "@ionic/react";
import Menu from "../components/Menu";
import {Route} from "react-router-dom";
import {IonReactRouter} from "@ionic/react-router";
import {albumsOutline, calculatorOutline, cashOutline, folderOutline, homeOutline} from "ionicons/icons";
import {Calculator} from "../pages/Calculator";
import {Costs} from "../pages/Costs";
import {Portfolios} from "../pages/Portfolios";
import {Home} from "../pages/Home";
import {Header} from "../components/Header";
import {Portfolio} from "../pages/Portfolio";

export const pages = {
  home: {
    title: "Home",
    url: "/",
    link: "/",
    iosIcon: homeOutline,
    mdIcon: homeOutline,
    inMenu: true
  },
  calculator: {
    title: 'Profit Calculator',
    url: '/calculator',
    link: '/calculator',
    iosIcon: calculatorOutline,
    mdIcon: calculatorOutline,
    inMenu: true
  },
  cost: {
    title: 'Cost Basis',
    url: '/costBasis',
    link: '/costBasis',
    iosIcon: cashOutline,
    mdIcon: cashOutline,
    inMenu: true
  },
  portfolios: {
    title: 'Portfolios',
    url: '/portfolios',
    link: '/portfolios',
    iosIcon: albumsOutline,
    mdIcon: albumsOutline,
    inMenu: true
  },
  portfolio: {
    title: "Portfolio",
    url: '/portfolio/:id',
    link: "/portfolio/",
    iosIcon: folderOutline,
    mdIcon: folderOutline,
    inMenu: false
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
          <Route path={pages.portfolio.url} exact={true}>
            <Portfolio />
          </Route>
        </IonPage>
      </IonRouterOutlet>
    </IonSplitPane>
  </IonReactRouter>
}