const { Telegraf, session, Markup } = require("telegraf");
const { authMiddleware, authStage } = require("./middleware/authMiddleware");

require("dotenv").config({
  path: `.env.${process.env.NODE_ENV}`,
});

const bot = new Telegraf(process.env.BOT_TOKEN);

function createMenu() {
  return Markup.inlineKeyboard([
    Markup.button.callback("Authorization", "auth"),
    Markup.button.callback("Login", "login"),
    Markup.button.callback("Cancel", "cancel"),
  ]);
}

bot.use(session());

bot.start((ctx) => {
  ctx.reply("Welcome.", createMenu());
});

bot.use(authMiddleware.middleware());

bot.launch();
