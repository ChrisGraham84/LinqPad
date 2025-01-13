<Query Kind="Statements" />

string[] weapons = new string[] {"sword","axe","gun","gauntlet","spear","staff","bow"};
var q = weapons.Where((x,i) => (i + 1) % 2 == 0);
q.Dump();