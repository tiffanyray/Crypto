import { requests } from "../index";

export const Portfolios = {
  list: () => requests.get("/Portfolio/all?userId=1")
}