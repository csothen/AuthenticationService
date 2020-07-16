import axios from "axios";
require("dotenv").config();

const config = {
  headers: {
    "Content-Type": "application/json",
    Accept: "application/json",
  },
};

const validateAttributes = (attributes) => {
  for (let i = 0; i < attributes.length; i++) {
    const attr = attributes[i];
    if (attr["name"] === "") {
      return false;
    }
  }
  return true;
};

const setAuthorization = (token) => {
  let newConfig = config;
  newConfig.headers.Authorization = "Bearer " + token;
  return newConfig;
};

export const getAll = async (token) => {
  let url = process.env.REACT_APP_API_URL + "template";
  let authConfig = setAuthorization(token);

  let response = await axios.get(url, authConfig);
  return response;
};

export const getByOrganization = async (orgEmail, token) => {
  let url = process.env.REACT_APP_API_URL + "template/org/" + orgEmail;
  let authConfig = setAuthorization(token);

  let response = await axios.get(url, authConfig);
  return response;
};

export const getById = async (id, token) => {
  let url = process.env.REACT_APP_API_URL + "template/" + id;
  let authConfig = setAuthorization(token);

  let response = await axios.get(url, authConfig);
  return response;
};

export const create = async (attributes, token) => {
  let url = process.env.REACT_APP_API_URL + "template";
  let body = { attributes: [] };

  for (let i in attributes) {
    body.attributes.push({
      name: attributes[i].name,
      type: attributes[i].type,
    });
  }

  let valid = validateAttributes(body);
  let authConfig = setAuthorization(token);

  if (valid) return await axios.post(url, JSON.stringify(body), authConfig);
  return "Inválido";
};
