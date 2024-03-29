const { Markup } = require("telegraf");

function createProfileMenu() {
  return Markup.inlineKeyboard([
    Markup.button.callback("Profile Info", "profile_info"),
    Markup.button.callback("Get Boxes Info", "box_info"),
    Markup.button.callback("Logout", "Logout"),
  ]);
}

module.exports = { createProfileMenu };
