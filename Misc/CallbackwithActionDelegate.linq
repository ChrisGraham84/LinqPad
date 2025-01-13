<Query Kind="Program" />

void Main()
{
	Test();
	PrintStringPrintDelegate("This is in the function parameter", () => "This is from the delegate function call".Dump());
}

// Define other methods and classes here
public void DoWork(Action<string> callback)
{
	callback("Hello World");
}

public void Test()
{
	DoWork((x) => x.Dump());
}


// Define other methods and classes here
static void PrintStringPrintDelegate(string p, Action onError)
{
	p.Dump();
	onError();
}
