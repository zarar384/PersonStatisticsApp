const { Telegraf, Scenes } = require("telegraf");
const authScene = require("../menu/authScene");
const accountService = require("../services/accountService");
const { firstValueFrom } = require("rxjs");

const stage = new Scenes.Stage([authScene], { default: "auth" });

function setupAuthMiddleware(bot) {
  stage.command("done", async (ctx) => {
    if (ctx.session?.doneAuth || false) {
      const userData = {
        login: ctx.session.login,
        password: ctx.session.password,
      };

      try {
        const resp = await firstValueFrom(accountService.register(userData));
        ctx.reply(`Authorization successful ${resp}.`);
      } catch (err) {
        ctx.reply(`Error: ${err}`);
      }

      //TODO: open next menu
      ctx.session = {};
    }
  });

  bot.use(stage.middleware());

  bot.action("auth", (ctx) => ctx.scene.enter("auth"));
}

module.exports = { setupAuthMiddleware };
