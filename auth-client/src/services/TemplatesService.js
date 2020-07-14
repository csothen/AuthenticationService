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

export const getAll = async () => {
  let url = process.env.REACT_APP_API_URL + "template";
  let response = await axios.get(url);
  console.log(response);
  return response;
};

export const getByOrganization = async (orgEmail) => {
  let url = process.env.REACT_APP_API_URL + "template/org/" + orgEmail;
  let response = await axios.get(url);
  console.log(response);
  return response;
};

export const getById = async (id) => {
  let url = process.env.REACT_APP_API_URL + "template/" + id;
  let response = await axios.get(url);
  console.log(response);
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
  let authConfig = config;
  authConfig.headers.Authorization = "Bearer " + token;

  if (valid) return await axios.post(url, JSON.stringify(body), authConfig);
  return "Inválido";
};
