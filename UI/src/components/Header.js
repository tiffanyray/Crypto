import {IonButtons, IonHeader, IonMenuButton, IonTitle, IonToolbar} from "@ionic/react";
import {useEffect, useState} from "react";
import {useLocation} from "react-router-dom";
import {getPage} from "../navigation";

export const Header = () => {
  let location = useLocation();
  const [page, setPage] = useState({});
  
  useEffect(() =>{
    let newPage = getPage(location.pathname);
    setPage(newPage)
  }, [location])
  
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