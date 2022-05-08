import {IonButton, IonContent} from "@ionic/react";
import {Header} from "../../components/Header";
import {useEffect, useState} from "react";
import {getPage, pages} from "../../navigation";
import {useRouteMatch} from "react-router";

export const EditPortfolio = () => {
  let [isEdit, setIsEdit] = useState(false);
  let routeMatch = useRouteMatch();
  
  useEffect(() => {
    let page = getPage(routeMatch.path);
    setIsEdit(page.url === pages.editPortfolio.url);
  }, [routeMatch]);
  
  return (<IonContent>
    <Header>
      <IonButton>Save</IonButton>
      <IonButton>Cancel</IonButton>
    </Header>
    {isEdit ? "Edit Portfolio": "Add Portfolio"}
  </IonContent>)
}