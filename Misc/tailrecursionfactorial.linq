<Query Kind="Program" />

void Main()
{
	Go(4,1);
}

// Define other methods, classes and namespaces here
public void Go(int a, int b)
{
	if(a == 1)
	{
		b.Dump();
	}
	else
	{
		b = a * b;
		Go((a - 1), b);
		a.Dump("bfr");
		b.Dump("aftr");
	}
}