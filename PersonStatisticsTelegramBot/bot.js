const { Telegraf, session } = require("telegraf");
const { authMiddleware } = require("./middleware/authMiddleware");
const { createMenu } = require("./menu/menu");

require("dotenv").config({
  path: `.env.${process.env.NODE_ENV}`,
});

const bot = new Telegraf(process.env.BOT_TOKEN);

bot.use(session());

bot.start((ctx) => {
  createMenu(ctx);
});

bot.use(authMiddleware.middleware());

bot.launch();
