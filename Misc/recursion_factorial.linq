<Query Kind="Program" />

void Main()
{
  factorial(6).Dump();
}

// Define other methods and classes here
	int factorial (int n )
	{
		if (n == 1) return 1;
		else
			return n * factorial(n -1);
	}