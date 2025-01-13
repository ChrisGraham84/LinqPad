<Query Kind="Program">
  <NuGetReference>EPPlus</NuGetReference>
  <NuGetReference>Newtonsoft.Json</NuGetReference>
  <NuGetReference>System.Collections</NuGetReference>
  <Namespace>OfficeOpenXml</Namespace>
</Query>

void Main()
{
	using var stream = File.OpenRead(@"");
	using var package = new ExcelPackage(stream);

	var sheet = package.Workbook.Worksheets["Entry"];
	//sheet.Dump();

	//for(var col = 1; col < sheet.Dimension.End.Column; col++)
	//{
	//	sheet.Cells[2,col].Value.ToString().Dump(col.ToString());
	//}
	//
	////49 is watch column, this returns the x. 
	//sheet.Cells[5, 49].Value.ToString().Dump();


	var dataTable = new DataTable();
	List<string> columns = new List<string>();
	for (int col = 1; col <= sheet.Dimension.End.Column; col++)
	{
		dataTable.Columns.Add(sheet.Cells[2, col].Value.ToString());
	}


	for (int row = 3; row <= sheet.Dimension.End.Row; row++)
	{
		var dataRow = dataTable.NewRow();
		for (int c = 1; c <= dataTable.Columns.Count; c++)
		{
			dataRow[dataTable.Columns[c - 1]] = sheet.Cells[row, c].Value;
		}
		dataTable.Rows.Add(dataRow);
	}
	dataTable.Dump();
	
	var QRMColumnMapp = new Dictionary<string, string>
	{
		{"Client", "Client"},
		{"Engagement","Engagement"},
		{"Type", "Type"},
		{"Watch", "Watch"},
		{"Highest", "Highest"},
		{"Total", "Total"},
		{"D","Fixed Fee"},
		{"G","Planned Revenue"},
		{"J","Percieved Risk Level"},
		{"M","Staffing Skills & Compentencies"},
		{"P","Schedule Length"},
		{"S","Confidence Level Budget/Sched"},
		{"V","Compexity of Solution"},
		{"Y","Team Size"},
		{"AB","Strategic Value to SPR"},
		{"AE","New Technology"},
		{"AH","Legal/Regulatory Requirements"},
		{"AK","Vsisibility / Scrutiny"},
		{"AN","Geographic Distribution Issues"},
		{"AQ","Critical Dependencies"},
		{"AT","Client/Partner Relationship Impoacts"}
	};
	
	var import = CreateList<QRMImport>(dataTable);
	var watched = import.Where(x=> x.Watch.ToLower() == "x").ToList();
	watched.Dump();
	
	if(File.Exists(@"C:\Projects\QRMOutput.xlsx"))
	{
		File.Delete(@"C:\Projects\QRMOutput.xlsx");
	}
	
	using var excel = new ExcelPackage(new System.IO.FileInfo(@"C:\Projects\QRMOutput.xlsx"));
	string worksheetName = "Entry";
	excel.Workbook.Worksheets.Add(worksheetName);
	
	var worksheet = excel.Workbook.Worksheets[worksheetName];
	
	var props = watched.FirstOrDefault().GetType().GetProperties().ToList();
	props = props.Where(x=> QRMColumnMapp.Keys.Contains(x.Name)).ToList();
	
	foreach(var col in props)
	{
		worksheet.Cells[1, props.IndexOf(col) + 1].Value = QRMColumnMapp[col.Name];
	}
	
	foreach(var row in watched)
	{
		foreach(var col in props)
		{
			worksheet.Cells[watched.IndexOf(row) + 2, props.IndexOf(col) + 1].Value = row.GetType().GetProperty(col.Name).GetValue(row);
		}
	}
	excel.Save();
}



public IEnumerable<T> CreateList<T>(DataTable sheet)
{
	List<T> data = new List<T>();

	List<string> columns = new List<string>();
	for (int col = 0; col <= sheet.Columns.Count - 1; col++)
	{
		columns.Add(sheet.Columns[col].ColumnName);
	}
	for (int row = 0; row <= sheet.Rows.Count - 1; row++)
	{
		var obj = (T)Activator.CreateInstance(typeof(T), null);
		foreach (var prop in obj.GetType().GetProperties())
		{
			try
			{
				object value = new object();
				value = sheet.Rows[row][columns.IndexOf(prop.Name)].ToString();

				var propertyInfo = obj.GetType().GetProperty(prop.Name);
				propertyInfo.SetValue(obj, value, null);

			}
			catch
			{
				continue;
			}
		}
		data.Add(obj);
	}
	return data;
}

// Define other methods, classes and namespaces here
public class QRMImport
{
	public string? Client { get; set; }
	public string? Engagement { get; set; }
	public string? Type { get; set; }
	public string? D { get; set; }
	public string? E { get; set; }
	public string? F { get; set; }
	public string? G { get; set; }
	public string? H { get; set; }
	public string? I { get; set; }
	public string? J { get; set; }
	public string? K { get; set; }
	public string? L { get; set; }
	public string? M { get; set; }
	public string? N { get; set; }
	public string? O { get; set; }
	public string? P { get; set; }
	public string? Q { get; set; }
	public string? R { get; set; }
	public string? S { get; set; }
	public string? T { get; set; }
	public string? U { get; set; }
	public string? V { get; set; }
	public string? W { get; set; }
	public string? X { get; set; }
	public string? Y { get; set; }
	public string? Z { get; set; }
	public string? AA { get; set; }
	public string? AB { get; set; }
	public string? AC { get; set; }
	public string? AD { get; set; }
	public string? AE { get; set; }
	public string? AF { get; set; }
	public string? AG { get; set; }
	public string? AH { get; set; }
	public string? AI { get; set; }
	public string? AJ { get; set; }
	public string? AK { get; set; }
	public string? AL { get; set; }
	public string? AM { get; set; }
	public string? AN { get; set; }
	public string? AO { get; set; }
	public string? AP { get; set; }
	public string? AQ { get; set; }
	public string? AR { get; set; }
	public string? AS { get; set; }
	public string? AT { get; set; }
	public string? AU { get; set; }
	public string? AV { get; set; }
	public string? Watch { get; set; }
	public string? Highest { get; set; }
	public string? Total { get; set; }

}