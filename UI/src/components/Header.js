import {IonButtons, IonHeader, IonMenuButton, IonTitle, IonToolbar} from "@ionic/react";
import {useEffect, useState} from "react";
import {getPage} from "../navigation";
import {useRouteMatch} from "react-router";
import {useLocation} from "react-router";

export const Header = () => {
  let location = useLocation();
  let routeMatch = useRouteMatch();
  const [page, setPage] = useState({});
  
  useEffect(() =>{
    let newPage = getPage(routeMatch.path);
    setPage(newPage)
  }, [routeMatch])
  
  return (
    <IonHeader>
      <IonToolbar>
        <IonButtons slot="start">
          <IonMenuButton />
        </IonButtons>
        <IonTitle>{page?.title}</IonTitle>
      </IonToolbar>
    </IonHeader>
  )
};