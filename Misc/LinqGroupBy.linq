<Query Kind="Program" />

void Main()
{
 List<Teacher> teachers = new List<Teacher>{
 	new Teacher {Name = "Tammy", Salary = 60000, Department = "SS"},
	new Teacher {Name = "Chris", Salary = 10000, Department = "SS"},
	new Teacher {Name = "Sarah", Salary = 30000, Department = "SS"},
	new Teacher {Name = "Brian", Salary = 20000, Department = "CS"},
	new Teacher {Name = "Lashonda", Salary = 100000, Department = "CS"},
 };

	teachers.Where(x => x.Department == "SS").Average(x => x.Salary).Dump();
	teachers.GroupBy(x => x.Department).Select(y => new {department = y.Key, salary = y.Average(a=>a.Salary)}).Dump();
	
}



public class Teacher
{
	public string Name {get; set;}
	public int Salary { get; set; }
	public string Department { get; set;}
}
// Define other methods and classes here