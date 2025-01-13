<Query Kind="Program" />

void Main()
{
	var (a, b, option) = (10, 5, "+");
	
	var example = option switch
	{
		"+" => a + b,
		"-" => a - b,
		_ => a * b
	};
	
	
	example.Dump();
	
	Calculation c1 = new Calculation(50, 10, "*");
	c1.print();
}

// Define other methods, classes and namespaces here
public class Calculation
{
	public int FirstNumber {get; set;}
	public int SecondNumber {get; set;}
	public string Operation {get; set;}
	public int ResultNumber {get; set;}
	
	public void print() =>  $"{this.FirstNumber} {this.Operation} {this.SecondNumber} = {this.ResultNumber}".Dump();
	
	public Calculation(int a, int b, string operation)
	{
		this.FirstNumber = a;
		this.SecondNumber = b;
		this.Operation = operation;
		
		this.ResultNumber = this.Operation switch
		{
			"+" => this.FirstNumber	+ this.SecondNumber,
			"-" => this.FirstNumber - this.SecondNumber,
			"/" => this.FirstNumber / this.SecondNumber,
			"*" => this.FirstNumber * this.SecondNumber,
			_ => -1
			
		};
	}
}