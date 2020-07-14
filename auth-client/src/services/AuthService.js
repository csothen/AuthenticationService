import axios from "axios";
require("dotenv").config();

const config = {
  headers: {
    "Content-Type": "application/json",
    Accept: "application/json",
  },
};

const validateRequest = (request) => {
  for (var el in request) {
    if (request[el] === "") {
      return false;
    }
  }
  return true;
};

export const login = async (email, password) => {
  let url = process.env.REACT_APP_API_URL + "auth/login";
  let body = {
    email,
    password,
  };
  let valid = validateRequest(body);
  if (valid) return await axios.post(url, JSON.stringify(body), config);
  return "Inválido";
};

export const register = async (email, name, password) => {
  let url = process.env.REACT_APP_API_URL + "auth/register";
  let body = {
    email,
    name,
    password,
  };
  let valid = validateRequest(body);
  if (valid) return await axios.post(url, JSON.stringify(body), config);
  return "Inválido";
};

export const externalLogin = async (identificator, password) => {
  let url = process.env.REACT_APP_API_URL + "auth/external/login";
  let body = {
    identificator,
    password,
  };
  let valid = validateRequest(body);
  if (valid) return await axios.post(url, JSON.stringify(body), config);
  return "Inválido";
};

export const externalRegister = async (identificator, password, extras) => {
  let url = process.env.REACT_APP_API_URL + "auth/external/register";
  let body = {
    identificator,
    password,
    extras,
  };
  let valid = validateRequest(body);
  if (valid) return await axios.post(url, JSON.stringify(body), config);
  return "Inválido";
};
