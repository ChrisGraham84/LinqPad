<Query Kind="Program" />

void Main()
{
	test(103).Dump();
	test(90).Dump();
	test(89).Dump();
}

// Define other methods and classes here
public bool test (int x)
{
	if(Math.Abs(x - 100) <= 10 || Math.Abs(x - 200) <= 10)
	{
		return true;
	}
	return false;
}