<Query Kind="Statements" />

List<string> test = new List<string>{"a","b","c","d"};
List<string> final = new List<string>();
for(int i = test.Count; i>0 ;i--)
{
   i.Dump();
   final.Add(test[i-1]);
}
final.Dump();