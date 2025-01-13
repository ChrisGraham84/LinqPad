<Query Kind="Program" />



void Main()
{
	var sc = new SomeClass();
	sc.emptyname?.Replace("this","that");
	sc.emptyname?.Dump();
}

// Define other methods, classes and namespaces here
public class SomeClass
{
	public string? emptyname {get; set;}
	
	public SomeClass()
	{
		emptyname = null;
	}
}