<Query Kind="Program" />

void Main()
{
	 test(50).Dump();
	 test(200).Dump();
	 test(150).Dump();
}

// Define other methods and classes here
public static bool test(int x)
{
	return (x > 10 && x < 100) || x == 200;
}