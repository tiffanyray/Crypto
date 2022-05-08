import {IonCard, IonCardContent, IonCardHeader, IonCardSubtitle, IonCardTitle, IonContent} from "@ionic/react";
import {useEffect, useState} from "react";
import {pages} from "../../navigation";
import {Header} from "../../components/Header";
import {agent} from "../../api";
import {toast} from "react-toastify";

export const Portfolios = () => {
  const [portfolios, setPortfolios] = useState([
      {
        id: 1,
        name: "Name",
        description: "Description",
        crypto: "Crypto Name",
        total: "100"
      },
      {
        id: 2,
        name: "Name 2",
        description: "Description 2",
        crypto: "Crypto name 2",
        total: "101"
      }
    ]);

  const getList = async () => {
    console.log("get list")
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
    <Header/>
    {portfolios.map((portfolio) => {
      return (<IonCard routerLink={pages.portfolio.link + portfolio.id} key={portfolio.id}>
        <IonCardHeader>
          <IonCardTitle>{portfolio.name}</IonCardTitle>
          <IonCardSubtitle>{portfolio.crypto} - {portfolio.total}</IonCardSubtitle>
        </IonCardHeader>
        <IonCardContent>{portfolio.description}</IonCardContent>
      </IonCard>)
    })}
  </IonContent>
}