import {requests} from "../index";

export const Cryptos = {
  list: () => requests.get("/Crypto/all"),
  one: (id) => requests.get(`/Crypto/one/${id}`),
  create: (body) => requests.post("/Crypto/create", body),
  update: (body) => requests.put("/Crypto/update", body),
  delete: (id) => requests.delete(`/Crypto/deleted/${id}`)
}