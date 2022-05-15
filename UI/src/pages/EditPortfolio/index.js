import {IonButton, IonContent, IonInput, IonItem, IonLabel, IonSelect, IonSelectOption} from "@ionic/react";
import {Header} from "../../components/Header";
import {useEffect, useState} from "react";
import {getPage, pages} from "../../navigation";
import {useHistory, useRouteMatch} from "react-router";
import {agent} from "../../api";

export const EditPortfolio = () => {
  const [portfolioId, setPortfolioId] = useState(null);
  const [portfolio, setPortfolio] = useState({});
  const [cryptos, setCryptos] = useState([]);
  let routeMatch = useRouteMatch();
  let history = useHistory();

  const setInput = (value, name) => {
    setPortfolio({...portfolio, [name]: value});
  }
  
  const onCryptoChange = (value) => {
    setPortfolio({...portfolio, crypto: value});
  }
  
  const getOne = async (id) => {
    return await agent.portfolios.one(id);
  }
  
  const getAllCryptos = async () => {
    return await agent.cryptos.list();
  }
  
  const onSave = async () => {
    let response;
    if (portfolioId != null) {
      // post
      response = await agent.portfolios.create(portfolio);
    } else {
      // put
      response = await agent.portfolios.update(portfolio);
    }
    
    console.log("response", response)
  }
  
  
  useEffect(() => {
    let page = getPage(routeMatch.path);
    
    if (page.url === pages.editPortfolio.url) {
      setPortfolioId(routeMatch.params.id);
      getOne(routeMatch.params.id)
        .then((response) => {
          setPortfolio(response.data);
        });
    } else {
      setPortfolioId(null);
    }
  }, [routeMatch]);
  
  useEffect(() => {
    getAllCryptos()
      .then((response) => {
        setCryptos(response.data);
      })
  }, [])

  return (<IonContent>
    <Header>
      <IonButton onClick={onSave}>Save</IonButton>
      <IonButton onClick={() => history.goBack()}>Cancel</IonButton>
    </Header>
    <IonItem>
      <IonLabel position="floating">Name</IonLabel>
      <IonInput
        value={portfolio?.name}
        onIonChange={e => setInput(e.detail.value, "name")}
      />
    </IonItem>
    <IonItem>
      <IonLabel position="floating">Description</IonLabel>
      <IonInput
        value={portfolio?.description}
        onIonChange={e => setInput(e.detail.value, "description")}/>
    </IonItem>
    <IonItem>
      <IonLabel>Crypto</IonLabel>
      <IonSelect
        multiple={false}
        onIonChange={e => onCryptoChange(e.detail.value)}
        interface="popover"
        value={portfolio?.crypto}
      >
        {cryptos.map((crypto) => {
          return (
            <IonSelectOption value={crypto?.id} key={crypto?.id}>{crypto.name}</IonSelectOption>
          );
        })}
      </IonSelect>
    </IonItem>
  </IonContent>)
}