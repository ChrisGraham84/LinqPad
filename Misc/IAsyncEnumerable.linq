<Query Kind="Program">
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

static async Task Main()
{
	await foreach(var dataPoint in FetchIOTData())
	{
		Console.WriteLine(dataPoint);
	}
}

static async IAsyncEnumerable<int> FetchIOTData()
{
	for(int i = 1; i <= 10; i++)
	{
		await Task.Delay(1000);
		yield return i;
	}
}
// Define other methods, classes and namespaces here