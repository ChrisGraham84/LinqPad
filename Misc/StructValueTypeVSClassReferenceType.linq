<Query Kind="Program" />

void Main()
{
	B b1 = new B { X = 1};
	ChangeB(b1);
	b1.X.Dump();
}

// Define other methods and classes here
public class B
{
 public int X {get; set;}
}

/*public struct B
{
 public int X {get; set;}
}*/

public static void ChangeB(B b)
{
	b.X = 2;
}