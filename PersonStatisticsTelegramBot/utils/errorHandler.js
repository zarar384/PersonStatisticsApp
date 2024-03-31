const { errorData } = require("../interfaces/errorData");

function handleError(error) {
  const { data } = error.response || {};

  const errorDatas = Array.isArray(data) ? data : [data];

  if (errorDatas.length === 0) {
    throw new Error(error);
  } else {
    throw errorDatas.map(({ code, description }) => ({ code, description }));
  }
}

module.exports = handleError;
