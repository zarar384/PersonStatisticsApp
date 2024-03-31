const path = require("path");

require("dotenv").config({
  path: path.join(__dirname, `.env.${process.env.NODE_ENV}`),
});

require("nodemon")({
  script: "./PersonStatisticsTelegramBot/bot.js",
  watch: ["PersonStatisticsTelegramBot"],
  ext: "js,json",
  ignore: ["node_modules"],
  exec: "node --inspect-brk",
});
