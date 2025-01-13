<Query Kind="Program" />

void Main()
{
	LeadingZeros("888",4).Dump();
}

// Define other methods and classes here
string LeadingZeros(string Zip, int ZipLength)
{
	if(Zip.Length < ZipLength)
	{
	 Zip = Zip.Insert(0,"0");
	 Zip = LeadingZeros(Zip,ZipLength);
	}
	return (Zip);
}