const person = require("./person.json");
const race = require("./race.json");
const weapon = require("./weapon.json");
const armor = require("./armor.json");
const ability = require("./ability.json");
const roleplayer = require("./roleplayer.json");

module.exports = () => ({
  person: person.person,
  race: race.race,
  weapon: weapon.weapon,
  armor: armor.armor,
  ability: ability.ability,
  roleplayer: roleplayer.roleplayer,
});
