<Query Kind="Statements" />

List<string> test = new List<string> {"all", "cops", "are", "bastards"};

var agg = test.Aggregate((a,b) => a + ", " + b);
//var agg = String.Join(", ", test);
agg.Dump()