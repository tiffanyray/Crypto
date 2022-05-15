import {
  IonButton,
  IonCard,
  IonCardContent,
  IonCardHeader,
  IonCardSubtitle,
  IonCardTitle,
  IonContent,
  IonRouterLink
} from "@ionic/react";
import {useEffect, useState} from "react";
import {pages} from "../../navigation";
import {Header} from "../../components/Header";
import {agent} from "../../api";
import {toast} from "react-toastify";

export const Portfolios = () => {
  const [portfolios, setPortfolios] = useState([]);

  const getList = async () => {
    return await agent.portfolios.list();
  }

  useEffect(() => {
    getList()
      .then((response) => {
        setPortfolios(response.data);
      })
      .catch((response) => {
        toast("There was an error. Please try again later.")
      });
  }, []);


  return <IonContent fullscreen>
    <Header>
      <IonButton routerLink={pages.addPortfolio.url}>Add</IonButton>
    </Header>
    {portfolios.map((portfolio) => {
      return (<IonCard key={portfolio.id}>
        <IonRouterLink routerLink={pages.portfolio.link + portfolio.id}>
          <IonCardHeader>
            <IonCardTitle>{portfolio.name}</IonCardTitle>
            <IonCardSubtitle>{portfolio.crypto.name} - {portfolio.total}</IonCardSubtitle>
          </IonCardHeader>
          <IonCardContent>{portfolio.description}</IonCardContent>
        </IonRouterLink>
        <IonButton routerLink={pages.editPortfolio.link + portfolio.id}>Edit</IonButton>
      </IonCard>)
    })}
  </IonContent>
}