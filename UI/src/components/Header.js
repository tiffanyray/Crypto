import {IonButtons, IonHeader, IonMenuButton, IonTitle, IonToolbar} from "@ionic/react";
import {useEffect, useState} from "react";
import {getPage} from "../navigation";
import {useRouteMatch} from "react-router";

export const Header = ({children, title = null}) => {
  let routeMatch = useRouteMatch();
  const [page, setPage] = useState({});

  useEffect(() => {
    if (title !== null) {
      setPage({ title })
    } else {
      let newPage = getPage(routeMatch.path);
      setPage(newPage)
    }
  }, [routeMatch, title])

  return (
    <IonHeader>
      <IonToolbar>
        <IonButtons slot="start">
          <IonMenuButton/>
        </IonButtons>
        <IonTitle>{page?.title}</IonTitle>
        <IonButtons slot="primary">
          {children}
        </IonButtons>
      </IonToolbar>
    </IonHeader>
  )
};