const { Markup } = require("telegraf");

function createAuthMenu() {
  return Markup.inlineKeyboard([
    Markup.button.callback("Authorization", "auth"),
    Markup.button.callback("Login", "login"),
    Markup.button.callback("Cancel", "cancel"),
  ]);
}

module.exports = { createAuthMenu };
