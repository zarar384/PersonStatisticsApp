const { Telegraf, Scenes, Composer } = require("telegraf");
const authScene = require("../menu/authScene");
const accountService = require("../services/accountService");
const { firstValueFrom } = require("rxjs");

const authStage = new Scenes.Stage([authScene], { default: "auth" });

const authMiddleware = new Composer();

authStage.command("done", async (ctx) => {
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

authMiddleware.use(authStage.middleware());

authMiddleware.action("auth", (ctx) => ctx.scene.enter("auth"));

module.exports = { authMiddleware };
