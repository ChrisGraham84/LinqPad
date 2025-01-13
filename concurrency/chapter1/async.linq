<Query Kind="Program">
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

async Task Main()
{
	async Task DoSomethingAsync()
	{
		int value = 13; 
		
		//Asynchronously wait 1 second.
		await Task.Delay(TimeSpan.FromSeconds(1));
		
		value *= 2;
		
		//Asynchronously wait 1 second.
		await Task.Delay(TimeSpan.FromSeconds(1));
		
		Trace.WriteLine(value);
		value.Dump();
	}
	
	async Task TrySomethingAsync(){
		try{
			await PossibleExceptionAsync();
		}
		catch (NotSupportedException ex){
			ex.Dump();
			throw;
		}
	}
	
	//Do not do this 
	void Deadlock()
	{
		Task task = WaitAsyc();
		
		task.Wait();
	}
	
	await DoSomethingAsync();

}

Task WaitAsyc()
{
	throw new NotImplementedException();
}

Task PossibleExceptionAsync()
{
	throw new NotImplementedException();
}

