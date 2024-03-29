const { Telegraf, Scenes } = require("telegraf");

const authScene = new Scenes.BaseScene("auth");

authScene.enter((ctx) => {
  ctx.session.authStep = "login";
  ctx.reply("Enter login:");
});

authScene.on("text", (ctx) => {
  if (!ctx.session.doneAuth) {
    if (ctx.session.authStep === "login") {
      ctx.session.login = ctx.message.text;
      ctx.session.authStep = "password";
      ctx.reply("Enter password:");
    } else if (ctx.session.authStep === "password") {
      ctx.session.password = ctx.message.text;
      ctx.scene.leave();
      ctx.reply("Type /done to continue.");
      ctx.session.doneAuth = true;
    }
  }
});

module.exports = authScene;
