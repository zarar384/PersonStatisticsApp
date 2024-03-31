const environment = require("../environments/environment");
const { from, map, catchError } = require("rxjs");

const axiosConfig = require("../utils/axiosConfig");

const baseUrl = environment.apiUrl;

const accountService = {
  register: (userData) => {
    return from(axiosConfig.post(baseUrl + "Account/register", userData)).pipe(
      map((resp) => resp.data),
      catchError((err) => {
        const errors = Array.isArray(err)
          ? err.map((e) => e.description).join("\n")
          : err.description;
        throw errors;
      })
    );
  },
};

module.exports = accountService;
