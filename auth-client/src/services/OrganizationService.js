import axios from "axios";
require("dotenv").config();

const config = {
  headers: {
    "Content-Type": "application/json",
    Accept: "application/json",
  },
};

export const getOrganization = async (email) => {
  let url = process.env.REACT_APP_API_URL + "organization/" + email;
  return await axios.get(url);
};
