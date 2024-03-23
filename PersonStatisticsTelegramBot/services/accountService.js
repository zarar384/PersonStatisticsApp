const environment = require("../environments/environment");
const { from, map, catchError } = require("rxjs");

const axios = require("axios");

const baseUrl = environment.apiUrl;

const accountService = {
  register: (userData) => {
    return from(axios.post(baseUrl + "account/register", userData)).pipe(
      map((resp) => resp.data),
      catchError((err) => {
        throw err;
      })
    );
  },
};

module.exports = accountService;
