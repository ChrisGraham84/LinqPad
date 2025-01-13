<Query Kind="Program" />

void Main()
{
	//SumNumbers(1,2).Dump();
	//SumNumbers(3,2).Dump();
	//SumNumbers(2,2).Dump();
	
	NDifference51(53).Dump();
	NDifference51(30).Dump();
	NDifference51(51).Dump();
}

// You can define other methods, fields, classes and namespaces here

//Write a C# Sharp program to compute the sum of the two numerical values. If the two values are the same, return triple their sum.
int SumNumbers(int x, int y)
{	
	return x == y ? 3 * (x + y): x + y;
}

//Write a C# Sharp program to get the absolute difference between n and 51. If n is broader than 51 return triple the absolute difference.
int NDifference51(int n)
{
	//return n > 51 ? 3 * (int)(Math.Abs(n - 51)) : (int)(Math.Abs(n - 51));
	return n > 51 ? 3 * (n - 51) : 51  - n; //website answer 
}