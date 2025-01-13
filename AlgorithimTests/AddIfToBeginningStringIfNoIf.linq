<Query Kind="Program" />

void Main()
{
	test("if else").Dump();
	test("not else").Dump();
}

// Define other methods and classes here
public static string test(string s)
{
	{
		if(s.Length > 2 && s.Substring(0, 2).Equals("if"))
		{
			return s;
		}
		return "if " + s;
	}
}