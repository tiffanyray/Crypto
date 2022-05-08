import axios from "axios";
import {toast} from "react-toastify";
import {Portfolios} from "./Portfolios";

axios.defaults.baseURL = "https://localhost:5001/api";

axios.interceptors.response.use(undefined, (error) => {
  if (error.message === "Network Error" && !error.response) {
    toast.error("Network error - Please comeback later.");
  }

  const { status, config } = error.response;

  // Do I want this??
  // if (status === 404) {
  //   history.push("/notfound");
  // }

  // if (status == 400 && config.method === "get") {
  //   history.push("/notfound");
  // }

  if (status === 500) {
    toast.error("Internal server error...");
  }

  throw error.response;
});


export const requests = {
  get: (url) => axios.get(url),
  post: (url, body) => axios.post(url, body),
  put: (url, body) => axios.put(url, body),
  delete: (url) => axios.delete(url)
}

export const agent = {
  portfolios: Portfolios
}