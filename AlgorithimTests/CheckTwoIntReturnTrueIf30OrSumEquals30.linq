<Query Kind="Program" />

void Main()
{
	 test(30,0).Dump();
	 test(25,5).Dump();
	 test(20,30).Dump();
	 test(20,25).Dump();
}

// Define other methods and classes here
public static bool test(int x, int y)
{
	return x == 30 || y == 30 || (x + y == 30);
}