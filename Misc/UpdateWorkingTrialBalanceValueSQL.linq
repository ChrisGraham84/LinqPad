<Query Kind="Program">
  <Connection>
    <ID>41ae6d78-15ee-4560-8db5-f08f0905c10c</ID>
    <Persist>true</Persist>
    <Server>IL0824AM099024</Server>
    <Database>ShowRoom</Database>
    <ShowServer>true</ShowServer>
  </Connection>
</Query>

void Main()
{
	string dir = @"C:\Dev\ArcGit";
	string prodDir = @"C:\Temp\temprocs\"; // @"C:\Dev\ArcGit\SQL"
	var txtProctFiles = Directory.EnumerateFiles(dir, "*.sql",SearchOption.AllDirectories).ToList();

		//var filtered = txtProctFiles.Select(x => File.ReadAllLines(x).Where(rl => rl.Contains("dbo.WorkingTrialBalanceValue")).ToList());
		var filtered = txtProctFiles.Where(x=>x.EndsWith(".sql")).ToList();
		string txt = string.Empty;
		foreach(var x in filtered)
		{
			//txt =  File.ReadAllText(x);
			//if(txt.Contains("gf_GetWorkingTrialBalanceValueForItem")) {x.Dump();} //check for use statement in file
			//File.WriteAllText(prodDir + Path.GetFileName(x).Replace("_PV.sql",".sql"), txt);
			
		}
		//filtered.Dump();

	var files = from retrievedFile in Directory.EnumerateFiles(dir, "*.sql", SearchOption.AllDirectories)
				from line in File.ReadLines(retrievedFile)
				where line.Contains("gp_UpdateWorkingTrialBalanceReallocationValue")
				select new
				{
					File = retrievedFile,
					Line = line,
					//ReplacedLine = line.Replace("WorkingTrialBalanceValue", "WorkingTrialBalanceValueActive")
				};

	foreach (var f in files.GroupBy(x=>x.File))
	{
		int i = 1;
		Console.WriteLine("-----------------------");
		Console.WriteLine("{0} \n\r\n\r contains: \n\r {1} ", f.Key, new string(f.SelectMany(x=>(i++).ToString() + " " + x.Line + " \n\r").ToArray()));
		//string lines = new string(f.SelectMany(x=>x.Line).ToArray());
		//Console.WriteLine("{0} Changed to {1}", f.Line, f.ReplacedLine);
		Console.WriteLine("-----------------------");
		//File.WriteAllText(@"C:\Temp\temprocs\tmpsql" + Path.GetFileName(f.File), f.ReplacedLine);
	}
	Console.WriteLine("{0} lines found.", files.Count().ToString());
}

// Define other methods and classes here