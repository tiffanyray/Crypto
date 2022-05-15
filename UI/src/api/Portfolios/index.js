import { requests } from "../index";

export const Portfolios = {
  list: () => requests.get("/Portfolio/all?userId=1"),
  one: (id) => requests.get(`/Portfolio/one/${id}`),
  create: (body) => requests.post("/Portfolio/create", body),
  update: (body) => requests.put("/Portfolio/update", body),
  delete: (id) => requests.delete(`/Portfolio/deleted/${id}`)
}