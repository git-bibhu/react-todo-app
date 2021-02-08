import axios from "axios";

const config = {
  headers: {
    "Content-Type": "application/json",
    'accept': '*/*'
  },
};

export default axios.create({
  baseURL: process.env.REACT_APP_API,
  config,
});
