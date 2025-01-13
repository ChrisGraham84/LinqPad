<Query Kind="Program">
  <IncludeAspNet>true</IncludeAspNet>
</Query>

void Main()
{
	CreatePassword(15).Dump();
}

// Define other methods, classes and namespaces here
public string CreatePassword(int length)
{
	const string valid = "!@#$%^&*_+=abcdefghjkmnpqrstuvwxyzABCDEFGHJKLMNPQRSTUVWXYZ123456789!@#$%^&*_+=";
	StringBuilder res = new StringBuilder();
	Random rnd = new Random();
	while (0 < length--)
	{
		res.Append(valid[rnd.Next(valid.Length)]);
	}
	return res.ToString();
}