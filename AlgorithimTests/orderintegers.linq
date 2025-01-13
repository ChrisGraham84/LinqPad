<Query Kind="Statements" />

List<int> test =  new List<int> {1,5,6,8,7,4,9};
List<int> final = new List<int>();
int max = 0;
int min = 0;
foreach(var i in test)
{
     if(i > max){
	   min = max;
	   max = i;
	  if (final.Count == 0)
	   {
	   final.Add(i);
	   }
	  else
	  {
	   final.Insert(final.Count,i);
	   
	   }
	}
	else
	{
	int index = 0;
	   foreach(int i2 in final)
	   {
	     if(i < i2)
		 {
		 index = final.IndexOf(i2);
		  break;
		 }
	   }
	   final.Insert(index,i);
	}
}
final.Dump();