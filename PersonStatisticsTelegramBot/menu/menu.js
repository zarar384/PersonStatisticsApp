const { createAuthMenu } = require("./authMenu");
const { createProfileMenu } = require("./profileMenu");

function createMenu(ctx) {
  if (ctx.session?.isLoggedIn | false) {
    ctx.reply(createProfileMenu());
  } else {
    ctx.reply("Welcome", createAuthMenu());
  }
}

module.exports = { createMenu };
