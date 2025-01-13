<Query Kind="Program" />

void Main()
{
	M().Dump();
}

// Define other methods, classes and namespaces here
int M()
{
	int y = 5;
	int x = 7;
	return Add(x,y);
	
	static int Add(int left, int right) => right + left;
	
}