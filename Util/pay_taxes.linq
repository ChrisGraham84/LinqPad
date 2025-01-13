<Query Kind="Statements" />

var payrate = 35.00;
var biweek = (payrate * 80);
var actual = biweek - (biweek* (.28 + .0));
actual.Dump("Freelance Pay");

var pay = 3461.54;
var actual2 = (pay - (pay * (.28 + .0)).Dump("Tax total")).Dump("SPR Pay");

(actual2 - actual).Dump("SPR / Freelance Difference");