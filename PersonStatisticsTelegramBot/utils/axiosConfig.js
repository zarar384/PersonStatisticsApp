const axios = require("axios");
const https = require("https");
const handleError = require("./errorHandler");

const axiosInstance = axios.create({
  httpsAgent: new https.Agent({
    rejectUnauthorized: false,
  }),
});

axiosInstance.interceptors.response.use(undefined, handleError);

module.exports = axiosInstance;
