const { Telegraf, Scenes, Composer } = require("telegraf");
const authScene = require("../scenes/authScene");
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
      ctx.session.isLoggedIn = true;
    } catch (err) {
      ctx.reply(`Error: ${err}`);
      ctx.session.isLoggedIn = false;
    }

    //TODO: open next menu
    ctx.session = {};
  }
});

authMiddleware.use(authStage.middleware());

authMiddleware.action("auth", (ctx) => ctx.scene.enter("auth"));

module.exports = { authMiddleware };
