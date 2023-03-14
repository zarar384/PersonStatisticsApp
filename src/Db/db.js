const person = require("./person.json");
const race = require("./race.json");
const weapon = require("./weapon.json");
const armor = require("./armor.json");
const ability = require("./ability.json");
const roleplayer = require("./roleplayer.json");

module.exports = () => ({
  person: person,
  race: race,
  weapon: weapon,
  armor: armor,
  ability: ability,
  roleplayer: roleplayer,
});
