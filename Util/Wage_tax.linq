<Query Kind="Statements" />

var rate = 43;
var hours = 80;
var ratehours = rate * hours;
var taxtakenout = ratehours * .28;
var actual = ratehours - taxtakenout;
taxtakenout.Dump();
actual.Dump();