<Query Kind="Program">
  <Namespace>Newtonsoft.Json</Namespace>
  <Namespace>Newtonsoft.Json.Linq</Namespace>
  <Namespace>System</Namespace>
  <Namespace>System.Collections.Generic</Namespace>
  <Namespace>System.Data</Namespace>
  <Namespace>System.Data.OleDb</Namespace>
  <Namespace>System.IO</Namespace>
  <Namespace>System.Linq</Namespace>
  <Namespace>System.Reflection</Namespace>
  <Namespace>System.Text</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

void Main()
{
	
}

// Define other methods and classes here
public static List<T> GetObjectsFromDataTable<T>(DataTable Table)
{
	List<T> collection = new List<T>();

	foreach (var row in Table.AsEnumerable())
	{
		T obj = (T)Activator.CreateInstance(typeof(T), null);

		foreach (var prop in obj.GetType().GetProperties())
		{
			try
			{
				PropertyInfo propertyInfo = obj.GetType().GetProperty(prop.Name);
				propertyInfo.SetValue(obj, Convert.ChangeType(row[prop.Name], propertyInfo.PropertyType), null);
			}
			catch
			{
				continue;
			}
		}
		collection.Add(obj);
	}

	return (collection);
}